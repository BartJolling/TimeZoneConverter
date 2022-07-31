﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TimeZoneConvertor
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TimeZoneConversionRequest", Namespace="http://thosa.it/")]
    public partial class TimeZoneConversionRequest : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private System.DateTime FromDateTimeField;
        
        private System.TimeSpan FromOffsetField;
        
        private System.TimeSpan ToOffsetField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.DateTime FromDateTime
        {
            get
            {
                return this.FromDateTimeField;
            }
            set
            {
                this.FromDateTimeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.TimeSpan FromOffset
        {
            get
            {
                return this.FromOffsetField;
            }
            set
            {
                this.FromOffsetField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.TimeSpan ToOffset
        {
            get
            {
                return this.ToOffsetField;
            }
            set
            {
                this.ToOffsetField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TimeZoneConversionResponse", Namespace="http://thosa.it/")]
    public partial class TimeZoneConversionResponse : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private System.DateTime ToDateTimeField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.DateTime ToDateTime
        {
            get
            {
                return this.ToDateTimeField;
            }
            set
            {
                this.ToDateTimeField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://thosa.it/", ConfigurationName="TimeZoneConvertor.ITimeZoneConvertor")]
    public interface ITimeZoneConvertor
    {
        
        // CODEGEN: Generating message contract since the wrapper name (ConvertToOffsetRequest) of message ConvertToOffsetRequest does not match the default value (ConvertToOffset)
        [System.ServiceModel.OperationContractAttribute(Action="http://thosa.it/ITimeZoneConvertor/ConvertToOffsetRequest", ReplyAction="http://thosa.it/ITimeZoneConvertor/ConvertToOffsetResponse")]
        TimeZoneConvertor.ConvertToOffsetResponse ConvertToOffset(TimeZoneConvertor.ConvertToOffsetRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ConvertToOffsetRequest", WrapperNamespace="http://thosa.it/", IsWrapped=true)]
    public partial class ConvertToOffsetRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://thosa.it/", Order=0)]
        public TimeZoneConvertor.TimeZoneConversionRequest TimeZoneConversionRequest;
        
        public ConvertToOffsetRequest()
        {
        }
        
        public ConvertToOffsetRequest(TimeZoneConvertor.TimeZoneConversionRequest TimeZoneConversionRequest)
        {
            this.TimeZoneConversionRequest = TimeZoneConversionRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ConvertToOffsetResponse", WrapperNamespace="http://thosa.it/", IsWrapped=true)]
    public partial class ConvertToOffsetResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://thosa.it/", Order=0)]
        public TimeZoneConvertor.TimeZoneConversionResponse TimeZoneConversionResponse;
        
        public ConvertToOffsetResponse()
        {
        }
        
        public ConvertToOffsetResponse(TimeZoneConvertor.TimeZoneConversionResponse TimeZoneConversionResponse)
        {
            this.TimeZoneConversionResponse = TimeZoneConversionResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITimeZoneConvertorChannel : TimeZoneConvertor.ITimeZoneConvertor, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TimeZoneConvertorClient : System.ServiceModel.ClientBase<TimeZoneConvertor.ITimeZoneConvertor>, TimeZoneConvertor.ITimeZoneConvertor
    {
        
        public TimeZoneConvertorClient()
        {
        }
        
        public TimeZoneConvertorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public TimeZoneConvertorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public TimeZoneConvertorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public TimeZoneConvertorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TimeZoneConvertor.ConvertToOffsetResponse TimeZoneConvertor.ITimeZoneConvertor.ConvertToOffset(TimeZoneConvertor.ConvertToOffsetRequest request)
        {
            return base.Channel.ConvertToOffset(request);
        }
        
        public TimeZoneConvertor.TimeZoneConversionResponse ConvertToOffset(TimeZoneConvertor.TimeZoneConversionRequest TimeZoneConversionRequest)
        {
            TimeZoneConvertor.ConvertToOffsetRequest inValue = new TimeZoneConvertor.ConvertToOffsetRequest();
            inValue.TimeZoneConversionRequest = TimeZoneConversionRequest;
            TimeZoneConvertor.ConvertToOffsetResponse retVal = ((TimeZoneConvertor.ITimeZoneConvertor)(this)).ConvertToOffset(inValue);
            return retVal.TimeZoneConversionResponse;
        }
    }
}
