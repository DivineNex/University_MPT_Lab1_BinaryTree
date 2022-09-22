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
        private int _mouseX = 0;
        private int _mouseY = 0;
        private int _mouseOffsetX = 0;
        private int _mouseOffsetY = 0;

        public formMain()
        {
            InitializeComponent();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            InitDBManager();
            InitBinaryTree();
            InitVisualizer();
            DoubleBuffered = true;
            pictureBox1.MouseWheel += PictureBox1_MouseWheel;

            typeof(PictureBox).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
           | BindingFlags.Instance | BindingFlags.NonPublic, null,
           pictureBox1, new object[] { true });
        }

        private void PictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                BinaryTreeVisualizerNode.node_size += 2;
            else
                BinaryTreeVisualizerNode.node_size -= 2;
            _visualizer.RecalculateNodes();
            _visualizer.Draw();
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

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                _mouseOffsetX = e.X - _mouseX;
                _mouseOffsetY = e.Y - _mouseY;

                _visualizer.xOffset += _mouseOffsetX;
                _visualizer.yOffset += _mouseOffsetY;
                _visualizer.Draw();
            }

            _mouseX = e.X;
            _mouseY = e.Y;
        }
    }
}
