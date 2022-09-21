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
        private protected abstract BinaryTreeItem<T> _rootItem { get; set; }

        public BinaryTree()
        {
            _rootItem = null;
        }

        public abstract void Insert(T item);

        private protected abstract void _Insert(BinaryTreeItem<T> currentItem, BinaryTreeItem<T> newItem);

        public abstract void Remove();

        public abstract void Search();

        public abstract void Recount();

        public abstract void Clear();

        public abstract bool IsEmpty();
    }
}
