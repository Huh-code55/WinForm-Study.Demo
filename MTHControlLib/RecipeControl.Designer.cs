namespace MTHControlLib
{
    partial class RecipeControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.title1 = new MTHControlLib.Title();
            this.textSetEx1 = new MTHControlLib.TextSetEx();
            this.textSetEx2 = new MTHControlLib.TextSetEx();
            this.textSetEx3 = new MTHControlLib.TextSetEx();
            this.textSetEx4 = new MTHControlLib.TextSetEx();
            this.checkBoxEx1 = new MTHControlLib.CheckBoxEx();
            this.checkBoxEx2 = new MTHControlLib.CheckBoxEx();
            this.SuspendLayout();
            // 
            // title1
            // 
            this.title1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title1.Location = new System.Drawing.Point(16, 15);
            this.title1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(89, 31);
            this.title1.TabIndex = 0;
            this.title1.TitleName = "1#站点";
            // 
            // textSetEx1
            // 
            this.textSetEx1.CurrentValue = 0F;
            this.textSetEx1.Font = new System.Drawing.Font("微软雅黑", 8.25F);
            this.textSetEx1.Location = new System.Drawing.Point(16, 55);
            this.textSetEx1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.textSetEx1.Name = "textSetEx1";
            this.textSetEx1.Size = new System.Drawing.Size(293, 40);
            this.textSetEx1.TabIndex = 1;
            this.textSetEx1.TitleName = "1#站点温度高限";
            this.textSetEx1.Unit = "℃";
            // 
            // textSetEx2
            // 
            this.textSetEx2.CurrentValue = 0F;
            this.textSetEx2.Font = new System.Drawing.Font("微软雅黑", 8.25F);
            this.textSetEx2.Location = new System.Drawing.Point(16, 103);
            this.textSetEx2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.textSetEx2.Name = "textSetEx2";
            this.textSetEx2.Size = new System.Drawing.Size(293, 40);
            this.textSetEx2.TabIndex = 2;
            this.textSetEx2.TitleName = "1#站点温度低限";
            this.textSetEx2.Unit = "℃";
            // 
            // textSetEx3
            // 
            this.textSetEx3.CurrentValue = 0F;
            this.textSetEx3.Font = new System.Drawing.Font("微软雅黑", 8.25F);
            this.textSetEx3.Location = new System.Drawing.Point(16, 151);
            this.textSetEx3.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.textSetEx3.Name = "textSetEx3";
            this.textSetEx3.Size = new System.Drawing.Size(293, 40);
            this.textSetEx3.TabIndex = 3;
            this.textSetEx3.TitleName = "1#站点湿度高限";
            this.textSetEx3.Unit = "%";
            // 
            // textSetEx4
            // 
            this.textSetEx4.CurrentValue = 0F;
            this.textSetEx4.Font = new System.Drawing.Font("微软雅黑", 8.25F);
            this.textSetEx4.Location = new System.Drawing.Point(16, 199);
            this.textSetEx4.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.textSetEx4.Name = "textSetEx4";
            this.textSetEx4.Size = new System.Drawing.Size(293, 40);
            this.textSetEx4.TabIndex = 4;
            this.textSetEx4.TitleName = "1#站点湿度低限";
            this.textSetEx4.Unit = "%";
            // 
            // checkBoxEx1
            // 
            this.checkBoxEx1.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx1.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx1.DefaultCheckButtonWidth = 20;
            this.checkBoxEx1.Location = new System.Drawing.Point(28, 246);
            this.checkBoxEx1.Name = "checkBoxEx1";
            this.checkBoxEx1.Size = new System.Drawing.Size(147, 19);
            this.checkBoxEx1.TabIndex = 5;
            this.checkBoxEx1.Text = "温度报警启用";
            this.checkBoxEx1.UseVisualStyleBackColor = true;
            // 
            // checkBoxEx2
            // 
            this.checkBoxEx2.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx2.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx2.DefaultCheckButtonWidth = 20;
            this.checkBoxEx2.Location = new System.Drawing.Point(187, 246);
            this.checkBoxEx2.Name = "checkBoxEx2";
            this.checkBoxEx2.Size = new System.Drawing.Size(149, 19);
            this.checkBoxEx2.TabIndex = 6;
            this.checkBoxEx2.Text = "湿度报警启用";
            this.checkBoxEx2.UseVisualStyleBackColor = true;
            // 
            // RecipeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxEx2);
            this.Controls.Add(this.checkBoxEx1);
            this.Controls.Add(this.textSetEx4);
            this.Controls.Add(this.textSetEx3);
            this.Controls.Add(this.textSetEx2);
            this.Controls.Add(this.textSetEx1);
            this.Controls.Add(this.title1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RecipeControl";
            this.Size = new System.Drawing.Size(339, 293);
            this.ResumeLayout(false);

        }

        #endregion

        private Title title1;
        private TextSetEx textSetEx1;
        private TextSetEx textSetEx2;
        private TextSetEx textSetEx3;
        private TextSetEx textSetEx4;
        private CheckBoxEx checkBoxEx1;
        private CheckBoxEx checkBoxEx2;
    }
}
