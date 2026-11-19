using MTHBLL;
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

namespace MTHProject
{
    public partial class FrmUserManage : Form
    {
        public FrmUserManage()
        {
            InitializeComponent();
            this.dgv_UserManage.AutoGenerateColumns = false;

            UpdateData();
        }

        private SysAdminManage sysAdminManage = new SysAdminManage();
        private List<SysAdmin> sysAdmins = new List<SysAdmin>();
        private void UpdateData()
        {
            sysAdmins = sysAdminManage.QuerySysAdmins();
            if (sysAdmins.Count > 0)
            {
                this.dgv_UserManage.DataSource = null;
                this.dgv_UserManage.DataSource = sysAdmins;
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            //数据验证
            if (this.txt_LoginName.Text.Length == 0)
            {
                new FrmMsgBoxWithoutAck("用户名不能为空！", "添加用户").Show();
                return;
            }

            if (this.txt_LoginPwd.Text.Length == 0)
            {
                new FrmMsgBoxWithoutAck("用户密码不能为空！", "添加用户").Show();
                return;
            }
            if (this.txt_LoginPwd2.Text.Length == 0)
            {
                new FrmMsgBoxWithoutAck("确认密码不能为空！", "添加用户").Show();
                return;
            }

            if (this.txt_LoginPwd.Text.Trim() != this.txt_LoginPwd2.Text.Trim())
            {
                new FrmMsgBoxWithoutAck("两次输入密码不一致！", "添加用户").Show();
                return;
            }

            if (sysAdmins.Where(c => c.LoginName == this.txt_LoginName.Text.Trim()).ToList().Count > 0)
            {
                new FrmMsgBoxWithoutAck("该用户名已经存在！", "添加用户").Show();
                return;
            }

            //添加用户
            SysAdmin sysAdmin = new SysAdmin()
            {
                LoginName = this.txt_LoginName.Text.Trim(),
                LoginPwd = this.txt_LoginPwd.Text.Trim(),
                ParamSet = this.chk_ParamSet.Checked,
                Recipe = this.chk_Recipe.Checked,
                HistoryLog = this.chk_HistoryLog.Checked,
                HistoryTrend = this.chk_HistoryTrend.Checked,
                UserManage = this.chk_UserManage.Checked
            };

            if (sysAdminManage.AddSysAdmin(sysAdmin))
            {
                UpdateData();
            }
            else
            {
                new FrmMsgBoxWithoutAck("添加用户失败，请检查！", "添加用户").Show();
            }
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            //数据验证
            if (this.txt_LoginName.Text.Length == 0)
            {
                new FrmMsgBoxWithoutAck("用户名不能为空！", "修改用户").Show();
                return;
            }

            if (this.txt_LoginPwd.Text.Length == 0)
            {
                new FrmMsgBoxWithoutAck("用户密码不能为空！", "修改用户").Show();
                return;
            }
            if (this.txt_LoginPwd2.Text.Length == 0)
            {
                new FrmMsgBoxWithoutAck("确认密码不能为空！", "修改用户").Show();
                return;
            }

            if (this.txt_LoginPwd.Text.Trim() != this.txt_LoginPwd2.Text.Trim())
            {
                new FrmMsgBoxWithoutAck("两次输入密码不一致！", "修改用户").Show();
                return;
            }

            //判断是否修改用户名称
            if (sysAdmins[this.dgv_UserManage.SelectedRows[0].Index].LoginName != this.txt_LoginName.Text.Trim())
            {
                if (sysAdmins.Where(c => c.LoginName == this.txt_LoginName.Text.Trim()).ToList().Count > 0)
                {
                    new FrmMsgBoxWithoutAck("该用户名已经存在！", "修改用户").Show();
                    return;
                }
            }

            SysAdmin sysAdmin = new SysAdmin()
            {
                LoginId = sysAdmins[this.dgv_UserManage.SelectedRows[0].Index].LoginId,
                LoginName = this.txt_LoginName.Text.Trim(),
                LoginPwd = this.txt_LoginPwd.Text.Trim(),
                ParamSet = this.chk_ParamSet.Checked,
                Recipe = this.chk_Recipe.Checked,
                HistoryLog = this.chk_HistoryLog.Checked,
                HistoryTrend = this.chk_HistoryTrend.Checked,
                UserManage = this.chk_UserManage.Checked
            };

            if (sysAdminManage.ModifySysAdmin(sysAdmin))
            {
                UpdateData();
            }
            else
            {
                new FrmMsgBoxWithoutAck("修改用户失败，请检查！", "修改用户").Show();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (sysAdminManage.DeleteSysAdmin(sysAdmins[this.dgv_UserManage.SelectedRows[0].Index].LoginId))
            {
                UpdateData();
            }
            else
            {
                new FrmMsgBoxWithoutAck("删除用户失败，请检查！", "删除用户").Show();
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            this.txt_LoginName.Clear();
            this.txt_LoginPwd.Clear();
            this.txt_LoginPwd2.Clear();
            SetChecked(false);
        }

        private void SetChecked(bool value)
        {
            this.chk_ParamSet.Checked = value;
            this.chk_Recipe.Checked = value;
            this.chk_HistoryLog.Checked = value;
            this.chk_HistoryTrend.Checked = value;
            this.chk_UserManage.Checked = value;
        }

        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            SetChecked(!this.chk_ParamSet.Checked);
        }

        private void dgv_UserManage_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint(sender as DataGridView, e);
        }

        private void dgv_UserManage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                UpdateInfo(sysAdmins[e.RowIndex]);
            }
        }

        private void UpdateInfo(SysAdmin sysAdmin)
        {
            if (sysAdmin != null)
            {
                this.txt_LoginName.Text = sysAdmin.LoginName;
                this.txt_LoginPwd.Text = sysAdmin.LoginPwd;
                this.txt_LoginPwd2.Text = sysAdmin.LoginPwd;
                this.chk_ParamSet.Checked = sysAdmin.ParamSet;
                this.chk_Recipe.Checked = sysAdmin.Recipe;
                this.chk_HistoryLog.Checked = sysAdmin.HistoryLog;
                this.chk_HistoryTrend.Checked = sysAdmin.HistoryTrend;
                this.chk_UserManage.Checked = sysAdmin.UserManage;
            }
        }

        private void dgv_UserManage_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 2)
            {
                object value = this.dgv_UserManage.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (value != null)
                {
                    if (value.ToString().ToLower() == "true")
                    {
                        e.Value = "启用";
                    }
                    else
                    {
                        e.Value = "禁用";
                    }
                }
            }
        }
    }
}
