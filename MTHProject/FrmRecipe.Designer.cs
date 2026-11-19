namespace MTHProject
{
    partial class FrmRecipe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            MTHModels.RecipeParam recipeParam7 = new MTHModels.RecipeParam();
            MTHModels.RecipeParam recipeParam8 = new MTHModels.RecipeParam();
            MTHModels.RecipeParam recipeParam9 = new MTHModels.RecipeParam();
            MTHModels.RecipeParam recipeParam10 = new MTHModels.RecipeParam();
            MTHModels.RecipeParam recipeParam11 = new MTHModels.RecipeParam();
            MTHModels.RecipeParam recipeParam12 = new MTHModels.RecipeParam();
            this.panelEnhanced1 = new MTHControlLib.PanelEnhanced();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_Modify = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.txt_RecipeName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_CurrentRecipe = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipeControl6 = new MTHControlLib.RecipeControl();
            this.recipeControl5 = new MTHControlLib.RecipeControl();
            this.recipeControl4 = new MTHControlLib.RecipeControl();
            this.recipeControl3 = new MTHControlLib.RecipeControl();
            this.recipeControl2 = new MTHControlLib.RecipeControl();
            this.recipeControl1 = new MTHControlLib.RecipeControl();
            this.panelEnhanced1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEnhanced1
            // 
            this.panelEnhanced1.BackgroundImage = global::MTHProject.Properties.Resources.backimage;
            this.panelEnhanced1.Controls.Add(this.splitContainer1);
            this.panelEnhanced1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEnhanced1.Location = new System.Drawing.Point(0, 0);
            this.panelEnhanced1.Name = "panelEnhanced1";
            this.panelEnhanced1.Size = new System.Drawing.Size(1599, 745);
            this.panelEnhanced1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btn_Modify);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Delete);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Apply);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Add);
            this.splitContainer1.Panel1.Controls.Add(this.txt_RecipeName);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_CurrentRecipe);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dgv_Main);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.recipeControl6);
            this.splitContainer1.Panel2.Controls.Add(this.recipeControl5);
            this.splitContainer1.Panel2.Controls.Add(this.recipeControl4);
            this.splitContainer1.Panel2.Controls.Add(this.recipeControl3);
            this.splitContainer1.Panel2.Controls.Add(this.recipeControl2);
            this.splitContainer1.Panel2.Controls.Add(this.recipeControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1599, 745);
            this.splitContainer1.SplitterDistance = 532;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // btn_Modify
            // 
            this.btn_Modify.BackColor = System.Drawing.Color.Transparent;
            this.btn_Modify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Modify.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_Modify.ForeColor = System.Drawing.Color.Black;
            this.btn_Modify.Location = new System.Drawing.Point(244, 573);
            this.btn_Modify.Name = "btn_Modify";
            this.btn_Modify.Size = new System.Drawing.Size(130, 40);
            this.btn_Modify.TabIndex = 25;
            this.btn_Modify.Text = "修改配方";
            this.btn_Modify.UseVisualStyleBackColor = false;
            this.btn_Modify.Click += new System.EventHandler(this.btn_Modify_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.Transparent;
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_Delete.ForeColor = System.Drawing.Color.Black;
            this.btn_Delete.Location = new System.Drawing.Point(91, 634);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(130, 40);
            this.btn_Delete.TabIndex = 24;
            this.btn_Delete.Text = "删除配方";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Apply
            // 
            this.btn_Apply.BackColor = System.Drawing.Color.Transparent;
            this.btn_Apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Apply.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_Apply.ForeColor = System.Drawing.Color.Black;
            this.btn_Apply.Location = new System.Drawing.Point(244, 634);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(130, 40);
            this.btn_Apply.TabIndex = 23;
            this.btn_Apply.Text = "应用配方";
            this.btn_Apply.UseVisualStyleBackColor = false;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.Transparent;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.btn_Add.ForeColor = System.Drawing.Color.Black;
            this.btn_Add.Location = new System.Drawing.Point(91, 573);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(130, 40);
            this.btn_Add.TabIndex = 22;
            this.btn_Add.Text = "添加配方";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // txt_RecipeName
            // 
            this.txt_RecipeName.Location = new System.Drawing.Point(245, 507);
            this.txt_RecipeName.Name = "txt_RecipeName";
            this.txt_RecipeName.Size = new System.Drawing.Size(100, 31);
            this.txt_RecipeName.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(107, 507);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 24);
            this.label3.TabIndex = 20;
            this.label3.Text = "配方名称：";
            // 
            // lbl_CurrentRecipe
            // 
            this.lbl_CurrentRecipe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_CurrentRecipe.ForeColor = System.Drawing.Color.White;
            this.lbl_CurrentRecipe.Location = new System.Drawing.Point(245, 454);
            this.lbl_CurrentRecipe.Name = "lbl_CurrentRecipe";
            this.lbl_CurrentRecipe.Size = new System.Drawing.Size(100, 24);
            this.lbl_CurrentRecipe.TabIndex = 19;
            this.lbl_CurrentRecipe.Text = "THPR";
            this.lbl_CurrentRecipe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(107, 454);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "当前配方：";
            // 
            // dgv_Main
            // 
            this.dgv_Main.AllowUserToAddRows = false;
            this.dgv_Main.AllowUserToDeleteRows = false;
            this.dgv_Main.AllowUserToResizeColumns = false;
            this.dgv_Main.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Main.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Main.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupName,
            this.Start});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Main.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Main.EnableHeadersVisualStyles = false;
            this.dgv_Main.Location = new System.Drawing.Point(53, 0);
            this.dgv_Main.Name = "dgv_Main";
            this.dgv_Main.ReadOnly = true;
            this.dgv_Main.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Main.RowHeadersVisible = false;
            this.dgv_Main.RowHeadersWidth = 51;
            this.dgv_Main.RowTemplate.Height = 32;
            this.dgv_Main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Main.Size = new System.Drawing.Size(356, 440);
            this.dgv_Main.TabIndex = 17;
            this.dgv_Main.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Main_CellClick);
            // 
            // GroupName
            // 
            this.GroupName.DataPropertyName = "GroupName";
            this.GroupName.HeaderText = "序号";
            this.GroupName.MinimumWidth = 6;
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            this.GroupName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GroupName.Width = 150;
            // 
            // Start
            // 
            this.Start.DataPropertyName = "Start";
            this.Start.HeaderText = "配方名称";
            this.Start.MinimumWidth = 6;
            this.Start.Name = "Start";
            this.Start.ReadOnly = true;
            this.Start.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Start.Width = 201;
            // 
            // recipeControl6
            // 
            this.recipeControl6.DevName = "6#站点";
            this.recipeControl6.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recipeControl6.Location = new System.Drawing.Point(695, 360);
            this.recipeControl6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.recipeControl6.Name = "recipeControl6";
            recipeParam7.HumidityAlarmEnable = false;
            recipeParam7.HumidityHigh = 0F;
            recipeParam7.HumidityLow = 0F;
            recipeParam7.TempAlarmEnable = false;
            recipeParam7.TempHigh = 0F;
            recipeParam7.TempLow = 0F;
            this.recipeControl6.RecipeParam = recipeParam7;
            this.recipeControl6.Size = new System.Drawing.Size(339, 293);
            this.recipeControl6.TabIndex = 5;
            // 
            // recipeControl5
            // 
            this.recipeControl5.DevName = "5#站点";
            this.recipeControl5.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recipeControl5.Location = new System.Drawing.Point(348, 360);
            this.recipeControl5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.recipeControl5.Name = "recipeControl5";
            recipeParam8.HumidityAlarmEnable = false;
            recipeParam8.HumidityHigh = 0F;
            recipeParam8.HumidityLow = 0F;
            recipeParam8.TempAlarmEnable = false;
            recipeParam8.TempHigh = 0F;
            recipeParam8.TempLow = 0F;
            this.recipeControl5.RecipeParam = recipeParam8;
            this.recipeControl5.Size = new System.Drawing.Size(339, 293);
            this.recipeControl5.TabIndex = 4;
            // 
            // recipeControl4
            // 
            this.recipeControl4.DevName = "4#站点";
            this.recipeControl4.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recipeControl4.Location = new System.Drawing.Point(1, 360);
            this.recipeControl4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.recipeControl4.Name = "recipeControl4";
            recipeParam9.HumidityAlarmEnable = false;
            recipeParam9.HumidityHigh = 0F;
            recipeParam9.HumidityLow = 0F;
            recipeParam9.TempAlarmEnable = false;
            recipeParam9.TempHigh = 0F;
            recipeParam9.TempLow = 0F;
            this.recipeControl4.RecipeParam = recipeParam9;
            this.recipeControl4.Size = new System.Drawing.Size(339, 293);
            this.recipeControl4.TabIndex = 3;
            // 
            // recipeControl3
            // 
            this.recipeControl3.DevName = "3#站点";
            this.recipeControl3.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recipeControl3.Location = new System.Drawing.Point(695, -13);
            this.recipeControl3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.recipeControl3.Name = "recipeControl3";
            recipeParam10.HumidityAlarmEnable = false;
            recipeParam10.HumidityHigh = 0F;
            recipeParam10.HumidityLow = 0F;
            recipeParam10.TempAlarmEnable = false;
            recipeParam10.TempHigh = 0F;
            recipeParam10.TempLow = 0F;
            this.recipeControl3.RecipeParam = recipeParam10;
            this.recipeControl3.Size = new System.Drawing.Size(339, 293);
            this.recipeControl3.TabIndex = 2;
            // 
            // recipeControl2
            // 
            this.recipeControl2.DevName = "2#站点";
            this.recipeControl2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recipeControl2.Location = new System.Drawing.Point(348, -13);
            this.recipeControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.recipeControl2.Name = "recipeControl2";
            recipeParam11.HumidityAlarmEnable = false;
            recipeParam11.HumidityHigh = 0F;
            recipeParam11.HumidityLow = 0F;
            recipeParam11.TempAlarmEnable = false;
            recipeParam11.TempHigh = 0F;
            recipeParam11.TempLow = 0F;
            this.recipeControl2.RecipeParam = recipeParam11;
            this.recipeControl2.Size = new System.Drawing.Size(339, 293);
            this.recipeControl2.TabIndex = 1;
            // 
            // recipeControl1
            // 
            this.recipeControl1.DevName = "1#站点";
            this.recipeControl1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recipeControl1.Location = new System.Drawing.Point(1, -13);
            this.recipeControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.recipeControl1.Name = "recipeControl1";
            recipeParam12.HumidityAlarmEnable = false;
            recipeParam12.HumidityHigh = 0F;
            recipeParam12.HumidityLow = 0F;
            recipeParam12.TempAlarmEnable = false;
            recipeParam12.TempHigh = 0F;
            recipeParam12.TempLow = 0F;
            this.recipeControl1.RecipeParam = recipeParam12;
            this.recipeControl1.Size = new System.Drawing.Size(339, 293);
            this.recipeControl1.TabIndex = 0;
            // 
            // FrmRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1599, 945);
            this.Controls.Add(this.panelEnhanced1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmRecipe";
            this.Text = "配方管理";
            this.panelEnhanced1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MTHControlLib.PanelEnhanced panelEnhanced1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.TextBox txt_RecipeName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_CurrentRecipe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start;
        private System.Windows.Forms.Button btn_Modify;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.Button btn_Add;
        private MTHControlLib.RecipeControl recipeControl6;
        private MTHControlLib.RecipeControl recipeControl5;
        private MTHControlLib.RecipeControl recipeControl4;
        private MTHControlLib.RecipeControl recipeControl3;
        private MTHControlLib.RecipeControl recipeControl2;
        private MTHControlLib.RecipeControl recipeControl1;
    }
}