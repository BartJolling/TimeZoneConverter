using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TimeZoneConverter
{
    public class TimeZoneConversionResponseSerializer : XmlObjectSerializer
    {
        private readonly XmlSerializer _serializer;
        private readonly XmlSerializerNamespaces namespaces;

        public TimeZoneConversionResponseSerializer()
        {
            namespaces = new XmlSerializerNamespaces();
            namespaces.Add("i", "http://www.w3.org/2001/XMLSchema-instance");

            _serializer = new XmlSerializer(typeof(TimeZoneConversionResponse), SerializerOverrides());
        }

        public static XmlAttributeOverrides SerializerOverrides()
        {
            // Ignore ToDateTime during serialization
            var toDateTimeAttributes = new XmlAttributes() { XmlIgnore = true };

            // Use ToDateTimeOffset during serialization
            var toDateTimeOffsetAttributes = new XmlAttributes();
            toDateTimeOffsetAttributes.XmlElements.Add(new XmlElementAttribute() 
            { 
                ElementName = "ToDateTime",
                Order = 0
            });

            var attributeOverrides = new XmlAttributeOverrides();

            attributeOverrides.Add(typeof(TimeZoneConversionResponse), "ToDateTime", toDateTimeAttributes);
            attributeOverrides.Add(typeof(TimeZoneConversionResponse), "ToDateTimeOffset", toDateTimeOffsetAttributes);

            return attributeOverrides;
        }

        public override bool IsStartObject(XmlDictionaryReader reader)
        {
            throw new NotImplementedException();
        }

        public override object ReadObject(XmlDictionaryReader reader, bool verifyObjectName)
        {
            if (_serializer.Deserialize(reader) is not TimeZoneConversionResponse deserializedObject)
            {
                return null;
            }

            return deserializedObject;
        }

        public override void WriteEndObject(XmlDictionaryWriter writer)
        {
            throw new NotImplementedException();
        }

        public override void WriteObjectContent(XmlDictionaryWriter writer, object graph)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            if (writer.WriteState != WriteState.Element)
                throw new SerializationException(string.Format("WriteState '{0}' not valid. Caller must write start element before serializing in contentOnly mode.", writer.WriteState));

            using MemoryStream memoryStream = new();
            using XmlDictionaryWriter bufferWriter = XmlDictionaryWriter.CreateTextWriter(memoryStream, Encoding.UTF8);

            _serializer.Serialize(bufferWriter, graph, namespaces);
            bufferWriter.Flush();
            memoryStream.Position = 0;

            using XmlReader reader = new XmlTextReader(memoryStream);
            reader.MoveToContent();
            writer.WriteAttributes(reader, false);

            if (reader.Read()) // move off start node (we want to skip it) 
            {
                while (reader.NodeType != XmlNodeType.EndElement) // also skip end node. 
                {
                    writer.WriteNode(reader, false);// this will take us to the start of the next child node, or the end node. 
                }
                reader.ReadEndElement(); // not necessary, but clean
            }
        }

        public override void WriteStartObject(XmlDictionaryWriter writer, object graph)
        {
            throw new NotImplementedException();
        }

        public override void WriteObject(XmlDictionaryWriter writer, object graph)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            _serializer.Serialize(writer, graph, namespaces);            
        }
    }
}