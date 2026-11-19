using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTHModels
{
    /// <summary>
    /// 通信设备实体类
    /// </summary>
    public class Device
    {
        /// <summary>
        /// IP地址
        /// </summary>
        // 0 个引用
        public string IPAddress { get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 通信组集合
        /// </summary>
        public List<Group> GroupList { get; set; }

        /// <summary>
        ///通信状态标志位 
        /// </summary>
        public bool IsConnected { get; set; }

        /// <summary>
        /// 重连时间
        /// </summary>
        public int ReConnectTime { get; set; } = 2000;

        /// <summary>
        /// 重连标志位
        /// </summary>
        public bool ReConnectSign { get; set; }

        /// <summary>
        /// 当前配方
        /// </summary>
        public string CurrentRecipe { get; set; }

        /// <summary>
        /// 所有变量的键值对，键使用变量的名称，值是变量的实际值
        /// </summary>
        public Dictionary<string, object> CurrentValue = new Dictionary<string, object>();

        /// <summary>
        /// 定义报警触发和消除事件
        /// </summary>
        public event Action<bool, Variable> AlarmTrigEvent;
        /// <summary>
        /// 更新变量
        /// </summary>
        /// <param name="variable"></param>
        public void UpdateVariable(Variable variable)
        {
            if (CurrentValue.ContainsKey(variable.VarName))
            {
                CurrentValue[variable.VarName] = variable.VarValue;
            }
            else
            {
                CurrentValue.Add(variable.VarName, variable.VarValue);
            }
            //报警检测
            CheckAlarm(variable);
        }

        /// <summary>
        /// 根据报警变量名推导出对应的"报警启用"变量名
        /// 如：模块1温度高 → 模块1温度报警启用；模块1湿度低 → 模块1湿度报警启用
        /// 没有对应启用变量的（如 模块1异常）返回 null
        /// </summary>
        private static string GetEnableVarName(string varName)
        {
            if (string.IsNullOrEmpty(varName) || varName.EndsWith("报警启用"))
            {
                return null;
            }

            foreach (string kind in new string[] { "温度", "湿度" })
            {
                int index = varName.IndexOf(kind);
                if (index > 0)
                {
                    return varName.Substring(0, index) + kind + "报警启用";
                }
            }
            return null;
        }

        /// <summary>
        /// 判断当前报警变量是否允许参与报警检测
        /// </summary>
        private bool CanCheckAlarm(Variable variable)
        {
            string enableName = GetEnableVarName(variable.VarName);

            //没有对应的启用变量，按原逻辑报警
            if (enableName == null)
            {
                return true;
            }

            object value = this[enableName];

            //启用状态还没有采集到，本轮先跳过，等下一轮再判断
            if (value == null)
            {
                return false;
            }

            int flag;
            return int.TryParse(value.ToString(), out flag) && flag == 1;
        }

        private void CheckAlarm(Variable variable)
        {
            //"模块N温度/湿度报警启用"未勾选时，不参与报警检测
            if (!CanCheckAlarm(variable))
            {
                return;
            }

            //上升沿报警检测
            if (variable.PosAlarm)
            {
                bool currentValue = variable.VarValue.ToString() == "True";

                if (variable.PosCacheValue == false && currentValue == true)
                {
                    //检测到了报警触发
                    AlarmTrigEvent?.Invoke(true, variable);
                }

                if (variable.PosCacheValue == true && currentValue == false)
                {
                    //检测到了报警消除
                    AlarmTrigEvent?.Invoke(false, variable);
                }
                variable.PosCacheValue = currentValue;
            }

            //下降沿报警检测
            if (variable.NegAlarm)
            {
                bool currentValue = variable.VarValue.ToString() == "True";

                if (variable.NegCacheValue == true && currentValue == false)
                {
                    //检测到了报警触发
                    AlarmTrigEvent?.Invoke(true, variable);
                }

                if (variable.NegCacheValue == false && currentValue == true)
                {
                    //检测到了报警消除
                    AlarmTrigEvent?.Invoke(false, variable);
                }
                variable.NegCacheValue = currentValue;
            }
        }
        /// <summary>
        /// 根据当前值、阈值和启用开关计算报警状态
        /// 每个采集周期结束后由通信线程调用
        /// </summary>
        public void CheckThresholdAlarm()
        {
            if (GroupList == null)
            {
                return;
            }

            foreach (var gp in GroupList)
            {
                if (gp.VarList == null)
                {
                    continue;
                }

                foreach (var variable in gp.VarList)
                {
                    string varName = variable.VarName;
                    string kind;

                    //只处理实时数据里的温度和湿度
                    if (varName.EndsWith("温度"))
                    {
                        kind = "温度";
                    }
                    else if (varName.EndsWith("湿度"))
                    {
                        kind = "湿度";
                    }
                    else
                    {
                        continue;
                    }

                    //模块1温度 → 前缀 模块1
                    string prefix = varName.Substring(0, varName.Length - kind.Length);
                    string highName = prefix + kind + "高";
                    string lowName = prefix + kind + "低";

                    //报警启用开关未勾选时，对应的报警位保持为 0
                    if (!CanCheckAlarm(variable))
                    {
                        SetAlarmValue(highName, false);
                        SetAlarmValue(lowName, false);
                        continue;
                    }

                    //当前值
                    double current;
                    if (!TryGetDouble(varName, out current))
                    {
                        continue;
                    }

                    //阈值
                    double high, low;
                    bool highAlarm = TryGetDouble(prefix + kind + "高限", out high) && current > high;
                    bool lowAlarm = TryGetDouble(prefix + kind + "低限", out low) && current < low;

                    SetAlarmValue(highName, highAlarm);
                    SetAlarmValue(lowName, lowAlarm);
                }
            }
        }

        /// <summary>
        /// 更新报警变量的值并触发报警检测
        /// </summary>
        private void SetAlarmValue(string varName, bool value)
        {
            Variable variable = FindVariable(varName);
            if (variable == null)
            {
                return;
            }

            variable.VarValue = value;
            UpdateVariable(variable);
        }

        /// <summary>
        /// 按变量名查找变量对象
        /// </summary>
        private Variable FindVariable(string varName)
        {
            if (GroupList == null)
            {
                return null;
            }

            foreach (var gp in GroupList)
            {
                if (gp.VarList == null)
                {
                    continue;
                }

                foreach (var variable in gp.VarList)
                {
                    if (variable.VarName == varName)
                    {
                        return variable;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 从当前值字典里取出数值
        /// </summary>
        private bool TryGetDouble(string varName, out double value)
        {
            value = 0;

            object obj = this[varName];
            if (obj == null)
            {
                return false;
            }

            return double.TryParse(obj.ToString(), out value);
        }

        /// <summary>
        /// 索引器，获取变量值，根据变量名称
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object this[string key]
        {
            get
            {
                if (CurrentValue.ContainsKey(key))
                {
                    return CurrentValue[key];
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
