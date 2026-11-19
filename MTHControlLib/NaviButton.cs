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
    [DefaultEvent("Click")]
    public partial class NaviButton : UserControl
    {
        public NaviButton()
        {
            InitializeComponent();
            // 设置控件样式以提高绘制性能
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private string titleName = "导航按钮";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示文本内容")]
        public string TitleName
        {
            get { return titleName; }
            set { titleName = value; this.lbl_Title.Text = value; }
        }

        private bool isSelected = false;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示导航按钮是否选中")]

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }

        /// <summary>
        /// 重写 OnClick，使点击 Label 子控件时也能正确触发 NaviButton 的 Click 事件。
        /// 不再使用 'new' 隐藏 Control.Click —— 设计器需要反射到基类事件。
        /// </summary>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }

        private void label_Title_Click(object sender, EventArgs e)
        {
            // 转发到基类 OnClick，自动触发设计器可序列化的 Click 事件
            this.OnClick(e);
        }
    }
}
