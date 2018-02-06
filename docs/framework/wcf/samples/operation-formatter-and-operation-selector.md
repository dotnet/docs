---
title: "Operation Formatter and Operation Selector"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1c27e9fe-11f8-4377-8140-828207b98a0e
caps.latest.revision: 19
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Operation Formatter and Operation Selector
This sample demonstrates how [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] extensibility points can be used to allow message data in a different format from what [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] expects. By default, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] formatters expect method parameters to be included under the `soap:body` element. The sample shows how to implement a custom operation formatter that parses parameter data from an HTTP GET query string instead and invokes methods using that data.  
  
 The sample is based on the [Getting Started](../../../../docs/framework/wcf/samples/getting-started-sample.md), which implements the `ICalculator` service contract. It shows how Add, Subtract, Multiply, and Divide messages can be changed to use HTTP GET for client-to-server requests and HTTP POST with POX messages for server-to-client responses.  
  
 To do so, the sample provides the following:  
  
-   `QueryStringFormatter`, which implements <xref:System.ServiceModel.Dispatcher.IClientMessageFormatter> and <xref:System.ServiceModel.Dispatcher.IDispatchMessageFormatter> for the client and server, respectively, and processes the data in the query string.  
  
-   `UriOperationSelector`, which implements <xref:System.ServiceModel.Dispatcher.IDispatchOperationSelector> on the server to perform operation dispatch based on the operation name in the GET request.  
  
-   `EnableHttpGetRequestsBehavior` endpoint behavior (and corresponding configuration), which adds the necessary operation selector to the runtime.  
  
-   Shows how to insert a new operation formatter into the runtime.  
  
-   In this sample, both the client and the service are console applications (.exe).  
  
> [!NOTE]
>  The setup procedure and build instructions for this sample are located at the end of this topic.  
  
## Key Concepts  
 `QueryStringFormatter` - The operation formatter is the component in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] that is responsible for converting a message into an array of parameter objects and an array of parameter objects into a message. This is done on the client using the <xref:System.ServiceModel.Dispatcher.IClientMessageFormatter> interface and on the server with the <xref:System.ServiceModel.Dispatcher.IDispatchMessageFormatter> interface. These interfaces enable users to get the request and response messages from the `Serialize` and `Deserialize` methods.  
  
 In this sample, `QueryStringFormatter` implements both of these interfaces and is implemented on the client and server.  
  
 Request:  
  
-   The sample uses the <xref:System.ComponentModel.TypeConverter> class to convert parameter data in the request message to and from strings. If a <xref:System.ComponentModel.TypeConverter> is not available for a specific type, the sample formatter throws an exception.  
  
-   In the `IClientMessageFormatter.SerializeRequest` method on the client, the formatter creates a URI with the appropriate To address and appends the operation name as a suffix. This name is used to dispatch to the appropriate operation on the server. It then takes the array of parameter objects and serializes the parameter data to the URI query string using parameter names and the values converted by the <xref:System.ComponentModel.TypeConverter> class. The <xref:System.ServiceModel.Channels.MessageHeaders.To%2A> and <xref:System.ServiceModel.Channels.MessageProperties.Via%2A> properties are then set to this URI. <xref:System.ServiceModel.Channels.MessageProperties> is accessed through the <xref:System.ServiceModel.Channels.Message.Properties%2A> property.  
  
-   In the `IDispatchMessageFormatter.DeserializeRequest` method on the server, the formatter retrieves the `Via` URI in the incoming request message properties. It parses the name-value pairs in the URI query string into parameter names and values and uses the parameter names and values to populate the array of parameters passed into the method. Note that operation dispatch has already occurred, so the operation name suffix is ignored in this method.  
  
 Response:  
  
-   In this sample, HTTP GET is used only for the request. The formatter delegates the sending of the response to the original formatter that would have been used to generate an XML message. One of the goals of this sample is to show how such a delegating formatter can be implemented.  
  
### UriPathSuffixOperationSelector Class  
 The <xref:System.ServiceModel.Dispatcher.IDispatchOperationSelector> interface enables users to implement their own logic for which operation a particular message should be dispatched.  
  
 In this sample, `UriPathSuffixOperationSelector` must be implemented on the server to select the appropriate operation because the operation name is included in the HTTP GET URI rather than an action header in the message. The sample is set up to allow only case-insensitive operation names.  
  
 The `SelectOperation` method takes the incoming message and looks up the `Via` URI in its message properties. It extracts the operation name suffix from the URI, looks up an internal table to get the operation name that the message should be dispatched to, and returns that operation name.  
  
### EnableHttpGetRequestsBehavior Class  
 The `UriPathSuffixOperationSelector` component can be set up programmatically or through an endpoint behavior. The sample implements the `EnableHttpGetRequestsBehavior` behavior, which is specified in service’s application configuration file.  
  
 On the server:  
  
 The <xref:System.ServiceModel.Dispatcher.DispatchRuntime.OperationSelector%2A> is set to the <xref:System.ServiceModel.Dispatcher.IDispatchOperationSelector> implementation.  
  
 By default, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses an exact-match address filter. The URI on the incoming message contains an operation name suffix followed by a query string that contains parameter data, so the endpoint behavior also changes the address filter to be a prefix match filter. It uses the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]<xref:System.ServiceModel.Dispatcher.PrefixEndpointAddressMessageFilter> for this purpose.  
  
