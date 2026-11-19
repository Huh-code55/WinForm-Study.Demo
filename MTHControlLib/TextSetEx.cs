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
    public partial class TextSetEx : UserControl
    {
        public TextSetEx()
        {
            InitializeComponent();

            //设置控件样式
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            //内部容器默认跟随控件背景色和前景色
            this.tableLayoutPanel1.BackColor = this.BackColor;
            this.tableLayoutPanel1.ForeColor = this.ForeColor;
        }

        /// <summary>
        /// 重写背景色：同步到内部铺满的容器，否则容器会遮住控件自身的背景
        /// </summary>
        [Browsable(true)]
        [Category("外观")]
        [Description("设置控件的背景颜色")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                if (this.tableLayoutPanel1 != null)
                {
                    this.tableLayoutPanel1.BackColor = value;
                }
            }
        }

        /// <summary>
        /// 重写前景色：同步到内部铺满的容器，否则文字颜色不受控件属性控制
        /// </summary>
        [Browsable(true)]
        [Category("外观")]
        [Description("设置控件的前景颜色（文字颜色）")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                if (this.tableLayoutPanel1 != null)
                {
                    this.tableLayoutPanel1.ForeColor = value;
                }
            }
        }

        private string titleName = "1#站点温度高限";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示标题名称")]
        public string TitleName
        {
            get { return titleName; }
            set
            {
                titleName = value;
                this.lbl_Title.Text = titleName;
            }
        }

        private float currentValue = 0.0f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示当前数值")]
        public float CurrentValue
        {
            get
            {
                currentValue = Convert.ToSingle(this.num_Value.Value);
                return currentValue;
            }
            set
            {
                    currentValue = value;
                    this.num_Value.Value = Convert.ToDecimal(currentValue);
                }
        }

        private string unit = "℃";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示单位名称")]
        public string Unit
        {
            get { return unit; }
            set
            {
                unit = value;
                this.lbl_Unit.Text = unit;
            }
        }
    }
}
