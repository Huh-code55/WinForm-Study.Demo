using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTHControlLib
{
    public partial class MTHControl : UserControl
    {
        public MTHControl()
        {
            InitializeComponent();
            // 设置控件样式以提高绘制性能
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private string title = "1#站点";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示标题名称")]
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                this.lbl_Title.Text = title;
            }
        }

        private string temp = "0.0";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示温度值")]
        public string Temp
        {
            get { return temp; }
            set
            {
                if (temp != value)
                {
                    temp = value;
                    this.lbl_Temp.Text = temp;
                    if (float.TryParse(temp, out float val))
                    {
                        this.dialPlate.Temp = val;
                    }
                    else
                    {
                        this.dialPlate.Temp = 0.0f;
                    }
                }
                temp = value;
                this.lbl_Temp.Text = temp;
            }
        }

        private string humidity = "0.0";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示湿度值")]
        public string Humidity
        {
            get { return humidity; }
            set
            {
                if(humidity != value)
                {
                    humidity = value;
                    this.lbl_Humidity.Text = humidity;
                    if (float.TryParse(humidity, out float val))
                    {
                        this.dialPlate.Humidity = val;
                    }
                    else
                    {
                        this.dialPlate.Humidity = 0.0f;
                    }
                }
            }
        }

        private bool moduleError = false;
        [Browsable(true)]
        [Category("自定义属性")]
        public bool ModuleError
        {
            get { return moduleError; }
            set
            {
                moduleError = value;
                this.lbl_Title.BackColor = moduleError ? Color.Red : Color.FromArgb(36, 184, 196);
            }
        }

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示温度绑定变量名称")]
        public string TempVarName { get; set; } = string.Empty;

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示湿度绑定变量名称")]
        public string HumidityVarName { get; set; } = string.Empty;

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示状态绑定变量名称")]
        public string StateVarName { get; set; } = string.Empty;












        private void lbl_Title_Click(object sender, EventArgs e)
        {

        }

        private void MTHControl_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
