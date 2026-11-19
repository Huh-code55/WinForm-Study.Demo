using MiniExcelLibs;
using MTHModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;

namespace MTHProject
{
    public partial class FrmVariableConfig : Form
    {
        // 配置目录：固定到 bin\Debug\Config（将来打包成 EXE 后应改为程序自身目录）
        private static readonly string ConfigGroupDir = @"D:\product\MTHProject\MTHProject\bin\Debug\Config";
        private string groupPath = Path.Combine(ConfigGroupDir, "Group.xlsx");

        private static readonly string ConfigVariableDir = @"D:\product\MTHProject\MTHProject\bin\Debug\Config";
        private string variablePath = Path.Combine(ConfigVariableDir, "Variable.xlsx");

        private List<Group> TotalGroups = new List<Group>();
        private List<Variable> TotalVariables = new List<Variable>();
        private List<Group> GetAllGroups()
        {
            try
            {
                return MiniExcel.Query<Group>(groupPath).ToList();
            }
            catch (Exception)
            {
                return new List<Group>();
            }
        }
        private List<Variable> GetAllVariables()
        {
            try
            {
                return MiniExcel.Query<Variable>(variablePath).ToList();
            }
            catch (Exception)
            {
                return new List<Variable>();
            }
        }

        private List<Variable> GetVariablesByGroupName(string groupName)
        {
            if (groupName.Length == 0)
            {
                return TotalVariables;
            }
            else
            {
                return TotalVariables.FindAll(c => c.GroupName == groupName).ToList();
            }
        }

        private void RefreshVariable()
        {
            var list = GetVariablesByGroupName(this.cmb_GroupName.Text.Trim());

            if (list != null)
            {
                this.dgv_Main.DataSource = null;
                this.dgv_Main.DataSource = list;
            }
        }

        public FrmVariableConfig()
        {
            InitializeComponent();
            this.cmb_DataType.DataSource = Enum.GetNames(typeof(DataType));
            this.dgv_Main.AutoGenerateColumns = false;

            //列标题不应被选中高亮
            DataGridViewHelper.SetHeaderNoHighlight(this.dgv_Main);
            TotalGroups = GetAllGroups();
            TotalVariables = GetAllVariables();
            this.cmb_GroupName.SelectedIndexChanged += Cmb_GroupName_SelectedIndexChanged;
            if (TotalGroups.Count > 0)
            {
                foreach (var item in TotalGroups)
                {
                    this.cmb_GroupName.Items.Add(item.GroupName);
                }
                this.cmb_GroupName.SelectedIndex = 0;
            }

            // 通信组表为空时 SelectedIndex 不会变化，也必须刷新一次，否则表格一片空白
            RefreshVariable();
        }

        private void Cmb_GroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshVariable();
        }

        private bool IsVariableNameExits(string variableName)
        {
            return TotalVariables.FindAll(c => c.VarName == variableName).ToList().Count > 0;
        }

        #region 添加通信组
        private void btn_Add_Click(object sender, EventArgs e)
        {

            string varName = this.txt_VarName.Text.Trim();

            if (varName.Length == 0)
            {
                new FrmMsgBoxWithoutAck("变量名称不能为空！", "添加变量").Show();
                return;
            }

            if (IsVariableNameExits(varName))
            {
                new FrmMsgBoxWithoutAck("变量名称已经存在！", "添加变量").Show();
                return;
            }

            TotalVariables.Add(new Variable()
            {
                VarName = varName,
                Start = Convert.ToUInt16(this.num_Start.Value),
                OffsetOrLength = Convert.ToUInt16(this.num_OffsetOrLength.Value),
                DataType = this.cmb_DataType.Text.Trim(),
                GroupName = this.cmb_GroupName.Text.Trim(),
                PosAlarm = this.chk_PosAlarm.Checked,
                NegAlarm = this.chk_NegAlarm.Checked,
                Scale = Convert.ToSingle(this.num_Scale.Value),
                Offset = Convert.ToSingle(this.num_Offset.Value),
                Remark = this.txt_Remark.Text.Trim()
            });

            try
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(variablePath));
                MiniExcel.SaveAs(variablePath, TotalVariables, overwriteFile: true);

