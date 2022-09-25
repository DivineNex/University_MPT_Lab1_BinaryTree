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

            splitContainer1.Select();
            cbParam.SelectedIndex = 1;
        }

        private void InitBinaryTree()
        {
            _binaryTree = new RadialBearingBinaryTree();
            _binaryTree.BuildBinaryTreeFromDBTable(_dBManager.connection, "RadialBearings");
        }

        private void InitVisualizer()
        {
            _visualizer = new BinaryTreeVisualizer(pictureBox1 ,_binaryTree);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            splitContainer1.Select();
        }

        private void cbParam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
