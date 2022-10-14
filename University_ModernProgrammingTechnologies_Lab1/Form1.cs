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

namespace University_ModernProgrammingTechnologies_Lab1
{
    public partial class formMain : Form
    {
        private DBManager _dBManager;
        private RadialBearingBinaryTree _binaryTree;
        private BinaryTreeVisualizer _visualizer;

        public formMain()
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

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
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
                switch (cmbParam.SelectedIndex)
                {
                    case 0:
                        if (cmbSearchMethod.SelectedIndex == 0)
                            _binaryTree.Search(_binaryTree.RootItem, new int[] { res }, BearingParam.d);
                        else if (cmbSearchMethod.SelectedIndex == 1)
                            _binaryTree.SearchByHalfDividing(_binaryTree.RootItem, res, BearingParam.d);
                        break;
                    case 1:
                        if (cmbSearchMethod.SelectedIndex == 0)
                            _binaryTree.Search(_binaryTree.RootItem, new int[] { res }, BearingParam.D);
                        else if (cmbSearchMethod.SelectedIndex == 1)
                            _binaryTree.SearchByHalfDividing(_binaryTree.RootItem, res, BearingParam.D);
                        break;
                    case 2:
                        if (cmbSearchMethod.SelectedIndex == 0)
                            _binaryTree.Search(_binaryTree.RootItem, new int[] { res }, BearingParam.B);
                        else if (cmbSearchMethod.SelectedIndex == 1)
                            _binaryTree.SearchByHalfDividing(_binaryTree.RootItem, res, BearingParam.B);
                        break;
                    case 3:
                        if (cmbSearchMethod.SelectedIndex == 0)
                            _binaryTree.Search(_binaryTree.RootItem, new int[] { res }, BearingParam.C);
                        else if (cmbSearchMethod.SelectedIndex == 1)
                            _binaryTree.SearchByHalfDividing(_binaryTree.RootItem, res, BearingParam.C);
                        break;
                    case 4:
                        if (cmbSearchMethod.SelectedIndex == 0)
                            _binaryTree.Search(_binaryTree.RootItem, new int[] { res }, BearingParam.C0);
                        else if (cmbSearchMethod.SelectedIndex == 1)
                            _binaryTree.SearchByHalfDividing(_binaryTree.RootItem, res, BearingParam.C0);
                        break;
                }
                stopwatch.Stop();
                lbSearchTime.Text = $"Last search time (ms): {stopwatch.ElapsedMilliseconds}";
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

        private void button1_Click(object sender, EventArgs e)
        {
            Int32.TryParse(tbAddRndRecords.Text, out int res);
            _dBManager.FillTableWithRandomValues(res);
            RebuildTree();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Int32.TryParse(tbDeleteRecords.Text, out int res);
            _dBManager.DeleteRecordsFromTable(res);
            RebuildTree();
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

            _visualizer.CreateNodes();
            _visualizer.UpdateAndDraw();
            _visualizer.Select();
            lbItemCount.Text = $"Current item count: {_binaryTree.ItemCount}";
            lbDBRecordsCount.Text = $"DB records count: {_dBManager.GetRecordsCount()}";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _visualizer.Select();
        }

        private void cbVisualization_CheckedChanged(object sender, EventArgs e)
        {
            _visualizer.Visible = cbVisualization.Checked;
        }
    }
}
