namespace University_ModernProgrammingTechnologies_Lab1
{
    partial class mainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bRebuild = new System.Windows.Forms.Button();
            this.bRunSQLProcedures = new System.Windows.Forms.Button();
            this.cbAutoRebuild = new System.Windows.Forms.CheckBox();
            this.bCancelDeletingRecords = new System.Windows.Forms.Button();
            this.bCancelAddingRecords = new System.Windows.Forms.Button();
            this.pbDBProgress = new System.Windows.Forms.ProgressBar();
            this.bOpenTestForm = new System.Windows.Forms.Button();
            this.lbDBRecordsCount = new System.Windows.Forms.Label();
            this.lbItemCount = new System.Windows.Forms.Label();
            this.cbVisualization = new System.Windows.Forms.CheckBox();
            this.tbAddRndRecords = new System.Windows.Forms.TextBox();
            this.tbDeleteRecords = new System.Windows.Forms.TextBox();
            this.bDeleteRecords = new System.Windows.Forms.Button();
            this.bAddRndRecords = new System.Windows.Forms.Button();
            this.lbSearchTime2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSearchMethod = new System.Windows.Forms.ComboBox();
            this.bResetSearch = new System.Windows.Forms.Button();
            this.bDeleteMode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMainParam = new System.Windows.Forms.TextBox();
            this.cbRandomizeDB = new System.Windows.Forms.CheckBox();
            this.lbParam = new System.Windows.Forms.Label();
            this.cmbParam = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bgwRecordsAdding = new System.ComponentModel.BackgroundWorker();
            this.bgwRecordsDeleting = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.bRebuild);
            this.splitContainer1.Panel1.Controls.Add(this.bRunSQLProcedures);
            this.splitContainer1.Panel1.Controls.Add(this.cbAutoRebuild);
            this.splitContainer1.Panel1.Controls.Add(this.bCancelDeletingRecords);
            this.splitContainer1.Panel1.Controls.Add(this.bCancelAddingRecords);
            this.splitContainer1.Panel1.Controls.Add(this.pbDBProgress);
            this.splitContainer1.Panel1.Controls.Add(this.bOpenTestForm);
            this.splitContainer1.Panel1.Controls.Add(this.lbDBRecordsCount);
            this.splitContainer1.Panel1.Controls.Add(this.lbItemCount);
            this.splitContainer1.Panel1.Controls.Add(this.cbVisualization);
            this.splitContainer1.Panel1.Controls.Add(this.tbAddRndRecords);
            this.splitContainer1.Panel1.Controls.Add(this.tbDeleteRecords);
            this.splitContainer1.Panel1.Controls.Add(this.bDeleteRecords);
            this.splitContainer1.Panel1.Controls.Add(this.bAddRndRecords);
            this.splitContainer1.Panel1.Controls.Add(this.lbSearchTime2);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.cmbSearchMethod);
            this.splitContainer1.Panel1.Controls.Add(this.bResetSearch);
            this.splitContainer1.Panel1.Controls.Add(this.bDeleteMode);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.tbMainParam);
            this.splitContainer1.Panel1.Controls.Add(this.cbRandomizeDB);
            this.splitContainer1.Panel1.Controls.Add(this.lbParam);
            this.splitContainer1.Panel1.Controls.Add(this.cmbParam);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1084, 861);
            this.splitContainer1.SplitterDistance = 317;
            this.splitContainer1.TabIndex = 0;
            // 
            // bRebuild
            // 
            this.bRebuild.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bRebuild.Location = new System.Drawing.Point(187, 162);
            this.bRebuild.Name = "bRebuild";
            this.bRebuild.Size = new System.Drawing.Size(119, 26);
            this.bRebuild.TabIndex = 25;
            this.bRebuild.Text = "Rebuild";
            this.bRebuild.UseVisualStyleBackColor = true;
            this.bRebuild.Click += new System.EventHandler(this.bRebuild_Click);
            // 
            // bRunSQLProcedures
            // 
            this.bRunSQLProcedures.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bRunSQLProcedures.Location = new System.Drawing.Point(12, 523);
            this.bRunSQLProcedures.Name = "bRunSQLProcedures";
            this.bRunSQLProcedures.Size = new System.Drawing.Size(296, 26);
            this.bRunSQLProcedures.TabIndex = 24;
            this.bRunSQLProcedures.Text = "Run stored SQL procedures";
            this.bRunSQLProcedures.UseVisualStyleBackColor = true;
            this.bRunSQLProcedures.Click += new System.EventHandler(this.bRunSQLProcedures_Click);
            // 
            // cbAutoRebuild
            // 
            this.cbAutoRebuild.AutoSize = true;
            this.cbAutoRebuild.Checked = true;
            this.cbAutoRebuild.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoRebuild.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbAutoRebuild.Location = new System.Drawing.Point(12, 164);
            this.cbAutoRebuild.Name = "cbAutoRebuild";
            this.cbAutoRebuild.Size = new System.Drawing.Size(145, 24);
            this.cbAutoRebuild.TabIndex = 23;
            this.cbAutoRebuild.Text = "Auto tree rebuild";
            this.cbAutoRebuild.UseVisualStyleBackColor = true;
            // 
            // bCancelDeletingRecords
            // 
            this.bCancelDeletingRecords.Enabled = false;
            this.bCancelDeletingRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCancelDeletingRecords.Location = new System.Drawing.Point(238, 226);
            this.bCancelDeletingRecords.Name = "bCancelDeletingRecords";
            this.bCancelDeletingRecords.Size = new System.Drawing.Size(70, 26);
            this.bCancelDeletingRecords.TabIndex = 22;
            this.bCancelDeletingRecords.Text = "Cancel";
            this.bCancelDeletingRecords.UseVisualStyleBackColor = true;
            // 
            // bCancelAddingRecords
            // 
            this.bCancelAddingRecords.Enabled = false;
            this.bCancelAddingRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCancelAddingRecords.Location = new System.Drawing.Point(238, 194);
            this.bCancelAddingRecords.Name = "bCancelAddingRecords";
            this.bCancelAddingRecords.Size = new System.Drawing.Size(70, 26);
            this.bCancelAddingRecords.TabIndex = 21;
            this.bCancelAddingRecords.Text = "Cancel";
            this.bCancelAddingRecords.UseVisualStyleBackColor = true;
            this.bCancelAddingRecords.Click += new System.EventHandler(this.bCancelAddingRecords_Click);
            // 
            // pbDBProgress
            // 
            this.pbDBProgress.Location = new System.Drawing.Point(12, 258);
            this.pbDBProgress.Name = "pbDBProgress";
            this.pbDBProgress.Size = new System.Drawing.Size(296, 23);
            this.pbDBProgress.Step = 1;
            this.pbDBProgress.TabIndex = 20;
            // 
            // bOpenTestForm
            // 
            this.bOpenTestForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bOpenTestForm.Location = new System.Drawing.Point(12, 459);
            this.bOpenTestForm.Name = "bOpenTestForm";
            this.bOpenTestForm.Size = new System.Drawing.Size(296, 26);
            this.bOpenTestForm.TabIndex = 19;
            this.bOpenTestForm.Text = "Open test window";
            this.bOpenTestForm.UseVisualStyleBackColor = true;
            this.bOpenTestForm.Click += new System.EventHandler(this.bOpenTestForm_Click);
            // 
            // lbDBRecordsCount
            // 
            this.lbDBRecordsCount.AutoSize = true;
            this.lbDBRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbDBRecordsCount.Location = new System.Drawing.Point(9, 141);
            this.lbDBRecordsCount.Name = "lbDBRecordsCount";
            this.lbDBRecordsCount.Size = new System.Drawing.Size(150, 20);
            this.lbDBRecordsCount.TabIndex = 18;
            this.lbDBRecordsCount.Text = "DB records count: 0";
            // 
            // lbItemCount
            // 
            this.lbItemCount.AutoSize = true;
            this.lbItemCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbItemCount.Location = new System.Drawing.Point(9, 121);
            this.lbItemCount.Name = "lbItemCount";
            this.lbItemCount.Size = new System.Drawing.Size(157, 20);
            this.lbItemCount.TabIndex = 17;
            this.lbItemCount.Text = "Current item count: 0";
            // 
            // cbVisualization
            // 
            this.cbVisualization.AutoSize = true;
            this.cbVisualization.Checked = true;
            this.cbVisualization.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbVisualization.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbVisualization.Location = new System.Drawing.Point(13, 74);
            this.cbVisualization.Name = "cbVisualization";
            this.cbVisualization.Size = new System.Drawing.Size(117, 24);
            this.cbVisualization.TabIndex = 15;
            this.cbVisualization.Text = "Visualization";
            this.cbVisualization.UseVisualStyleBackColor = true;
            this.cbVisualization.CheckedChanged += new System.EventHandler(this.cbVisualization_CheckedChanged);
            // 
            // tbAddRndRecords
            // 
            this.tbAddRndRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbAddRndRecords.Location = new System.Drawing.Point(12, 194);
            this.tbAddRndRecords.Name = "tbAddRndRecords";
            this.tbAddRndRecords.Size = new System.Drawing.Size(68, 26);
            this.tbAddRndRecords.TabIndex = 14;
            this.tbAddRndRecords.Text = "5000";
            // 
            // tbDeleteRecords
            // 
            this.tbDeleteRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDeleteRecords.Location = new System.Drawing.Point(12, 226);
            this.tbDeleteRecords.Name = "tbDeleteRecords";
            this.tbDeleteRecords.Size = new System.Drawing.Size(68, 26);
            this.tbDeleteRecords.TabIndex = 13;
            this.tbDeleteRecords.Text = "5000";
            // 
            // bDeleteRecords
            // 
            this.bDeleteRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bDeleteRecords.Location = new System.Drawing.Point(86, 226);
            this.bDeleteRecords.Name = "bDeleteRecords";
            this.bDeleteRecords.Size = new System.Drawing.Size(146, 26);
            this.bDeleteRecords.TabIndex = 12;
            this.bDeleteRecords.Text = "Delete records";
            this.bDeleteRecords.UseVisualStyleBackColor = true;
            this.bDeleteRecords.Click += new System.EventHandler(this.bDeleteRecords_Click);
            // 
            // bAddRndRecords
            // 
            this.bAddRndRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bAddRndRecords.Location = new System.Drawing.Point(86, 194);
            this.bAddRndRecords.Name = "bAddRndRecords";
            this.bAddRndRecords.Size = new System.Drawing.Size(146, 26);
            this.bAddRndRecords.TabIndex = 11;
            this.bAddRndRecords.Text = "Add rnd records";
            this.bAddRndRecords.UseVisualStyleBackColor = true;
            this.bAddRndRecords.Click += new System.EventHandler(this.bAddRndRecords_Click);
            // 
            // lbSearchTime2
            // 
            this.lbSearchTime2.AutoSize = true;
            this.lbSearchTime2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSearchTime2.Location = new System.Drawing.Point(8, 402);
            this.lbSearchTime2.Name = "lbSearchTime2";
            this.lbSearchTime2.Size = new System.Drawing.Size(189, 20);
            this.lbSearchTime2.TabIndex = 10;
            this.lbSearchTime2.Text = "Last search time (ticks): 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Search method";
            // 
            // cmbSearchMethod
            // 
            this.cmbSearchMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbSearchMethod.FormattingEnabled = true;
            this.cmbSearchMethod.Items.AddRange(new object[] {
            "Full tree",
            "Half Dividing"});
            this.cmbSearchMethod.Location = new System.Drawing.Point(187, 307);
            this.cmbSearchMethod.Name = "cmbSearchMethod";
            this.cmbSearchMethod.Size = new System.Drawing.Size(121, 28);
            this.cmbSearchMethod.TabIndex = 7;
            // 
            // bResetSearch
            // 
            this.bResetSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bResetSearch.Location = new System.Drawing.Point(12, 373);
            this.bResetSearch.Name = "bResetSearch";
            this.bResetSearch.Size = new System.Drawing.Size(296, 26);
            this.bResetSearch.TabIndex = 6;
            this.bResetSearch.Text = "Reset search results";
            this.bResetSearch.UseVisualStyleBackColor = true;
            this.bResetSearch.Click += new System.EventHandler(this.bResetSearch_Click);
            // 
            // bDeleteMode
            // 
            this.bDeleteMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bDeleteMode.Location = new System.Drawing.Point(12, 491);
            this.bDeleteMode.Name = "bDeleteMode";
            this.bDeleteMode.Size = new System.Drawing.Size(296, 26);
            this.bDeleteMode.TabIndex = 5;
            this.bDeleteMode.Text = "Enter delete mode";
            this.bDeleteMode.UseVisualStyleBackColor = true;
            this.bDeleteMode.Click += new System.EventHandler(this.bDeleteMode_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 341);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search (main param)";
            // 
            // tbMainParam
            // 
            this.tbMainParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbMainParam.Location = new System.Drawing.Point(187, 341);
            this.tbMainParam.Name = "tbMainParam";
            this.tbMainParam.Size = new System.Drawing.Size(121, 26);
            this.tbMainParam.TabIndex = 3;
            this.tbMainParam.TextChanged += new System.EventHandler(this.tbMainParam_TextChanged);
            // 
            // cbRandomizeDB
            // 
            this.cbRandomizeDB.AutoSize = true;
            this.cbRandomizeDB.Checked = true;
            this.cbRandomizeDB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRandomizeDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbRandomizeDB.Location = new System.Drawing.Point(13, 44);
            this.cbRandomizeDB.Name = "cbRandomizeDB";
            this.cbRandomizeDB.Size = new System.Drawing.Size(205, 24);
            this.cbRandomizeDB.TabIndex = 2;
            this.cbRandomizeDB.Text = "Randomize rows on build";
            this.cbRandomizeDB.UseVisualStyleBackColor = true;
            // 
            // lbParam
            // 
            this.lbParam.AutoSize = true;
            this.lbParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbParam.Location = new System.Drawing.Point(10, 13);
            this.lbParam.Name = "lbParam";
            this.lbParam.Size = new System.Drawing.Size(91, 20);
            this.lbParam.TabIndex = 1;
            this.lbParam.Text = "Tree Param";
            // 
            // cmbParam
            // 
            this.cmbParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbParam.FormattingEnabled = true;
            this.cmbParam.Items.AddRange(new object[] {
            "d",
            "D",
            "B",
            "C",
            "C0"});
            this.cmbParam.Location = new System.Drawing.Point(189, 10);
            this.cmbParam.Name = "cmbParam";
            this.cmbParam.Size = new System.Drawing.Size(121, 28);
            this.cmbParam.TabIndex = 0;
            this.cmbParam.SelectedIndexChanged += new System.EventHandler(this.cbParam_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(759, 857);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // bgwRecordsAdding
            // 
            this.bgwRecordsAdding.WorkerReportsProgress = true;
            this.bgwRecordsAdding.WorkerSupportsCancellation = true;
            this.bgwRecordsAdding.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRecordsAdding_DoWork);
            this.bgwRecordsAdding.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwRecordsAdding_ProgressChanged);
            this.bgwRecordsAdding.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRecordsAdding_RunWorkerCompleted);
            // 
            // bgwRecordsDeleting
            // 
            this.bgwRecordsDeleting.WorkerReportsProgress = true;
            this.bgwRecordsDeleting.WorkerSupportsCancellation = true;
            this.bgwRecordsDeleting.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRecordsDeleting_DoWork);
            this.bgwRecordsDeleting.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwRecordsDeleting_ProgressChanged);
            this.bgwRecordsDeleting.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRecordsDeleting_RunWorkerCompleted);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 861);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Radial bearing binary tree";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.formMain_Load);
            this.Resize += new System.EventHandler(this.formMain_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbParam;
        private System.Windows.Forms.ComboBox cmbParam;
        private System.Windows.Forms.CheckBox cbRandomizeDB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMainParam;
        private System.Windows.Forms.Button bDeleteMode;
        private System.Windows.Forms.Button bResetSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSearchMethod;
        private System.Windows.Forms.Label lbSearchTime2;
        private System.Windows.Forms.Button bAddRndRecords;
        private System.Windows.Forms.TextBox tbDeleteRecords;
        private System.Windows.Forms.Button bDeleteRecords;
        private System.Windows.Forms.TextBox tbAddRndRecords;
        private System.Windows.Forms.CheckBox cbVisualization;
        private System.Windows.Forms.Label lbItemCount;
        private System.Windows.Forms.Label lbDBRecordsCount;
        private System.Windows.Forms.Button bOpenTestForm;
        private System.Windows.Forms.ProgressBar pbDBProgress;
        private System.ComponentModel.BackgroundWorker bgwRecordsAdding;
        private System.Windows.Forms.Button bCancelDeletingRecords;
        private System.Windows.Forms.Button bCancelAddingRecords;
        private System.ComponentModel.BackgroundWorker bgwRecordsDeleting;
        private System.Windows.Forms.CheckBox cbAutoRebuild;
        private System.Windows.Forms.Button bRunSQLProcedures;
        private System.Windows.Forms.Button bRebuild;
    }
}

