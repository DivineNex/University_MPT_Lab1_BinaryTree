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
        private protected const string ELEMENT_EXIST_MESSAGE = "The element has already in the tree";
        private protected abstract BinaryTreeItem _root { get; set; }

        public BinaryTree()
        {
            _root = null;
        }

        public abstract void Insert();

        private protected abstract void _Insert();

        public abstract void Remove();

        public abstract void Search();

        public abstract void Recount();

        public abstract void Clear();

        public abstract bool IsEmpty();
    }
}
