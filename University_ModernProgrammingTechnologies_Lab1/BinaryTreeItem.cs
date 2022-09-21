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
        public BinaryTreeItem<T> LeftItem { get; set; }
        public BinaryTreeItem<T> RightItem { get; set; }

        public BinaryTreeItem(T item)
        {
            Item = item;
            LeftItem = null;
            RightItem = null;
        }
    }
}
