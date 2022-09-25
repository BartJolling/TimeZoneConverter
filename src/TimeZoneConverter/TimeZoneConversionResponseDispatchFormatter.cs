using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Runtime.Serialization;
using TimeZoneConverter.Contracts;

namespace TimeZoneConverter;

public class TimeZoneConversionResponseDispatchFormatter : IDispatchMessageFormatter
{
    private IDispatchMessageFormatter InnerDispatchFormatter { get; set; }
    XmlObjectSerializer Serializer { get; set; }

    public TimeZoneConversionResponseDispatchFormatter(IDispatchMessageFormatter formatter)
    {
        InnerDispatchFormatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
        Serializer = new TimeZoneConversionResponseSerializer();
    }

    #region server
    public void DeserializeRequest(Message message, object[] parameters)
    {
        InnerDispatchFormatter.DeserializeRequest(message, parameters);
    }

    public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
    {
        var wrappedResponse = result as ConvertToOffsetResponse;
        var response = wrappedResponse.TimeZoneConversionResponse;

        Message message = Message.CreateMessage(messageVersion, "ConvertToOffset", response, Serializer);
        return message;
    }
    #endregion
}