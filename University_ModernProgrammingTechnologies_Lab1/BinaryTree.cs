using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_ModernProgrammingTechnologies_Lab1
{
    internal abstract class BinaryTree
    {
        private protected const string ELEMENT_EXIST_MESSAGE = "The element is already in the tree";
        private protected BinaryTreeItem _rootItem;
        private protected double _maxValue = Int32.MinValue;
        private protected double _minValue = Int32.MaxValue;

        public double MaxValue { get { return _maxValue; } private protected set { _maxValue = value; } }
        public double MinValue { get { return _minValue; } private protected set { _minValue = value; } }

        public int ItemCount { get; private protected set; } = 0;
        public BinaryTreeItem RootItem { get { return _rootItem; } }

        public BinaryTree()
        {
            _rootItem = null;
        }

        public abstract void Insert(double value, string dbKey);

        private protected abstract void _Insert(BinaryTreeItem currentItem, double value, string dbKey);

        public abstract void RemoveItem(ref BinaryTreeItem item);

        public abstract void Clear(ref BinaryTreeItem item);
    }
}
