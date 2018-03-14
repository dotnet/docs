---
title: "Dispatch by Body Element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f64a3c04-62b4-47b2-91d9-747a3af1659f
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Dispatch by Body Element
This sample demonstrates how to implement an alternate algorithm for assigning incoming messages to operations.  
  
 By default, the service model dispatcher selects the appropriate handling method for an incoming message based on the message's WS-Addressing "Action" header or the equivalent information in the HTTP SOAP request.  
  
 Some SOAP 1.1 Web services stacks that do not follow the WS-I Basic Profile 1.1 guidelines do not dispatch messages based on the Action URI, but rather based on the XML qualified name of the first element inside the SOAP body. Likewise, the client side of these stacks might send messages with an empty or arbitrary HTTP SoapAction header, which was permitted by the SOAP 1.1 specification.  
  
 To change the way messages are dispatched to methods, the sample implements the <xref:System.ServiceModel.Dispatcher.IDispatchOperationSelector> extensibility interface on the `DispatchByBodyElementOperationSelector`. This class selects operations based on the first element of the message body.  
  
 The class constructor expects a dictionary populated with pairs of `XmlQualifiedName` and strings, whereby the qualified names indicate the name of the first child of the SOAP body and the strings indicate the matching operation name. The `defaultOperationName` is the name of the operation that receives all messages that cannot be matched against this dictionary:  
  
```  
class DispatchByBodyElementOperationSelector : IDispatchOperationSelector  
{  
    Dictionary<XmlQualifiedName, string> dispatchDictionary;  
    string defaultOperationName;  
  
    public DispatchByBodyElementOperationSelector(Dictionary<XmlQualifiedName,string> dispatchDictionary, string defaultOperationName)  
    {  
        this.dispatchDictionary = dispatchDictionary;  
        this.defaultOperationName = defaultOperationName;  
    }  
```  
  
 <xref:System.ServiceModel.Dispatcher.IDispatchOperationSelector> implementations are very straightforward to build as there is only one method on the interface: <xref:System.ServiceModel.Dispatcher.IDispatchOperationSelector.SelectOperation%2A>. The job of this method is to inspect an incoming message and to return a string that equals the name of a method on the service contract for the current endpoint.  
  
 In this sample, the operation selector acquires an <xref:System.Xml.XmlDictionaryReader> for the incoming message's body using <xref:System.ServiceModel.Channels.Message.GetReaderAtBodyContents%2A>. This method already positions the reader on the first child of the message's body so that it is sufficient to get the current element's name and namespace URI and combine them into an `XmlQualifiedName` that is then used for looking up the corresponding operation from the dictionary held by the operation selector.  
  
```  
public string SelectOperation(ref System.ServiceModel.Channels.Message message)  
{  
    XmlDictionaryReader bodyReader = message.GetReaderAtBodyContents();  
    XmlQualifiedName lookupQName = new  
       XmlQualifiedName(bodyReader.LocalName, bodyReader.NamespaceURI);  
    message = CreateMessageCopy(message,bodyReader);  
    if (dispatchDictionary.ContainsKey(lookupQName))  
    {  
         return dispatchDictionary[lookupQName];  
    }  
    else  
    {  
        return defaultOperationName;  
    }  
}  
```  
  
 Accessing the message body with <xref:System.ServiceModel.Channels.Message.GetReaderAtBodyContents%2A> or any of the other methods that provide access to the message's body content causes the message to be marked as "read", which means that the message is invalid for any further processing. Therefore, the operation selector creates a copy of the incoming message with the method shown in the following code. Because the reader's position has not been changed during the inspection, it can be referenced by the newly created message to which the message properties and the message headers are also copied, which results in an exact clone of the original message:  
  
```  
private Message CreateMessageCopy(Message message,   
                                     XmlDictionaryReader body)  
{  
    Message copy = Message.CreateMessage(message.Version,message.Headers.Action,body);  
    copy.Headers.CopyHeaderFrom(message,0);  
    copy.Properties.CopyProperties(message.Properties);  
    return copy;  
}  
```  
  
## Adding an Operation Selector to a Service  
 Service dispatch operation selectors are extensions to the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] dispatcher. For selecting methods on the callback channel of duplex contracts, there are also client operation selectors, which work very much like the dispatch operation selectors described here, but which are not explicitly covered in this sample.  
  
 Like most service model extensions, dispatch operation selectors are added to the dispatcher using behaviors. A *behavior* is a configuration object, which either adds one or more extensions to the dispatch runtime (or to the client runtime) or otherwise changes its settings.  
  
 Because operation selectors have contract scope, the appropriate behavior to implement here is the <xref:System.ServiceModel.Description.IContractBehavior>. Because the interface is implemented on a <xref:System.Attribute> derived class as shown in the following code, the behavior can be declaratively added to any service contract. Whenever a <xref:System.ServiceModel.ServiceHost> is opened and the dispatch runtime is built, all behaviors found either as attributes on contracts, operations, and service implementations or as element in the service configuration are automatically added and subsequently asked to contribute extensions or modify the default configuration.  
  
 For brevity, the following code excerpt only shows the implementation of the method <xref:System.ServiceModel.Description.IContractBehavior.ApplyDispatchBehavior%2A>, which effects the configuration changes for the dispatcher in this sample. The other methods are not shown because they return to the caller without doing any work.  
  
