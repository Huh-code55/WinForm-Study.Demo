namespace MTHProject
{
    partial class FrmMain
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
            this.TopPanel = new System.Windows.Forms.Panel();
            this.naviButton11 = new MTHControlLib.NaviButton();
            this.naviButton9 = new MTHControlLib.NaviButton();
            this.naviButton8 = new MTHControlLib.NaviButton();
            this.naviButton3 = new MTHControlLib.NaviButton();
            this.naviButton2 = new MTHControlLib.NaviButton();
            this.navi_Monitor = new MTHControlLib.NaviButton();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.lbl_TitleName = new System.Windows.Forms.Label();
            this.MiddlePanel = new System.Windows.Forms.Panel();
            this.led_CommState = new SeeSharpTools.JY.GUI.LED();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.AlarmPanel = new System.Windows.Forms.Panel();
            this.scrollingAlarm = new SeeSharpTools.JY.GUI.ScrollingText();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.btn_Right = new System.Windows.Forms.Button();
            this.btn_Left = new System.Windows.Forms.Button();
            this.lbl_CurrentTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_User = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.CorePanel = new MTHControlLib.PanelEx();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.TopPanel.SuspendLayout();
            this.MiddlePanel.SuspendLayout();
            this.AlarmPanel.SuspendLayout();
            this.CorePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.Transparent;
            this.TopPanel.Controls.Add(this.naviButton11);
            this.TopPanel.Controls.Add(this.naviButton9);
            this.TopPanel.Controls.Add(this.naviButton8);
            this.TopPanel.Controls.Add(this.naviButton3);
            this.TopPanel.Controls.Add(this.naviButton2);
            this.TopPanel.Controls.Add(this.navi_Monitor);
            this.TopPanel.Controls.Add(this.btn_Exit);
            this.TopPanel.Controls.Add(this.lbl_TitleName);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(2037, 133);
            this.TopPanel.TabIndex = 0;
            // 
            // naviButton11
            // 
            this.naviButton11.IsSelected = false;
            this.naviButton11.Location = new System.Drawing.Point(1693, 50);
            this.naviButton11.Name = "naviButton11";
            this.naviButton11.Size = new System.Drawing.Size(129, 43);
            this.naviButton11.TabIndex = 4;
            this.naviButton11.TitleName = "用户管理";
            this.naviButton11.Click += new System.EventHandler(this.CommonNaviButton_Click);
            // 
            // naviButton9
            // 
            this.naviButton9.IsSelected = false;
            this.naviButton9.Location = new System.Drawing.Point(1453, 50);
            this.naviButton9.Name = "naviButton9";
            this.naviButton9.Size = new System.Drawing.Size(129, 43);
            this.naviButton9.TabIndex = 3;
            this.naviButton9.TitleName = "历史趋势";
            this.naviButton9.Click += new System.EventHandler(this.CommonNaviButton_Click);
            // 
            // naviButton8
            // 
            this.naviButton8.IsSelected = false;
            this.naviButton8.Location = new System.Drawing.Point(1204, 50);
            this.naviButton8.Name = "naviButton8";
            this.naviButton8.Size = new System.Drawing.Size(129, 43);
            this.naviButton8.TabIndex = 2;
            this.naviButton8.TitleName = "报警追溯";
            this.naviButton8.Click += new System.EventHandler(this.CommonNaviButton_Click);
            // 
            // naviButton3
            // 
            this.naviButton3.IsSelected = false;
            this.naviButton3.Location = new System.Drawing.Point(457, 50);
            this.naviButton3.Name = "naviButton3";
            this.naviButton3.Size = new System.Drawing.Size(129, 43);
            this.naviButton3.TabIndex = 4;
            this.naviButton3.TitleName = "配方管理";
            this.naviButton3.Click += new System.EventHandler(this.CommonNaviButton_Click);
            // 
            // naviButton2
            // 
            this.naviButton2.IsSelected = false;
            this.naviButton2.Location = new System.Drawing.Point(257, 48);
            this.naviButton2.Name = "naviButton2";
            this.naviButton2.Size = new System.Drawing.Size(129, 43);
            this.naviButton2.TabIndex = 3;
            this.naviButton2.TitleName = "参数设置";
            this.naviButton2.Click += new System.EventHandler(this.CommonNaviButton_Click);
            // 
            // navi_Monitor
            // 
            this.navi_Monitor.IsSelected = false;
            this.navi_Monitor.Location = new System.Drawing.Point(37, 48);
            this.navi_Monitor.Name = "navi_Monitor";
            this.navi_Monitor.Size = new System.Drawing.Size(129, 43);
            this.navi_Monitor.TabIndex = 2;
            this.navi_Monitor.TitleName = "集中监控";
            this.navi_Monitor.Click += new System.EventHandler(this.CommonNaviButton_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Exit.Location = new System.Drawing.Point(1960, 62);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(75, 23);
            this.btn_Exit.TabIndex = 1;
            this.btn_Exit.Text = "退出";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // lbl_TitleName
            // 
            this.lbl_TitleName.AutoSize = true;
            this.lbl_TitleName.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_TitleName.Location = new System.Drawing.Point(805, 60);
            this.lbl_TitleName.Name = "lbl_TitleName";
            this.lbl_TitleName.Size = new System.Drawing.Size(192, 25);
            this.lbl_TitleName.TabIndex = 0;
            this.lbl_TitleName.Text = "多温湿度采集监控系统";
            // 
            // MiddlePanel
            // 
            this.MiddlePanel.BackColor = System.Drawing.Color.Transparent;
            this.MiddlePanel.Controls.Add(this.led_CommState);
            this.MiddlePanel.Controls.Add(this.flowLayoutPanel1);
            this.MiddlePanel.Controls.Add(this.label5);
            this.MiddlePanel.Controls.Add(this.AlarmPanel);
            this.MiddlePanel.Controls.Add(this.lbl_Title);
            this.MiddlePanel.Controls.Add(this.btn_Right);
            this.MiddlePanel.Controls.Add(this.btn_Left);
            this.MiddlePanel.Controls.Add(this.lbl_CurrentTime);
            this.MiddlePanel.Controls.Add(this.label2);
            this.MiddlePanel.Controls.Add(this.label_User);
            this.MiddlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MiddlePanel.Location = new System.Drawing.Point(0, 133);
            this.MiddlePanel.Name = "MiddlePanel";
            this.MiddlePanel.Size = new System.Drawing.Size(2037, 65);
            this.MiddlePanel.TabIndex = 1;
            // 
            // led_CommState
            // 
            this.led_CommState.BlinkColor = System.Drawing.Color.Lime;
            this.led_CommState.BlinkInterval = 1000;
            this.led_CommState.BlinkOn = false;
            this.led_CommState.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.led_CommState.Interacton = SeeSharpTools.JY.GUI.LED.InteractionStyle.Indicator;
            this.led_CommState.Location = new System.Drawing.Point(1857, 19);
            this.led_CommState.Name = "led_CommState";
            this.led_CommState.OffColor = System.Drawing.Color.Red;
            this.led_CommState.OnColor = System.Drawing.Color.Lime;
            this.led_CommState.Size = new System.Drawing.Size(28, 28);
            this.led_CommState.Style = SeeSharpTools.JY.GUI.LED.LedStyle.Circular;
            this.led_CommState.TabIndex = 8;
            this.led_CommState.Value = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1124, 15);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(9, 9);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(1749, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 27);
            this.label5.TabIndex = 7;
            this.label5.Text = "通信状态";
            // 
            // AlarmPanel
            // 
            this.AlarmPanel.Controls.Add(this.scrollingAlarm);
            this.AlarmPanel.Location = new System.Drawing.Point(1407, 6);
            this.AlarmPanel.Name = "AlarmPanel";
            this.AlarmPanel.Size = new System.Drawing.Size(289, 53);
            this.AlarmPanel.TabIndex = 6;
            // 
            // scrollingAlarm
            // 
            this.scrollingAlarm.BorderColor = System.Drawing.Color.Black;
            this.scrollingAlarm.BorderVisible = true;
            this.scrollingAlarm.Cursor = System.Windows.Forms.Cursors.Default;
            this.scrollingAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollingAlarm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scrollingAlarm.Location = new System.Drawing.Point(0, 0);
            this.scrollingAlarm.Name = "scrollingAlarm";
            this.scrollingAlarm.ScrollDirection = SeeSharpTools.JY.GUI.ScrollingText.TextDirection.RightToLeft;
            this.scrollingAlarm.ScrollSpeed = 25;
            this.scrollingAlarm.Size = new System.Drawing.Size(289, 53);
            this.scrollingAlarm.TabIndex = 0;
            this.scrollingAlarm.Text = "当前系统无报警";
            this.scrollingAlarm.VerticleAligment = SeeSharpTools.JY.GUI.ScrollingText.TextVerticalAlignment.Center;
            // 
            // lbl_Title
            // 
            this.lbl_Title.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Title.Location = new System.Drawing.Point(1015, 22);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(118, 25);
            this.lbl_Title.TabIndex = 2;
            this.lbl_Title.Text = "集中监控";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Right
            // 
            this.btn_Right.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Right.Location = new System.Drawing.Point(1204, 24);
            this.btn_Right.Name = "btn_Right";
            this.btn_Right.Size = new System.Drawing.Size(75, 23);
            this.btn_Right.TabIndex = 5;
            this.btn_Right.Text = "》";
            this.btn_Right.UseVisualStyleBackColor = true;
            this.btn_Right.Click += new System.EventHandler(this.btn_Right_Click);
            // 
            // btn_Left
            // 
            this.btn_Left.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Left.Location = new System.Drawing.Point(876, 24);
            this.btn_Left.Name = "btn_Left";
            this.btn_Left.Size = new System.Drawing.Size(75, 23);
            this.btn_Left.TabIndex = 2;
            this.btn_Left.Text = "《";
            this.btn_Left.UseVisualStyleBackColor = true;
            this.btn_Left.Click += new System.EventHandler(this.btn_Left_Click);
            // 
            // lbl_CurrentTime
            // 
            this.lbl_CurrentTime.AutoSize = true;
            this.lbl_CurrentTime.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.lbl_CurrentTime.Location = new System.Drawing.Point(452, 18);
            this.lbl_CurrentTime.Name = "lbl_CurrentTime";
            this.lbl_CurrentTime.Size = new System.Drawing.Size(156, 27);
            this.lbl_CurrentTime.TabIndex = 4;
            this.lbl_CurrentTime.Text = "2026年11月1日";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(149, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "欢迎登录！现在时间是";
            // 
            // label_User
            // 
            this.label_User.AutoSize = true;
            this.label_User.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label_User.Location = new System.Drawing.Point(32, 16);
            this.label_User.Name = "label_User";
            this.label_User.Size = new System.Drawing.Size(72, 27);
            this.label_User.TabIndex = 2;
            this.label_User.Text = "管理员";
            // 
            // CorePanel
            // 
            this.CorePanel.BackColor = System.Drawing.Color.Transparent;
            this.CorePanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(79)))), ((int)(((byte)(150)))));
            this.CorePanel.BorderWidth = 10;
            this.CorePanel.BottomGap = 10;
            this.CorePanel.Controls.Add(this.MainPanel);
            this.CorePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CorePanel.LeftGap = 20;
            this.CorePanel.Location = new System.Drawing.Point(0, 198);
            this.CorePanel.Name = "CorePanel";
            this.CorePanel.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.CorePanel.RightGap = 20;
            this.CorePanel.Size = new System.Drawing.Size(2037, 918);
            this.CorePanel.TabIndex = 2;
            this.CorePanel.TopGap = 10;
            // 
            // MainPanel
            // 
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(20, 10);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1997, 898);
            this.MainPanel.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2037, 1116);
            this.Controls.Add(this.CorePanel);
            this.Controls.Add(this.MiddlePanel);
            this.Controls.Add(this.TopPanel);
            this.Name = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.MiddlePanel.ResumeLayout(false);
            this.MiddlePanel.PerformLayout();
            this.AlarmPanel.ResumeLayout(false);
            this.CorePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel MiddlePanel;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Label lbl_TitleName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_User;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Button btn_Right;
        private System.Windows.Forms.Button btn_Left;
        private System.Windows.Forms.Label lbl_CurrentTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel AlarmPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private MTHControlLib.NaviButton navi_Monitor;
        private MTHControlLib.NaviButton naviButton2;
        private MTHControlLib.NaviButton naviButton3;
        private MTHControlLib.NaviButton naviButton11;
        private MTHControlLib.NaviButton naviButton9;
        private MTHControlLib.NaviButton naviButton8;
        private MTHControlLib.PanelEx CorePanel;
        private System.Windows.Forms.Panel MainPanel;
        private SeeSharpTools.JY.GUI.ScrollingText scrollingAlarm;
        private SeeSharpTools.JY.GUI.LED led_CommState;
    }
}
