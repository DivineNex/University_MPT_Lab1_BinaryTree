using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_ModernProgrammingTechnologies_Lab1
{
    internal abstract class BinaryTree<T>
    {
        private protected const string ELEMENT_EXIST_MESSAGE = "The element is already in the tree";
        private protected BinaryTreeItem<T> _rootItem;
        private protected int _maxValue = Int32.MinValue;
        private protected int _minValue = Int32.MaxValue;

        public int MaxValue { get { return _maxValue; } private protected set { _maxValue = value; } }
        public int MinValue { get { return _minValue; } private protected set { _minValue = value; } }

        public int ItemCount { get; private protected set; } = 0;
        public BinaryTreeItem<T> RootItem { get { return _rootItem; } }

        public BinaryTree()
        {
            _rootItem = null;
        }

        public abstract void Insert(T item);

        private protected abstract void _Insert(BinaryTreeItem<T> currentItem, BinaryTreeItem<T> newItem);

        public abstract void Remove();

        public abstract void Clear(ref BinaryTreeItem<T> item);
    }
}
