using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_ModernProgrammingTechnologies_Lab1
{
    internal class RadialBearing
    {
        public string Designation { get; private set; }
        public int d { get; private set; }
        public int D { get; private set; }
        public int B { get; private set; }
        public int C { get; private set; }
        public int C0 { get; private set; }

        public RadialBearing(string designation, int d, int D, int B, int C, int C0)
        {
            Designation = designation;
            this.d = d;
            this.D = D;
            this.B = B;
            this.C = C;
            this.C0 = C0;
        }
    }
}
