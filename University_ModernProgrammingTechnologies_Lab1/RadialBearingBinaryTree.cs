using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace University_ModernProgrammingTechnologies_Lab1
{
    internal sealed class RadialBearingBinaryTree : BinaryTree<RadialBearing>
    {
        private protected override BinaryTreeItem<RadialBearing> _rootItem { get; set; }

        public override void Clear()
        {
            
        }

        public override void Insert(RadialBearing radialBearing)
        {
            BinaryTreeItem<RadialBearing> binaryTreeItem = new BinaryTreeItem<RadialBearing>(radialBearing);

            if (_rootItem == null)
            {
                _rootItem = binaryTreeItem;
                return;
            }

            _Insert(_rootItem, binaryTreeItem);
        }

        public override bool IsEmpty()
        {
            //временная заглушка
            return true;
        }

        public override void Recount()
        {
            
        }

        public override void Remove()
        {
            
        }

        public override void Search()
        {
            
        }

        private protected override void _Insert(BinaryTreeItem<RadialBearing> currentBearing, BinaryTreeItem<RadialBearing> newBearing)
        {
            if (newBearing.Item.C < currentBearing.Item.C)
            {
                if (currentBearing.LeftItem == null)
                    currentBearing.LeftItem = newBearing;
                else
                    _Insert(currentBearing.LeftItem, newBearing);
            }
            else if (newBearing.Item.C > currentBearing.Item.C)
            {
                if (currentBearing.RightItem == null)
                    currentBearing.RightItem = newBearing;
                else
                    _Insert(currentBearing.RightItem, newBearing);
            }
            else
            {
                MessageBox.Show(ELEMENT_EXIST_MESSAGE);
            }
        }

        public void BuildBinaryTreeFromDBTable(SqlConnection connection, string tableName)
        {

        }
    }
}
