---
title: "Message Inspectors"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9bd1f305-ad03-4dd7-971f-fa1014b97c9b
caps.latest.revision: 19
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Message Inspectors
This sample demonstrates how to implement and configure client and service message inspectors.  
  
 A message inspector is an extensibility object that can be used in the service model's client runtime and dispatch runtime programmatically or through configuration and that can inspect and alter messages after they are received or before they are sent.  
  
 This sample implements a basic client and service message validation mechanism that validates incoming messages against a set of configurable XML Schema documents. Note that this sample does not validate messages for each operation. This is an intentional simplification.  
  
## Message Inspector  
 Client message inspectors implement the <xref:System.ServiceModel.Dispatcher.IClientMessageInspector> interface and service message inspectors implement the <xref:System.ServiceModel.Dispatcher.IDispatchMessageInspector> interface. The implementations can be combined into a single class to form a message inspector that works for both sides. This sample implements such a combined message inspector. The inspector is constructed passing in a set of schemas against which incoming and outgoing messages are validated and allows the developer to specify whether incoming or outgoing messages are validated and whether the inspector is in dispatch or client mode, which affects the error handling as discussed later in this topic.  
  
```  
public class SchemaValidationMessageInspector : IClientMessageInspector, IDispatchMessageInspector  
{  
    XmlSchemaSet schemaSet;  
    bool validateRequest;  
    bool validateReply;  
    bool isClientSide;  
    [ThreadStatic]  
    bool isRequest;  
  
    public SchemaValidationMessageInspector(XmlSchemaSet schemaSet,  
         bool validateRequest, bool validateReply, bool isClientSide)  
    {  
        this.schemaSet = schemaSet;  
        this.validateReply = validateReply;  
        this.validateRequest = validateRequest;  
        this.isClientSide = isClientSide;  
    }  
```  
  
 Any service (dispatcher) message inspector must implement the two <xref:System.ServiceModel.Dispatcher.IDispatchMessageInspector> methods <xref:System.ServiceModel.Dispatcher.IDispatchMessageInspector.AfterReceiveRequest%2A> and <xref:System.ServiceModel.Dispatcher.IDispatchMessageInspector.BeforeSendReply%28System.ServiceModel.Channels.Message%40%2CSystem.Object%29>.  
  
 <xref:System.ServiceModel.Dispatcher.IDispatchMessageInspector.AfterReceiveRequest%2A> is invoked by the dispatcher when a message has been received, processed by the channel stack and assigned to a service, but before it is deserialized and dispatched to an operation. If the incoming message was encrypted, the message is already decrypted when it reaches the message inspector. The method gets the `request` message passed as a reference parameter, which allows the message to be inspected, manipulated or replaced as required. The return value can be any object and is used as a correlation state object that is passed to <xref:System.ServiceModel.Dispatcher.IDispatchMessageInspector.BeforeSendReply%2A> when the service returns a reply to the current message. In this sample, <xref:System.ServiceModel.Dispatcher.IDispatchMessageInspector.AfterReceiveRequest%2A> delegates the inspection (validation) of the message to the private, local method `ValidateMessageBody` and returns no correlation state object. This method ensures that no invalid messages pass into the service.  
  
```  
object IDispatchMessageInspector.AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)  
{  
    if (validateRequest)  
    {  
        // inspect the message. If a validation error occurs,  
        // the thrown fault exception bubbles up.  
        ValidateMessageBody(ref request, true);  
    }  
    return null;  
}  
```  
  
 <xref:System.ServiceModel.Dispatcher.IDispatchMessageInspector.BeforeSendReply%28System.ServiceModel.Channels.Message%40%2CSystem.Object%29> is invoked whenever a reply is ready to be sent back to a client, or in the case of one-way messages, when the incoming message has been processed. This allows extensions to count on being called symmetrically, regardless of MEP. As with <xref:System.ServiceModel.Dispatcher.IDispatchMessageInspector.AfterReceiveRequest%2A>, the message is passed as a reference parameter and can be inspected, modified or replaced. The validation of the message that is performed in this sample is again delegated to the `ValidMessageBody` method, but the handling of validation errors is slightly different in this case.  
  
 If a validation error occurs on the service, the `ValidateMessageBody` method throws <xref:System.ServiceModel.FaultException>-derived exceptions. In <xref:System.ServiceModel.Dispatcher.IDispatchMessageInspector.AfterReceiveRequest%2A>, these exceptions can be put into the service model infrastructure where they are automatically transformed into SOAP faults and relayed to the client. In <xref:System.ServiceModel.Dispatcher.IDispatchMessageInspector.BeforeSendReply%2A>, <xref:System.ServiceModel.FaultException> exceptions must not be put into the infrastructure, because the transformation of fault exceptions thrown by the service occurs before the message inspector is called. Therefore the following implementation catches the known `ReplyValidationFault` exception and replaces the reply message with an explicit fault message. This method ensures that no invalid messages are returned by the service implementation.  
  
