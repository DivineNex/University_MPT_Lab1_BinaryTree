using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_ModernProgrammingTechnologies_Lab1
{
    internal class BinaryTreeVisualizer : Control
    {
        private Pen _pen;
        private SolidBrush _brush;
        private PictureBox _pictureBox;
        private BinaryTree<RadialBearing> _tree;
        private List<BinaryTreeVisualizerNode> _nodes;
        private Graphics _graphics;
        public int xOffset = 0;
        public int yOffset = 0;

        public BinaryTreeVisualizer(PictureBox pictureBox, RadialBearingBinaryTree binaryTree)
        {
            _pictureBox = pictureBox;
            _pictureBox.Image = new Bitmap(_pictureBox.Width, _pictureBox.Height);
            _tree = binaryTree;
            _pen = new Pen(Color.DarkGray);
            _brush = new SolidBrush(Color.PeachPuff);
            _graphics = Graphics.FromImage(pictureBox.Image);
            _nodes = new List<BinaryTreeVisualizerNode>();
            CreateNodes();
        }

        public void Draw()
        {
            _pictureBox.Image = new Bitmap(_pictureBox.Width, _pictureBox.Height);
            _graphics = Graphics.FromImage(_pictureBox.Image);
            int hS = BinaryTreeVisualizerNode.node_size / 2;

            foreach (var node in _nodes)
            {
                if (node.ParentNode != null)
                    _graphics.DrawLine(_pen, node.X + hS + xOffset, 
                                       node.Y + hS + yOffset,
                                       node.ParentNode.X + hS + xOffset, 
                                       node.ParentNode.Y + hS + yOffset);
            }

            foreach (var node in _nodes)
            {   
                _graphics.FillEllipse(_brush, new Rectangle(node.X + xOffset, node.Y + yOffset,
                                                          BinaryTreeVisualizerNode.node_size,
                                                          BinaryTreeVisualizerNode.node_size));
                _graphics.DrawEllipse(_pen, new Rectangle(node.X + xOffset, node.Y + yOffset,
                                                          BinaryTreeVisualizerNode.node_size,
                                                          BinaryTreeVisualizerNode.node_size));
            }

            _pictureBox.Invalidate();
        }

        public void CreateNodes()
        {
            _nodes.Clear();

            //root node creation
            int x = _pictureBox.Width / 2;
            int y = BinaryTreeVisualizerNode.node_size;
            BinaryTreeVisualizerNode rootNode = new BinaryTreeVisualizerNode(x,y,
                                                                             _tree.RootItem, null);
            _nodes.Add(rootNode);
            Controls.Add(rootNode);
            _CreateNodeChilds(rootNode);
        } 

        private void _CreateNodeChilds(BinaryTreeVisualizerNode node)
        {
            if (node.TreeItem.leftItem != null)
            {
                BinaryTreeVisualizerNode newNode = new BinaryTreeVisualizerNode(node.X - BinaryTreeVisualizerNode.node_size * 2,
                                                                                node.Y + BinaryTreeVisualizerNode.node_size * 2,
                                                                                node.TreeItem.leftItem, node);
                _nodes.Add(newNode);
                Controls.Add(newNode);
                _CreateNodeChilds(newNode);
            }

            if (node.TreeItem.rightItem != null)
            {
                BinaryTreeVisualizerNode newNode = new BinaryTreeVisualizerNode(node.X + BinaryTreeVisualizerNode.node_size * 2,
                                                                                node.Y + BinaryTreeVisualizerNode.node_size * 2,
                                                                                node.TreeItem.rightItem, node);
                _nodes.Add(newNode);
                Controls.Add(newNode);
                _CreateNodeChilds(newNode);
            }
        }

        public void RecalculateNodes()
        {
            CreateNodes();
        }
    }
}
