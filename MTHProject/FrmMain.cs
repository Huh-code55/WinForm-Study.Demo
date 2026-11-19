using MiniExcelLibs;
using MTHBLL;
using MTHControlLib;
using MTHHelper;
using MTHModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;
namespace MTHProject
{
    public partial class FrmMain: Form
    {
        public FrmMain()
        {
            InitializeComponent();

            naviButtons.Add(this.navi_Monitor);
            naviButtons.Add(this.naviButton2);
            naviButtons.Add(this.naviButton3);
            naviButtons.Add(this.naviButton8);
            naviButtons.Add(this.naviButton9);
            naviButtons.Add(this.naviButton11);

            actualAlarmList.CollectionChanged += ActualAlarmList_CollectionChanged;
            storeTimer.Interval = 1000;
            storeTimer.AutoReset = true;
            storeTimer.Elapsed += StoreTimer_Elapsed;
            storeTimer.Start();

            this.Load += FrmMain_Load;
            this.FormClosing += FrmMain_FormClosing;
        }

        #region 窗体退出确认
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = new FrmMsgBoxWithAck("是否确认要退出系统？", "退出系统").ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                storeTimer.Stop();

                CommonMethods.Modbus?.DisConnect();

                cts?.Cancel();
            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion

        private void StoreTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //更新时间和通信状态
            this.Invoke(new Action(() =>
            {
                this.lbl_CurrentTime.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToString("HH:mm:ss") + " " + week;
                this.led_CommState.Value = CommonMethods.Device.IsConnected;
            }));

            if (CommonMethods.Device.IsConnected)
            {
                //判断
                bool result = CommonMethods.Device["模块1温度"] != null;
                result &= CommonMethods.Device["模块1湿度"] != null;
                result &= CommonMethods.Device["模块2温度"] != null;
                result &= CommonMethods.Device["模块2湿度"] != null;
                result &= CommonMethods.Device["模块3温度"] != null;
                result &= CommonMethods.Device["模块3湿度"] != null;
                result &= CommonMethods.Device["模块4温度"] != null;
                result &= CommonMethods.Device["模块4湿度"] != null;
                result &= CommonMethods.Device["模块5温度"] != null;
                result &= CommonMethods.Device["模块5湿度"] != null;
                result &= CommonMethods.Device["模块6温度"] != null;
                result &= CommonMethods.Device["模块6湿度"] != null;

                if (result)
                {
                    actualDataManage.AddActualData(new ActualData()
                    {
                        InsertTime = CurrentTime,
                        Station1Temp = CommonMethods.Device["模块1温度"].ToString(),
                        Station1Humidity = CommonMethods.Device["模块1湿度"].ToString(),
                        Station2Temp = CommonMethods.Device["模块2温度"].ToString(),
                        Station2Humidity = CommonMethods.Device["模块2湿度"].ToString(),
                        Station3Temp = CommonMethods.Device["模块3温度"].ToString(),
                        Station3Humidity = CommonMethods.Device["模块3湿度"].ToString(),
                        Station4Temp = CommonMethods.Device["模块4温度"].ToString(),
                        Station4Humidity = CommonMethods.Device["模块4湿度"].ToString(),
                        Station5Temp = CommonMethods.Device["模块5温度"].ToString(),
                        Station5Humidity = CommonMethods.Device["模块5湿度"].ToString(),
                        Station6Temp = CommonMethods.Device["模块6温度"].ToString(),
                        Station6Humidity = CommonMethods.Device["模块6湿度"].ToString(),
                    });
                }
            }
        }

        private CancellationTokenSource cts = new CancellationTokenSource();
        private ObservableCollection<string> actualAlarmList = new ObservableCollection<string>();
        private SysLogManage sysLogManage = new SysLogManage();
        private ActualDataManage actualDataManage = new ActualDataManage();
        private System.Timers.Timer storeTimer = new System.Timers.Timer();

