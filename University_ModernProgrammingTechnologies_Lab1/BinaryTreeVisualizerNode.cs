﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_ModernProgrammingTechnologies_Lab1
{
    internal class BinaryTreeVisualizerNode : Control
    {
        public static int node_size = 25;

        public int X { get; set; }
        public int Y { get; set; }
        public BinaryTreeItem<RadialBearing> TreeItem { get; private set; }
        public BinaryTreeVisualizerNode LeftNode { get; set; } = null;
        public BinaryTreeVisualizerNode RightNode { get; set; } = null;
        public BinaryTreeVisualizerNode ParentNode { get; private set; } = null;


        public BinaryTreeVisualizerNode(BinaryTreeItem<RadialBearing> treeItem, BinaryTreeVisualizerNode parentNode)
        {
            Width = node_size;
            Height = node_size;
            TreeItem = treeItem;
            ParentNode = parentNode;
        }
    }
}
