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
            InitDBManager();
            InitBinaryTree();
            InitVisualizer();
        }

        private void InitDBManager()
        {
            _dBManager = new DBManager();
            _dBManager.connection.Open();
        }

        private void InitBinaryTree()
        {
            _binaryTree = new RadialBearingBinaryTree();
            _binaryTree.BuildBinaryTreeFromDBTable(_dBManager.connection, "RadialBearings");
        }

        private void InitVisualizer()
        {
            _visualizer = new BinaryTreeVisualizer(pictureBox1, _binaryTree);
            Controls.Add(_visualizer);
            _visualizer.Draw();
        }

        private void formMain_Resize(object sender, EventArgs e)
        {
            _visualizer.Draw();
        }
    }
}
