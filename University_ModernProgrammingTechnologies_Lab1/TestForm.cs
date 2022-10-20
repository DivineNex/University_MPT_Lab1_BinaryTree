using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace University_ModernProgrammingTechnologies_Lab1
{
    public partial class TestForm : Form
    {
        private mainForm _mainForm;

        public TestForm(mainForm mainForm)
        {
            this._mainForm = mainForm;
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowCharts.Checked)
            {
                Width = 1145;
                chart1.Visible = true;
                chart2.Visible = true;
            }
            else
            {
                Width = 335;
                chart1.Visible = false;
                chart2.Visible = false;
            }
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Title = "Iteration";
            chart1.ChartAreas[0].AxisY.Title = "Ticks";
            chart2.ChartAreas[0].AxisX.Title = "Iteration";
            chart2.ChartAreas[0].AxisY.Title = "Ticks";
            cmbParam.SelectedIndex = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!bgwTester.IsBusy)
                bgwTester.RunWorkerAsync();
            bStopTest.Enabled = true;
        }

        private void TestAsync(int iterationCount, BearingParam param, BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => chart1.Series[0].Points.Clear()));
                this.Invoke(new Action(() => chart2.Series[0].Points.Clear()));
            }

            Stopwatch stopwatch = new Stopwatch();
            Stopwatch stopwatchInMs = new Stopwatch();
            Random rnd = new Random();

            if (Int32.TryParse(tbIterationsCount.Text, out int res))
            {
                long sum1InTicks = 0;
                long sum2InTicks = 0;
                long sum1InMs = 0;
                long sum2InMs = 0;

                //Full tree method
                if (InvokeRequired)
                    this.Invoke(new Action(() => lbTestStatus.Text = "Current status: Full tree method"));
                stopwatchInMs.Start();
                for (int i = 1; i <= res; i++)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                      
                    int value = rnd.Next(_mainForm.BinaryTree.MaxValue);
                    stopwatch.Start();

                    switch (param)
                    {
                        case BearingParam.d:
                            _mainForm.BinaryTree.Search(_mainForm.BinaryTree.RootItem, new int[] { value }, BearingParam.d);
                            break;
                        case BearingParam.D:
                            _mainForm.BinaryTree.Search(_mainForm.BinaryTree.RootItem, new int[] { value }, BearingParam.D);
                            break;
                        case BearingParam.B:
                            _mainForm.BinaryTree.Search(_mainForm.BinaryTree.RootItem, new int[] { value }, BearingParam.B);
                            break;
                        case BearingParam.C:
                            _mainForm.BinaryTree.Search(_mainForm.BinaryTree.RootItem, new int[] { value }, BearingParam.C);
                            break;
                        case BearingParam.C0:
                            _mainForm.BinaryTree.Search(_mainForm.BinaryTree.RootItem, new int[] { value }, BearingParam.C0);
                            break;
                    }

                    stopwatch.Stop();

                    if (InvokeRequired)
                        this.Invoke(new Action(() => chart1.Series[0].Points.AddXY(i, stopwatch.ElapsedTicks)));
                    
                    sum1InTicks += stopwatch.ElapsedTicks;
                    stopwatch.Reset();

                    worker.ReportProgress(i * 100 / res);
                }
                stopwatchInMs.Stop();
                sum1InMs = stopwatchInMs.ElapsedMilliseconds;
                stopwatchInMs.Reset();

                //Half dividing method
                if (InvokeRequired)
                    this.Invoke(new Action(() => lbTestStatus.Text = "Current status: Half dividing method"));
                stopwatchInMs.Start();
                for (int i = 1; i <= res; i++)
                {
                    int value = rnd.Next(_mainForm.BinaryTree.MaxValue);
                    stopwatch.Start();

                    switch (param)
                    {
                        case BearingParam.d:
                            _mainForm.BinaryTree.SearchByHalfDividing(_mainForm.BinaryTree.RootItem, value, BearingParam.d);
                            break;
                        case BearingParam.D:
                            _mainForm.BinaryTree.SearchByHalfDividing(_mainForm.BinaryTree.RootItem, value, BearingParam.D);
                            break;
                        case BearingParam.B:
                            _mainForm.BinaryTree.SearchByHalfDividing(_mainForm.BinaryTree.RootItem, value, BearingParam.B);
                            break;
                        case BearingParam.C:
                            _mainForm.BinaryTree.SearchByHalfDividing(_mainForm.BinaryTree.RootItem, value, BearingParam.C);
                            break;
                        case BearingParam.C0:
                            _mainForm.BinaryTree.SearchByHalfDividing(_mainForm.BinaryTree.RootItem, value, BearingParam.C0);
                            break;
                    }

                    stopwatch.Stop();
                    if (InvokeRequired)
                    {
                        this.Invoke(new Action(() => chart2.Series[0].Points.AddXY(i, stopwatch.ElapsedTicks)));
                    }

                    sum2InTicks += stopwatch.ElapsedTicks;
                    stopwatch.Reset();

                    worker.ReportProgress(i * 100 / res);
                }
                stopwatchInMs.Stop();
                sum2InMs = stopwatchInMs.ElapsedMilliseconds;
                stopwatchInMs.Reset();

                double method1Average = sum1InTicks / res;
                double method2Average = sum2InTicks / res;

                if (InvokeRequired)
                {
                    this.Invoke(new Action(() => label4.Text = $"Full tree method result (ms): {sum1InMs}"));
                    this.Invoke(new Action(() => label5.Text = $"Half dividing method result (ms): {sum2InMs}"));
                    this.Invoke(new Action(() => label10.Text = $"Full tree method average (ticks): {method1Average}"));
                    this.Invoke(new Action(() => label11.Text = $"Half dividing method average (ticks): {method2Average}"));
                    this.Invoke(new Action(() => label7.Text = $"Speed difference (ratio): {Math.Round((double)sum1InMs / (double)sum2InMs, 3)}"));
                    this.Invoke(new Action(() => lbTestStatus.Text = "Current status: waiting for start"));
                }

                
            }
        }

        private void Test(int iterationCount, BearingParam param)
        {
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();

            Stopwatch stopwatch = new Stopwatch();
            Stopwatch stopwatchInMs = new Stopwatch();
            Random rnd = new Random();

            if (Int32.TryParse(tbIterationsCount.Text, out int res))
            {
                long sum1InTicks = 0;
                long sum2InTicks = 0;
                long sum1InMs = 0;
                long sum2InMs = 0;

                //Full tree method
                lbTestStatus.Text = "Current status: Full tree method";
                stopwatchInMs.Start();
                for (int i = 0; i < res; i++)
                {
                    int value = rnd.Next(_mainForm.BinaryTree.MaxValue);
                    stopwatch.Start();

                    switch (param)
                    {
                        case BearingParam.d:
                            _mainForm.BinaryTree.Search(_mainForm.BinaryTree.RootItem, new int[] { value }, BearingParam.d);
                            break;
                        case BearingParam.D:
                            _mainForm.BinaryTree.Search(_mainForm.BinaryTree.RootItem, new int[] { value }, BearingParam.D);
                            break;
                        case BearingParam.B:
                            _mainForm.BinaryTree.Search(_mainForm.BinaryTree.RootItem, new int[] { value }, BearingParam.B);
                            break;
                        case BearingParam.C:
                            _mainForm.BinaryTree.Search(_mainForm.BinaryTree.RootItem, new int[] { value }, BearingParam.C);
                            break;
                        case BearingParam.C0:
                            _mainForm.BinaryTree.Search(_mainForm.BinaryTree.RootItem, new int[] { value }, BearingParam.C0);
                            break;
                    }

                    stopwatch.Stop();

                    chart1.Series[0].Points.AddXY(i, stopwatch.ElapsedTicks);

                    sum1InTicks += stopwatch.ElapsedTicks;
                    stopwatch.Reset();
                }
                stopwatchInMs.Stop();
                sum1InMs = stopwatchInMs.ElapsedMilliseconds;
                stopwatchInMs.Reset();

                //Half dividing method
                lbTestStatus.Text = "Current status: Half dividing method";
                stopwatchInMs.Start();
                for (int i = 0; i < res; i++)
                {
                    int value = rnd.Next(_mainForm.BinaryTree.MaxValue);
                    stopwatch.Start();

                    switch (param)
                    {
                        case BearingParam.d:
                            _mainForm.BinaryTree.SearchByHalfDividing(_mainForm.BinaryTree.RootItem, value, BearingParam.d);
                            break;
                        case BearingParam.D:
                            _mainForm.BinaryTree.SearchByHalfDividing(_mainForm.BinaryTree.RootItem, value, BearingParam.D);
                            break;
                        case BearingParam.B:
                            _mainForm.BinaryTree.SearchByHalfDividing(_mainForm.BinaryTree.RootItem, value, BearingParam.B);
                            break;
                        case BearingParam.C:
                            _mainForm.BinaryTree.SearchByHalfDividing(_mainForm.BinaryTree.RootItem, value, BearingParam.C);
                            break;
                        case BearingParam.C0:
                            _mainForm.BinaryTree.SearchByHalfDividing(_mainForm.BinaryTree.RootItem, value, BearingParam.C0);
                            break;
                    }

                    stopwatch.Stop();
                    chart2.Series[0].Points.AddXY(i, stopwatch.ElapsedTicks);

                    sum2InTicks += stopwatch.ElapsedTicks;
                    stopwatch.Reset();
                }
                stopwatchInMs.Stop();
                sum2InMs = stopwatchInMs.ElapsedMilliseconds;
                stopwatchInMs.Reset();

                double method1Average = sum1InTicks / res;
                double method2Average = sum2InTicks / res;

                label4.Text = $"Full tree method result (ms): {sum1InMs}";
                label5.Text = $"Half dividing method result (ms): {sum2InMs}";
                label10.Text = $"Full tree method average (ticks): {method1Average}";
                label11.Text = $"Half dividing method average (ticks): {method2Average}";
                label7.Text = $"Speed difference (ratio): {Math.Round((double)sum1InMs / (double)sum2InMs, 3)}";
                lbTestStatus.Text = "Current status: waiting for start";
            }
        }

        private void bgwTester_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;

            if (Int32.TryParse(tbIterationsCount.Text, out int res))
            {
                BearingParam param = new BearingParam();

                byte selectedIndex = 0;
                if (InvokeRequired)
                {
                    this.Invoke(new Action(() => selectedIndex = (byte)cmbParam.SelectedIndex));
                }

                switch (selectedIndex)
                {
                    case 0:
                        param = BearingParam.d;
                        break;
                    case 1:
                        param = BearingParam.D;
                        break;
                    case 2:
                        param = BearingParam.B;
                        break;
                    case 3:
                        param = BearingParam.C;
                        break;
                    case 4:
                        param = BearingParam.C0;
                        break;
                }

                TestAsync(res, param, backgroundWorker, e);
            }
            else
            {
                bgwTester.CancelAsync();
            }
        }

        private void bgwTester_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbProgress.Value = e.ProgressPercentage;
            pbProgress.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(tbIterationsCount.Text, out int res))
            {
                BearingParam param = new BearingParam();

                byte selectedIndex = 0;
                selectedIndex = (byte)cmbParam.SelectedIndex;

                switch (selectedIndex)
                {
                    case 0:
                        param = BearingParam.d;
                        break;
                    case 1:
                        param = BearingParam.D;
                        break;
                    case 2:
                        param = BearingParam.B;
                        break;
                    case 3:
                        param = BearingParam.C;
                        break;
                    case 4:
                        param = BearingParam.C0;
                        break;
                }

                Test(res, param);
            }
        }

        private void bStopTest_Click(object sender, EventArgs e)
        {
            bgwTester.CancelAsync();
            bStopTest.Enabled = false;
        }
    }
}
