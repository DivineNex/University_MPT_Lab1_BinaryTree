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
        private protected const string ELEMENT_EXIST_MESSAGE = "The element has already in the tree";
        private protected BinaryTreeItem<T> _rootItem;

        public int ItemCount { get; private protected set; } = 0;
        public BinaryTreeItem<T> RootItem { get { return _rootItem; } }

        public BinaryTree()
        {
            _rootItem = null;
        }

        public abstract void Insert(T item);

        private protected abstract void _Insert(BinaryTreeItem<T> currentItem, BinaryTreeItem<T> newItem);

        public abstract void Remove();

        public abstract void Search();

        public abstract void Clear();
    }
}