```  
void IDispatchMessageInspector.BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)  
{  
    if (validateReply)  
    {  
        // Inspect the reply, catch a possible validation error   
        try  
        {  
            ValidateMessageBody(ref reply, false);  
        }  
        catch (ReplyValidationFault fault)  
        {  
            // if a validation error occurred, the message is replaced  
            // with the validation fault.  
            reply = Message.CreateMessage(reply.Version,   
                    fault.CreateMessageFault(), reply.Headers.Action);  
        }  
    }  
```  
  
 The client message inspector is very similar. The two methods that must be implemented from <xref:System.ServiceModel.Dispatcher.IClientMessageInspector> are <xref:System.ServiceModel.Dispatcher.IClientMessageInspector.AfterReceiveReply%2A> and <xref:System.ServiceModel.Dispatcher.IClientMessageInspector.BeforeSendRequest%2A>.  
  
 <xref:System.ServiceModel.Dispatcher.IClientMessageInspector.BeforeSendRequest%2A> is invoked when the message has been composed either by the client application or by the operation formatter. As with the dispatcher message inspectors, the message can just be inspected or entirely replaced. In this sample, the inspector delegates to the same local `ValidateMessageBody` helper method that is also used for the dispatch message inspectors.  
  
 The behavioral difference between the client and service validation (as specified in the constructor) is that the client validation throws local exceptions that are put into the user code because they occur locally and not because of a service failure. Generally, the rule is that service dispatcher inspectors throw faults and that client inspectors throw exceptions.  
  
 This <xref:System.ServiceModel.Dispatcher.IClientMessageInspector.BeforeSendRequest%2A> implementation ensures that no invalid messages are sent to the service.  
  
```  
object IClientMessageInspector.BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)  
{  
    if (validateRequest)  
    {  
        ValidateMessageBody(ref request, true);  
    }  
    return null;  
}  
```  
  
 The `AfterReceiveReply` implementation ensures that no invalid messages received from the service are relayed to the client user code.  
  
```  
void IClientMessageInspector.AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)  
{  
    if (validateReply)  
    {  
        ValidateMessageBody(ref reply, false);  
    }  
}  
```  
  
 The heart of this particular message inspector is the `ValidateMessageBody` method. To perform its work, it wraps a validating <xref:System.Xml.XmlReader> around the body content sub-tree of the passed message. The reader is populated with the set of schemas that the message inspector holds and the validation callback is set to a delegate referring to the `InspectionValidationHandler` that is defined alongside this method. To perform the validation, the message is then read and spooled into a memory stream-backed <xref:System.Xml.XmlDictionaryWriter>. If a validation error or warning occurs in the process, the callback method is invoked.  
  
 If no error occurs, a new message is constructed that copies the properties and headers from the original message and uses the now-validated infoset in the memory stream, which is wrapped by an <xref:System.Xml.XmlDictionaryReader> and added to the replacement message.  
  