```  
[AttributeUsage(AttributeTargets.Class|AttributeTargets.Interface)]  
class DispatchByBodyElementBehaviorAttribute : Attribute, IContractBehavior  
{  
    // public void AddBindingParameters(...)   
    // public void ApplyClientBehavior(...)  
    // public void Validate(...)  
```  
  
 First, the <xref:System.ServiceModel.Description.IContractBehavior.ApplyDispatchBehavior%2A> implementation sets up the lookup dictionary for the operation selector by iterating over the <xref:System.ServiceModel.Description.OperationDescription> elements in the service endpoint's <xref:System.ServiceModel.Description.ContractDescription>. Then, each operation description is inspected for the presence of the `DispatchBodyElementAttribute` behavior, an implementation of <xref:System.ServiceModel.Description.IOperationBehavior> that is also defined in this sample. While this class is also a behavior, it is passive and does not actively contribute any configuration changes to the dispatch runtime. All of its methods return to the caller without taking any actions. The operation behavior only exists so that the metadata required for the new dispatch mechanism, namely the qualified name of the body element on whose occurrence an operation is selected, can be associated with the respective operations.  
  
 If such a behavior is found, a value pair created from the XML qualified name (`QName` property) and the operation name (`Name` property) is added to the dictionary.  
  
 Once the dictionary is populated, a new `DispatchByBodyElementOperationSelector` is constructed with this information and set as the operation selector of the dispatch runtime:  
  
```  
public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.DispatchRuntime dispatchRuntime)  
{  
    Dictionary<XmlQualifiedName,string> dispatchDictionary =   
                     new Dictionary<XmlQualifiedName,string>();  
    foreach( OperationDescription operationDescription in   
                              contractDescription.Operations )  
    {  
        DispatchBodyElementAttribute dispatchBodyElement =   
   operationDescription.Behaviors.Find<DispatchBodyElementAttribute>();  
        if ( dispatchBodyElement != null )  
        {  
             dispatchDictionary.Add(dispatchBodyElement.QName,   
                              operationDescription.Name);  
        }  
    }  
    dispatchRuntime.OperationSelector =   
            new DispatchByBodyElementOperationSelector(  
               dispatchDictionary,   
               dispatchRuntime.UnhandledDispatchOperation.Name);  
    }  
}  
```  
  
## Implementing the Service  
 The behavior implemented in this sample directly affects how messages from the wire are interpreted and dispatched, which is a function of the service contract. Consequently, the behavior should be declared on the service contract level in any service implementation that chooses to use it.  
  
 The sample project service applies the `DispatchByBodyElementBehaviorAttribute` contract behavior to the `IDispatchedByBody` service contract and labels each of the two operations `OperationForBodyA()` and `OperationForBodyB()` with a `DispatchBodyElementAttribute` operation behavior. When a service host for a service that implements this contract is opened, this metadata is picked up by the dispatcher builder as previously described.  
  
 Because the operation selector dispatches solely based on the message body element and ignores the "Action", it is required to tell the runtime not to check the "Action" header on the returned replies by assigning the wildcard "*" to the `ReplyAction` property of <xref:System.ServiceModel.OperationContractAttribute>. Furthermore, it is required to have a default operation that has the "Action" property set to the wildcard "\*". The default operation receives all messages which cannot be dispatched and does not have a `DispatchBodyElementAttribute`:  
  
```  
[ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples"),  
                            DispatchByBodyElementBehavior]  
public interface IDispatchedByBody  
{  
    [OperationContract(ReplyAction="*"),   
     DispatchBodyElement("bodyA","http://tempuri.org")]  
    Message OperationForBodyA(Message msg);  
    [OperationContract(ReplyAction = "*"),   
     DispatchBodyElement("bodyB", "http://tempuri.org")]  
    Message OperationForBodyB(Message msg);  
    [OperationContract(Action="*", ReplyAction="*")]  
    Message DefaultOperation(Message msg);  
}  
```  
  
 The sample service implementation is straightforward. Every method wraps the received message into a reply message and echoes it back to the client.  
  
## Running and Building the Sample  
 When you run the sample, the body content of the operation responses are displayed in the client console window similar to the following (formatted) output.  
  
 The client sends three messages to the service whose body content element is named `bodyA`, `bodyB`, and `bodyX`, respectively. As can be deferred from the previous description and the service contract shown, the incoming message with the `bodyA` element is dispatched to the `OperationForBodyA()` method. Because there is no explicit dispatch target for the message with the `bodyX` body element, the message is dispatched to the `DefaultOperation()`. Each of the service operations wraps the received message body into an element specific to the method and returns it, which is done to correlate input and output messages clearly for this sample:  
  
```xml  
<?xml version="1.0" encoding="IBM437"?>  
<replyBodyA xmlns="http://tempuri.org">  
   <q:bodyA xmlns:q="http://tempuri.org">test</q:bodyA>  
</replyBodyA>  
<?xml version="1.0" encoding="IBM437"?>  
<replyBodyB xmlns="http://tempuri.org">  
  <q:bodyB xmlns:q="http://tempuri.org">test</q:bodyB>  
</replyBodyB>  
<?xml version="1.0" encoding="IBM437"?>  
<replyDefault xmlns="http://tempuri.org">  
   <q:bodyX xmlns:q="http://tempuri.org">test</q:bodyX>  
</replyDefault>  
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
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Extensibility\Interop\AdvancedDispatchByBody`  
  
## See Also
