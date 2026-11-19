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

namespace MTHControlLib
{
    public partial class RecipeControl : UserControl
    {
        public RecipeControl()
        {
            InitializeComponent();
            //设置控件样式
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
        private string devName = "1#站点";

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示设备名称")]
        public string DevName
        {
            get { return devName; }
            set
            {
                devName = value;

                this.title1.TitleName = devName;
                this.textSetEx1.TitleName = devName + "温度高限";
                this.textSetEx2.TitleName = devName + "温度低限";
                this.textSetEx3.TitleName = devName + "湿度高限";
                this.textSetEx4.TitleName = devName + "湿度低限";
            }
        }

        private RecipeParam recipeParam = new RecipeParam();
        [Browsable(false)]
        public RecipeParam RecipeParam
        {
            get
            {
                recipeParam = GetRecipeParam();
                return recipeParam;
            }
            set
            {
                recipeParam = value;
                SetRecipeParam(recipeParam);
            }
        }

        private RecipeParam GetRecipeParam()
        {
            return new RecipeParam()
            {
                TempHigh = this.textSetEx1.CurrentValue,
                TempLow = this.textSetEx2.CurrentValue,
                HumidityHigh = this.textSetEx3.CurrentValue,
                HumidityLow = this.textSetEx4.CurrentValue,
                TempAlarmEnable = this.checkBoxEx1.Checked,
                HumidityAlarmEnable = this.checkBoxEx2.Checked
            };
        }

        private void SetRecipeParam(RecipeParam recipeParam)
        {
            this.textSetEx1.CurrentValue = recipeParam.TempHigh;
            this.textSetEx2.CurrentValue = recipeParam.TempLow;
            this.textSetEx3.CurrentValue = recipeParam.HumidityHigh;
            this.textSetEx4.CurrentValue = recipeParam.HumidityLow;
            this.checkBoxEx1.Checked = recipeParam.TempAlarmEnable;
            this.checkBoxEx2.Checked = recipeParam.HumidityAlarmEnable;
        }
    }
}
