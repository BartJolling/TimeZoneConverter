using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using TimeZoneConverter.Contracts;

namespace TimeZoneConvertor.Serializers;

public class ConvertToOffsetRequestSerializer : XmlObjectSerializer
{
    private readonly XmlSerializer _serializer = new(typeof(ConvertToOffsetRequest), "http://bartjolling.github.io/");

    public override bool IsStartObject(XmlDictionaryReader reader)
    {
        throw new NotImplementedException();
    }

    public override object ReadObject(XmlDictionaryReader reader, bool verifyObjectName)
    {
        if (_serializer.Deserialize(reader) is not ConvertToOffsetRequest deserializedObject)
        {
            return null;
        }

        return deserializedObject;
    }

    public override void WriteObject(XmlDictionaryWriter writer, object graph)
    {
        if (writer == null)
            throw new ArgumentNullException(nameof(writer));

        _serializer.Serialize(writer, graph);
    }

    #region Not Implemented

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

    #endregion
}