                new FrmMsgBoxWithoutAck("添加变量成功", "添加变量").Show();

                //刷新数据
                RefreshVariable();
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("添加变量失败: " + ex.Message, "添加变量").Show();

            }

        }
        #endregion
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        #region 无边框拖动

        private Point mPoint;
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }
        #endregion

        private void dgv_Main_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // 在行头区域内绘制行号（从 1 开始）
            Rectangle rowHeaderRect = new Rectangle(
                e.RowBounds.Left,
                e.RowBounds.Top,
                this.dgv_Main.RowHeadersWidth,
                e.RowBounds.Height);

            TextRenderer.DrawText(
                e.Graphics,
                (e.RowIndex + 1).ToString(),
                this.dgv_Main.RowHeadersDefaultCellStyle.Font ?? this.dgv_Main.Font,
                rowHeaderRect,
                this.dgv_Main.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }

        private void dgv_Main_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                object value = this.dgv_Main.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (e.ColumnIndex == 7 || e.ColumnIndex == 8)
                {
                    if (value != null)
                    {
                        e.Value = value.ToString() == "True" ? "启用" : "禁用";
                    }
                }
                else
                {
                    if (value == null || value.ToString().Length == 0)
                    {
                        e.Value = "--";
                    }
                }
            }
        }
        #region 删除通信组
        private void button3_Click(object sender, EventArgs e)
        {
            string variableName = this.txt_VarName.Text.Trim();

            if (!IsVariableNameExits(variableName))
            {
                new FrmMsgBoxWithoutAck("变量名称不存在！", "删除变量").Show();
                return;
            }

            TotalVariables.RemoveAll(c => c.VarName == variableName);

            try
            {
                MiniExcel.SaveAs(variablePath, TotalVariables, overwriteFile: true);

                //刷新数据
                RefreshVariable();
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("删除变量失败：" + ex.Message, "删除变量").Show();
            }
        }
        #endregion

        #region 修改通信组
        private void btn_Modify_Click(object sender, EventArgs e)
        {
            string variableName = this.txt_VarName.Text.Trim();

            if (!IsVariableNameExits(variableName))
            {
                new FrmMsgBoxWithoutAck("变量名称不存在！", "修改变量").Show();
                return;
            }

            var variable = TotalVariables.Find(c => c.VarName == variableName);

            variable.Start = Convert.ToUInt16(this.num_Start.Value);
            variable.OffsetOrLength = Convert.ToUInt16(this.num_OffsetOrLength.Value);
            variable.GroupName = this.cmb_GroupName.Text.Trim();
            variable.PosAlarm = this.chk_PosAlarm.Checked;
            variable.NegAlarm = this.chk_NegAlarm.Checked;
            variable.Scale = Convert.ToSingle(this.num_Scale.Value);
            variable.Offset = Convert.ToSingle(this.num_Offset.Value);
            variable.Remark = this.txt_Remark.Text.Trim();
            variable.DataType = this.cmb_DataType.Text.Trim();

            try
            {
                MiniExcel.SaveAs(variablePath, TotalVariables, overwriteFile: true);

                //刷新数据
                RefreshVariable();
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("修改变量失败：" + ex.Message, "修改变量").Show();
            }
        }
        #endregion

        private void dgv_Main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                UpdateVariable(TotalVariables[e.RowIndex]);
            }
        }
        private void UpdateVariable(Variable variable)
        {
            if (variable != null)
            {
                this.cmb_GroupName.Text = variable.GroupName;
                this.txt_VarName.Text = variable.VarName;
                this.num_Start.Text = variable.Start.ToString();
                this.num_OffsetOrLength.Text = variable.OffsetOrLength.ToString();
                this.cmb_DataType.Text = variable.DataType;
                this.chk_PosAlarm.Checked = variable.PosAlarm;
                this.chk_NegAlarm.Checked = variable.NegAlarm;
                this.num_Scale.Value = Convert.ToDecimal(variable.Scale);
                this.num_Offset.Value = Convert.ToDecimal(variable.Offset);
                this.txt_Remark.Text = variable.Remark;
            }
        }
    }
}
