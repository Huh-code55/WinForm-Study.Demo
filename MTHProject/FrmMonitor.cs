using MTHControlLib;
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
    public partial class FrmMonitor : Form
    {
        public FrmMonitor()
        {
            InitializeComponent();
            this.lst_Info.Columns[1].Width = this.lst_Info.Width - this.lst_Info.Columns[0].Width - 25;
            SetChart();
            //把本窗体的日志方法注册到全局，其他窗体通过 CommonMethods.AddLog 写日志
            CommonMethods.AddLog = this.AddLog;
            this.updateTimer.Interval = 1000;
            this.updateTimer.Tick += UpdateTimer_Tick;
            this.updateTimer.Start();

            this.FormClosing += (sender, e) =>
            {
                this.updateTimer.Stop();
            };
        }
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            //窗体已被释放（例如随主窗体一起销毁）时，chart内部控件已失效，
            //此时再调用PlotSingle会在Chart.Invalidate()里抛NullReferenceException
            if (this.IsDisposed || this.Disposing)
            {
                this.updateTimer.Stop();
                return;
            }

            if (CommonMethods.Device.IsConnected)
            {
                foreach (var item in this.panelEnhanced1.Controls.OfType<MTHControl>())
                {
                    UpdateMTHControl(item);
                }
                List<double> ydata = new List<double>();

                for (int i = 1; i <= 6; i++)
                {
                    ydata.Add(Convert.ToDouble(CommonMethods.Device[$"模块{i}温度"]));
                    ydata.Add(Convert.ToDouble(CommonMethods.Device[$"模块{i}湿度"]));
                }
                this.chart_ActualTrend.PlotSingle(ydata.ToArray());
            }
        }

        private Timer updateTimer = new Timer();

        private string CurrentTime
        {
            get { return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); }
        }

        private void UpdateMTHControl(MTHControl mTHControl)
        {
            if (CommonMethods.Device[mTHControl.TempVarName] != null)
            {
                mTHControl.Temp = CommonMethods.Device[mTHControl.TempVarName].ToString();
            }
            if (CommonMethods.Device[mTHControl.HumidityVarName] != null)
            {
                mTHControl.Humidity = CommonMethods.Device[mTHControl.HumidityVarName].ToString();
            }
            if (CommonMethods.Device[mTHControl.StateVarName] != null)
            {
                mTHControl.ModuleError = CommonMethods.Device[mTHControl.StateVarName].ToString() == "True";
            }
        }

        private void SetChart()
        {
            //设置X轴数据类型及格式
            this.chart_ActualTrend.XDataType = SeeSharpTools.JY.GUI.StripChartX.XAxisDataType.TimeStamp;
            this.chart_ActualTrend.TimeStampFormat = "HH:mm:ss";
            //设置图例
            this.chart_ActualTrend.LegendVisible = true;
            //设置显示数据点
            this.chart_ActualTrend.DisplayPoints = 4000;
            //Y轴范围
            this.chart_ActualTrend.AxisY.Minimum = 0.0f;
            this.chart_ActualTrend.AxisY.Maximum = 100.0f;
            this.chart_ActualTrend.AxisY.AutoScale = false;
            //清除曲线
            this.chart_ActualTrend.Series.Clear();
            //设置曲线数量
            this.chart_ActualTrend.SeriesCount = 12;
            //设置曲线
            for (int i = 0; i < 12; i++)
            {
                //设置曲线名称
                this.chart_ActualTrend.Series[i].Name = i % 2 == 0 ? $"{i / 2 + 1}#站点温度" : $"{i / 2 + 1}#站点湿度";
                //设置曲线不可见
                this.chart_ActualTrend.Series[i].Visible = false;
                //设置曲线的粗细
                this.chart_ActualTrend.Series[i].Width = SeeSharpTools.JY.GUI.StripChartXSeries.LineWidth.Middle;
                //设置曲线的Y轴
                this.chart_ActualTrend.Series[i].YPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            }

            this.chk_Temp1.Checked = true;
            this.chk_Humidity1.Checked = true;
        }

        /// <summary>
        /// 实现通用日志记录的方法
        /// </summary>
        /// <param name="level"></param>
        /// <param name="log"></param>
        public void AddLog(int level, string log)
        {
            if (level > 2)
            {
                level = 2;
            }
            if (level < 0)
            {
                level = 0;
            }

            if (this.lst_Info.InvokeRequired)
            {
                this.lst_Info.Invoke(new Action<int, string>(AddLog), level, log);
            }
            else
            {
                ListViewItem listViewItem = new ListViewItem(CurrentTime, level);
                listViewItem.SubItems.Add(log);
                this.lst_Info.Items.Add(listViewItem);
                //让最新的日志显示在最下面
                this.lst_Info.Items[this.lst_Info.Items.Count - 1].EnsureVisible();

            }
        }

        private void chk_Common_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBoxEx checkBox)
            {
                if (checkBox.Tag != null && checkBox.Tag.ToString().Length > 0)
                {
                    int index = Convert.ToInt32(checkBox.Tag.ToString());

                    this.chart_ActualTrend.Series[index].Visible = checkBox.Checked;
                }
            }
        }
    }
}
