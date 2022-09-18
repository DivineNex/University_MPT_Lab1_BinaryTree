using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_ModernProgrammingTechnologies_Lab1
{
    internal class BinaryTreeItem
    {
        public RadialBearing Bearing { get; private set; }
        public BinaryTreeItem LeftItem { get; set; }
        public BinaryTreeItem RightItem { get; set; }

        public BinaryTreeItem(RadialBearing radialBearing)
        {
            Bearing = radialBearing;
            LeftItem = null;
            RightItem = null;
        }
    }
}