        //当前的页面索引
        private int CurrentIndex = 0;
        private List<NaviButton> naviButtons = new List<NaviButton>();
        private string CurrentTime
        {
            get { return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); }
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //更新用户名称
            this.label_User.Text = CommonMethods.CurrentAdmin.LoginName;
            //打开集中监控窗体
            CommonNaviButton_Click(this.navi_Monitor, null);
            CommonMethods.AddLog(0, "登录窗体");
            CommonMethods.Device = LoadDevice(devPath, groupPath, variablePath);
            if (CommonMethods.Device != null)
            {
                CommonMethods.AddLog(0, "设备信息加载成功");

                //开启多线程实时通信
                CommonMethods.Device.AlarmTrigEvent += Device_AlarmTrigEvent;
                Task.Run(new Action(() =>
                {
                    DeviceCommunication(CommonMethods.Device);
                }), cts.Token);
            }
        }

        /// <summary>
        /// 报警触发事件
        /// </summary>
        /// <param name="ackType"></param>
        /// <param name="variable"></param>
        private void Device_AlarmTrigEvent(bool ackType, Variable variable)
        {
            if (ackType)
            {
                CommonMethods.AddLog(1, variable.Remark + " 触发");

                //存储
                sysLogManage.AddSysLog(new SysLog()
                {
                    InsertTime = CurrentTime,
                    Note = variable.Remark,
                    AlarmType = "触发",
                    Operator = CommonMethods.CurrentAdmin.LoginName,
                    VarName = variable.VarName
                });

                if (!this.actualAlarmList.Contains(variable.Remark))
                {
                    this.actualAlarmList.Add(variable.Remark);
                }
            }
            else
            {
                CommonMethods.AddLog(0, variable.Remark + " 消除");

                //存储
                sysLogManage.AddSysLog(new SysLog()
                {
                    InsertTime = CurrentTime,
                    Note = variable.Remark,
                    AlarmType = "消除",
                    Operator = CommonMethods.CurrentAdmin.LoginName,
                    VarName = variable.VarName
                });

                if (this.actualAlarmList.Contains(variable.Remark))
                {
                    this.actualAlarmList.Remove(variable.Remark);
                }
            }
        }
        private void ActualAlarmList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                //根据集合的数量进行处理

                switch (actualAlarmList.Count)
                {
                    case 0:
                        this.scrollingAlarm.Text = "当前系统无报警";
                        break;
                    default:
                        this.scrollingAlarm.Text = string.Join(" ", actualAlarmList);
                        break;
                }
            }));
        }

        private void DeviceCommunication(Device device)
        {
            while (!cts.IsCancellationRequested)
            {
                if (device.IsConnected)
                {
                    //通信读取
                    foreach (var gp in device.GroupList)
                    {
                        //报警状态由程序根据阈值和启用开关本地计算，不再从从站读取
                        if (gp.GroupName == "报警状态")
                        {
                            continue;
                        }

                        byte[] data = null;

                        //应该返回的字节长度
                        int reqLength = 0;

                        if (gp.StoreArea == "输入线圈" || gp.StoreArea == "输出线圈")
                        {
                            switch (gp.StoreArea)
                            {
                                case "输入线圈":
                                    data = CommonMethods.Modbus.ReadInputCoils(gp.Start, gp.Length);
                                    reqLength = ShortLib.GetByteLengthFromBoolLength(gp.Length);
                                    break;
                                case "输出线圈":
                                    data = CommonMethods.Modbus.ReadOutputCoils(gp.Start, gp.Length);
                                    reqLength = ShortLib.GetByteLengthFromBoolLength(gp.Length);
                                    break;
                                default:
                                    break;
                            }
                            if (data != null && data.Length == reqLength)
                            {
                                //变量解析
                                foreach (var variable in gp.VarList)
                                {
                                    DataType dataType = (DataType)Enum.Parse(typeof(DataType), variable.DataType, true);

                                    int start = variable.Start - gp.Start;

                                    switch (dataType)
                                    {
                                        case DataType.Bool:
                                            variable.VarValue = BitLib.GetBitFromByteArray(data, start, variable.OffsetOrLength);
                                            break;
                                        default:
                                            break;
                                    }
                                    //处理
                                    //直接更新
                                    device.UpdateVariable(variable);
                                }
                            }
                            else
                            {
                                device.IsConnected = false;
                                break;
                            }
                        }
                        else
                        {
                            switch (gp.StoreArea)
                            {
                                case "输入寄存器":
                                    data = CommonMethods.Modbus.ReadInputRegisters(gp.Start, gp.Length);
                                    reqLength = gp.Length * 2;
                                    break;
                                case "输出寄存器":
                                    data = CommonMethods.Modbus.ReadOutputRegisters(gp.Start, gp.Length);
                                    reqLength = gp.Length * 2;
                                    break;
                                default:
                                    break;
                            }
                            if (data != null && data.Length == reqLength)
                            {
                                //变量解析
                                foreach (var variable in gp.VarList)
                                {
                                    DataType dataType = (DataType)Enum.Parse(typeof(DataType), variable.DataType, true);

                                    int start = variable.Start - gp.Start;

                                    start *= 2;

                                    switch (dataType)
                                    {
                                        case DataType.Bool:
                                            variable.VarValue = BitLib.GetBitFrom2BytesArray(data, start, variable.OffsetOrLength, CommonMethods.dataFormat == DataFormat.BADC || CommonMethods.dataFormat == DataFormat.DCBA);
                                            break;
                                        case DataType.Byte:
                                            variable.VarValue = ByteLib.GetByteFromByteArray(data, CommonMethods.dataFormat == DataFormat.BADC || CommonMethods.dataFormat == DataFormat.DCBA ? start : start + 1);
                                            break;
                                        case DataType.Short:
                                            variable.VarValue = ShortLib.GetShortFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.UShort:
                                            variable.VarValue = UShortLib.GetUShortFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.Int:
                                            variable.VarValue = IntLib.GetIntFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.UInt:
                                            variable.VarValue = UIntLib.GetUIntFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.Float:
                                            variable.VarValue = FloatLib.GetFloatFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.Double:
                                            variable.VarValue = DoubleLib.GetDoubleFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.Long:
                                            variable.VarValue = LongLib.GetLongFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.ULong:
                                            variable.VarValue = ULongLib.GetULongFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.String:
                                            variable.VarValue = StringLib.GetStringFromByteArrayByEncoding(data, start, variable.OffsetOrLength, Encoding.ASCII);
                                            break;
                                        case DataType.ByteArray:
                                            variable.VarValue = ByteArrayLib.GetByteArrayFromByteArray(data, start, variable.OffsetOrLength);
                                            break;
                                        case DataType.HexString:
                                            variable.VarValue = StringLib.GetHexStringFromByteArray(data, start, variable.OffsetOrLength);
                                            break;
                                        default:
                                            break;
                                    }

                                    //处理
                                    //先做线性转换，再更新

                                    variable.VarValue = MigrationLib.GetMigrationValue(variable.VarValue, variable.Scale.ToString(), variable.Offset.ToString()).Content;

                                    device.UpdateVariable(variable);
                                }
                            }
                            else
                            {
                                device.IsConnected = false;
                                break;
                            }
                        }
                    }

                    //所有组采集完成后，按阈值和启用开关本地计算报警
                    if (device.IsConnected)
                    {
                        device.CheckThresholdAlarm();
                    }
                }
                else
                {
                    //非首次连接，需要延时
                    if (device.ReConnectSign)
                    {
                        CommonMethods.Modbus?.DisConnect();
                        Thread.Sleep(device.ReConnectTime);
                    }

                    //通信连接
                    CommonMethods.Modbus = new ModbusTCP();

                    device.IsConnected = CommonMethods.Modbus.Connect(device.IPAddress, device.Port);

                    if (device.ReConnectSign)
                    {
                        CommonMethods.AddLog(device.IsConnected ? 0 : 1, device.IsConnected ? "控制器重新连接成功" : "控制器重新连接失败");
                    }
                    else
                    {
                        CommonMethods.AddLog(device.IsConnected ? 0 : 1, device.IsConnected ? "控制器初次连接成功" : "控制器初次连接失败");
                        device.ReConnectSign = true;
                    }
                }
            }
        }

        /// <summary>
        /// 从 Device.ini 读取通信参数，生成设备对象
        /// </summary>
        private Device LoadDevice(string devicePath, string groupPath, string variablePath)
        {
            // 判断文件是否存在
            if (!File.Exists(devicePath))
            {
                CommonMethods.AddLog(1, "设备文件不存在");
                return null;
            }

            List<Group> gpList = LoadGroup(groupPath, variablePath);

            if (gpList != null && gpList.Count > 0)
            {
                try
                {
                    return new Device()
                    {
                        IPAddress = IniConfigHelper.ReadIniData("设备参数", "IP地址", "127.0.0.1", devicePath),
                        Port = Convert.ToInt32(IniConfigHelper.ReadIniData("设备参数", "端口号", "502", devicePath)),
                        CurrentRecipe = IniConfigHelper.ReadIniData("配方参数", "当前配方", "", devicePath),
                        GroupList = gpList
                    };
                }
                catch (Exception ex)
                {
                    //日志写入
                    CommonMethods.AddLog(1, "设备信息加载失败：" + ex.Message);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 通信组和通信变量解析
        /// </summary>
        /// <param name="groupPath"></param>
        /// <param name="variablePath"></param>
        /// <returns></returns>
        private List<Group> LoadGroup(string groupPath, string variablePath)
        {
            // 判断文件是否存在
            if (!File.Exists(groupPath))
            {
                CommonMethods.AddLog(1, "通信组文件不存在");
                return null;
            }
            if (!File.Exists(variablePath))
            {
                CommonMethods.AddLog(1, "通信变量文件不存在");
                return null;
            }

            // 先解析通信组
            List<Group> GpList = null;
            try
            {
                GpList = MiniExcel.Query<Group>(groupPath).ToList();
            }
            catch (Exception ex)
            {
                CommonMethods.AddLog(1, "通信组加载失败：" + ex.Message);
                return null;
            }

            List<Variable> VarList = null;
            try
            {
                VarList = MiniExcel.Query<Variable>(variablePath).ToList();
            }
            catch (Exception ex)
            {
                CommonMethods.AddLog(1, "通信变量加载失败：" + ex.Message);
                return null;
            }

            if (GpList != null && VarList != null)
            {
                foreach (var group in GpList)
                {
                    group.VarList = VarList.FindAll(c => c.GroupName == group.GroupName).ToList();
                }
                return GpList;
            }
            else
            {
                return null;
            }
        }
        private void naviButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NaviButton1_Load");
        }
      
        private string devPath = @"D:\product\MTHProject\MTHProject\bin\Debug\Config\Device.ini";
        private string groupPath = @"D:\product\MTHProject\MTHProject\bin\Debug\Config\Group.xlsx";
        private string variablePath = @"D:\product\MTHProject\MTHProject\bin\Debug\Config\Variable.xlsx";

        private void CommonNaviButton_Click(object sender, EventArgs e)
        {
           if(sender is NaviButton navi)
            {
                if(Enum.IsDefined(typeof(FrmNames), navi.TitleName))
                {
                    FrmNames frmNames = (FrmNames)Enum.Parse(typeof(FrmNames), navi.TitleName, true);

                    //用户权限处理

                    switch (frmNames)
                    {
                        case FrmNames.参数设置:
                            if (!CommonMethods.CurrentAdmin.ParamSet)
                            {
                                new FrmMsgBoxWithoutAck("用户权限不足，请切换用户！", "权限不足").ShowDialog();
                                return;
                            }
                            break;
                        case FrmNames.配方管理:
                            if (!CommonMethods.CurrentAdmin.Recipe)
                            {
                                new FrmMsgBoxWithoutAck("用户权限不足，请切换用户！", "权限不足").ShowDialog();
                                return;
                            }
                            break;
                        case FrmNames.报警追溯:
                            if (!CommonMethods.CurrentAdmin.HistoryLog)
                            {
                                new FrmMsgBoxWithoutAck("用户权限不足，请切换用户！", "权限不足").ShowDialog();
                                return;
                            }
                            break;
                        case FrmNames.历史趋势:
                            if (!CommonMethods.CurrentAdmin.HistoryTrend)
                            {
                                new FrmMsgBoxWithoutAck("用户权限不足，请切换用户！", "权限不足").ShowDialog();
                                return;
                            }
                            break;
                        case FrmNames.用户管理:
                            if (!CommonMethods.CurrentAdmin.UserManage)
                            {
                                new FrmMsgBoxWithoutAck("用户权限不足，请切换用户！", "权限不足").ShowDialog();
                                return;
                            }
                            break;
                        default:
                            break;
                    }

                    //窗口切换
                    OpenForm(this.MainPanel, frmNames);
                    SetTitle(this.lbl_Title,frmNames);
                    SetNaviButtonSelected(this.TopPanel, navi);
                }
            }
        }

        //通用打开窗体
        private void OpenForm (Panel mainPanel,FrmNames frmNames)
        {
            int total = mainPanel.Controls.Count;
            int closeCount = 0;
            bool isFind = false;
            for (int i = 0; i < total; i++)
            {
                Control ct = mainPanel.Controls[i - closeCount];
                if (ct is Form frm)
                {
                    if (frm.Text == frmNames.ToString())
                    {
                        frm.BringToFront();
                        isFind = true;
                        break;
                    }
                    else if ((FrmNames)Enum.Parse(typeof(FrmNames), frm.Text, true) >= FrmNames.临界窗体)
                    {
                        frm.Close();
                        closeCount++;
                    }
                }
            }
                if (isFind == false)
                {
                    Form frm = null;
                    switch(frmNames)
                    {
                        case FrmNames.集中监控:
                            frm = new FrmMonitor();
                            break;
                        case FrmNames.参数设置:
                            frm = new FrmParamSet(devPath);
                            break;
                        case FrmNames.配方管理:
                            frm = new FrmRecipe(devPath);
                            break;
                        case FrmNames.报警追溯:
                            frm = new FrmAlarm();
                            break;
                        case FrmNames.历史趋势:
                            frm = new FrmHistory();
                            break;
                        case FrmNames.用户管理:
                            frm = new FrmUserManage();
                            break;
                        default:
                            break;
                    }
                    if(frm!=null)
                    {
                        frm.TopLevel = false;
                        frm.FormBorderStyle = FormBorderStyle.None;
                        frm.Dock = DockStyle.Fill;
                        frm.Parent = mainPanel;
                        frm.BringToFront();
                        frm.Show();
                    }
                }
            

        }
        
        private void SetTitle(Label lable,FrmNames frmNames)
        {
            lable.Text = frmNames.ToString();
        }

        private void SetNaviButtonSelected(Panel topPanel, NaviButton naviButton)
        {
            foreach (var item in topPanel.Controls.OfType<NaviButton>())
            {
                item.IsSelected = false;
            }
            naviButton.IsSelected = true;
        }

        #region 减少闪烁
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion

        #region 获取星期信息

        private string[] weeks = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
        private string week
        {
            get { return weeks[Convert.ToInt32(DateTime.Now.DayOfWeek)]; }
        }

        #endregion

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 左右切换
        private void btn_Right_Click(object sender, EventArgs e)
        {
            CurrentIndex++;
            if (CurrentIndex < naviButtons.Count)
            {
                CommonNaviButton_Click(naviButtons[CurrentIndex], null);
            }
            else
            {
                CurrentIndex--;
            }
        }

        private void btn_Left_Click(object sender, EventArgs e)
        {
            CurrentIndex--;
            if (CurrentIndex >= 0)
            {
                CommonNaviButton_Click(naviButtons[CurrentIndex], null);
            }
            else
            {
                CurrentIndex++;
            }
        }
        #endregion
    }
}
