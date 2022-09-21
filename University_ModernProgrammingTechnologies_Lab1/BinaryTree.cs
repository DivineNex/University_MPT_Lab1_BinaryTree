using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_ModernProgrammingTechnologies_Lab1
{
    internal class BinaryTree
    {
        private const string ELEMENT_EXIST_MESSAGE = "The element has already in the tree";
        private BinaryTreeItem _rootBearing;

        public BinaryTree()
        {
            _rootBearing = null;
        }

        public void Insert(RadialBearing radialBearing)
        {
            BinaryTreeItem binaryTreeItem = new BinaryTreeItem(radialBearing);

            if (_rootBearing == null)
            {
                _rootBearing = binaryTreeItem;
                return;
            }

            _Insert(_rootBearing, binaryTreeItem);
        }

        private void _Insert(BinaryTreeItem currentItem, BinaryTreeItem newItem)
        {
            if (newItem.Bearing.C < currentItem.Bearing.C)
            {
                if (currentItem.LeftItem == null)
                    currentItem.LeftItem = newItem;
                else
                    _Insert(currentItem.LeftItem, newItem);
            }
            else if (newItem.Bearing.C > currentItem.Bearing.C)
            {
                if (currentItem.RightItem == null)
                    currentItem.RightItem = newItem;
                else
                    _Insert(currentItem.RightItem, newItem);
            }
            else
            {
                MessageBox.Show(ELEMENT_EXIST_MESSAGE);
            }
            
        }

        public void Remove()
        {

        }

        public void Search()
        {

        }

        public void Display()
        {

        }

        public void Recount()
        {

        }

        public void Clear()
        {

        }

        public bool IsEmpty()
        {
            return true;
        }
    }
}
