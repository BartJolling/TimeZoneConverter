using System;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using TimeZoneConvertor.Serializers;

namespace TimeZoneConverter;

public class ResponseDispatchFormatter : IDispatchMessageFormatter
{
    private readonly IDispatchMessageFormatter _requestFormatter;
    private readonly XmlObjectSerializer _reponseSerializer;

    public ResponseDispatchFormatter(IDispatchMessageFormatter requestFormatter)
    {
        _requestFormatter = requestFormatter ?? throw new ArgumentNullException(nameof(requestFormatter));
        _reponseSerializer = new ConvertToOffsetResponseSerializer();
    }

    public void DeserializeRequest(Message message, object[] parameters)
    {
        // Use the default WCF formatter for the request
        _requestFormatter.DeserializeRequest(message, parameters);
    }

    public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
    {
        // Use the custom serializer to format the response
        Message message = Message.CreateMessage(messageVersion, "ConvertToOffset", result, _reponseSerializer);
        return message;
    }
}