```  
void ValidateMessageBody(ref System.ServiceModel.Channels.Message message, bool isRequest)  
{  
    if (!message.IsFault)  
    {  
        XmlDictionaryReaderQuotas quotas =   
                new XmlDictionaryReaderQuotas();  
        XmlReader bodyReader =   
            message.GetReaderAtBodyContents().ReadSubtree();  
        XmlReaderSettings wrapperSettings =   
                              new XmlReaderSettings();  
        wrapperSettings.CloseInput = true;  
        wrapperSettings.Schemas = schemaSet;  
        wrapperSettings.ValidationFlags =   
                                XmlSchemaValidationFlags.None;  
        wrapperSettings.ValidationType = ValidationType.Schema;  
        wrapperSettings.ValidationEventHandler += new   
           ValidationEventHandler(InspectionValidationHandler);  
        XmlReader wrappedReader = XmlReader.Create(bodyReader,   
                                            wrapperSettings);  
  
        // pull body into a memory backed writer to validate  
        this.isRequest = isRequest;  
        MemoryStream memStream = new MemoryStream();  
        XmlDictionaryWriter xdw =  
              XmlDictionaryWriter.CreateBinaryWriter(memStream);  
        xdw.WriteNode(wrappedReader, false);  
        xdw.Flush(); memStream.Position = 0;  
        XmlDictionaryReader xdr =   
        XmlDictionaryReader.CreateBinaryReader(memStream, quotas);  
  
        // reconstruct the message with the validated body  
        Message replacedMessage =   
            Message.CreateMessage(message.Version, null, xdr);  
        replacedMessage.Headers.CopyHeadersFrom(message.Headers);  
        replacedMessage.Properties.CopyProperties(message.Properties);  
        message = replacedMessage;  
    }  
}  
```  
  
 The `InspectionValidationHandler` method is called by the validating <xref:System.Xml.XmlReader> whenever a schema validation error or warning occurs. The following implementation only works with errors and ignores all warnings.  
  
 On first consideration, it might seem possible to inject a validating <xref:System.Xml.XmlReader> into the message with the message inspector and let the validation happen as the message is processed and without buffering the message. That, however, means that this callback throws the validation exceptions somewhere into the service model infrastructure or the user code as invalid XML nodes are detected, resulting in unpredictable behavior. The buffering approach shields the user code from invalid messages, entirely.  
  
 As previously discussed, the exceptions thrown by the handler differ between the client and the service. On the service, the exceptions are derived from <xref:System.ServiceModel.FaultException>, on the client the exceptions are regular custom exceptions.  
  
```  
        void InspectionValidationHandler(object sender, ValidationEventArgs e)  
{  
    if (e.Severity == XmlSeverityType.Error)  
    {  
        // We are treating client and service side validation errors  
        // differently here. Client side errors cause exceptions  
        // and are thrown straight up to the user code. Service side  
        // validations cause faults.  
        if (isClientSide)  
        {  
            if (isRequest)  
            {  
                throw new RequestClientValidationException(e.Message);  
            }  
            else  
            {  
                throw new ReplyClientValidationException(e.Message);  
            }  
        }  
        else  
        {  
            if (isRequest)  
            {  
                // this fault is caught by the ServiceModel   
                // infrastructure and turned into a fault reply.  
                throw new RequestValidationFault(e.Message);  
             }  
             else  
             {  
                // this fault is caught and turned into a fault message  
                // in BeforeSendReply in this class  
                throw new ReplyValidationFault(e.Message);  
              }  
          }  
      }  
    }  
```  
  
## Behavior  
 Message inspectors are extensions to the client runtime or the dispatch runtime. Such extensions are configured using *behaviors*. A behavior is a class that changes the behavior of the service model runtime by changing the default configuration or adding extensions (such as message inspectors) to it.  
  
 The following `SchemaValidationBehavior` class is the behavior used to add this sample's message inspector to the client or dispatch runtime. The implementation is rather basic in both cases. In <xref:System.ServiceModel.Description.IEndpointBehavior.ApplyClientBehavior%2A> and <xref:System.ServiceModel.Description.IEndpointBehavior.ApplyDispatchBehavior%2A>, the message inspector is created and added to the <xref:System.ServiceModel.Dispatcher.ClientRuntime.MessageInspectors%2A> collection of the respective runtime.  
  
