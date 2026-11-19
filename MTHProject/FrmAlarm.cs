using MiniExcelLibs;
using MTHBLL;
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
    public partial class FrmAlarm : Form
    {
        public FrmAlarm()
        {
            InitializeComponent();
            this.dgv_Main.AutoGenerateColumns = false;

            //列标题不应被选中高亮
            DataGridViewHelper.SetHeaderNoHighlight(this.dgv_Main);

            this.cmb_AlarmType.Items.AddRange(new string[] { "全部", "触发", "消除" });
            this.cmb_AlarmType.SelectedIndex = 0;

            this.dtp_Start.Value = DateTime.Now.AddHours(-2.0f);
            this.dtp_End.Value = DateTime.Now;
        }
        private SysLogManage sysLogManage = new SysLogManage();
        private void btn_Query_Click(object sender, EventArgs e)
        {
            string start = this.dtp_Start.Text;
            string end = this.dtp_End.Text;

            string alarmType = this.cmb_AlarmType.Text == "全部" ? "" : this.cmb_AlarmType.Text;

            Task<OperateResult<DataTable>> task1 = Task.Run(() =>
            {
                return QueryProcess(start, end, alarmType);
            });

            var task2 = task1.ContinueWith(task =>
            {
                this.Invoke(new Action(() =>
                {
                    if (task.Result.IsSuccess)
                    {
                        this.dgv_Main.DataSource = null;
                        this.dgv_Main.DataSource = task.Result.Content;
                    }
                    else
                    {
                        new FrmMsgBoxWithoutAck("查询失败：" + task.Result.Message, "报警查询").Show();
                    }
                }));
            });

        }
        private OperateResult<DataTable> QueryProcess(string start, string end, string alarmType)
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

            DataTable dataTable = sysLogManage.QuerySysLogByCondition(start, end, alarmType);

            if (dataTable != null)
            {
                return OperateResult.CreateSuccessResult(dataTable);
            }
            else
            {
                return OperateResult.CreateFailResult<DataTable>("未查询到有效数据");
            }
        }

        private void dgv_Main_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint(sender as DataGridView, e);
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "XLSX文件(*.xlsx)|*.xlsx|所有文件*.*|*.*";
            saveFileDialog.Title = "导出历史报警";
            saveFileDialog.FileName = "历史报警" + DateTime.Now.ToString("yyyyMMddHHmmss");
            saveFileDialog.DefaultExt = "xlsx";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                MiniExcel.SaveAs(saveFileDialog.FileName, this.dgv_Main.DataSource);

                if (new FrmMsgBoxWithAck("导出报警成功，是否立即打开？", "打开报警记录").ShowDialog() == DialogResult.OK)
                {
                    Process.Start(saveFileDialog.FileName);
                }
            }
        }
    }
}
