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
using System.IO;

namespace University_ModernProgrammingTechnologies_Lab1
{
    internal sealed class RadialBearingBinaryTree : BinaryTree<RadialBearing>
    {
        public BearingParam bearingParam { get; private set; } = BearingParam.None;

        public override void Clear(ref BinaryTreeItem<RadialBearing> item)
        {
            if (item.leftItem != null)
                Clear(ref item.leftItem);
            if (item.rightItem != null)
                Clear(ref item.rightItem);

            item = null;
        }

        public override void Insert(RadialBearing radialBearing)
        {
            BinaryTreeItem<RadialBearing> binaryTreeItem = new BinaryTreeItem<RadialBearing>(radialBearing);

            int paramValue = 0;

            switch (bearingParam)
            {
                case BearingParam.d:
                    paramValue = radialBearing.d;
                    break;
                case BearingParam.D:
                    paramValue = radialBearing.D;
                    break;
                case BearingParam.B:
                    paramValue = radialBearing.B;
                    break;
                case BearingParam.C:
                    paramValue = radialBearing.C;
                    break;
                case BearingParam.C0:
                    paramValue = radialBearing.C0;
                    break;
                default:
                    break;
            }

            if (_rootItem == null)
            {
                _rootItem = binaryTreeItem;
                ItemCount++;
                _minValue = paramValue;
                _maxValue = paramValue;
                return;
            }

            _Insert(_rootItem, binaryTreeItem);
        }

        public override void RemoveItem(ref BinaryTreeItem<RadialBearing> bearing)
        {
            if (bearing.Equals(bearing.parentItem?.leftItem))
                bearing.parentItem.leftItem = null;
            else if (bearing.Equals(bearing.parentItem?.rightItem))
                bearing.parentItem.rightItem = null;

            if (bearing.rightItem != null)
                _RemoveItem(ref bearing.rightItem);
            if (bearing.leftItem != null)
                _RemoveItem(ref bearing.leftItem);

            bearing.Dispose();
            bearing = null;
            ItemCount--;
        }

        private void _RemoveItem(ref BinaryTreeItem<RadialBearing> bearing)
        {
            if (bearing.rightItem != null)
                _RemoveItem(ref bearing.rightItem);
            if (bearing.leftItem != null)
                _RemoveItem(ref bearing.leftItem);

            BinaryTreeItem<RadialBearing> copyBearing = bearing;

            bearing.Dispose();
            bearing = null;

            Insert(copyBearing.Item);
        }

        public void Search(BinaryTreeItem<RadialBearing> item, int[] values, params BearingParam[] bearingParams)
        {
            if (values.Length == bearingParams.Length)
            {
                for (int i = 0; i < bearingParams.Length; i++)
                {
                    switch (bearingParams[i])
                    {
                        case BearingParam.d:
                            if (item.Item.d != values[i])
                                item.Active = false;
                            break;
                        case BearingParam.D:
                            if (item.Item.D != values[i])
                                item.Active = false;
                            break;
                        case BearingParam.B:
                            if (item.Item.B != values[i])
                                item.Active = false;
                            break;
                        case BearingParam.C:
                            if (item.Item.C != values[i])
                                item.Active = false;
                            break;
                        case BearingParam.C0:
                            if (item.Item.C0 != values[i])
                                item.Active = false;
                            break;
                    }
                }

                if (item.leftItem != null)
                    Search(item.leftItem, values, bearingParams);
                if (item.rightItem != null)
                    Search(item.rightItem, values, bearingParams);
            }
        }

        private protected override void _Insert(BinaryTreeItem<RadialBearing> currentBearing, BinaryTreeItem<RadialBearing> newBearing)
        {
            int currentBearingParamValue = 0;
            int newBearingParamValue = 0;

            switch (bearingParam)
            {
                case BearingParam.d:
                    currentBearingParamValue = currentBearing.Item.d;
                    newBearingParamValue = newBearing.Item.d;
                    break;
                case BearingParam.D:
                    currentBearingParamValue = currentBearing.Item.D;
                    newBearingParamValue = newBearing.Item.D;
                    break;
                case BearingParam.B:
                    currentBearingParamValue = currentBearing.Item.B;
                    newBearingParamValue = newBearing.Item.B;
                    break;
                case BearingParam.C:
                    currentBearingParamValue = currentBearing.Item.C;
                    newBearingParamValue = newBearing.Item.C;
                    break;
                case BearingParam.C0:
                    currentBearingParamValue = currentBearing.Item.C0;
                    newBearingParamValue = newBearing.Item.C0;
                    break;
                default:
                    break;
            }

            if (newBearingParamValue < currentBearingParamValue)
            {
                if (currentBearing.leftItem == null)
                {
                    currentBearing.leftItem = newBearing;
                    newBearing.parentItem = currentBearing;
                    ItemCount++;
                }
                else 
                    _Insert(currentBearing.leftItem, newBearing);
            }
            else if (newBearingParamValue > currentBearingParamValue)
            {
                if (currentBearing.rightItem == null)
                {
                    currentBearing.rightItem = newBearing;
                    newBearing.parentItem = currentBearing;
                    ItemCount++;
                }
                else
                    _Insert(currentBearing.rightItem, newBearing);
            }
            else
            {
                //MessageBox.Show(ELEMENT_EXIST_MESSAGE);
            }

            if (newBearingParamValue < _minValue)
            {
                _minValue = newBearingParamValue;
            }
            else if (newBearingParamValue > _maxValue)
            {
                _maxValue = newBearingParamValue;
            }
        }

        public void BuildBinaryTreeFromDBTable(SqlConnection connection, string tableName, BearingParam param, bool randomize)
        {
            if (_rootItem != null)
            {
                Clear(ref _rootItem);
                ItemCount = 0;
            }     

            MinValue = 0;
            MaxValue = 0;

            bearingParam = param;

            string oString = "";
            if (randomize)
                oString = $"SELECT * FROM {tableName} ORDER BY NEWID()";
            else
                oString = $"Select * from {tableName}";

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

        public void ResetSearch(BinaryTreeItem<RadialBearing> item)
        {
            if (item != null)
                item.Active = true;
            if (item.leftItem != null)
                ResetSearch(item.leftItem);
            if (item.rightItem != null)
                ResetSearch(item.rightItem);
        }
    }
}
