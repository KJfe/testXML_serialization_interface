using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace testXML_serialization_interface
{  
    class Program
    {
        public List<IVolumeFigure> ListFigureParametrs = new List<IVolumeFigure>(); 


        static void Main(string[] args)
        {
            ListFigure list = new ListFigure
            {
                VolumeFigure = new ListOfIDispatcher
                {
                    new Box{ Height=2,Width=5,Deep=9}
                }

            };

            list.VolumeFigure.Add(new Sphear {Radius=5 });

            //serialize
            var xmlSerializer = new XmlSerializer(typeof(ListFigure));
            using (StreamWriter writer = new StreamWriter("E:\\vol.xml"))
            {
                xmlSerializer.Serialize(writer, list);
                writer.Close();
            }

            //deserialize
            xmlSerializer = new XmlSerializer(typeof(ListFigure));
            var xmlReader = XmlReader.Create(new StringReader("E:\\vol.xml"));
            var deserializedOrder = (ListFigure)xmlSerializer.Deserialize(xmlReader);

            //ListFigureParametrs.Add( xmlReader);

            Console.ReadLine();
        }
    }
}


