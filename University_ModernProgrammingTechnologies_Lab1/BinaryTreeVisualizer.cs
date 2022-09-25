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
        public static int widthMultiplier = 30;
        private Pen _pen;
        private SolidBrush _brush;
        private SolidBrush _fontBrush;
        private BinaryTree<RadialBearing> _tree;
        private List<BinaryTreeVisualizerNode> _nodes;
        private Graphics _graphics;
        public int xOffset = 0;
        public int yOffset = 0;
        private int hS;
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

            Width = Parent.Width;
            Height = Parent.Height;

            Paint += BinaryTreeVisualizer_Paint;
            MouseWheel += BinaryTreeVisualizer_MouseWheel;
            MouseMove += BinaryTreeVisualizer_MouseMove;
            KeyDown += BinaryTreeVisualizer_KeyDown;
            KeyUp += BinaryTreeVisualizer_KeyUp;

            typeof(BinaryTreeVisualizer).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            this, new object[] { true });

            CreateNodes();
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
            }

            _mouseX = e.X;
            _mouseY = e.Y;
        }

        private void BinaryTreeVisualizer_MouseWheel(object sender, MouseEventArgs e)
        {
            if (_shiftPressed)
            {
                if (e.Delta > 0)
                    widthMultiplier += 10;
                else
                    if (widthMultiplier > 0)
                    widthMultiplier -= 10;
            }
            else
            {
                if (e.Delta > 0)
                    BinaryTreeVisualizerNode.nodeSize += 2;
                else
                    if (BinaryTreeVisualizerNode.nodeSize > 2)
                    BinaryTreeVisualizerNode.nodeSize -= 2;
            }
        }

        private void BinaryTreeVisualizer_Paint(object sender, PaintEventArgs e)
        {
            _graphics = e.Graphics;
            Draw();
        }

        public void Draw()
        {
            hS = BinaryTreeVisualizerNode.nodeSize / 2;

            RecalculateNodes();
            //connectiong lines drawing
            for (int i = 0; i < _nodes.Count; i++)
            {
                if (_nodes[i].ParentNode != null)
                    _graphics.DrawLine(_pen, _nodes[i].X + hS + xOffset,
                                       _nodes[i].Y + hS + yOffset,
                                       _nodes[i].ParentNode.X + hS + xOffset,
                                       _nodes[i].ParentNode.Y + hS + yOffset);
            }

            //nodes drawing (also nodes labels)
            for (int i = 0; i < _nodes.Count; i++)
            {
                _graphics.FillEllipse(_brush, new Rectangle(_nodes[i].X + xOffset, _nodes[i].Y + yOffset,
                                                          BinaryTreeVisualizerNode.nodeSize,
                                                          BinaryTreeVisualizerNode.nodeSize));
                _graphics.DrawEllipse(_pen, new Rectangle(_nodes[i].X + xOffset, _nodes[i].Y + yOffset,
                                                          BinaryTreeVisualizerNode.nodeSize,
                                                          BinaryTreeVisualizerNode.nodeSize));

                Font font = new Font(Name = "Times New Roman", BinaryTreeVisualizerNode.nodeSize / 3.5f);
                string valueString = _nodes[i].TreeItem.Item.C.ToString();
                SizeF stringSize = _graphics.MeasureString(valueString, font);
                PointF stringLocation = new PointF(_nodes[i].X + xOffset + BinaryTreeVisualizerNode.nodeSize / 2 - stringSize.Width / 2,
                                                   _nodes[i].Y + yOffset + BinaryTreeVisualizerNode.nodeSize / 2 - stringSize.Height / 2);
                _graphics.DrawString(valueString, font, _fontBrush, stringLocation);
            }

            Invalidate();
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

        private void RecalculateNodes()
        {
            _width = BinaryTreeVisualizerNode.nodeSize * widthMultiplier;

            _nodes[0].X = InterpolateX(_nodes[0].TreeItem.Item.C, _tree.MinValue, _tree.MaxValue, 0, _width) + Width / 2;
            _nodes[0].Y = BinaryTreeVisualizerNode.nodeSize;
            //_nodes[0].Width = BinaryTreeVisualizerNode.nodeSize;
            //_nodes[0].Height = BinaryTreeVisualizerNode.nodeSize;
            //_nodes[0].Left = _nodes[0].X;
            //_nodes[0].Top = _nodes[0].Y;

            for (int i = 1; i < _nodes.Count; i++)
            {
                _nodes[i].X = InterpolateX(_nodes[i].TreeItem.Item.C, _tree.MinValue, _tree.MaxValue, 0, _width) + Width / 2;
                _nodes[i].Y = _nodes[i].ParentNode.Y + BinaryTreeVisualizerNode.nodeSize * 2;
                //_nodes[i].Width = BinaryTreeVisualizerNode.nodeSize;
                //_nodes[i].Height = BinaryTreeVisualizerNode.nodeSize;
                //_nodes[i].Left = _nodes[i].X;
                //_nodes[i].Top = _nodes[i].Y;
            }
        }

        private int InterpolateX(int x, int x1, int x2, int y1, int y2)
        {
            return y1 + (y2 - y1) * (x - x1) / (x2 - x1);
        }
    }
}