```  
public class SchemaValidationBehavior : IEndpointBehavior  
{  
    XmlSchemaSet schemaSet;   
    bool validateRequest;   
    bool validateReply;  
  
    public SchemaValidationBehavior(XmlSchemaSet schemaSet, bool   
                           inspectRequest, bool inspectReply)  
    {  
        this.schemaSet = schemaSet;  
        this.validateReply = inspectReply;  
        this.validateRequest = inspectRequest;  
    }  
    #region IEndpointBehavior Members  
  
    public void AddBindingParameters(ServiceEndpoint endpoint,   
       System.ServiceModel.Channels.BindingParameterCollection   
                                            bindingParameters)  
    {  
    }  
  
    public void ApplyClientBehavior(ServiceEndpoint endpoint,   
            System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)  
    {  
        SchemaValidationMessageInspector inspector =   
           new SchemaValidationMessageInspector(schemaSet,   
                      validateRequest, validateReply, true);  
            clientRuntime.MessageInspectors.Add(inspector);  
    }  
  
    public void ApplyDispatchBehavior(ServiceEndpoint endpoint,   
         System.ServiceModel.Dispatcher.EndpointDispatcher   
                                          endpointDispatcher)  
    {  
        SchemaValidationMessageInspector inspector =   
           new SchemaValidationMessageInspector(schemaSet,   
                        validateRequest, validateReply, false);  
   endpointDispatcher.DispatchRuntime.MessageInspectors.Add(inspector);  
    }  
  
   public void Validate(ServiceEndpoint endpoint)  
   {  
   }  
  
    #endregion  
}  
```  
  
> [!NOTE]
>  This particular behavior does not double as an attribute and therefore cannot be added declaratively onto a contract type of a service type. This is a by-design decision made because the schema collection cannot be loaded in an attribute declaration and referring to an extra configuration location (for instance to the application settings) in this attribute means creating a configuration element that is not consistent with the rest of the service model configuration. Therefore, this behavior can only be added imperatively through code and through a service model configuration extension.  
  
## Adding the Message Inspector through Configuration  
 For configuring a custom behavior on an endpoint in the application configuration file, the service model requires implementers to create a configuration *extension element* represented by a class derived from <xref:System.ServiceModel.Configuration.BehaviorExtensionElement>. This extension must then be added to the service model's configuration section for extensions as shown for the following extension discussed in this section.  
  
```xml  
<system.serviceModel>  
…  
   <extensions>  
      <behaviorExtensions>  
        <add name="schemaValidator" type="Microsoft.ServiceModel.Samples.SchemaValidationBehaviorExtensionElement, MessageInspectors, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"/>  
      </behaviorExtensions>  
    </extensions>  
…  
</system.serviceModel>  
```  
  
 Extensions can be added in the application or ASP.NET configuration file, which is the most common choice, or in the machine configuration file.  
  
 When the extension is added to a configuration scope, the behavior can be added to a behavior configuration as it is shown in the following code. Behavior configurations are reusable elements that can be applied to multiple endpoints as required. Because the particular behavior to be configured here implements <xref:System.ServiceModel.Description.IEndpointBehavior>, it is only valid in the respective configuration section in the configuration file.  
  
```xml  
<system.serviceModel>  
   <behaviors>  
      …  
     <endpointBehaviors>  
        <behavior name="HelloServiceEndpointBehavior">  
          <schemaValidator validateRequest="True" validateReply="True">  
            <schemas>  
              <add location="messages.xsd" />    
            </schemas>  
          </schemaValidator>  
        </behavior>  
      </endpointBehaviors>  
      …  
    </behaviors>  
</system.serviceModel>  
```  
  
 The `<schemaValidator>` element that configures the message inspector is backed by the `SchemaValidationBehaviorExtensionElement` class. The class exposes two Boolean public properties named `ValidateRequest` and `ValidateReply`. Both of these are marked with a <xref:System.Configuration.ConfigurationPropertyAttribute>. This attribute constitutes the link between the code properties and the XML attributes that can be seen on the preceding XML configuration element. The class also has a property `Schemas` that is additionally marked with the <xref:System.Configuration.ConfigurationCollectionAttribute> and is of the type `SchemaCollection`, which is also part of this sample but omitted from this document for brevity. This property along with the collection and the collection element class `SchemaConfigElement` backs the `<schemas>` element in the preceding configuration snippet and allows adding a collection of schemas to the validation set.  
  
 The overridden `CreateBehavior` method turns the configuration data into a behavior object when the runtime evaluates the configuration data as it builds a client or an endpoint.  
  
