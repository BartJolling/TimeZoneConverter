using CoreWCF.Channels;
using CoreWCF.Description;
using CoreWCF.Dispatcher;

namespace TimeZoneConverter;

[AttributeUsage(AttributeTargets.Method)]
public class RequestResponseSerializerAttribute : Attribute, IOperationBehavior
{
    private IOperationBehavior? XmlSerializerBehavior { get; set; }

    public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
    {
        if (XmlSerializerBehavior != null)
        {
            XmlSerializerBehavior.AddBindingParameters(operationDescription, bindingParameters);
        }
    }

    public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
    {
        throw new NotImplementedException();
    }

    public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
    {
        XmlSerializerBehavior = operationDescription.OperationBehaviors[typeof(XmlSerializerOperationBehavior)];

        if (XmlSerializerBehavior != null && dispatchOperation.Formatter == null)
        {
            // no formatter has been applied yet - set our custom formatter to avoid WCF initializing a default formatter
            dispatchOperation.Formatter = new RequestResponseDispatchFormatter();
            dispatchOperation.DeserializeRequest = true;
            dispatchOperation.SerializeReply = true;
            
            XmlSerializerBehavior.ApplyDispatchBehavior(operationDescription, dispatchOperation);
        }
    }

    public void Validate(OperationDescription operationDescription)
    {
        if (XmlSerializerBehavior != null)
        {
            XmlSerializerBehavior.Validate(operationDescription);
        }
    }
}