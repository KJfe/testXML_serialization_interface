using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testXML_serialization_interface
{
    public class Pyramid:IVolumeFigure
    {
        public double Area;
        public double Height;

        public double Volume
        {
            get
            {
                return Math.Round((Area * Height) / 3, 3);
            }
        }

    }
}
