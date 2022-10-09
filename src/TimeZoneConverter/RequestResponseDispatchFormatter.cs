using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using TimeZoneConverter.Contracts;
using TimeZoneConvertor.Serializers;

namespace TimeZoneConverter;

public class RequestResponseDispatchFormatter : IDispatchMessageFormatter
{
    private readonly XmlObjectSerializer _reponseSerializer = new ConvertToOffsetResponseSerializer();
    private readonly XmlObjectSerializer _requestSerializer = new ConvertToOffsetRequestSerializer();

    public void DeserializeRequest(Message message, object[] parameters)
    {
        // Use the default WCF formatter for the request
        var request = message.GetBody<ConvertToOffsetRequest>(_requestSerializer);
        parameters[0] = request;
    }

    public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
    {
        // Use the custom serializer to format the response
        Message message = Message.CreateMessage(messageVersion, "ConvertToOffset", result, _reponseSerializer);
        return message;
    }
}