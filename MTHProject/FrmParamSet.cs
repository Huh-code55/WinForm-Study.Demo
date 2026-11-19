using MTHControlLib;
using MTHHelper;
using MTHModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTHProject
{
    public partial class FrmParamSet : Form
    {
        // 配置文件目录：与 Group.xlsx、Variable.xlsx 保持一致（打包成 EXE 后应改为程序自身目录）
        private static readonly string ConfigDir = @"D:\product\MTHProject\MTHProject\bin\Debug\Config";

        // 供 VS 设计器使用
        public FrmParamSet()
            : this(System.IO.Path.Combine(ConfigDir, "Device.ini"))
        {
        }

        public FrmParamSet(string devPath)
        {
            InitializeComponent();
            this.devPath = devPath;
            updateTimer.Interval = 500;
            updateTimer.Tick += UpdateTimer_Tick;

            InitParam();
            CommonBindEvent();
            this.FormClosing += (sender, e) =>
            {
                this.updateTimer.Stop();
            };

            this.updateTimer.Start();
            LoadDeviceParam();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            GetLimitParam();
            GetAlarmParam();
        }
        private string devPath = string.Empty;
        private Timer updateTimer = new Timer();

        /// <summary>
        /// 通用事件绑定
        /// </summary>
        private void CommonBindEvent()
        {
            foreach (var item in this.PanelMain.Controls.OfType<TextSet>())
            {
                if (item.BindVarName != null && item.BindVarName.ToString().Length > 0)
                {
                    item.ControlDoubleClick += Common_ControlDoubleClick;
                }
            }

            foreach (var item in this.PanelMain.Controls.OfType<CheckBoxEx>())
            {
                if (item.Tag != null && item.Tag.ToString().Length > 0)
                {
                    item.CheckedChanged += Common_CheckedChanged;
                }
            }
        }

        private void GetLimitParam()
        {
            if (CommonMethods.Device != null && CommonMethods.Device.IsConnected)
            {
                foreach (var item in this.PanelMain.Controls.OfType<TextSet>())
                {
                    if (item.BindVarName != null && item.BindVarName.ToString().Length > 0)
                    {
                        object value = CommonMethods.Device[item.BindVarName.ToString()];
                        if (value != null)
                        {
                            item.CurrentValue = value.ToString();
                        }
                    }
                    if (item.AlarmVarName != null && item.AlarmVarName.ToString().Length > 0)
                    {
                        object value = CommonMethods.Device[item.AlarmVarName.ToString()];
                        if (value != null)
                        {
                            item.IsAlarm = value.ToString() == "True";
                        }
                    }
                }
            }
        }

        private void GetAlarmParam()
        {
            if (CommonMethods.Device != null && CommonMethods.Device.IsConnected)
            {
                foreach (var item in this.PanelMain.Controls.OfType<CheckBoxEx>())
                {
                    if (item.Tag != null && item.Tag.ToString().Length > 0)
                    {
                        object value = CommonMethods.Device[item.Tag.ToString()];
                        if (value != null)
                        {
                            item.Checked = value.ToString() == "1";
                        }
                    }
                }
            }
        }

        // 默认通信参数
        private const string DefaultIp = "127.0.0.1";
        private const int DefaultPort = 502;

        /// <summary>
        /// 设备对象为空时，从 Device.ini 加载已保存的通信参数
        /// </summary>
        private void LoadDeviceParam()
        {
            if (CommonMethods.Device != null)
            {
                return;
            }

            string ip = IniConfigHelper.ReadIniData("设备参数", "IP地址", DefaultIp, this.devPath);
            int port;
            if (!int.TryParse(IniConfigHelper.ReadIniData("设备参数", "端口号", DefaultPort.ToString(), this.devPath), out port))
            {
                port = DefaultPort;
            }

            CommonMethods.Device = new Device { IPAddress = ip, Port = port };
        }

        /// <summary>
        /// 初始化参数：把设备对象中的通信参数填充到界面
        /// </summary>
        private void InitParam()
        {
            if (CommonMethods.Device == null)
            {
                return;
            }

            this.txt_IP.Text = CommonMethods.Device.IPAddress;
            this.txt_Port.Text = CommonMethods.Device.Port.ToString();
            GetLimitParam();
            GetAlarmParam();
        }

        private void btn_GroupConfig_Click(object sender, EventArgs e)
        {
            new FrmGroupConfig().ShowDialog();
        }

        private void btn_VarConfig_Click(object sender, EventArgs e)
        {
            new FrmVariableConfig().ShowDialog();
        }

        private void btn_Sure_Click(object sender, EventArgs e)
        {
            int port;
            if (!int.TryParse(this.txt_Port.Text.Trim(), out port))
            {
                new FrmMsgBoxWithoutAck("端口号必须是数字", "通信设置").Show();
                return;
            }

            bool result = IniConfigHelper.WriteIniData("设备参数", "IP地址", this.txt_IP.Text.Trim(), this.devPath);

            result &= IniConfigHelper.WriteIniData("设备参数", "端口号", port.ToString(), this.devPath);

            if (result)
            {
                // 同步更新设备对象，这样“取消设置”才能恢复到刚保存的值
                CommonMethods.Device.IPAddress = this.txt_IP.Text.Trim();
                CommonMethods.Device.Port = port;
                DialogResult dialogResult = new FrmMsgBoxWithAck("通信参数设置成功，是否立即重连？", "通信设置").ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    CommonMethods.Device.IsConnected = false;
                }
            }
            else
            {
                new FrmMsgBoxWithoutAck("通信参数设置失败", "通信设置").Show();
            }
        }
        /// <summary>
        /// 取消设置：放弃界面上的修改，恢复为已保存的参数
        /// </summary>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            InitParam();
        }

        /// <summary>
        /// 删除参数：删除 Device.ini 中已保存的通信参数，并恢复默认值
        /// </summary>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除已保存的通信参数吗？", "删除参数",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            if (IniConfigHelper.DeleteIniSection("设备参数", this.devPath))
            {
                // 删除后设备对象恢复默认值，界面同步刷新
                CommonMethods.Device.IPAddress = DefaultIp;
                CommonMethods.Device.Port = DefaultPort;
                InitParam();
                new FrmMsgBoxWithoutAck("通信参数删除成功", "删除参数").Show();
            }
            else
            {
                new FrmMsgBoxWithoutAck("没有找到已保存的通信参数", "删除参数").Show();
            }
        }

        private void Common_ControlDoubleClick(object sender, EventArgs e)
        {
            if (sender is TextSet textset)
            {
                if (textset.BindVarName != null && textset.BindVarName.ToString().Length > 0)
                {
                    FrmModify frmModify = new FrmModify(textset.TitleName, textset.BindVarName, textset.CurrentValue);
                    frmModify.ShowDialog();
                }
            }
        }

        private void Common_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBoxEx checkbox)
            {
                if (checkbox.Tag != null && checkbox.Tag.ToString().Length > 0)
                {
                    bool result = CommonMethods.CommonWrite(checkbox.Tag.ToString(), checkbox.Checked ? "1" : "0");

                    if (result == false)
                    {
                        checkbox.CheckedChanged -= Common_CheckedChanged;
                        checkbox.Checked = !checkbox.Checked;
                        checkbox.CheckedChanged += Common_CheckedChanged;
                    }
                }
            }
        }
    }
}