### Installing operation formatters  
 Operation behaviors that specify formatters are unique. One such behavior is always implemented by default for every operation to create the necessary operation formatter. However, these behaviors look like just another operation behavior; they are not identifiable by any other attribute. To install a replacement behavior, the implementation must look for specific formatter behaviors that are installed by the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] type loader by default and either replace it or add a compatible behavior to run after the default behavior.  
  
 These operation formatters behaviors can be set up programmatically prior to calling <xref:System.ServiceModel.Channels.CommunicationObject.Open%2A?displayProperty=nameWithType> or by specifying an operation behavior that is executed after the default one. However, it cannot easily be set up by an endpoint behavior (and therefore by configuration) because the behavior model does not allow a behavior to replace other behaviors or otherwise modify the description tree.  
  
 On the client:  
  
 The <xref:System.ServiceModel.Dispatcher.IClientMessageFormatter> implementation must be implemented so that it can convert the requests into HTTP GET requests and delegate to the original formatter for responses. This is done by calling the `EnableHttpGetRequestsBehavior.ReplaceFormatterBehavior` helper method.  
  
 This must be done before calling `CreateChannel`.  
  
```  
void ReplaceFormatterBehavior(OperationDescription operationDescription, EndpointAddress address)  
{  
    // Remove the DataContract behavior if it is present.  
    IOperationBehavior formatterBehavior = operationDescription.Behaviors.Remove<DataContractSerializerOperationBehavior>();  
    if (formatterBehavior == null)  
    {  
        // Remove the XmlSerializer behavior if it is present.  
        formatterBehavior = operationDescription.Behaviors.Remove<XmlSerializerOperationBehavior>();  
        ...  
    }  
  
    // Remember what the innerFormatterBehavior was.  
    DelegatingFormatterBehavior delegatingFormatterBehavior = new DelegatingFormatterBehavior(address);  
    delegatingFormatterBehavior.InnerFormatterBehavior = formatterBehavior;  
   operationDescription.Behaviors.Add(delegatingFormatterBehavior);  
}  
```  
  
 On the server:  
  
-   The <xref:System.ServiceModel.Dispatcher.IDispatchMessageFormatter> interface must be implemented so that it can read HTTP GET requests and delegate to the original formatter for writing responses. This is done by calling the same `EnableHttpGetRequestsBehavior.ReplaceFormatterBehavior` helper method as the client (see the previous code sample).  
  
-   This must be done before <xref:System.ServiceModel.Channels.CommunicationObject.Open%2A> is called. In this sample, we show how the formatter is manually modified before calling <xref:System.ServiceModel.Channels.CommunicationObject.Open%2A>. Another way to achieve the same thing is to derive a class from <xref:System.ServiceModel.ServiceHost> that makes the calls to `EnableHttpGetRequestsBehavior.ReplaceFormatterBehavior` before opening (please see hosting documentation and samples for examples).  
  
### User experience  
 On the server:  
  
-   The server `ICalculator` implementation does not need to change.  
  
-   The App.config for the service must use a custom POX binding that sets the `messageVersion` attribute of the `textMessageEncoding` element to `None`.  
  
    ```xml  
    <bindings>  
      <customBinding>  
        <binding name="poxBinding">  
          <textMessageEncoding messageVersion="None" />  
          <httpTransport />  
        </binding>  
      </customBinding>  
    </bindings>  
    ```  
  
-   The App.config for the service also must specify the custom `EnableHttpGetRequestsBehavior` by adding it to the behavior extensions section and using it.  
  
    ```xml  
    <behaviors>  
      <endpointBehaviors>  
        <behavior name="enableHttpGetRequestsBehavior">  
          <enableHttpGetRequests />  
        </behavior>  
      </endpointBehaviors>  
    </behaviors>  
  
    <extensions>  
      <behaviorExtensions>  
        <!-- Enabling HTTP GET requests: Behavior Extension -->  
        <add   
          name="enableHttpGetRequests"           type="Microsoft.ServiceModel.Samples.EnableHttpGetRequestsBehaviorElement, QueryStringFormatter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" />  
      </behaviorExtensions>  
    </extensions>  
    ```  
  
-   Add operation formatters before calling <xref:System.ServiceModel.Channels.CommunicationObject.Open%2A>.  
  
 On the client:  
  
-   The client implementation does not need to change.  
  
-   The App.config for the client must use a custom POX binding that sets the `messageVersion` attribute of the `textMessageEncoding` element to `None`. One difference from the service is that the client must enable manual addressing so that the outgoing To address can be modified.  
  
    ```xml  
    <bindings>  
      <customBinding>  
        <binding name="poxBinding">  
          <textMessageEncoding messageVersion="None" />  
          <httpTransport manualAddressing="True" />  
        </binding>  
      </customBinding>  
    </bindings>  
    ```  
  
-   The App.config for the client must specify the same custom `EnableHttpGetRequestsBehavior` as the server.  
  
-   Add operation formatters before calling <xref:System.ServiceModel.ChannelFactory%601.CreateChannel>.  
  
 When you run the sample, the operation requests and responses are displayed in the client console window. All four operations (Add, Subtract, Multiply, and Divide) must succeed.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Extensibility\Formatters\QuieryStringFormatter`  
  
##### To set up, build, and run the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  To build the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
3.  To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
## See Also
