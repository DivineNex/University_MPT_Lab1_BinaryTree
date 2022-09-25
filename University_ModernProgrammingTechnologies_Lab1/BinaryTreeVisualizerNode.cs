using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_ModernProgrammingTechnologies_Lab1
{
    internal class BinaryTreeVisualizerNode : Control
    {
        public static int nodeSize = 25;

        private int x;
        public int X
        {
            get { return x; }
            set { x = value; Left = value; }
        }

        private int y;
        public int Y
        {
            get { return y; }
            set { y = value; Top = value; }
        }

        public BinaryTreeItem<RadialBearing> TreeItem { get; private set; }
        public BinaryTreeVisualizerNode LeftNode { get; set; } = null;
        public BinaryTreeVisualizerNode RightNode { get; set; } = null;
        public BinaryTreeVisualizerNode ParentNode { get; private set; } = null;

        private Pen _pen;

        public BinaryTreeVisualizerNode(BinaryTreeVisualizer visualizer, BinaryTreeItem<RadialBearing> treeItem, BinaryTreeVisualizerNode parentNode)
        {
            Size = new Size(nodeSize, nodeSize);
            TreeItem = treeItem;
            ParentNode = parentNode;

            visualizer.Controls.Add(this);
            Parent = visualizer;
            BackColor = Color.Blue;

            _pen = new Pen(Color.DarkGray);
            _pen.DashPattern = new float[] { 2, 2 };

            MouseMove += BinaryTreeVisualizerNode_MouseMove;

            Location = new Point(X, Y);
        }

        private void BinaryTreeVisualizerNode_MouseMove(object sender, MouseEventArgs e)
        {
            MessageBox.Show("lol");
            //_graphics.DrawRectangle(_pen, X, Y, Width, Height);
        }
    }
}
