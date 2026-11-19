using MTHBLL;
using MTHControlLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;

namespace MTHProject
{
    public partial class FrmHistory : Form
    {
        public FrmHistory()
        {
            InitializeComponent();
            CheckBoxList.Add(this.checkBoxEx1);
            CheckBoxList.Add(this.checkBoxEx2);
            CheckBoxList.Add(this.checkBoxEx3);
            CheckBoxList.Add(this.checkBoxEx4);
            CheckBoxList.Add(this.checkBoxEx5);
            CheckBoxList.Add(this.checkBoxEx6);
            CheckBoxList.Add(this.checkBoxEx7);
            CheckBoxList.Add(this.checkBoxEx8);
            CheckBoxList.Add(this.checkBoxEx9);
            CheckBoxList.Add(this.checkBoxEx10);
            CheckBoxList.Add(this.checkBoxEx11);
            CheckBoxList.Add(this.checkBoxEx12);
            this.dtp_Start.Value = DateTime.Now.AddHours(-2.0f);
            this.dtp_End.Value = DateTime.Now;

            //设置X轴类型
            this.chart_HistoryTrend.XDataType = SeeSharpTools.JY.GUI.StripChartX.XAxisDataType.String;

            //设置图例
            this.chart_HistoryTrend.LegendVisible = false;

            this.chart_HistoryTrend.DisplayPoints = 100000;

            //Y1轴范围
            this.chart_HistoryTrend.AxisY.Minimum = 0.0f;
            this.chart_HistoryTrend.AxisY.Maximum = 100.0f;
            this.chart_HistoryTrend.AxisY.AutoScale = false;
        }

        private Dictionary<string, string> ParamList = new Dictionary<string, string>();
        private ActualDataManage actualDataManage = new ActualDataManage();
        private List<CheckBoxEx> CheckBoxList = new List<CheckBoxEx>();
        private void btn_Query_Click(object sender, EventArgs e)
        {
            ParamList = GetParamList();

            string start = this.dtp_Start.Text;
            string end = this.dtp_End.Text;

            if (ParamList.Count == 0)
            {
                new FrmMsgBoxWithoutAck("请勾选需要查询的参数！", "查询出错").Show();
                return;
            }

            Task<OperateResult<DataTable>> task1 = Task.Run(() =>
            {
                return QueryProcess(start, end);
            });


            var task2 = task1.ContinueWith(task =>
            {
                this.Invoke(new Action(() =>
                {
                    if (task.Result.IsSuccess)
                    {
                        UpdateChart(task.Result.Content);
                    }
                    else
                    {
                        new FrmMsgBoxWithoutAck("查询出错：" + task.Result.Message, "查询出错").Show();
                    }
                }));
            });
        }

        private Dictionary<string, string> GetParamList()
        {
            Dictionary<string, string> paramList = new Dictionary<string, string>();

            foreach (var item in CheckBoxList)
            {
                if (item.Tag != null && item.Tag.ToString().Length > 0)
                {
                    if (item.Checked)
                    {
                        paramList.Add(item.Tag.ToString(), item.Text);
                    }
                }
            }
            return paramList;
        }

        /// <summary>
        /// 根据时间节点查询
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private OperateResult<DataTable> QueryProcess(string start, string end)
        {
            //判断时间
            DateTime startTime = Convert.ToDateTime(start);
            DateTime endTime = Convert.ToDateTime(end);

            if (startTime >= endTime)
            {
                return OperateResult.CreateFailResult<DataTable>("开始时间不能大于结束时间");
            }

            TimeSpan timeSpan = endTime - startTime;

            if (timeSpan.TotalDays > 1.0)
            {
                return OperateResult.CreateFailResult<DataTable>("查询范围不能超过1天");
            }

            DataTable dataTable = actualDataManage.QueryActualDataByCondition(start, end, ParamList.Keys.ToList());

            if (dataTable != null)
            {
                return OperateResult.CreateSuccessResult(dataTable);
            }
            else
            {
                return OperateResult.CreateFailResult<DataTable>("未查询到有效数据");
            }
        }

        private void UpdateChart(DataTable dataTable)
        {
            int rowcount = dataTable.Rows.Count;
            int columnCount = ParamList.Count;

            //需要设置Chart
            this.chart_HistoryTrend.Clear();
            this.chart_HistoryTrend.SeriesCount = columnCount;

            for (int i = 0; i < ParamList.Count; i++)
            {
                this.chart_HistoryTrend.Series[i].Name = ParamList.Values.ToList()[i];
                this.chart_HistoryTrend.Series[i].Width = SeeSharpTools.JY.GUI.StripChartXSeries.LineWidth.Middle;
            }

            //解析DataTable
            double[,] YData = new double[columnCount, rowcount];
            string[] XData = new string[rowcount];

            for (int i = 0; i < rowcount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    if (dataTable.Rows[i][j + 1] is DBNull)
                    {
                        YData[j, i] = 0.0f;
                    }
                    else
                    {
                        try
                        {
                            YData[j, i] = Convert.ToDouble(dataTable.Rows[i][j + 1]);
                        }
                        catch (Exception)
                        {
                            YData[j, i] = 0.0f;
                        }
                    }
                    // 根据图3，X轴数据在此处赋值
                    XData[i] = Convert.ToDateTime(dataTable.Rows[i][0]).ToString("HH:mm:ss");
                }
            }

            this.chart_HistoryTrend.Plot(YData, XData);
        }

        private void btn_QuickQuery_Click(object sender, EventArgs e)
        {
            this.dtp_Start.Value = DateTime.Now.AddHours(-5.0f);
            this.dtp_End.Value = DateTime.Now;

            this.btn_Query_Click(null, null);

        }

        private void btn_SaveImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "图片文件(*.jpg)|*.jpg|所有文件*.*|*.*";
            saveFileDialog.FileName = "历史趋势图片" + DateTime.Now.ToString("yyyyMMddHHmmss");
            saveFileDialog.Title = "历史趋势保存";
            saveFileDialog.DefaultExt = "jpg";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.chart_HistoryTrend.SaveAsImage(saveFileDialog.FileName);

                if (new FrmMsgBoxWithAck("图片保存成功，是否立即打开？", "打开趋势图片").ShowDialog() == DialogResult.OK)
                {
                    Process.Start(saveFileDialog.FileName);
                }
            }
        }

        private void btn_ExportCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "CSV(*.csv)|*.csv|所有文件*.*|*.*";
            saveFileDialog.FileName = "历史趋势CSV" + DateTime.Now.ToString("yyyyMMddHHmmss");
            saveFileDialog.Title = "历史趋势CSV";
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.chart_HistoryTrend.SaveAsCsv(saveFileDialog.FileName);

                if (new FrmMsgBoxWithAck("CSV导出成功，是否立即打开？", "打开趋势CSV").ShowDialog() == DialogResult.OK)
                {
                    Process.Start(saveFileDialog.FileName);
                }
            }
        }
    }
}
