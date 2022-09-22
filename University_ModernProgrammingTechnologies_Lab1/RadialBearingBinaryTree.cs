using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Xml.Linq;

namespace University_ModernProgrammingTechnologies_Lab1
{
    internal sealed class RadialBearingBinaryTree : BinaryTree<RadialBearing>
    {
        public override void Clear()
        {
            
        }

        public override void Insert(RadialBearing radialBearing)
        {
            BinaryTreeItem<RadialBearing> binaryTreeItem = new BinaryTreeItem<RadialBearing>(radialBearing);

            if (_rootItem == null)
            {
                _rootItem = binaryTreeItem;
                ItemCount++;
                return;
            }

            _Insert(_rootItem, binaryTreeItem);
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
                if (currentBearing.leftItem == null)
                {
                    currentBearing.leftItem = newBearing;
                    ItemCount++;
                }
                else 
                    _Insert(currentBearing.leftItem, newBearing);

            }
            else if (newBearing.Item.C > currentBearing.Item.C)
            {
                if (currentBearing.rightItem == null)
                {
                    currentBearing.rightItem = newBearing;
                    ItemCount++;
                }
                else
                    _Insert(currentBearing.rightItem, newBearing);
            }
            else
            {
                MessageBox.Show(ELEMENT_EXIST_MESSAGE);
            }
        }

        public void BuildBinaryTreeFromDBTable(SqlConnection connection, string tableName)
        {
            string oString = $"Select * from {tableName}";
            SqlCommand oCmd = new SqlCommand(oString, connection);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            using (SqlDataReader oReader = oCmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    RadialBearing radialBearing = new RadialBearing(oReader["Designation"].ToString(),
                                                                    Convert.ToInt32(oReader["Din"]),
                                                                    Convert.ToInt32(oReader["Dex"]),
                                                                    Convert.ToInt32(oReader["B"]),
                                                                    Convert.ToInt32(oReader["C"]),
                                                                    Convert.ToInt32(oReader["C0"]));

                    Insert(radialBearing);
                }

                connection.Close();
            }
        }
    }
}
