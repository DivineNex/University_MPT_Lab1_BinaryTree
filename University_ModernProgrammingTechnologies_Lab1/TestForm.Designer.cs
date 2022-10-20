namespace University_ModernProgrammingTechnologies_Lab1
{
    partial class TestForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lbIterationsCount = new System.Windows.Forms.Label();
            this.tbIterationsCount = new System.Windows.Forms.TextBox();
            this.bStartTest = new System.Windows.Forms.Button();
            this.cbShowCharts = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label6 = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbParam = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.bStopTest = new System.Windows.Forms.Button();
            this.bgwTester = new System.ComponentModel.BackgroundWorker();
            this.lbTestStatus = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // lbIterationsCount
            // 
            this.lbIterationsCount.AutoSize = true;
            this.lbIterationsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbIterationsCount.Location = new System.Drawing.Point(12, 9);
            this.lbIterationsCount.Name = "lbIterationsCount";
            this.lbIterationsCount.Size = new System.Drawing.Size(120, 20);
            this.lbIterationsCount.TabIndex = 40;
            this.lbIterationsCount.Text = "Iterations count";
            // 
            // tbIterationsCount
            // 
            this.tbIterationsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbIterationsCount.Location = new System.Drawing.Point(191, 6);
            this.tbIterationsCount.Name = "tbIterationsCount";
            this.tbIterationsCount.Size = new System.Drawing.Size(121, 26);
            this.tbIterationsCount.TabIndex = 41;
            this.tbIterationsCount.Text = "1000";
            // 
            // bStartTest
            // 
            this.bStartTest.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bStartTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bStartTest.Location = new System.Drawing.Point(12, 104);
            this.bStartTest.Name = "bStartTest";
            this.bStartTest.Size = new System.Drawing.Size(207, 26);
            this.bStartTest.TabIndex = 42;
            this.bStartTest.Text = "Start test async";
            this.bStartTest.UseVisualStyleBackColor = true;
            this.bStartTest.Click += new System.EventHandler(this.button5_Click);
            // 
            // cbShowCharts
            // 
            this.cbShowCharts.AutoSize = true;
            this.cbShowCharts.Checked = true;
            this.cbShowCharts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowCharts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbShowCharts.Location = new System.Drawing.Point(16, 74);
            this.cbShowCharts.Name = "cbShowCharts";
            this.cbShowCharts.Size = new System.Drawing.Size(116, 24);
            this.cbShowCharts.TabIndex = 43;
            this.cbShowCharts.Text = "Show charts";
            this.cbShowCharts.UseVisualStyleBackColor = true;
            this.cbShowCharts.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 20);
            this.label4.TabIndex = 44;
            this.label4.Text = "Full tree method result (ms): 0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(247, 20);
            this.label5.TabIndex = 45;
            this.label5.Text = "Half dividing method result (ms): 0";
            // 
            // chart1
            // 
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            this.chart1.Location = new System.Drawing.Point(318, 32);
            this.chart1.Name = "chart1";
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.IsVisibleInLegend = false;
            series5.Name = "Series1";
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(399, 334);
            this.chart1.TabIndex = 46;
            this.chart1.Text = "chart1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 52;
            this.label6.Text = "Progress";
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(90, 188);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(218, 23);
            this.pbProgress.TabIndex = 51;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(12, 346);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(197, 20);
            this.label7.TabIndex = 53;
            this.label7.Text = "Speed difference (ratio): 0 ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(463, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 20);
            this.label8.TabIndex = 54;
            this.label8.Text = "Full tree method";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(855, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 20);
            this.label9.TabIndex = 55;
            this.label9.Text = "Half dividing method";
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
            this.cmbParam.Location = new System.Drawing.Point(191, 38);
            this.cmbParam.Name = "cmbParam";
            this.cmbParam.Size = new System.Drawing.Size(121, 28);
            this.cmbParam.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 58;
            this.label3.Text = "Search param";
            // 
            // chart2
            // 
            chartArea6.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea6);
            this.chart2.Location = new System.Drawing.Point(723, 32);
            this.chart2.Name = "chart2";
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.IsVisibleInLegend = false;
            series6.Name = "Series1";
            this.chart2.Series.Add(series6);
            this.chart2.Size = new System.Drawing.Size(399, 334);
            this.chart2.TabIndex = 59;
            this.chart2.Text = "chart2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(12, 286);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(237, 20);
            this.label10.TabIndex = 60;
            this.label10.Text = "Full tree method average (ms): 0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(12, 306);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(265, 20);
            this.label11.TabIndex = 61;
            this.label11.Text = "Half dividing method average (ms): 0";
            // 
            // bStopTest
            // 
            this.bStopTest.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bStopTest.Enabled = false;
            this.bStopTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bStopTest.Location = new System.Drawing.Point(225, 104);
            this.bStopTest.Name = "bStopTest";
            this.bStopTest.Size = new System.Drawing.Size(83, 26);
            this.bStopTest.TabIndex = 62;
            this.bStopTest.Text = "Stop";
            this.bStopTest.UseVisualStyleBackColor = true;
            this.bStopTest.Click += new System.EventHandler(this.bStopTest_Click);
            // 
            // bgwTester
            // 
            this.bgwTester.WorkerReportsProgress = true;
            this.bgwTester.WorkerSupportsCancellation = true;
            this.bgwTester.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwTester_DoWork);
            this.bgwTester.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwTester_ProgressChanged);
            // 
            // lbTestStatus
            // 
            this.lbTestStatus.AutoSize = true;
            this.lbTestStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbTestStatus.Location = new System.Drawing.Point(12, 165);
            this.lbTestStatus.Name = "lbTestStatus";
            this.lbTestStatus.Size = new System.Drawing.Size(226, 20);
            this.lbTestStatus.TabIndex = 63;
            this.lbTestStatus.Text = "Current status: waiting for start";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(207, 26);
            this.button1.TabIndex = 64;
            this.button1.Text = "Start test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 376);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbTestStatus);
            this.Controls.Add(this.bStopTest);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbParam);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbShowCharts);
            this.Controls.Add(this.bStartTest);
            this.Controls.Add(this.tbIterationsCount);
            this.Controls.Add(this.lbIterationsCount);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbIterationsCount;
        private System.Windows.Forms.TextBox tbIterationsCount;
        private System.Windows.Forms.Button bStartTest;
        private System.Windows.Forms.CheckBox cbShowCharts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbParam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button bStopTest;
        private System.ComponentModel.BackgroundWorker bgwTester;
        private System.Windows.Forms.Label lbTestStatus;
        private System.Windows.Forms.Button button1;
    }
}