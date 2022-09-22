using System;
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

        public int X { get; private set; }
        public int Y { get; private set; }
        public BinaryTreeItem<RadialBearing> TreeItem { get; private set; }
        public BinaryTreeVisualizerNode LeftNode { get; private set; } = null;
        public BinaryTreeVisualizerNode RightNode { get; private set; } = null;
        public BinaryTreeVisualizerNode ParentNode { get; private set; } = null;


        public BinaryTreeVisualizerNode(int x, int y, BinaryTreeItem<RadialBearing> treeItem, BinaryTreeVisualizerNode parentNode)
        {
            X = x;
            Y = y;
            Left = x;
            Top = y;
            Width = node_size;
            Height = node_size;
            TreeItem = treeItem;
            ParentNode = parentNode;
        }
    }
}
