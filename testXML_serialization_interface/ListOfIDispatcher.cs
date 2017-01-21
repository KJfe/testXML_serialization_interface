using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;


namespace testXML_serialization_interface
{
    public class ListOfIDispatcher : List<IVolumeFigure>, IXmlSerializable
    {
        public ListOfIDispatcher() : base() { }

        public System.Xml.Schema.XmlSchema GetSchema() { return null; }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement("VolumeFigure");
            while (reader.IsStartElement("IVolumeFigure"))
            {
                Type type = Type.GetType(reader.GetAttribute("AssemblyQualifiedName"));
                XmlSerializer serial = new XmlSerializer(type);

                reader.ReadStartElement("IVolumeFigure");
                this.Add((IVolumeFigure)serial.Deserialize(reader));
                reader.ReadEndElement();
            }
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (IVolumeFigure dispatcher in this)
            {
                writer.WriteStartElement("IVolumeFigure");
                writer.WriteAttributeString("AssemblyQualifiedName", dispatcher.GetType().AssemblyQualifiedName);
                XmlSerializer xmlSerializer = new XmlSerializer(dispatcher.GetType());
                xmlSerializer.Serialize(writer, dispatcher);
                writer.WriteEndElement();
            }
        }
    }
}
