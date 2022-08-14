using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace TimeZoneConvertor;

public class TimeZoneConversionResponseSerializerAttribute : Attribute, IOperationBehavior
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
        //InnerFormatterBehavior = operationDescription.Behaviors.Find<XmlSerializerOperationBehavior>();
        InnerFormatterBehavior = operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();

        if (InnerFormatterBehavior != null && dispatchOperation.Formatter == null)
        {
            // no formatter has been applied yet
            InnerFormatterBehavior.ApplyDispatchBehavior(operationDescription, dispatchOperation);
        }
        dispatchOperation.Formatter = new TimeZoneConversionResponseDispatchFormatter(dispatchOperation.Formatter);
    }

    public void Validate(OperationDescription operationDescription)
    {
        if (InnerFormatterBehavior != null)
        {
            InnerFormatterBehavior.Validate(operationDescription);
        }
    }
}