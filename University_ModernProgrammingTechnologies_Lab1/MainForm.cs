using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace University_ModernProgrammingTechnologies_Lab1
{
    public partial class mainForm : Form
    {
        private DBManager _dBManager;
        internal RadialBearingBinaryTree _binaryTree;

        internal RadialBearingBinaryTree BinaryTree
        {
            get { return _binaryTree; }
        }


        private BinaryTreeVisualizer _visualizer;

        public mainForm()
        {
            InitializeComponent();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            _dBManager = new DBManager();
            InitBinaryTree();
            InitVisualizer();
            cmbParam.SelectedIndex = 0;
            cmbSearchMethod.SelectedIndex = 0;
        }

        private void InitBinaryTree()
        {
            _binaryTree = new RadialBearingBinaryTree();
        }

        private void InitVisualizer()
        {
            _visualizer = new BinaryTreeVisualizer(pictureBox1 ,_binaryTree);
            _visualizer.Select();
        }

        private void cbParam_SelectedIndexChanged(object sender, EventArgs e)
        {
            _visualizer.Select();
            RebuildTree();
        }

        private void formMain_Resize(object sender, EventArgs e)
        {
            _visualizer?.UpdateAndDraw();
        }

        private void tbMainParam_TextChanged(object sender, EventArgs e)
        {
            _visualizer.ResetSearching();

            if (int.TryParse(tbMainParam.Text, out int res))
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                if (cmbSearchMethod.SelectedIndex == 0)
                    _binaryTree.Search(_binaryTree.RootItem, res);
                else if (cmbSearchMethod.SelectedIndex == 1)
                    _binaryTree.SearchByHalfDividing(_binaryTree.RootItem, res);

                stopwatch.Stop();
                lbSearchTime2.Text = $"Last search time (ticks): {stopwatch.ElapsedTicks}";
                stopwatch.Reset();
            }
            _visualizer.IsSearching = true;
            _visualizer.UpdateAndDraw();
        }

        private void bResetSearch_Click(object sender, EventArgs e)
        {
            _visualizer.ResetSearching();
        }

        private void bDeleteMode_Click(object sender, EventArgs e)
        {
            if (!_visualizer.DeleteMode)
            {
                _visualizer.DeleteMode = true;
                bDeleteMode.Text = "Exit delete mode";
            }
            else
            {
                _visualizer.DeleteMode = false;
                bDeleteMode.Text = "Enter delete mode";
            }
        }

        private void bAddRndRecords_Click(object sender, EventArgs e)
        {
            bCancelAddingRecords.Enabled = true;
            if (!bgwRecordsAdding.IsBusy)
                bgwRecordsAdding.RunWorkerAsync();
        }

        private void bDeleteRecords_Click(object sender, EventArgs e)
        {
            bCancelDeletingRecords.Enabled = true;
            if (!bgwRecordsDeleting.IsBusy)
                bgwRecordsDeleting.RunWorkerAsync();
        }

        private void RebuildTree()
        {
            switch (cmbParam.SelectedIndex)
            {
                case 0:
                    _binaryTree.BuildBinaryTreeFromDBTable(_dBManager.connection, "RadialBearings", BearingParam.d, cbRandomizeDB.Checked);
                    break;
                case 1:
                    _binaryTree.BuildBinaryTreeFromDBTable(_dBManager.connection, "RadialBearings", BearingParam.D, cbRandomizeDB.Checked);
                    break;
                case 2:
                    _binaryTree.BuildBinaryTreeFromDBTable(_dBManager.connection, "RadialBearings", BearingParam.B, cbRandomizeDB.Checked);
                    break;
                case 3:
                    _binaryTree.BuildBinaryTreeFromDBTable(_dBManager.connection, "RadialBearings", BearingParam.C, cbRandomizeDB.Checked);
                    break;
                case 4:
                    _binaryTree.BuildBinaryTreeFromDBTable(_dBManager.connection, "RadialBearings", BearingParam.C0, cbRandomizeDB.Checked);
                    break;
                default:
                    break;
            }
            if (_binaryTree.ItemCount != 0)
            {
                _visualizer.CreateNodes();
                _visualizer.UpdateAndDraw();
            }

            _visualizer.Select();
            lbItemCount.Text = $"Current item count: {_binaryTree.ItemCount}";
            lbDBRecordsCount.Text = $"DB records count: {_dBManager.GetRecordsCount()}";
        }

        private void cbVisualization_CheckedChanged(object sender, EventArgs e)
        {
            _visualizer.Visible = cbVisualization.Checked;
        }

        private void bOpenTestForm_Click(object sender, EventArgs e)
        {
            TestForm testForm = new TestForm(this);
            testForm.Show();
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_dBManager.GetRecordsCount() > 100)
            {
                var window = MessageBox.Show("Записей в БД много, ты уверен?",
                                            "Закрыть окно?",
                                            MessageBoxButtons.YesNo);

                e.Cancel = (window == DialogResult.No);
            }
        }

        private void bgwRecordsAdding_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;

            if (Int32.TryParse(tbAddRndRecords.Text, out int res))
            {
                if (res > 100 && cbVisualization.Checked)
                {
                    MessageBox.Show("Внимание! Выключи визуализацию!");
                    bgwRecordsAdding.CancelAsync();
                    return;
                }

                _dBManager.FillTableWithRandomValues(res, backgroundWorker, e);

                int recordsCount = _dBManager.GetRecordsCount();
                if (InvokeRequired)
                    this.Invoke(new Action(() => lbDBRecordsCount.Text = $"DB records count: {recordsCount}"));
            }

            if (InvokeRequired)
                this.Invoke(new Action(() => bCancelAddingRecords.Enabled = false));
        }

        private void bgwRecordsAdding_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbDBProgress.Value = e.ProgressPercentage;
            pbDBProgress.Update();
        }

        private void bCancelAddingRecords_Click(object sender, EventArgs e)
        {
            bgwRecordsAdding.CancelAsync();
            pbDBProgress.Value = 0;
        }

        private void bgwRecordsDeleting_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;

            if (Int32.TryParse(tbAddRndRecords.Text, out int res))
            {
                _dBManager.DeleteRecordsFromTable(res, backgroundWorker, e);

                int recordsCount = _dBManager.GetRecordsCount();
                if (InvokeRequired)
                    this.Invoke(new Action(() => lbDBRecordsCount.Text = $"DB records count: {recordsCount}"));
            }

            if (InvokeRequired)
                this.Invoke(new Action(() => bCancelDeletingRecords.Enabled = false));
        }

        private void bgwRecordsDeleting_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbDBProgress.Value = e.ProgressPercentage;
            pbDBProgress.Update();
        }

        private void bgwRecordsAdding_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (cbAutoRebuild.Checked)
                RebuildTree();
        }

        private void bgwRecordsDeleting_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (cbAutoRebuild.Checked)
                RebuildTree();
        }

        private void bRunSQLProcedures_Click(object sender, EventArgs e)
        {
            _dBManager.RunStoredSQLProcedures("..\\..\\SQLQueries\\ExtralightSeriesOfRadialBearings.sql",
                                               "..\\..\\SQLQueries\\SuperlightSeriesOfRadialBearings.sql");
            RebuildTree();
        }

        private void bRebuild_Click(object sender, EventArgs e)
        {
            RebuildTree();
        }
    }
}
