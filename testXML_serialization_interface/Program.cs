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
        /// <summary>
        /// Лист данных
        /// </summary>
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
            var xmlReader = XmlReader.Create("E:\\vol.xml");
            var deserializedOrder = (ListFigure)xmlSerializer.Deserialize(xmlReader);
            
            //возможность запихивать результат в лист
            list.VolumeFigure.Add(deserializedOrder.VolumeFigure[0]);
            List<IVolumeFigure> ListFigureParametrs2 = new List<IVolumeFigure>();
            ListFigureParametrs2.Add(deserializedOrder.VolumeFigure[0]);

            Console.ReadLine();
        }
    }
}


