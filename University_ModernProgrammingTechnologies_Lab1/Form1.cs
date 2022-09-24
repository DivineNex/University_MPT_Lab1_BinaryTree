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
        private Timer _drawTimer;
        private bool _shiftPressed = false;

        public formMain()
        {
            InitializeComponent();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            _dBManager = new DBManager();
            _drawTimer = new Timer() { Interval = 20 };

            InitBinaryTree();
            InitVisualizer();
            
            pictureBox1.MouseWheel += PictureBox1_MouseWheel;
            _drawTimer.Tick += _drawTimer_Tick;
            splitContainer1.KeyDown += SplitContainer1_KeyDown;
            splitContainer1.KeyUp += SplitContainer1_KeyUp;

            typeof(PictureBox).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
           | BindingFlags.Instance | BindingFlags.NonPublic, null,
           pictureBox1, new object[] { true });
        }

        private void SplitContainer1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
                _shiftPressed = false;
        }

        private void SplitContainer1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
                _shiftPressed = true;
        }

        private void _drawTimer_Tick(object sender, EventArgs e)
        {
            _visualizer.Draw();
        }

        private void PictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (_shiftPressed)
            {
                if (e.Delta > 0)
                    BinaryTreeVisualizer.widthMultiplier += 10;
                else
                    if (BinaryTreeVisualizer.widthMultiplier > 0)
                        BinaryTreeVisualizer.widthMultiplier -= 10;
            }
            else
            {
                if (e.Delta > 0)
                    BinaryTreeVisualizerNode.node_size += 2;
                else
                    BinaryTreeVisualizerNode.node_size -= 2;
            }

        }

        private void InitBinaryTree()
        {
            _binaryTree = new RadialBearingBinaryTree();
            _binaryTree.BuildBinaryTreeFromDBTable(_dBManager.connection, "RadialBearings");
        }

        private void InitVisualizer()
        {
            _visualizer = new BinaryTreeVisualizer(pictureBox1, _binaryTree);
            _visualizer.Parent = this;
            _visualizer.Width = Width;
            Controls.Add(_visualizer);
            _drawTimer.Start();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                _mouseOffsetX = e.X - _mouseX;
                _mouseOffsetY = e.Y - _mouseY;

                _visualizer.xOffset += _mouseOffsetX;
                _visualizer.yOffset += _mouseOffsetY;
            }

            _mouseX = e.X;
            _mouseY = e.Y;
        }

        private void formMain_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void formMain_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