```  
public class SchemaValidationBehaviorExtensionElement : BehaviorExtensionElement  
{  
    public SchemaValidationBehaviorExtensionElement()  
    {  
    }  
  
    public override Type BehaviorType   
    {   
        get  
        {  
            return typeof(SchemaValidationBehavior);  
        }   
    }  
  
    protected override object CreateBehavior()  
    {  
        XmlSchemaSet schemaSet = new XmlSchemaSet();  
        foreach (SchemaConfigElement schemaCfg in this.Schemas)  
        {  
            Uri baseSchema = new   
                Uri(AppDomain.CurrentDomain.BaseDirectory);  
            string location = new   
                Uri(baseSchema,schemaCfg.Location).ToString();  
            XmlSchema schema =   
                XmlSchema.Read(new XmlTextReader(location), null);  
            schemaSet.Add(schema);  
        }  
     return new   
     SchemaValidationBehavior(schemaSet,ValidateRequest,ValidateReply);  
    }  
  
[ConfigurationProperty("validateRequest",DefaultValue=false,IsRequired=false)]  
public bool ValidateRequest  
{  
    get { return (bool)base["validateRequest"]; }  
    set { base["validateRequest"] = value; }  
}  
  
[ConfigurationProperty("validateReply", DefaultValue = false, IsRequired = false)]  
        public bool ValidateReply  
        {  
            get { return (bool)base["validateReply"]; }  
            set { base["validateReply"] = value; }  
        }  
  
     //Declare the Schema collection property.  
     //Note: the "IsDefaultCollection = false" instructs   
     //.NET Framework to build a nested section of   
     //the kind <Schema> ...</Schema>.  
    [ConfigurationProperty("schemas", IsDefaultCollection = true)]  
    [ConfigurationCollection(typeof(SchemasCollection),  
        AddItemName = "add",  
        ClearItemsName = "clear",  
        RemoveItemName = "remove")]  
    public SchemasCollection Schemas  
    {  
        get  
        {  
            SchemasCollection SchemasCollection =  
            (SchemasCollection)base["schemas"];  
            return SchemasCollection;  
        }  
    }  
}  
```  
  
## Adding Message Inspectors Imperatively  
 Except through attributes (which is not supported in this sample for the reason cited previously) and configuration, behaviors can quite easily be added to a client and service runtime using imperative code. In this sample, this is done in the client application to test the client message inspector. The `GenericClient` class is derived from <xref:System.ServiceModel.ClientBase%601>, which exposes the endpoint configuration to the user code. Before the client is implicitly opened the endpoint configuration can be changed, for instance by adding behaviors as shown in the following code. Adding the behavior on the service is largely equivalent to the client technique shown here and must be performed before the service host is opened.  
  
```  
try  
{  
    Console.WriteLine("*** Call 'Hello' with generic client, with client behavior");  
    GenericClient client = new GenericClient();  
  
    // Configure client programmatically, adding behavior  
    XmlSchema schema = XmlSchema.Read(new StreamReader("messages.xsd"),   
                                                          null);  
    XmlSchemaSet schemaSet = new XmlSchemaSet();  
    schemaSet.Add(schema);  
    client.Endpoint.Behaviors.Add(new   
                SchemaValidationBehavior(schemaSet, true, true));  
  
    Console.WriteLine("--- Sending valid client request:");  
    GenericCallValid(client, helloAction);  
    Console.WriteLine("--- Sending invalid client request:");  
    GenericCallInvalid(client, helloAction);  
  
    client.Close();  
}  
catch (Exception e)  
{  
    DumpException(e);  
}  
```  
  
#### To set up, build, and run the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  To build the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
3.  To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Extensibility\MessageInspectors`  
  
## See Also
