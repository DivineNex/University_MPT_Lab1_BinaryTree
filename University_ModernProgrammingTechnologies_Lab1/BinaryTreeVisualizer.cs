using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace University_ModernProgrammingTechnologies_Lab1
{
    internal class BinaryTreeVisualizer : Control
    {
        public static int widthScale = 30;

        private Pen _pen;
        private SolidBrush _brush;
        private SolidBrush _fontBrush;
        private BinaryTree<RadialBearing> _tree;
        private List<BinaryTreeVisualizerNode> _nodes;
        public int xOffset = 0;
        public int yOffset = 0;
        private int _width = 0;
        private int _mouseX = 0;
        private int _mouseY = 0;
        private int _mouseOffsetX = 0;
        private int _mouseOffsetY = 0;
        private bool _shiftPressed = false;


        public BinaryTreeVisualizer(Control parent, RadialBearingBinaryTree binaryTree)
        {
            _tree = binaryTree;
            _pen = new Pen(Color.DarkGray);
            _brush = new SolidBrush(Color.FromArgb(210, 185, 255));
            _fontBrush = new SolidBrush(Color.FromArgb(80, 80, 80));
            _nodes = new List<BinaryTreeVisualizerNode>();

            Parent = parent;
            parent.Controls.Add(this);

            Size = new Size(Parent.Width, Parent.Height);
            DoubleBuffered = true;

            Paint += BinaryTreeVisualizer_Paint;
            MouseWheel += BinaryTreeVisualizer_MouseWheel;
            MouseMove += BinaryTreeVisualizer_MouseMove;
            KeyDown += BinaryTreeVisualizer_KeyDown;
            KeyUp += BinaryTreeVisualizer_KeyUp;

            CreateNodes();
            UpdateAndDraw();
        }

        private void BinaryTreeVisualizer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
                _shiftPressed = false;
        }

        private void BinaryTreeVisualizer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
                _shiftPressed = true;
        }

        private void BinaryTreeVisualizer_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                _mouseOffsetX = e.X - _mouseX;
                _mouseOffsetY = e.Y - _mouseY;

                xOffset += _mouseOffsetX;
                yOffset += _mouseOffsetY;

                UpdateAndDraw();
            }

            _mouseX = e.X;
            _mouseY = e.Y;
        }

        private void BinaryTreeVisualizer_MouseWheel(object sender, MouseEventArgs e)
        {
            if (_shiftPressed)
            {
                if (e.Delta > 0)
                    widthScale += 10;
                else
                    if (widthScale > 0)
                    widthScale -= 10;
            }
            else
            {
                if (e.Delta > 0)
                    BinaryTreeVisualizerNode.nodeSize += 2;
                else
                    if (BinaryTreeVisualizerNode.nodeSize > 2)
                    BinaryTreeVisualizerNode.nodeSize -= 2;
            }

            UpdateAndDraw();
        }

        private void BinaryTreeVisualizer_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        public void Draw(Graphics graphics)
        {
            int hS = BinaryTreeVisualizerNode.nodeSize / 2;

            //connectiong lines drawing
            for (int i = 0; i < _nodes.Count; i++)
            {
                if (_nodes[i].ParentNode != null)
                    graphics.DrawLine(_pen, _nodes[i].X + hS + xOffset,
                                       _nodes[i].Y + hS + yOffset,
                                       _nodes[i].ParentNode.X + hS + xOffset,
                                       _nodes[i].ParentNode.Y + hS + yOffset);
            }

            //nodes drawing (also nodes labels)
            for (int i = 0; i < _nodes.Count; i++)
            {
                graphics.FillEllipse(_brush, new Rectangle(_nodes[i].X + xOffset, _nodes[i].Y + yOffset,
                                                          BinaryTreeVisualizerNode.nodeSize,
                                                          BinaryTreeVisualizerNode.nodeSize));
                graphics.DrawEllipse(_pen, new Rectangle(_nodes[i].X + xOffset, _nodes[i].Y + yOffset,
                                                          BinaryTreeVisualizerNode.nodeSize,
                                                          BinaryTreeVisualizerNode.nodeSize));

                Font font = new Font(Name = "Times New Roman", BinaryTreeVisualizerNode.nodeSize / 3.5f);
                string valueString = _nodes[i].TreeItem.Item.C.ToString();
                SizeF stringSize = graphics.MeasureString(valueString, font);
                PointF stringLocation = new PointF(_nodes[i].X + xOffset + BinaryTreeVisualizerNode.nodeSize / 2 - stringSize.Width / 2,
                                                   _nodes[i].Y + yOffset + BinaryTreeVisualizerNode.nodeSize / 2 - stringSize.Height / 2);
                graphics.DrawString(valueString, font, _fontBrush, stringLocation);
            }
        }

        public void CreateNodes()
        {
            _nodes.Clear();

            //root node creation
            BinaryTreeVisualizerNode rootNode = new BinaryTreeVisualizerNode(this, _tree.RootItem, null);
            _nodes.Add(rootNode);
            _CreateNodeChilds(rootNode);
        } 

        private void _CreateNodeChilds(BinaryTreeVisualizerNode node)
        {
            if (node.TreeItem.leftItem != null)
            {
                BinaryTreeVisualizerNode newNode = new BinaryTreeVisualizerNode(this, node.TreeItem.leftItem, node);
                node.LeftNode = newNode;
                _nodes.Add(newNode);
                _CreateNodeChilds(newNode);
            }

            if (node.TreeItem.rightItem != null)
            {
                BinaryTreeVisualizerNode newNode = new BinaryTreeVisualizerNode(this, node.TreeItem.rightItem, node);
                node.RightNode = newNode;
                _nodes.Add(newNode);
                _CreateNodeChilds(newNode);
            }
        }

        private void RecalculateNodesPosition()
        {
            _width = BinaryTreeVisualizerNode.nodeSize * widthScale;

            _nodes[0].X = InterpolateX(_nodes[0].TreeItem.Item.C, _tree.MinValue, _tree.MaxValue, 0, _width) + Width / 2;
            _nodes[0].Y = BinaryTreeVisualizerNode.nodeSize;
            _nodes[0].Width = BinaryTreeVisualizerNode.nodeSize;
            _nodes[0].Height = BinaryTreeVisualizerNode.nodeSize;
            _nodes[0].Left = _nodes[0].X + xOffset;
            _nodes[0].Top = _nodes[0].Y + yOffset;

            for (int i = 1; i < _nodes.Count; i++)
            {
                _nodes[i].X = InterpolateX(_nodes[i].TreeItem.Item.C, _tree.MinValue, _tree.MaxValue, 0, _width) + Width / 2;
                _nodes[i].Y = _nodes[i].ParentNode.Y + BinaryTreeVisualizerNode.nodeSize * 2;
                _nodes[i].Width = BinaryTreeVisualizerNode.nodeSize;
                _nodes[i].Height = BinaryTreeVisualizerNode.nodeSize;
                _nodes[i].Left = _nodes[i].X + xOffset;
                _nodes[i].Top = _nodes[i].Y + yOffset;
            }
        }

        private void UpdateAndDraw()
        {
            RecalculateNodesPosition();
            Refresh();
        }

        private int InterpolateX(int x, int x1, int x2, int y1, int y2)
        {
            return y1 + (y2 - y1) * (x - x1) / (x2 - x1);
        }
    }
}
