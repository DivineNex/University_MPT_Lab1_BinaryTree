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
            Test();
        }

        private void Test()
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
                stopwatchInMs.Start();
                for (int i = 0; i < res; i++)
                {
                    int value = rnd.Next(_mainForm.BinaryTree.MaxValue);
                    stopwatch.Start();

                    switch (cmbParam.SelectedIndex)
                    {
                        case 0:
                            _mainForm.BinaryTree.Search(_mainForm.BinaryTree.RootItem, new int[] { value }, BearingParam.d);
                            break;
                        case 1:
                            _mainForm.BinaryTree.Search(_mainForm.BinaryTree.RootItem, new int[] { value }, BearingParam.D);
                            break;
                        case 2:
                            _mainForm.BinaryTree.Search(_mainForm.BinaryTree.RootItem, new int[] { value }, BearingParam.B);
                            break;
                        case 3:
                            _mainForm.BinaryTree.Search(_mainForm.BinaryTree.RootItem, new int[] { value }, BearingParam.C);
                            break;
                        case 4:
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
                stopwatchInMs.Start();
                for (int i = 0; i < res; i++)
                {
                    int value = rnd.Next(_mainForm.BinaryTree.MaxValue);
                    stopwatch.Start();

                    switch (cmbParam.SelectedIndex)
                    {
                        case 0:
                            _mainForm.BinaryTree.SearchByHalfDividing(_mainForm.BinaryTree.RootItem, value, BearingParam.d);
                            break;
                        case 1:
                            _mainForm.BinaryTree.SearchByHalfDividing(_mainForm.BinaryTree.RootItem, value, BearingParam.D);
                            break;
                        case 2:
                            _mainForm.BinaryTree.SearchByHalfDividing(_mainForm.BinaryTree.RootItem, value, BearingParam.B);
                            break;
                        case 3:
                            _mainForm.BinaryTree.SearchByHalfDividing(_mainForm.BinaryTree.RootItem, value, BearingParam.C);
                            break;
                        case 4:
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
            }
        }
    }
}
