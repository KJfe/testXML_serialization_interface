using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testXML_serialization_interface
{
    public class Sphear:IVolumeFigure
    {
        public Sphear() { }

        public double Radius;

        public double Volume
        {
            get
            {
                return Math.Round(((4 * Math.PI * Math.Pow(Radius, 3)) / 3), 3);
            }
        }
    }
}
