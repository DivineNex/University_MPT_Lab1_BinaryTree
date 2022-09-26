using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace University_ModernProgrammingTechnologies_Lab1
{
    internal class BinaryTreeVisualizer : Control
    {
        public static int widthScale = 30;
        private int _width;
        private Pen _pen;
        private SolidBrush _brush;
        private SolidBrush _fontBrush;
        private RadialBearingBinaryTree _tree;
        private List<BinaryTreeVisualizerNode> _nodes;
        public int xOffset = 0;
        public int yOffset = 0;
        private int _mouseX = 0;
        private int _mouseY = 0;
        private bool _shiftPressed = false;
        private bool _infoPanelShowing = false;
        private BinaryTreeVisualizerNode _nodeInfoPanelShowing = null;

        public bool IsSearching { get; set; } = false;

        public BinaryTreeVisualizer(Control parent, RadialBearingBinaryTree binaryTree)
        {
            _tree = binaryTree;
            _pen = new Pen(Color.DarkGray);
            _brush = new SolidBrush(Color.FromArgb(210, 185, 255));
            _fontBrush = new SolidBrush(Color.Black);
            _nodes = new List<BinaryTreeVisualizerNode>();

            Parent = parent;
            parent.Controls.Add(this);

            Size = new Size(Parent.Width, Parent.Height);

            Paint += BinaryTreeVisualizer_Paint;
            MouseWheel += BinaryTreeVisualizer_MouseWheel;
            MouseClick += BinaryTreeVisualizer_MouseClick;
            MouseMove += BinaryTreeVisualizer_MouseMove;
            KeyDown += BinaryTreeVisualizer_KeyDown;
            KeyUp += BinaryTreeVisualizer_KeyUp;
        }

        public void UpdateAndDraw()
        {
            RecalculateNodesPosition();
            Refresh();
        }

        private void Clear()
        {
            foreach (var node in _nodes)
                node.Dispose();
            _nodes.Clear();
        }

        private void BinaryTreeVisualizer_MouseClick(object sender, MouseEventArgs e)
        {
            _nodeInfoPanelShowing = null;
            if (e.Button != MouseButtons.Middle)
            {
                if (_infoPanelShowing)
                {
                    _infoPanelShowing = false;
                    Refresh();
                }
            }
        }

        private void BinaryTreeVisualizer_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            Draw(e.Graphics);
        }

        //removes flickering
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public void Draw(Graphics graphics)
        {
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            DrawConnectionLines(graphics);
            DrawNodes(graphics);
            if (_nodeInfoPanelShowing != null)
                DrawNodeInfoPanel(graphics, _nodeInfoPanelShowing);
        }

        public void CreateNodes()
        {
            Clear();

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
            int itemValue = 0;

            _width = BinaryTreeVisualizerNode.nodeSize * widthScale;

            for (int i = 0; i < _nodes.Count; i++)
            {
                switch (_tree.bearingParam)
                {
                    case BearingParam.d:
                        itemValue = _nodes[i].TreeItem.Item.d;
                        break;
                    case BearingParam.D:
                        itemValue = _nodes[i].TreeItem.Item.D;
                        break;
                    case BearingParam.B:
                        itemValue = _nodes[i].TreeItem.Item.B;
                        break;
                    case BearingParam.C:
                        itemValue = _nodes[i].TreeItem.Item.C;
                        break;
                    case BearingParam.C0:
                        itemValue = _nodes[i].TreeItem.Item.C0;
                        break;
                    default:
                        break;
                }

                _nodes[i].X = InterpolateX(itemValue, _tree.MinValue, _tree.MaxValue, 0, _width) + Parent.Width / 2;
                if(i == 0)
                    _nodes[0].Y = BinaryTreeVisualizerNode.nodeSize;
                else
                    _nodes[i].Y = _nodes[i].ParentNode.Y + BinaryTreeVisualizerNode.nodeSize * 2;
                _nodes[i].Width = BinaryTreeVisualizerNode.nodeSize;
                _nodes[i].Height = BinaryTreeVisualizerNode.nodeSize;
                _nodes[i].Location = new Point(_nodes[i].X + xOffset, _nodes[i].Y + yOffset);
            }
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
                xOffset += e.X - _mouseX;
                yOffset += e.Y - _mouseY;
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

        private int InterpolateX(int x, int x1, int x2, int y1, int y2)
        {
            return y1 + (y2 - y1) * (x - x1) / (x2 - x1);
        }

        public void DrawNodeInfoPanel(BinaryTreeVisualizerNode node)
        {
            _nodeInfoPanelShowing = node;
            Refresh();
        }

        private void DrawConnectionLines(Graphics graphics)
        {
            int hS = BinaryTreeVisualizerNode.nodeSize / 2;

            for (int i = 0; i < _nodes.Count; i++)
            {
                if (_nodes[i].ParentNode != null)
                    graphics.DrawLine(_pen, _nodes[i].X + hS + xOffset,
                                       _nodes[i].Y + hS + yOffset,
                                       _nodes[i].ParentNode.X + hS + xOffset,
                                       _nodes[i].ParentNode.Y + hS + yOffset);
            }
        }

        private void DrawNodes(Graphics graphics)
        {
            //also drawing node label
            for (int i = 0; i < _nodes.Count; i++)
            {
                if (IsSearching)
                {
                    if (_nodes[i].TreeItem.Active)
                        _brush.Color = Color.Green;
                    else
                        _brush.Color = Color.Red;
                }

                graphics.FillEllipse(_brush, new Rectangle(_nodes[i].X + xOffset, _nodes[i].Y + yOffset,
                                                          BinaryTreeVisualizerNode.nodeSize,
                                                          BinaryTreeVisualizerNode.nodeSize));
                graphics.DrawEllipse(_pen, new Rectangle(_nodes[i].X + xOffset, _nodes[i].Y + yOffset,
                                                          BinaryTreeVisualizerNode.nodeSize,
                                                          BinaryTreeVisualizerNode.nodeSize));

                Font font = new Font(Name = "Arial", BinaryTreeVisualizerNode.nodeSize / 3.5f);

                string valueString = _nodes[i].TreeItem.Item.d.ToString();
                switch (_tree.bearingParam) 
                {
                    case BearingParam.d:
                        valueString = _nodes[i].TreeItem.Item.d.ToString();
                        break;
                    case BearingParam.D:
                        valueString = _nodes[i].TreeItem.Item.D.ToString();
                        break;
                    case BearingParam.B:
                        valueString = _nodes[i].TreeItem.Item.B.ToString();
                        break;
                    case BearingParam.C:
                        valueString = _nodes[i].TreeItem.Item.C.ToString();
                        break;
                    case BearingParam.C0:
                        valueString = _nodes[i].TreeItem.Item.C0.ToString();
                        break;
                    default:
                        break;
                }


                SizeF stringSize = graphics.MeasureString(valueString, font);
                PointF stringLocation = new PointF(_nodes[i].X + xOffset + BinaryTreeVisualizerNode.nodeSize / 2 - stringSize.Width / 2,
                                                   _nodes[i].Y + yOffset + BinaryTreeVisualizerNode.nodeSize / 2 - stringSize.Height / 2);
                graphics.DrawString(valueString, font, _fontBrush, stringLocation);
            }
        }

        private void DrawNodeInfoPanel(Graphics graphics, BinaryTreeVisualizerNode node)
        {
            Rectangle rect = _nodeInfoPanelShowing.ClientRectangle;
            rect.Width = BinaryTreeVisualizerNode.nodeSize * 4;
            rect.Height = BinaryTreeVisualizerNode.nodeSize * 3;
            rect.X = _nodeInfoPanelShowing.X + BinaryTreeVisualizerNode.nodeSize + xOffset;
            rect.Y = _nodeInfoPanelShowing.Y - rect.Height + yOffset;

            string str = $"Designation: {_nodeInfoPanelShowing.TreeItem.Item.Designation}\n" +
                $"d: {_nodeInfoPanelShowing.TreeItem.Item.d}\n" +
                $"D: {_nodeInfoPanelShowing.TreeItem.Item.D}\n" +
                $"B: {_nodeInfoPanelShowing.TreeItem.Item.B}\n" +
                $"C: {_nodeInfoPanelShowing.TreeItem.Item.C}\n" +
                $"C0: {_nodeInfoPanelShowing.TreeItem.Item.C0}";

            Font font = new Font(Name = "Arial", BinaryTreeVisualizerNode.nodeSize / 4f);
            Point stringLocation = new Point(rect.X + rect.Width / 12, rect.Y + rect.Height / 10);
            SolidBrush backgroundBrush = new SolidBrush(Color.LightGray);

            graphics.FillRectangle(backgroundBrush, rect);
            graphics.DrawRectangle(_pen, rect);
            graphics.DrawString(str, font, _fontBrush, stringLocation);

            if (!_infoPanelShowing)
            {
                _infoPanelShowing = true;
                Refresh();
            }
        }

        private void ResetBrushColor()
        {
            _brush.Color = Color.FromArgb(210, 185, 255);
        }

        public void ResetSearching()
        {
            _tree.ResetSearch(_tree.RootItem);
            ResetBrushColor();
            IsSearching = false;
            UpdateAndDraw();
        }
    }
}
