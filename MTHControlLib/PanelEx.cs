using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTHControlLib
{
    public partial class PanelEx : Panel
    {
        public PanelEx()
        {
            InitializeComponent();
            // 设置控件样式以提高绘制性能
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private int topGap=1;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示上面的间距")]
        public int TopGap
        {
            get { return topGap; }
            set { topGap = value; this.Invalidate(); }
        }
        private int bottomGap=1;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示下面的间距")]
        public int BottomGap
        {
            get { return bottomGap; }
            set { bottomGap = value; this.Invalidate(); }
        }
        private int leftGap=1;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示左边的间距")]
        public int LeftGap
        {
            get { return leftGap; }
            set { leftGap = value; this.Invalidate(); }
        }
        private int rightGap=1;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示右边的间距")]
        public int RightGap
        {
            get { return rightGap; }
            set { rightGap = value; this.Invalidate(); }
        }

        private int borderWidth = 2;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示边框宽度")]
        public int BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; this.Invalidate(); }
        }

        private Color borderColor = Color.FromArgb(35, 255, 253);
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示边框颜色")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; this.Invalidate(); }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Pen pen = new Pen(borderColor,borderWidth);
            float x = leftGap+borderWidth*0.5f;
            float y = topGap+borderWidth*0.5f;
            float width = this.Width -leftGap-rightGap- borderWidth;
            float height = this.Height - topGap - bottomGap - borderWidth;
            g.DrawRectangle(pen, x, y, width, height);
        }
    }
}
