using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace TimeZoneConverter;

public class ConvertToOffsetResponseSerializerAttribute : Attribute, IOperationBehavior
{
    private IOperationBehavior InnerFormatterBehavior { get; set; }

    public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
    {
        if (InnerFormatterBehavior != null)
        {
            InnerFormatterBehavior.AddBindingParameters(operationDescription, bindingParameters);
        }
    }

    public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
    {
        throw new NotImplementedException();
    }

    public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
    {
        InnerFormatterBehavior = operationDescription.Behaviors.Find<XmlSerializerOperationBehavior>();

        if (InnerFormatterBehavior != null && dispatchOperation.Formatter == null)
        {
            // no formatter has been applied yet - initialize the formatter on the default behavior
            InnerFormatterBehavior.ApplyDispatchBehavior(operationDescription, dispatchOperation);
        }

        // Override the default formatter, but pass in the default formatter that was initialized above
        dispatchOperation.Formatter = new ConvertToOffsetDispatchFormatter(dispatchOperation.Formatter);
    }

    public void Validate(OperationDescription operationDescription)
    {
        if (InnerFormatterBehavior != null)
        {
            InnerFormatterBehavior.Validate(operationDescription);
        }
    }
}