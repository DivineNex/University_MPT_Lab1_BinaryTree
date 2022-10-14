namespace University_ModernProgrammingTechnologies_Lab1
{
    partial class formMain
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
            this.button1 = new System.Windows.Forms.Button();
            this.lbSearchTime2 = new System.Windows.Forms.Label();
            this.lbSearchTime = new System.Windows.Forms.Label();
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
            this.button2 = new System.Windows.Forms.Button();
            this.tbDeleteRecords = new System.Windows.Forms.TextBox();
            this.tbAddRndRecords = new System.Windows.Forms.TextBox();
            this.cbVisualization = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.lbItemCount = new System.Windows.Forms.Label();
            this.lbDBRecordsCount = new System.Windows.Forms.Label();
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
            this.splitContainer1.Panel1.Controls.Add(this.lbDBRecordsCount);
            this.splitContainer1.Panel1.Controls.Add(this.lbItemCount);
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.cbVisualization);
            this.splitContainer1.Panel1.Controls.Add(this.tbAddRndRecords);
            this.splitContainer1.Panel1.Controls.Add(this.tbDeleteRecords);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.lbSearchTime2);
            this.splitContainer1.Panel1.Controls.Add(this.lbSearchTime);
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
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(141, 314);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 26);
            this.button1.TabIndex = 11;
            this.button1.Text = "Add rnd records";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbSearchTime2
            // 
            this.lbSearchTime2.AutoSize = true;
            this.lbSearchTime2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSearchTime2.Location = new System.Drawing.Point(10, 251);
            this.lbSearchTime2.Name = "lbSearchTime2";
            this.lbSearchTime2.Size = new System.Drawing.Size(189, 20);
            this.lbSearchTime2.TabIndex = 10;
            this.lbSearchTime2.Text = "Last search time (ticks): 0";
            // 
            // lbSearchTime
            // 
            this.lbSearchTime.AutoSize = true;
            this.lbSearchTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSearchTime.Location = new System.Drawing.Point(10, 231);
            this.lbSearchTime.Name = "lbSearchTime";
            this.lbSearchTime.Size = new System.Drawing.Size(178, 20);
            this.lbSearchTime.TabIndex = 9;
            this.lbSearchTime.Text = "Last search time (ms): 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(10, 47);
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
            this.cmbSearchMethod.Location = new System.Drawing.Point(189, 44);
            this.cmbSearchMethod.Name = "cmbSearchMethod";
            this.cmbSearchMethod.Size = new System.Drawing.Size(121, 28);
            this.cmbSearchMethod.TabIndex = 7;
            // 
            // bResetSearch
            // 
            this.bResetSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bResetSearch.Location = new System.Drawing.Point(14, 202);
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
            this.bDeleteMode.Location = new System.Drawing.Point(14, 170);
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
            this.label1.Location = new System.Drawing.Point(10, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search (main param)";
            // 
            // tbMainParam
            // 
            this.tbMainParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbMainParam.Location = new System.Drawing.Point(189, 78);
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
            this.cbRandomizeDB.Location = new System.Drawing.Point(14, 110);
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
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(141, 346);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 26);
            this.button2.TabIndex = 12;
            this.button2.Text = "Delete records";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbDeleteRecords
            // 
            this.tbDeleteRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDeleteRecords.Location = new System.Drawing.Point(14, 346);
            this.tbDeleteRecords.Name = "tbDeleteRecords";
            this.tbDeleteRecords.Size = new System.Drawing.Size(121, 26);
            this.tbDeleteRecords.TabIndex = 13;
            this.tbDeleteRecords.Text = "10";
            // 
            // tbAddRndRecords
            // 
            this.tbAddRndRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbAddRndRecords.Location = new System.Drawing.Point(14, 314);
            this.tbAddRndRecords.Name = "tbAddRndRecords";
            this.tbAddRndRecords.Size = new System.Drawing.Size(121, 26);
            this.tbAddRndRecords.TabIndex = 14;
            this.tbAddRndRecords.Text = "10";
            // 
            // cbVisualization
            // 
            this.cbVisualization.AutoSize = true;
            this.cbVisualization.Checked = true;
            this.cbVisualization.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbVisualization.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbVisualization.Location = new System.Drawing.Point(14, 140);
            this.cbVisualization.Name = "cbVisualization";
            this.cbVisualization.Size = new System.Drawing.Size(117, 24);
            this.cbVisualization.TabIndex = 15;
            this.cbVisualization.Text = "Visualization";
            this.cbVisualization.UseVisualStyleBackColor = true;
            this.cbVisualization.CheckedChanged += new System.EventHandler(this.cbVisualization_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(14, 378);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(296, 26);
            this.button3.TabIndex = 16;
            this.button3.Text = "Add rnd records";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // lbItemCount
            // 
            this.lbItemCount.AutoSize = true;
            this.lbItemCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbItemCount.Location = new System.Drawing.Point(10, 271);
            this.lbItemCount.Name = "lbItemCount";
            this.lbItemCount.Size = new System.Drawing.Size(157, 20);
            this.lbItemCount.TabIndex = 17;
            this.lbItemCount.Text = "Current item count: 0";
            // 
            // lbDBRecordsCount
            // 
            this.lbDBRecordsCount.AutoSize = true;
            this.lbDBRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbDBRecordsCount.Location = new System.Drawing.Point(10, 291);
            this.lbDBRecordsCount.Name = "lbDBRecordsCount";
            this.lbDBRecordsCount.Size = new System.Drawing.Size(150, 20);
            this.lbDBRecordsCount.TabIndex = 18;
            this.lbDBRecordsCount.Text = "DB records count: 0";
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 861);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Radial bearing binary tree";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.Label lbSearchTime;
        private System.Windows.Forms.Label lbSearchTime2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbDeleteRecords;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbAddRndRecords;
        private System.Windows.Forms.CheckBox cbVisualization;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lbItemCount;
        private System.Windows.Forms.Label lbDBRecordsCount;
    }
}

