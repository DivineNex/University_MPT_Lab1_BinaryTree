using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_ModernProgrammingTechnologies_Lab1
{
    internal class BinaryTreeItem<T> : IDisposable
    {
        public T Item { get; private set; }
        public bool FoundBySearch { get; set; } = false;

        public BinaryTreeItem<T> leftItem;
        public BinaryTreeItem<T> rightItem;
        public BinaryTreeItem<T> parentItem;

        public BinaryTreeItem(T item)
        {
            Item = item;
            leftItem = null;
            rightItem = null;
        }

        public void Dispose() {}
    }
}
