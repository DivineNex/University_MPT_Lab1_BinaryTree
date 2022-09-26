using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_ModernProgrammingTechnologies_Lab1
{
    internal class BinaryTreeItem<T>
    {
        public T Item { get; private set; }
        public BinaryTreeItem<T> leftItem;
        public BinaryTreeItem<T> rightItem;
        public bool Active { get; set; } = true;

        public BinaryTreeItem(T item)
        {
            Item = item;
            leftItem = null;
            rightItem = null;
        }
    }
}
