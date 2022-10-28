using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_ModernProgrammingTechnologies_Lab1
{
    internal class BinaryTreeItem : IDisposable
    {
        public double Value { get; private set; }
        public bool FoundBySearch { get; set; } = false;
        public List<string> dbKeys { get; private set; } = new List<string>();
        public BinaryTreeItem leftItem;
        public BinaryTreeItem rightItem;
        public BinaryTreeItem parentItem;

        public BinaryTreeItem(double value, string dbRecordKey)
        {
            Value = value;
            dbKeys.Add(dbRecordKey);
            leftItem = null;
            rightItem = null;
        }

        public void Dispose() {}
    }
}
