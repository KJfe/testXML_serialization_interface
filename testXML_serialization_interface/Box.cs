using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testXML_serialization_interface
{
    public class Box:IVolumeFigure
    {
        public Box() { }

        public double Height;
        public double Width;
        public double Deep;

        public double Volume
        {
            get
            {
                return Math.Round(Height * Width * Deep, 3);
            }
        }
    }
}
