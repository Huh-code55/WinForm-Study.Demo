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
using MiniExcelLibs;
using MTHModels;

namespace MTHProject
{
    public partial class FrmGroupConfig : Form
    {
        // 配置目录：固定到 bin\Debug\Config（将来打包成 EXE 后应改为程序自身目录）
        private static readonly string ConfigDir = @"D:\product\MTHProject\MTHProject\bin\Debug\Config";
        private string groupPath = Path.Combine(ConfigDir, "Group.xlsx");

        private List<Group> TotalGroups = new List<Group>();
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

        private void RefreshGroup()
        {
            if (TotalGroups != null)
            {
                this.dgv_Main.DataSource = null;
                this.dgv_Main.DataSource = TotalGroups;
            }
        }

        public FrmGroupConfig()
        {
            InitializeComponent();
            this.cmb_StoreArea.DataSource = new string[] { "输入线圈", "输出线圈", "输入寄存器", "输出寄存器" };
            this.dgv_Main.AutoGenerateColumns = false;

            //列标题不应被选中高亮
            DataGridViewHelper.SetHeaderNoHighlight(this.dgv_Main);

            TotalGroups = GetAllGroups();
            RefreshGroup();
        }

        private bool IsGroupNameExits(string groupName)
        {
            return TotalGroups.FindAll(c => c.GroupName == groupName).ToList().Count > 0;
        }

        #region 添加通信组
        private void btn_Add_Click(object sender, EventArgs e)
        {

            string groupName = this.txt_GroupName.Text.Trim();

            if (groupName.Length == 0)
            {
                new FrmMsgBoxWithoutAck("通信组名称不能为空！", "添加通信组").Show();
                return;
            }

            if (IsGroupNameExits(groupName))
            {
                new FrmMsgBoxWithoutAck("通信组名称已经存在！", "添加通信组").Show();
                return;
            }

            TotalGroups.Add(new Group()
            {
                GroupName = groupName,
                Start = Convert.ToUInt16(this.num_Start.Value),
                Length = Convert.ToUInt16(this.num_Length.Value),
                StoreArea = this.cmb_StoreArea.Text.Trim(),
                Remark = this.txt_Remark.Text.Trim()
            });

            try
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(groupPath));
                MiniExcel.SaveAs(groupPath, TotalGroups, overwriteFile: true);

                new FrmMsgBoxWithoutAck("添加通信组成功", "添加通信组").Show();

                //刷新数据
                RefreshGroup();
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("添加通信组失败: " + ex.Message, "添加通信组").Show();

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

                if (value == null || value.ToString().Length == 0)
                {
                    e.Value = "---";
                }
            }
        }
        #region 删除通信组
        private void button3_Click(object sender, EventArgs e)
        {
            string groupName = this.txt_GroupName.Text.Trim();

            if (!IsGroupNameExits(groupName))
            {
                new FrmMsgBoxWithoutAck("通信组名称不存在！", "删除通信组").Show();
                return;
            }

            TotalGroups.RemoveAll(c => c.GroupName == groupName);

            try
            {
                MiniExcel.SaveAs(groupPath, TotalGroups, overwriteFile: true);

                //刷新数据
                RefreshGroup();
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("删除通信组失败：" + ex.Message, "删除通信组").Show();
            }
        }
        #endregion

        #region 修改通信组
        private void btn_Modify_Click(object sender, EventArgs e)
        {
            string groupName = this.txt_GroupName.Text.Trim();

            if (!IsGroupNameExits(groupName))
            {
                new FrmMsgBoxWithoutAck("通信组名称不存在！", "修改通信组").Show();
                return;
            }

            var group = TotalGroups.Find(c => c.GroupName == groupName);

            group.Start = Convert.ToUInt16(this.num_Start.Value);
            group.Length = Convert.ToUInt16(this.num_Length.Value);
            group.StoreArea = this.cmb_StoreArea.Text.Trim();
            group.Remark = this.txt_Remark.Text.Trim();

            try
            {
                MiniExcel.SaveAs(groupPath, TotalGroups, overwriteFile: true);

                //刷新数据
                RefreshGroup();
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("修改通信组失败：" + ex.Message, "修改通信组").Show();
            }
        }
        #endregion

        private void dgv_Main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                UpdateGroup(TotalGroups[e.RowIndex]);
            }
        }
        private void UpdateGroup(Group group)
        {
            if (group != null)
            {
                this.txt_GroupName.Text = group.GroupName;
                this.num_Start.Text = group.Start.ToString();
                this.num_Length.Text = group.Length.ToString();
                this.cmb_StoreArea.Text = group.StoreArea;
                this.txt_Remark.Text = group.Remark;
            }
        }
    }
}
