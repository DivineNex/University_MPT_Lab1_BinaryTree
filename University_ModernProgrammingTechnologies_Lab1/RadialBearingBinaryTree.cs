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
using System.ComponentModel;

namespace University_ModernProgrammingTechnologies_Lab1
{
    internal sealed class RadialBearingBinaryTree : BinaryTree
    {
        public BearingParam bearingParam { get; private set; } = BearingParam.None;
        public Timer Timer { get; private set; }

        public override void Clear(ref BinaryTreeItem item)
        {
            if (item.leftItem != null)
                Clear(ref item.leftItem);
            if (item.rightItem != null)
                Clear(ref item.rightItem);

            item = null;
        }

        public override void Insert(double value, string dbKey)
        {
            int paramValue = 0;

            if (_rootItem == null)
            {
                _rootItem = new BinaryTreeItem(value, dbKey);
                ItemCount++;
                _minValue = paramValue;
                _maxValue = paramValue;
                return;
            }

            _Insert(_rootItem, value, dbKey);
        }

        public override void RemoveItem(ref BinaryTreeItem bearing)
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

        private void _RemoveItem(ref BinaryTreeItem bearing)
        {
            if (bearing.rightItem != null)
                _RemoveItem(ref bearing.rightItem);
            if (bearing.leftItem != null)
                _RemoveItem(ref bearing.leftItem);

            BinaryTreeItem copyBearing = bearing;

            bearing.Dispose();
            bearing = null;

            foreach (var key in copyBearing.dbKeys)
                Insert(copyBearing.Value, key);
        }

        public void Search(BinaryTreeItem item, double value)
        {
            if (item.Value == value)
            {
                item.FoundBySearch = true;
                return;
            }

            if (item.leftItem != null)
                Search(item.leftItem, value);
            if (item.rightItem != null)
                Search(item.rightItem, value);
        }

        public void SearchByHalfDividing(BinaryTreeItem item, double value)
        {
            if (item.Value == value)
            {
                item.FoundBySearch = true;
                return;
            }
            if (item.Value < value)
            {
                if (item.rightItem != null)
                    SearchByHalfDividing(item.rightItem, value);
            }
            else if (item.Value > value)
            {
                if (item.leftItem != null)
                    SearchByHalfDividing(item.leftItem, value);
            }
        }

        private protected override void _Insert(BinaryTreeItem currentBearing, double value, string dbKey)
        {
            double currentBearingParamValue = currentBearing.Value;
            double newBearingParamValue = value;

            if (newBearingParamValue < currentBearingParamValue)
            {
                if (currentBearing.leftItem == null)
                {
                    BinaryTreeItem newItem = new BinaryTreeItem(value, dbKey);
                    currentBearing.leftItem = newItem;
                    newItem.parentItem = currentBearing;
                    ItemCount++;
                }
                else 
                    _Insert(currentBearing.leftItem, value, dbKey);
            }
            else if (newBearingParamValue > currentBearingParamValue)
            {
                if (currentBearing.rightItem == null)
                {
                    BinaryTreeItem newItem = new BinaryTreeItem(value, dbKey);
                    currentBearing.rightItem = newItem;
                    newItem.parentItem = currentBearing;
                    ItemCount++;
                }
                else
                    _Insert(currentBearing.rightItem, value, dbKey);
            }
            else
            {
                currentBearing.dbKeys.Add(dbKey);
            }

            if (newBearingParamValue < _minValue)
            {
                _minValue = value;
            }
            else if (newBearingParamValue > _maxValue)
            {
                _maxValue = value;
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
                    string key = oReader["Id"].ToString();
                    RadialBearing radialBearing = new RadialBearing(oReader["Designation"].ToString(),
                                                                    Convert.ToInt32(oReader["Din"]),
                                                                    Convert.ToInt32(oReader["Dex"]),
                                                                    Convert.ToInt32(oReader["B"]),
                                                                    Convert.ToInt32(oReader["C"]),
                                                                    Convert.ToInt32(oReader["C0"]));

                    switch (param)
                    {
                        case BearingParam.d:
                            Insert(radialBearing.d, key);
                            break;
                        case BearingParam.D:
                            Insert(radialBearing.D, key);
                            break;
                        case BearingParam.B:
                            Insert(radialBearing.B, key);
                            break;
                        case BearingParam.C:
                            Insert(radialBearing.C, key);
                            break;
                        case BearingParam.C0:
                            Insert(radialBearing.C0, key);
                            break;
                    }
                }

                connection.Close();
            }
        }

        public void ResetSearch(BinaryTreeItem item)
        {
            if (item != null)
                item.FoundBySearch = false;
            if (item.leftItem != null)
                ResetSearch(item.leftItem);
            if (item.rightItem != null)
                ResetSearch(item.rightItem);
        }
    }
}
