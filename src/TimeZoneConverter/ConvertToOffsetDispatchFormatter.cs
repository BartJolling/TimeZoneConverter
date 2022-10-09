using System;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using TimeZoneConvertor.Serializers;

namespace TimeZoneConverter;

public class ConvertToOffsetDispatchFormatter : IDispatchMessageFormatter
{
    private IDispatchMessageFormatter InnerDispatchFormatter { get; set; }
    XmlObjectSerializer Serializer { get; set; }

    public ConvertToOffsetDispatchFormatter(IDispatchMessageFormatter formatter)
    {
        InnerDispatchFormatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
        Serializer = new ConvertToOffsetResponseSerializer();
    }

    #region server
    public void DeserializeRequest(Message message, object[] parameters)
    {
        // Use the default WCF formatter for the request
        InnerDispatchFormatter.DeserializeRequest(message, parameters);
    }

    public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
    {
        // Use the custom serializer to format the response
        Message message = Message.CreateMessage(messageVersion, "ConvertToOffset", result, Serializer);
        return message;
    }
    #endregion
}