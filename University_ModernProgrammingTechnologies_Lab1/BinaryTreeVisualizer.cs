using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace University_ModernProgrammingTechnologies_Lab1
{
    internal class BinaryTreeVisualizer : Control
    {
        public static int widthMultiplier = 10;
        private Pen _pen;
        private SolidBrush _brush;
        private PictureBox _pictureBox;
        private BinaryTree<RadialBearing> _tree;
        private List<BinaryTreeVisualizerNode> _nodes;
        private Graphics _graphics;
        public int xOffset = 0;
        public int yOffset = 0;
        private int hS;
        private int _width = 0;

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
            hS = BinaryTreeVisualizerNode.node_size / 2;

            RecalculateNodes();
            for (int i = 0; i < _nodes.Count; i++)
            {
                if (_nodes[i].ParentNode != null)
                    _graphics.DrawLine(_pen, _nodes[i].X + hS + xOffset,
                                       _nodes[i].Y + hS + yOffset,
                                       _nodes[i].ParentNode.X + hS + xOffset,
                                       _nodes[i].ParentNode.Y + hS + yOffset);
            }

            for (int i = 0; i < _nodes.Count; i++)
            {
                _graphics.FillEllipse(_brush, new Rectangle(_nodes[i].X + xOffset, _nodes[i].Y + yOffset,
                                                          BinaryTreeVisualizerNode.node_size,
                                                          BinaryTreeVisualizerNode.node_size));
                _graphics.DrawEllipse(_pen, new Rectangle(_nodes[i].X + xOffset, _nodes[i].Y + yOffset,
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
            BinaryTreeVisualizerNode rootNode = new BinaryTreeVisualizerNode(_tree.RootItem, null);
            _nodes.Add(rootNode);
            Controls.Add(rootNode);
            _CreateNodeChilds(rootNode);
        } 

        private void _CreateNodeChilds(BinaryTreeVisualizerNode node)
        {
            if (node.TreeItem.leftItem != null)
            {
                BinaryTreeVisualizerNode newNode = new BinaryTreeVisualizerNode(node.TreeItem.leftItem, node);
                node.LeftNode = newNode;
                _nodes.Add(newNode);
                Controls.Add(newNode);
                _CreateNodeChilds(newNode);
            }

            if (node.TreeItem.rightItem != null)
            {
                BinaryTreeVisualizerNode newNode = new BinaryTreeVisualizerNode(node.TreeItem.rightItem, node);
                node.RightNode = newNode;
                _nodes.Add(newNode);
                Controls.Add(newNode);
                _CreateNodeChilds(newNode);
            }
        }

        private void RecalculateNodes()
        {
            _width = BinaryTreeVisualizerNode.node_size * widthMultiplier;

            _nodes[0].X = InterpolateX(_nodes[0].TreeItem.Item.C, _tree.MinValue, _tree.MaxValue, 0, _width);
            _nodes[0].Y = BinaryTreeVisualizerNode.node_size;

            for (int i = 1; i < _nodes.Count; i++)
            {
                _nodes[i].X = InterpolateX(_nodes[i].TreeItem.Item.C, _tree.MinValue, _tree.MaxValue, 0, _width);
                _nodes[i].Y = _nodes[i].ParentNode.Y + BinaryTreeVisualizerNode.node_size*2;
            }
        }

        private int InterpolateX(int x, int x1, int x2, int y1, int y2)
        {
            return y1 + (y2 - y1) * (x - x1) / (x2 - x1);
        }
    }
}
