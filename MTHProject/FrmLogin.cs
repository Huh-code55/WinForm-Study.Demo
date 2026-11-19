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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private SysAdminManage sysAdminManage = new SysAdminManage();
        private void btn_Login_Click(object sender, EventArgs e)
        {
            //验证数据
            if (this.txt_LoginName.Text.Trim().Length == 0)
            {
                new FrmMsgBoxWithoutAck("请填写登录用户名！", "登录提示").ShowDialog();
                this.txt_LoginName.Focus();
                return;
            }

            if (this.txt_Pwd.Text.Trim().Length == 0)
            {
                new FrmMsgBoxWithoutAck("请填写登录用户密码！", "登录提示").ShowDialog();
                this.txt_Pwd.Focus();
                return;
            }

            //封装对象
            SysAdmin sysAdmin = new SysAdmin()
            {
                LoginName = this.txt_LoginName.Text.Trim(),
                LoginPwd = this.txt_Pwd.Text.Trim()
            };

            sysAdmin = sysAdminManage.AdminLogin(sysAdmin);

            if (sysAdmin == null)
            {
                new FrmMsgBoxWithoutAck("用户名或密码不正确！", "登录提示").ShowDialog();
                this.txt_LoginName.Focus();
                return;
            }
            else
            {
                this.DialogResult = DialogResult.OK;

                //存储登录用户信息
                CommonMethods.CurrentAdmin = sysAdmin;
            }
        }

        private void txt_LoginName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btn_Login_Click(null, null);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
