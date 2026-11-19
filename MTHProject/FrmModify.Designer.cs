namespace MTHProject
{
    partial class FrmModify
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelEx1 = new MTHControlLib.PanelEx();
            this.txt_SetValue = new System.Windows.Forms.TextBox();
            this.lbl_CurrentValue = new MTHControlLib.Title();
            this.lbl_Title = new MTHControlLib.Title();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Sure = new System.Windows.Forms.Button();
            this.title4 = new MTHControlLib.Title();
            this.title3 = new MTHControlLib.Title();
            this.title2 = new MTHControlLib.Title();
            this.button4 = new System.Windows.Forms.Button();
            this.title1 = new MTHControlLib.Title();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.BackColor = System.Drawing.Color.Transparent;
            this.panelEx1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(79)))), ((int)(((byte)(150)))));
            this.panelEx1.BorderWidth = 2;
            this.panelEx1.BottomGap = 1;
            this.panelEx1.Controls.Add(this.txt_SetValue);
            this.panelEx1.Controls.Add(this.lbl_CurrentValue);
            this.panelEx1.Controls.Add(this.lbl_Title);
            this.panelEx1.Controls.Add(this.btn_Cancel);
            this.panelEx1.Controls.Add(this.btn_Sure);
            this.panelEx1.Controls.Add(this.title4);
            this.panelEx1.Controls.Add(this.title3);
            this.panelEx1.Controls.Add(this.title2);
            this.panelEx1.Controls.Add(this.button4);
            this.panelEx1.Controls.Add(this.title1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.LeftGap = 1;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.RightGap = 1;
            this.panelEx1.Size = new System.Drawing.Size(573, 365);
            this.panelEx1.TabIndex = 0;
            this.panelEx1.TopGap = 1;
            this.panelEx1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.panelEx1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // txt_SetValue
            // 
            this.txt_SetValue.Location = new System.Drawing.Point(248, 214);
            this.txt_SetValue.Name = "txt_SetValue";
            this.txt_SetValue.Size = new System.Drawing.Size(261, 34);
            this.txt_SetValue.TabIndex = 18;
            this.txt_SetValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_SetValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SetValue_KeyDown);
            // 
            // lbl_CurrentValue
            // 
            this.lbl_CurrentValue.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_CurrentValue.Location = new System.Drawing.Point(248, 146);
            this.lbl_CurrentValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbl_CurrentValue.Name = "lbl_CurrentValue";
            this.lbl_CurrentValue.Size = new System.Drawing.Size(261, 31);
            this.lbl_CurrentValue.TabIndex = 17;
            this.lbl_CurrentValue.TitleName = "0.0";
            // 
            // lbl_Title
            // 
            this.lbl_Title.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Title.Location = new System.Drawing.Point(248, 78);
            this.lbl_Title.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(261, 31);
            this.lbl_Title.TabIndex = 16;
            this.lbl_Title.TitleName = "1#站点温度高限";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_Cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancel.Location = new System.Drawing.Point(331, 292);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(85, 46);
            this.btn_Cancel.TabIndex = 15;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Sure
            // 
            this.btn_Sure.BackColor = System.Drawing.Color.Transparent;
            this.btn_Sure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Sure.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_Sure.ForeColor = System.Drawing.Color.Black;
            this.btn_Sure.Location = new System.Drawing.Point(162, 292);
            this.btn_Sure.Name = "btn_Sure";
            this.btn_Sure.Size = new System.Drawing.Size(85, 46);
            this.btn_Sure.TabIndex = 14;
            this.btn_Sure.Text = "确定";
            this.btn_Sure.UseVisualStyleBackColor = false;
            this.btn_Sure.Click += new System.EventHandler(this.btn_Sure_Click);
            // 
            // title4
            // 
            this.title4.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title4.Location = new System.Drawing.Point(81, 214);
            this.title4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title4.Name = "title4";
            this.title4.Size = new System.Drawing.Size(103, 31);
            this.title4.TabIndex = 12;
            this.title4.TitleName = "修改值：";
            // 
            // title3
            // 
            this.title3.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title3.Location = new System.Drawing.Point(81, 146);
            this.title3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title3.Name = "title3";
            this.title3.Size = new System.Drawing.Size(103, 31);
            this.title3.TabIndex = 11;
            this.title3.TitleName = "当前值：";
            // 
            // title2
            // 
            this.title2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title2.Location = new System.Drawing.Point(81, 78);
            this.title2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title2.Name = "title2";
            this.title2.Size = new System.Drawing.Size(103, 31);
            this.title2.TabIndex = 10;
            this.title2.TitleName = "参数名称：";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(524, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(46, 40);
            this.button4.TabIndex = 9;
            this.button4.Text = "X";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // title1
            // 
            this.title1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title1.Location = new System.Drawing.Point(28, 12);
            this.title1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(89, 31);
            this.title1.TabIndex = 1;
            this.title1.TitleName = "参数修改";
            // 
            // FrmModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 365);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmModify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参数修改";
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MTHControlLib.PanelEx panelEx1;
        private MTHControlLib.Title title1;
        private MTHControlLib.Title title4;
        private MTHControlLib.Title title3;
        private MTHControlLib.Title title2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btn_Sure;
        private MTHControlLib.Title lbl_CurrentValue;
        private MTHControlLib.Title lbl_Title;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox txt_SetValue;
    }
}