using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using TimeZoneConverter.Contracts;

namespace TimeZoneConvertor.Serializers;

public class ConvertToOffsetResponseSerializer : XmlObjectSerializer
{

    private readonly XmlSerializer _serializer;
    private readonly XmlSerializerNamespaces namespaces;

    public ConvertToOffsetResponseSerializer()
    {
        namespaces = new XmlSerializerNamespaces();
        namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
        namespaces.Add("xsd", "http://www.w3.org/2001/XMLSchema");

        _serializer = new XmlSerializer(typeof(ConvertToOffsetResponse), SerializerOverrides(), null, null, "http://bartjolling.github.io/");
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
        if (_serializer.Deserialize(reader) is not ConvertToOffsetResponse deserializedObject)
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
        throw new NotImplementedException();
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