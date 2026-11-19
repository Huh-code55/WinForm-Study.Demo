namespace MTHProject
{
    partial class FrmMonitor
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
            SeeSharpTools.JY.GUI.StripChartXSeries stripChartXSeries1 = new SeeSharpTools.JY.GUI.StripChartXSeries();
            this.panelEnhanced1 = new MTHControlLib.PanelEnhanced();
            this.checkBoxEx11 = new MTHControlLib.CheckBoxEx();
            this.lst_Info = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkBoxEx12 = new MTHControlLib.CheckBoxEx();
            this.mthControl2 = new MTHControlLib.MTHControl();
            this.checkBoxEx7 = new MTHControlLib.CheckBoxEx();
            this.checkBoxEx9 = new MTHControlLib.CheckBoxEx();
            this.checkBoxEx8 = new MTHControlLib.CheckBoxEx();
            this.mthControl3 = new MTHControlLib.MTHControl();
            this.checkBoxEx3 = new MTHControlLib.CheckBoxEx();
            this.checkBoxEx10 = new MTHControlLib.CheckBoxEx();
            this.checkBoxEx4 = new MTHControlLib.CheckBoxEx();
            this.MainPanel = new MTHControlLib.MTHControl();
            this.checkBoxEx5 = new MTHControlLib.CheckBoxEx();
            this.title1 = new MTHControlLib.Title();
            this.chart_ActualTrend = new SeeSharpTools.JY.GUI.StripChartX();
            this.chk_Temp1 = new MTHControlLib.CheckBoxEx();
            this.checkBoxEx6 = new MTHControlLib.CheckBoxEx();
            this.title2 = new MTHControlLib.Title();
            this.mthControl4 = new MTHControlLib.MTHControl();
            this.chk_Humidity1 = new MTHControlLib.CheckBoxEx();
            this.mthControl6 = new MTHControlLib.MTHControl();
            this.mthControl5 = new MTHControlLib.MTHControl();
            this.panelEnhanced1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEnhanced1
            // 
            this.panelEnhanced1.BackgroundImage = global::MTHProject.Properties.Resources.backimage;
            this.panelEnhanced1.Controls.Add(this.checkBoxEx11);
            this.panelEnhanced1.Controls.Add(this.lst_Info);
            this.panelEnhanced1.Controls.Add(this.checkBoxEx12);
            this.panelEnhanced1.Controls.Add(this.mthControl2);
            this.panelEnhanced1.Controls.Add(this.checkBoxEx7);
            this.panelEnhanced1.Controls.Add(this.checkBoxEx9);
            this.panelEnhanced1.Controls.Add(this.checkBoxEx8);
            this.panelEnhanced1.Controls.Add(this.mthControl3);
            this.panelEnhanced1.Controls.Add(this.checkBoxEx3);
            this.panelEnhanced1.Controls.Add(this.checkBoxEx10);
            this.panelEnhanced1.Controls.Add(this.checkBoxEx4);
            this.panelEnhanced1.Controls.Add(this.MainPanel);
            this.panelEnhanced1.Controls.Add(this.checkBoxEx5);
            this.panelEnhanced1.Controls.Add(this.title1);
            this.panelEnhanced1.Controls.Add(this.chart_ActualTrend);
            this.panelEnhanced1.Controls.Add(this.chk_Temp1);
            this.panelEnhanced1.Controls.Add(this.checkBoxEx6);
            this.panelEnhanced1.Controls.Add(this.title2);
            this.panelEnhanced1.Controls.Add(this.mthControl4);
            this.panelEnhanced1.Controls.Add(this.chk_Humidity1);
            this.panelEnhanced1.Controls.Add(this.mthControl6);
            this.panelEnhanced1.Controls.Add(this.mthControl5);
            this.panelEnhanced1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEnhanced1.Location = new System.Drawing.Point(0, 0);
            this.panelEnhanced1.Name = "panelEnhanced1";
            this.panelEnhanced1.Size = new System.Drawing.Size(1660, 945);
            this.panelEnhanced1.TabIndex = 22;
            // 
            // checkBoxEx11
            // 
            this.checkBoxEx11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxEx11.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx11.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx11.DefaultCheckButtonWidth = 20;
            this.checkBoxEx11.Location = new System.Drawing.Point(1501, 366);
            this.checkBoxEx11.Name = "checkBoxEx11";
            this.checkBoxEx11.Size = new System.Drawing.Size(153, 19);
            this.checkBoxEx11.TabIndex = 20;
            this.checkBoxEx11.Tag = "11";
            this.checkBoxEx11.Text = "6#站点的湿度";
            this.checkBoxEx11.UseVisualStyleBackColor = true;
            this.checkBoxEx11.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // lst_Info
            // 
            this.lst_Info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst_Info.BackColor = System.Drawing.SystemColors.Window;
            this.lst_Info.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lst_Info.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lst_Info.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lst_Info.HideSelection = false;
            this.lst_Info.Location = new System.Drawing.Point(978, 450);
            this.lst_Info.Name = "lst_Info";
            this.lst_Info.ShowItemToolTips = true;
            this.lst_Info.Size = new System.Drawing.Size(600, 462);
            this.lst_Info.TabIndex = 21;
            this.lst_Info.UseCompatibleStateImageBehavior = false;
            this.lst_Info.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "日志时间";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "日志内容";
            this.columnHeader2.Width = 200;
            // 
            // checkBoxEx12
            // 
            this.checkBoxEx12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxEx12.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx12.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx12.DefaultCheckButtonWidth = 20;
            this.checkBoxEx12.Location = new System.Drawing.Point(1325, 366);
            this.checkBoxEx12.Name = "checkBoxEx12";
            this.checkBoxEx12.Size = new System.Drawing.Size(157, 19);
            this.checkBoxEx12.TabIndex = 19;
            this.checkBoxEx12.Tag = "10";
            this.checkBoxEx12.Text = "6#站点的温度";
            this.checkBoxEx12.UseVisualStyleBackColor = true;
            this.checkBoxEx12.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // mthControl2
            // 
            this.mthControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.mthControl2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mthControl2.Humidity = "0.0";
            this.mthControl2.HumidityVarName = "模块2湿度";
            this.mthControl2.Location = new System.Drawing.Point(402, 5);
            this.mthControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mthControl2.ModuleError = false;
            this.mthControl2.Name = "mthControl2";
            this.mthControl2.Size = new System.Drawing.Size(390, 180);
            this.mthControl2.StateVarName = "模块2异常";
            this.mthControl2.TabIndex = 1;
            this.mthControl2.Temp = "0.0";
            this.mthControl2.TempVarName = "模块2温度";
            this.mthControl2.Title = "2#站点";
            // 
            // checkBoxEx7
            // 
            this.checkBoxEx7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxEx7.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx7.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx7.DefaultCheckButtonWidth = 20;
            this.checkBoxEx7.Location = new System.Drawing.Point(1501, 330);
            this.checkBoxEx7.Name = "checkBoxEx7";
            this.checkBoxEx7.Size = new System.Drawing.Size(152, 19);
            this.checkBoxEx7.TabIndex = 16;
            this.checkBoxEx7.Tag = "7";
            this.checkBoxEx7.Text = "4#站点的湿度";
            this.checkBoxEx7.UseVisualStyleBackColor = true;
            this.checkBoxEx7.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBoxEx9
            // 
            this.checkBoxEx9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxEx9.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx9.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx9.DefaultCheckButtonWidth = 20;
            this.checkBoxEx9.Location = new System.Drawing.Point(1150, 366);
            this.checkBoxEx9.Name = "checkBoxEx9";
            this.checkBoxEx9.Size = new System.Drawing.Size(152, 19);
            this.checkBoxEx9.TabIndex = 18;
            this.checkBoxEx9.Tag = "9";
            this.checkBoxEx9.Text = "5#站点的湿度";
            this.checkBoxEx9.UseVisualStyleBackColor = true;
            this.checkBoxEx9.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBoxEx8
            // 
            this.checkBoxEx8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxEx8.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx8.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx8.DefaultCheckButtonWidth = 20;
            this.checkBoxEx8.Location = new System.Drawing.Point(1325, 330);
            this.checkBoxEx8.Name = "checkBoxEx8";
            this.checkBoxEx8.Size = new System.Drawing.Size(157, 19);
            this.checkBoxEx8.TabIndex = 15;
            this.checkBoxEx8.Tag = "6";
            this.checkBoxEx8.Text = "4#站点的温度";
            this.checkBoxEx8.UseVisualStyleBackColor = true;
            this.checkBoxEx8.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // mthControl3
            // 
            this.mthControl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.mthControl3.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mthControl3.Humidity = "0.0";
            this.mthControl3.HumidityVarName = "模块4湿度";
            this.mthControl3.Location = new System.Drawing.Point(402, 211);
            this.mthControl3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mthControl3.ModuleError = false;
            this.mthControl3.Name = "mthControl3";
            this.mthControl3.Size = new System.Drawing.Size(390, 180);
            this.mthControl3.StateVarName = "模块4异常";
            this.mthControl3.TabIndex = 3;
            this.mthControl3.Temp = "0.0";
            this.mthControl3.TempVarName = "模块4温度";
            this.mthControl3.Title = "4#站点";
            // 
            // checkBoxEx3
            // 
            this.checkBoxEx3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxEx3.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx3.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx3.DefaultCheckButtonWidth = 20;
            this.checkBoxEx3.Location = new System.Drawing.Point(1501, 294);
            this.checkBoxEx3.Name = "checkBoxEx3";
            this.checkBoxEx3.Size = new System.Drawing.Size(159, 19);
            this.checkBoxEx3.TabIndex = 12;
            this.checkBoxEx3.Tag = "3";
            this.checkBoxEx3.Text = "2#站点的湿度";
            this.checkBoxEx3.UseVisualStyleBackColor = true;
            this.checkBoxEx3.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBoxEx10
            // 
            this.checkBoxEx10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxEx10.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx10.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx10.DefaultCheckButtonWidth = 20;
            this.checkBoxEx10.Location = new System.Drawing.Point(978, 366);
            this.checkBoxEx10.Name = "checkBoxEx10";
            this.checkBoxEx10.Size = new System.Drawing.Size(155, 19);
            this.checkBoxEx10.TabIndex = 17;
            this.checkBoxEx10.Tag = "8";
            this.checkBoxEx10.Text = "5#站点的温度";
            this.checkBoxEx10.UseVisualStyleBackColor = true;
            this.checkBoxEx10.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBoxEx4
            // 
            this.checkBoxEx4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxEx4.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx4.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx4.DefaultCheckButtonWidth = 20;
            this.checkBoxEx4.Location = new System.Drawing.Point(1325, 294);
            this.checkBoxEx4.Name = "checkBoxEx4";
            this.checkBoxEx4.Size = new System.Drawing.Size(158, 19);
            this.checkBoxEx4.TabIndex = 11;
            this.checkBoxEx4.Tag = "2";
            this.checkBoxEx4.Text = "2#站点的温度";
            this.checkBoxEx4.UseVisualStyleBackColor = true;
            this.checkBoxEx4.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.MainPanel.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainPanel.Humidity = "0.0";
            this.MainPanel.HumidityVarName = "模块1湿度";
            this.MainPanel.Location = new System.Drawing.Point(4, 5);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MainPanel.ModuleError = false;
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(390, 180);
            this.MainPanel.StateVarName = "模块1异常";
            this.MainPanel.TabIndex = 0;
            this.MainPanel.Temp = "0.0";
            this.MainPanel.TempVarName = "模块1温度";
            this.MainPanel.Title = "1#站点";
            // 
            // checkBoxEx5
            // 
            this.checkBoxEx5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxEx5.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx5.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx5.DefaultCheckButtonWidth = 20;
            this.checkBoxEx5.Location = new System.Drawing.Point(1150, 330);
            this.checkBoxEx5.Name = "checkBoxEx5";
            this.checkBoxEx5.Size = new System.Drawing.Size(152, 19);
            this.checkBoxEx5.TabIndex = 14;
            this.checkBoxEx5.Tag = "5";
            this.checkBoxEx5.Text = "3#站点的湿度";
            this.checkBoxEx5.UseVisualStyleBackColor = true;
            this.checkBoxEx5.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // title1
            // 
            this.title1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.title1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title1.Location = new System.Drawing.Point(978, 411);
            this.title1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(89, 31);
            this.title1.TabIndex = 6;
            this.title1.TitleName = "系统日志";
            // 
            // chart_ActualTrend
            // 
            this.chart_ActualTrend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chart_ActualTrend.AxisX.AutoScale = false;
            this.chart_ActualTrend.AxisX.AutoZoomReset = false;
            this.chart_ActualTrend.AxisX.Color = System.Drawing.Color.Black;
            this.chart_ActualTrend.AxisX.InitWithScaleView = false;
            this.chart_ActualTrend.AxisX.IsLogarithmic = false;
            this.chart_ActualTrend.AxisX.LabelAngle = 0;
            this.chart_ActualTrend.AxisX.LabelEnabled = true;
            this.chart_ActualTrend.AxisX.LabelFormat = null;
            this.chart_ActualTrend.AxisX.MajorGridColor = System.Drawing.Color.Black;
            this.chart_ActualTrend.AxisX.MajorGridCount = 6;
            this.chart_ActualTrend.AxisX.MajorGridEnabled = true;
            this.chart_ActualTrend.AxisX.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_ActualTrend.AxisX.Maximum = 1000D;
            this.chart_ActualTrend.AxisX.Minimum = 0D;
            this.chart_ActualTrend.AxisX.MinorGridColor = System.Drawing.Color.Black;
            this.chart_ActualTrend.AxisX.MinorGridEnabled = false;
            this.chart_ActualTrend.AxisX.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_ActualTrend.AxisX.TickWidth = 1F;
            this.chart_ActualTrend.AxisX.Title = "";
            this.chart_ActualTrend.AxisX.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_ActualTrend.AxisX.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_ActualTrend.AxisX.ViewMaximum = 1000D;
            this.chart_ActualTrend.AxisX.ViewMinimum = 0D;
            this.chart_ActualTrend.AxisX2.AutoScale = false;
            this.chart_ActualTrend.AxisX2.AutoZoomReset = false;
            this.chart_ActualTrend.AxisX2.Color = System.Drawing.Color.Black;
            this.chart_ActualTrend.AxisX2.InitWithScaleView = false;
            this.chart_ActualTrend.AxisX2.IsLogarithmic = false;
            this.chart_ActualTrend.AxisX2.LabelAngle = 0;
            this.chart_ActualTrend.AxisX2.LabelEnabled = true;
            this.chart_ActualTrend.AxisX2.LabelFormat = null;
            this.chart_ActualTrend.AxisX2.MajorGridColor = System.Drawing.Color.Black;
            this.chart_ActualTrend.AxisX2.MajorGridCount = 6;
            this.chart_ActualTrend.AxisX2.MajorGridEnabled = true;
            this.chart_ActualTrend.AxisX2.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_ActualTrend.AxisX2.Maximum = 1000D;
            this.chart_ActualTrend.AxisX2.Minimum = 0D;
            this.chart_ActualTrend.AxisX2.MinorGridColor = System.Drawing.Color.Black;
            this.chart_ActualTrend.AxisX2.MinorGridEnabled = false;
            this.chart_ActualTrend.AxisX2.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_ActualTrend.AxisX2.TickWidth = 1F;
            this.chart_ActualTrend.AxisX2.Title = "";
            this.chart_ActualTrend.AxisX2.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_ActualTrend.AxisX2.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_ActualTrend.AxisX2.ViewMaximum = 1000D;
            this.chart_ActualTrend.AxisX2.ViewMinimum = 0D;
            this.chart_ActualTrend.AxisY.AutoScale = true;
            this.chart_ActualTrend.AxisY.AutoZoomReset = false;
            this.chart_ActualTrend.AxisY.Color = System.Drawing.Color.Black;
            this.chart_ActualTrend.AxisY.InitWithScaleView = false;
            this.chart_ActualTrend.AxisY.IsLogarithmic = false;
            this.chart_ActualTrend.AxisY.LabelAngle = 0;
            this.chart_ActualTrend.AxisY.LabelEnabled = true;
            this.chart_ActualTrend.AxisY.LabelFormat = null;
            this.chart_ActualTrend.AxisY.MajorGridColor = System.Drawing.Color.Black;
            this.chart_ActualTrend.AxisY.MajorGridCount = 6;
            this.chart_ActualTrend.AxisY.MajorGridEnabled = true;
            this.chart_ActualTrend.AxisY.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_ActualTrend.AxisY.Maximum = 3.5D;
            this.chart_ActualTrend.AxisY.Minimum = 0.5D;
            this.chart_ActualTrend.AxisY.MinorGridColor = System.Drawing.Color.Black;
            this.chart_ActualTrend.AxisY.MinorGridEnabled = false;
            this.chart_ActualTrend.AxisY.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_ActualTrend.AxisY.TickWidth = 1F;
            this.chart_ActualTrend.AxisY.Title = "";
            this.chart_ActualTrend.AxisY.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_ActualTrend.AxisY.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_ActualTrend.AxisY.ViewMaximum = 3.5D;
            this.chart_ActualTrend.AxisY.ViewMinimum = 0.5D;
            this.chart_ActualTrend.AxisY2.AutoScale = true;
            this.chart_ActualTrend.AxisY2.AutoZoomReset = false;
            this.chart_ActualTrend.AxisY2.Color = System.Drawing.Color.Black;
            this.chart_ActualTrend.AxisY2.InitWithScaleView = false;
            this.chart_ActualTrend.AxisY2.IsLogarithmic = false;
            this.chart_ActualTrend.AxisY2.LabelAngle = 0;
            this.chart_ActualTrend.AxisY2.LabelEnabled = true;
            this.chart_ActualTrend.AxisY2.LabelFormat = null;
            this.chart_ActualTrend.AxisY2.MajorGridColor = System.Drawing.Color.Black;
            this.chart_ActualTrend.AxisY2.MajorGridCount = 6;
            this.chart_ActualTrend.AxisY2.MajorGridEnabled = true;
            this.chart_ActualTrend.AxisY2.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_ActualTrend.AxisY2.Maximum = 3.5D;
            this.chart_ActualTrend.AxisY2.Minimum = 0.5D;
            this.chart_ActualTrend.AxisY2.MinorGridColor = System.Drawing.Color.Black;
            this.chart_ActualTrend.AxisY2.MinorGridEnabled = false;
            this.chart_ActualTrend.AxisY2.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_ActualTrend.AxisY2.TickWidth = 1F;
            this.chart_ActualTrend.AxisY2.Title = "";
            this.chart_ActualTrend.AxisY2.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_ActualTrend.AxisY2.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_ActualTrend.AxisY2.ViewMaximum = 3.5D;
            this.chart_ActualTrend.AxisY2.ViewMinimum = 0.5D;
            this.chart_ActualTrend.BackColor = System.Drawing.Color.White;
            this.chart_ActualTrend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chart_ActualTrend.ChartAreaBackColor = System.Drawing.Color.Empty;
            this.chart_ActualTrend.Direction = SeeSharpTools.JY.GUI.StripChartX.ScrollDirection.LeftToRight;
            this.chart_ActualTrend.DisplayPoints = 4000;
            this.chart_ActualTrend.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chart_ActualTrend.GradientStyle = SeeSharpTools.JY.GUI.StripChartX.ChartGradientStyle.None;
            this.chart_ActualTrend.LegendBackColor = System.Drawing.Color.Transparent;
            this.chart_ActualTrend.LegendFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chart_ActualTrend.LegendForeColor = System.Drawing.Color.Black;
            this.chart_ActualTrend.LegendVisible = true;
            stripChartXSeries1.Color = System.Drawing.Color.Red;
            stripChartXSeries1.Marker = SeeSharpTools.JY.GUI.StripChartXSeries.MarkerType.None;
            stripChartXSeries1.Name = "1#站点的温度";
            stripChartXSeries1.Type = SeeSharpTools.JY.GUI.StripChartXSeries.LineType.FastLine;
            stripChartXSeries1.Visible = true;
            stripChartXSeries1.Width = SeeSharpTools.JY.GUI.StripChartXSeries.LineWidth.Thin;
            stripChartXSeries1.XPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            stripChartXSeries1.YPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            this.chart_ActualTrend.LineSeries.Add(stripChartXSeries1);
            this.chart_ActualTrend.Location = new System.Drawing.Point(978, 57);
            this.chart_ActualTrend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chart_ActualTrend.Miscellaneous.CheckInfinity = false;
            this.chart_ActualTrend.Miscellaneous.CheckNaN = false;
            this.chart_ActualTrend.Miscellaneous.CheckNegtiveOrZero = false;
            this.chart_ActualTrend.Miscellaneous.DirectionChartCount = 3;
            this.chart_ActualTrend.Miscellaneous.Fitting = SeeSharpTools.JY.GUI.StripChartX.FitType.Range;
            this.chart_ActualTrend.Miscellaneous.MaxSeriesCount = 32;
            this.chart_ActualTrend.Miscellaneous.MaxSeriesPointCount = 4000;
            this.chart_ActualTrend.Miscellaneous.SplitLayoutColumnInterval = 0F;
            this.chart_ActualTrend.Miscellaneous.SplitLayoutDirection = SeeSharpTools.JY.GUI.StripChartXUtility.LayoutDirection.LeftToRight;
            this.chart_ActualTrend.Miscellaneous.SplitLayoutRowInterval = 0F;
            this.chart_ActualTrend.Miscellaneous.SplitViewAutoLayout = true;
            this.chart_ActualTrend.Name = "chart_ActualTrend";
            this.chart_ActualTrend.NextTimeStamp = new System.DateTime(((long)(0)));
            this.chart_ActualTrend.ScrollType = SeeSharpTools.JY.GUI.StripChartX.StripScrollType.Cumulation;
            this.chart_ActualTrend.SeriesCount = 1;
            this.chart_ActualTrend.Size = new System.Drawing.Size(600, 230);
            this.chart_ActualTrend.SplitView = false;
            this.chart_ActualTrend.StartIndex = 0;
            this.chart_ActualTrend.TabIndex = 8;
            this.chart_ActualTrend.TimeInterval = System.TimeSpan.Parse("00:00:00");
            this.chart_ActualTrend.TimeStampFormat = null;
            this.chart_ActualTrend.XCursor.AutoInterval = true;
            this.chart_ActualTrend.XCursor.Color = System.Drawing.Color.DeepSkyBlue;
            this.chart_ActualTrend.XCursor.Interval = 0.001D;
            this.chart_ActualTrend.XCursor.Mode = SeeSharpTools.JY.GUI.StripChartXCursor.CursorMode.Zoom;
            this.chart_ActualTrend.XCursor.SelectionColor = System.Drawing.Color.LightGray;
            this.chart_ActualTrend.XCursor.Value = double.NaN;
            this.chart_ActualTrend.XDataType = SeeSharpTools.JY.GUI.StripChartX.XAxisDataType.Index;
            this.chart_ActualTrend.YCursor.AutoInterval = true;
            this.chart_ActualTrend.YCursor.Color = System.Drawing.Color.DeepSkyBlue;
            this.chart_ActualTrend.YCursor.Interval = 0.001D;
            this.chart_ActualTrend.YCursor.Mode = SeeSharpTools.JY.GUI.StripChartXCursor.CursorMode.Disabled;
            this.chart_ActualTrend.YCursor.SelectionColor = System.Drawing.Color.LightGray;
            this.chart_ActualTrend.YCursor.Value = double.NaN;
            // 
            // chk_Temp1
            // 
            this.chk_Temp1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_Temp1.CheckBackColor = System.Drawing.Color.White;
            this.chk_Temp1.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_Temp1.DefaultCheckButtonWidth = 20;
            this.chk_Temp1.Location = new System.Drawing.Point(980, 294);
            this.chk_Temp1.Name = "chk_Temp1";
            this.chk_Temp1.Size = new System.Drawing.Size(155, 19);
            this.chk_Temp1.TabIndex = 9;
            this.chk_Temp1.Tag = "0";
            this.chk_Temp1.Text = "1#站点的温度";
            this.chk_Temp1.UseVisualStyleBackColor = true;
            this.chk_Temp1.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBoxEx6
            // 
            this.checkBoxEx6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxEx6.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx6.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx6.DefaultCheckButtonWidth = 20;
            this.checkBoxEx6.Location = new System.Drawing.Point(980, 330);
            this.checkBoxEx6.Name = "checkBoxEx6";
            this.checkBoxEx6.Size = new System.Drawing.Size(153, 19);
            this.checkBoxEx6.TabIndex = 13;
            this.checkBoxEx6.Tag = "4";
            this.checkBoxEx6.Text = "3#站点的温度";
            this.checkBoxEx6.UseVisualStyleBackColor = true;
            this.checkBoxEx6.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // title2
            // 
            this.title2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.title2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title2.Location = new System.Drawing.Point(980, 14);
            this.title2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title2.Name = "title2";
            this.title2.Size = new System.Drawing.Size(89, 31);
            this.title2.TabIndex = 7;
            this.title2.TitleName = "实时趋势";
            // 
            // mthControl4
            // 
            this.mthControl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.mthControl4.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mthControl4.Humidity = "0.0";
            this.mthControl4.HumidityVarName = "模块3湿度";
            this.mthControl4.Location = new System.Drawing.Point(4, 211);
            this.mthControl4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mthControl4.ModuleError = false;
            this.mthControl4.Name = "mthControl4";
            this.mthControl4.Size = new System.Drawing.Size(390, 180);
            this.mthControl4.StateVarName = "模块3异常";
            this.mthControl4.TabIndex = 2;
            this.mthControl4.Temp = "0.0";
            this.mthControl4.TempVarName = "模块3温度";
            this.mthControl4.Title = "3#站点";
            // 
            // chk_Humidity1
            // 
            this.chk_Humidity1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_Humidity1.CheckBackColor = System.Drawing.Color.White;
            this.chk_Humidity1.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_Humidity1.DefaultCheckButtonWidth = 20;
            this.chk_Humidity1.Location = new System.Drawing.Point(1150, 294);
            this.chk_Humidity1.Name = "chk_Humidity1";
            this.chk_Humidity1.Size = new System.Drawing.Size(152, 19);
            this.chk_Humidity1.TabIndex = 10;
            this.chk_Humidity1.Tag = "1";
            this.chk_Humidity1.Text = "1#站点的湿度";
            this.chk_Humidity1.UseVisualStyleBackColor = true;
            this.chk_Humidity1.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // mthControl6
            // 
            this.mthControl6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.mthControl6.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mthControl6.Humidity = "0.0";
            this.mthControl6.HumidityVarName = "模块5湿度";
            this.mthControl6.Location = new System.Drawing.Point(4, 417);
            this.mthControl6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mthControl6.ModuleError = false;
            this.mthControl6.Name = "mthControl6";
            this.mthControl6.Size = new System.Drawing.Size(390, 180);
            this.mthControl6.StateVarName = "模块5异常";
            this.mthControl6.TabIndex = 4;
            this.mthControl6.Temp = "0.0";
            this.mthControl6.TempVarName = "模块5温度";
            this.mthControl6.Title = "5#站点";
            // 
            // mthControl5
            // 
            this.mthControl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.mthControl5.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mthControl5.Humidity = "0.0";
            this.mthControl5.HumidityVarName = "模块6湿度";
            this.mthControl5.Location = new System.Drawing.Point(402, 417);
            this.mthControl5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mthControl5.ModuleError = false;
            this.mthControl5.Name = "mthControl5";
            this.mthControl5.Size = new System.Drawing.Size(390, 180);
            this.mthControl5.StateVarName = "模块6异常";
            this.mthControl5.TabIndex = 5;
            this.mthControl5.Temp = "0.0";
            this.mthControl5.TempVarName = "模块6温度";
            this.mthControl5.Title = "6#站点";
            // 
            // FrmMonitor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1660, 945);
            this.Controls.Add(this.panelEnhanced1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMonitor";
            this.Text = "集中监控";
            this.panelEnhanced1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MTHControlLib.MTHControl MainPanel;
        private MTHControlLib.MTHControl mthControl2;
        private MTHControlLib.MTHControl mthControl3;
        private MTHControlLib.MTHControl mthControl4;
        private MTHControlLib.MTHControl mthControl5;
        private MTHControlLib.MTHControl mthControl6;
        private MTHControlLib.Title title1;
        private MTHControlLib.Title title2;
        private SeeSharpTools.JY.GUI.StripChartX chart_ActualTrend;
        private MTHControlLib.CheckBoxEx chk_Temp1;
        private MTHControlLib.CheckBoxEx chk_Humidity1;
        private MTHControlLib.CheckBoxEx checkBoxEx3;
        private MTHControlLib.CheckBoxEx checkBoxEx4;
        private MTHControlLib.CheckBoxEx checkBoxEx5;
        private MTHControlLib.CheckBoxEx checkBoxEx6;
        private MTHControlLib.CheckBoxEx checkBoxEx7;
        private MTHControlLib.CheckBoxEx checkBoxEx8;
        private MTHControlLib.CheckBoxEx checkBoxEx9;
        private MTHControlLib.CheckBoxEx checkBoxEx10;
        private MTHControlLib.CheckBoxEx checkBoxEx11;
        private MTHControlLib.CheckBoxEx checkBoxEx12;
        private System.Windows.Forms.ListView lst_Info;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private MTHControlLib.PanelEnhanced panelEnhanced1;
    }
}
