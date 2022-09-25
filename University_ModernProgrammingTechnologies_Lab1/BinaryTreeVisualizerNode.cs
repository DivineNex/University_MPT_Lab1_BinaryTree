﻿using System;
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

        public int X { get; set; }

        public int Y { get; set; }

        public BinaryTreeItem<RadialBearing> TreeItem { get; private set; }
        public BinaryTreeVisualizerNode LeftNode { get; set; } = null;
        public BinaryTreeVisualizerNode RightNode { get; set; } = null;
        public BinaryTreeVisualizerNode ParentNode { get; private set; } = null;

        private Pen _pen;
        private bool cursorOnIt = false;

        public BinaryTreeVisualizerNode(BinaryTreeVisualizer visualizer, BinaryTreeItem<RadialBearing> treeItem, BinaryTreeVisualizerNode parentNode)
        {
            Size = new Size(nodeSize, nodeSize);
            TreeItem = treeItem;
            ParentNode = parentNode;

            visualizer.Controls.Add(this);
            Parent = visualizer;

            _pen = new Pen(Color.Black);
            _pen.Width = 2;
            _pen.DashPattern = new float[] { 2, 2 };

            MouseEnter += BinaryTreeVisualizerNode_MouseEnter;
            MouseLeave += BinaryTreeVisualizerNode_MouseLeave;
            MouseClick += BinaryTreeVisualizerNode_MouseClick;
            Paint += BinaryTreeVisualizerNode_Paint;

            Location = new Point(X, Y);
            DoubleBuffered = true;

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        private void BinaryTreeVisualizerNode_MouseClick(object sender, MouseEventArgs e)
        {
            if (cursorOnIt)
                if (e.Button == MouseButtons.Left)
                    MessageBox.Show("Clicked!");
        }

        private void BinaryTreeVisualizerNode_MouseLeave(object sender, EventArgs e)
        {
            cursorOnIt = false;
            Refresh();
        }

        private void BinaryTreeVisualizerNode_MouseEnter(object sender, EventArgs e)
        {
            cursorOnIt = true;
            Refresh();
        }

        private void BinaryTreeVisualizerNode_Paint(object sender, PaintEventArgs e)
        {
            if (cursorOnIt)
                DrawBorder(e.Graphics);
        }

        private void DrawBorder(Graphics graphics)
        {
            graphics.DrawRectangle(_pen, ClientRectangle);
        }
    }
}
