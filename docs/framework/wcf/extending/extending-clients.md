---
title: "Extending Clients"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "proxy extensions [WCF]"
ms.assetid: 1328c61c-06e5-455f-9ebd-ceefb59d3867
caps.latest.revision: 17
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Extending Clients
In a calling application, the service model layer is responsible for translating method invocations in application code into outbound messages, pushing them to the underlying channels, translating results back into return values and out parameters in application code, and returning the results back to the caller. Service model extensions modify or implement execution or communication behavior and features involving client or dispatcher functionality, custom behaviors, message and parameter interception, and other extensibility functionality.  
  
 This topic describes how to use the <xref:System.ServiceModel.Dispatcher.ClientRuntime> and <xref:System.ServiceModel.Dispatcher.ClientOperation> classes in a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] client application to modify the default execution behavior of a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client or to intercept or modify messages, parameters, or return values prior to or subsequent to sending or retrieving them from the channel layer. For more information about extending the service runtime, see [Extending Dispatchers](../../../../docs/framework/wcf/extending/extending-dispatchers.md). For more information about the behaviors that modify and insert customization objects into the client runtime, see [Configuring and Extending the Runtime with Behaviors](../../../../docs/framework/wcf/extending/configuring-and-extending-the-runtime-with-behaviors.md).  
  
## Clients  
 On a client, a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client object or client channel converts method invocations into outgoing messages and incoming messages to operation results that are returned to the calling application. (For more information about client types, see [WCF Client Architecture](../../../../docs/framework/wcf/feature-details/client-architecture.md).)  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client types have runtime types that handle this endpoint- and operation-level functionality. When an application calls an operation, the <xref:System.ServiceModel.Dispatcher.ClientOperation> translates the outbound objects into a message, processes interceptors, confirms that the outbound call conforms to the target contract, and hands the outbound message to the <xref:System.ServiceModel.Dispatcher.ClientRuntime>, which is responsible for creating and managing outbound channels (and inbound channels in the case of duplex services), handling extra outbound message processing (such as header modification), processing message interceptors in both directions, and routing inbound duplex calls to the appropriate client-side <xref:System.ServiceModel.Dispatcher.DispatchRuntime> object. Both the <xref:System.ServiceModel.Dispatcher.ClientOperation> and <xref:System.ServiceModel.Dispatcher.ClientRuntime> provide similar services when messages (including faults) are returned to the client.  
  
 These two runtime classes are the main extension to customize the processing of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client objects and channels. The <xref:System.ServiceModel.Dispatcher.ClientRuntime> class allows users to intercept and extend client execution across all messages in the contract. The <xref:System.ServiceModel.Dispatcher.ClientOperation> class allows users to intercept and extend client execution for all messages in a given operation.  
  
 Modifying the properties or inserting customizations are done by using contract, endpoint, and operation behaviors. For more information about how to use these types of behaviors to perform client runtime customizations, see [Configuring and Extending the Runtime with Behaviors](../../../../docs/framework/wcf/extending/configuring-and-extending-the-runtime-with-behaviors.md).  
  
## Scenarios  
 There a number of reasons to extend the client system, including:  
  
-   Custom Message Validation. A user may want to enforce that a message is valid for a certain schema. This can be done by implementing the <xref:System.ServiceModel.Dispatcher.IClientMessageInspector> interface and assigning the implementation to the <xref:System.ServiceModel.Dispatcher.DispatchRuntime.MessageInspectors%2A> property. For examples, see [How to: Inspect or Modify Messages on the Client](../../../../docs/framework/wcf/extending/how-to-inspect-or-modify-messages-on-the-client.md) and [How to: Inspect or Modify Messages on the Client](../../../../docs/framework/wcf/extending/how-to-inspect-or-modify-messages-on-the-client.md).  
  
-   Custom Message Logging. A user may want to inspect and log some set of application messages that flow through an endpoint. This can also be accomplished with the message interceptor interfaces.  
  
-   Custom Message Transformations. Rather than modifying application code, the user may want to apply certain transformations to the message in the runtime (for example, for versioning). This can be accomplished, again, with the message interceptor interfaces.  
  
-   Custom Data Model. A user may want to have a data or serialization model other than those supported by default in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] (namely, <xref:System.Runtime.Serialization.DataContractSerializer?displayProperty=nameWithType>, <xref:System.Xml.Serialization.XmlSerializer?displayProperty=nameWithType>, and <xref:System.ServiceModel.Channels.Message?displayProperty=nameWithType> objects). This can be done by implementing the message formatter interfaces. For more information, see <xref:System.ServiceModel.Dispatcher.IClientMessageFormatter?displayProperty=nameWithType> and the <xref:System.ServiceModel.Dispatcher.ClientOperation.Formatter%2A?displayProperty=nameWithType> property.  
  
-   Custom Parameter Validation. A user may want to enforce that typed parameters are valid (as opposed to XML). This can be done using the parameter inspector interfaces. For an example, see [How to: Inspect or Modify Parameters](../../../../docs/framework/wcf/extending/how-to-inspect-or-modify-parameters.md) or [Client Validation](../../../../docs/framework/wcf/samples/client-validation.md).  
  
### Using the ClientRuntime Class  
 The <xref:System.ServiceModel.Dispatcher.ClientRuntime> class is an extensibility point to which you can add extension objects that intercept messages and extend client behavior. Interception objects can process all messages in a particular contract, process only messages for particular operations, perform custom channel initialization, and implement other custom client application behavior.  
  
-   The <xref:System.ServiceModel.Dispatcher.ClientRuntime.CallbackDispatchRuntime%2A> property returns the dispatch run-time object for service-initiated callback clients.  
  
-   The <xref:System.ServiceModel.Dispatcher.ClientRuntime.OperationSelector%2A> property accepts a custom operation selector object.  
  
-   The <xref:System.ServiceModel.Dispatcher.ClientRuntime.ChannelInitializers%2A> property enables the addition of a channel initializer that can inspect or modify the client channel.  
  
-   The <xref:System.ServiceModel.Dispatcher.ClientRuntime.Operations%2A> property gets a collection of <xref:System.ServiceModel.Dispatcher.ClientOperation> objects to which you can add custom message interceptors that provide functionality specific to the messages of that operation.  
  
-   The <xref:System.ServiceModel.Dispatcher.ClientRuntime.ManualAddressing%2A> property enables an application to turn off some automatic addressing headers to directly control addressing.  
  
-   The <xref:System.ServiceModel.Dispatcher.ClientRuntime.Via%2A> property sets the value of the destination of the message at the transport level to support intermediaries and other scenarios.  
  
-   The <xref:System.ServiceModel.Dispatcher.ClientRuntime.MessageInspectors%2A> property gets a collection of <xref:System.ServiceModel.Dispatcher.IClientMessageInspector> objects to which you can add custom message interceptors for all messages traveling through a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client.  
  
 In addition, there are a number of other properties that retrieve the contract information:  
  
-   <xref:System.ServiceModel.Dispatcher.ClientRuntime.ContractName%2A>  
  
-   <xref:System.ServiceModel.Dispatcher.ClientRuntime.ContractNamespace%2A>  
  
-   <xref:System.ServiceModel.Dispatcher.ClientRuntime.ContractClientType%2A>  
  
 If the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client is a duplex [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client, the following properties also retrieve the callback [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client information:  
  
-   <xref:System.ServiceModel.Dispatcher.ClientRuntime.CallbackClientType%2A>  
  
-   <xref:System.ServiceModel.Dispatcher.ClientRuntime.CallbackDispatchRuntime%2A>  
  
 To extend [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client execution across an entire [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client, review the properties available on the <xref:System.ServiceModel.Dispatcher.ClientRuntime> class to see whether modifying a property or implementing an interface and adding it to a property creates the functionality you are seeking. Once you have chosen a particular extension to build, insert your extension into the appropriate <xref:System.ServiceModel.Dispatcher.ClientRuntime> property by implementing a client behavior that provides access to the <xref:System.ServiceModel.Dispatcher.ClientRuntime> class when invoked.  
  
 You can insert custom extension objects into a collection using an operation behavior (an object that implements <xref:System.ServiceModel.Description.IOperationBehavior>), a contract behavior (an object that implements <xref:System.ServiceModel.Description.IContractBehavior>), or an endpoint behavior (an object that implements <xref:System.ServiceModel.Description.IEndpointBehavior>). The installing behavior object is added to the appropriate collection of behaviors either programmatically, declaratively (by implementing a custom attribute), or by implementing a custom <xref:System.ServiceModel.Configuration.BehaviorExtensionElement> object to enable the behavior to be inserted using an application configuration file. For details, see [Configuring and Extending the Runtime with Behaviors](../../../../docs/framework/wcf/extending/configuring-and-extending-the-runtime-with-behaviors.md).  
  
 For examples that demonstrate interception across a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client, see [How to: Inspect or Modify Messages on the Client](../../../../docs/framework/wcf/extending/how-to-inspect-or-modify-messages-on-the-client.md).  
  
### Using the ClientOperation Class  
 The <xref:System.ServiceModel.Dispatcher.ClientOperation> class is the location for client run-time modifications and insertion point for custom extensions that are scoped to only one service operation. (To modify client run-time behavior for all messages in a contract, use the <xref:System.ServiceModel.Dispatcher.ClientRuntime> class.)  
  
 Use the <xref:System.ServiceModel.Dispatcher.ClientRuntime.Operations%2A> property to locate the <xref:System.ServiceModel.Dispatcher.ClientOperation> object that represents a particular service operation. The following properties enable you to insert custom objects into the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client system:  
  
-   Use the <xref:System.ServiceModel.Dispatcher.ClientOperation.Formatter%2A> property to insert a custom <xref:System.ServiceModel.Dispatcher.IClientMessageFormatter> implementation for an operation or modify the current formatter.  
  
-   Use the <xref:System.ServiceModel.Dispatcher.ClientOperation.ParameterInspectors%2A> property to insert a custom <xref:System.ServiceModel.Dispatcher.IParameterInspector> implementation or to modify the current one.  
  
 The following properties enable you to modify the system in interaction with the formatter and custom parameter inspectors:  
  
-   Use the <xref:System.ServiceModel.Dispatcher.ClientOperation.SerializeRequest%2A> property to control the serialization of an outbound message.  
  
-   Use the <xref:System.ServiceModel.Dispatcher.ClientOperation.DeserializeReply%2A> property to control the deserialization of an inbound message.  
  
-   Use the <xref:System.ServiceModel.Dispatcher.ClientOperation.Action%2A> property to control the WS-Addressing action of the request message.  
  
-   Use the <xref:System.ServiceModel.Dispatcher.ClientOperation.BeginMethod%2A> and <xref:System.ServiceModel.Dispatcher.ClientOperation.EndMethod%2A> to specify which [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client methods are associated with an asynchronous operation.  
  
-   Use the <xref:System.ServiceModel.Dispatcher.ClientOperation.FaultContractInfos%2A> property to get a collection that contains the types that can appear in SOAP faults as the detail type.  
  
-   Use the <xref:System.ServiceModel.Dispatcher.ClientOperation.IsInitiating%2A> and <xref:System.ServiceModel.Dispatcher.ClientOperation.IsTerminating%2A> properties to control whether a session is initiated or is torn down, respectively, when the operation is called.  
  
-   Use the <xref:System.ServiceModel.Dispatcher.ClientOperation.IsOneWay%2A> property to control whether the operation is a one-way operation.  
  
-   Use the <xref:System.ServiceModel.Dispatcher.ClientOperation.Parent%2A> property to obtain the containing <xref:System.ServiceModel.Dispatcher.ClientRuntime> object.  
  
-   Use the <xref:System.ServiceModel.Dispatcher.ClientOperation.Name%2A> property to get the name of the operation.  
  
-   Use the <xref:System.ServiceModel.Dispatcher.ClientOperation.SyncMethod%2A> property to control which method is mapped to the operation.  
  
 To extend [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client execution across only one service operation, review the properties available on the <xref:System.ServiceModel.Dispatcher.ClientOperation> class to see whether modifying a property or implementing an interface and adding it to a property creates the functionality you are seeking. Once you have chosen a particular extension to build, insert your extension into the appropriate <xref:System.ServiceModel.Dispatcher.ClientOperation> property by implementing a client behavior that provides access to the <xref:System.ServiceModel.Dispatcher.ClientOperation> class when invoked. Inside that behavior you can then modify the <xref:System.ServiceModel.Dispatcher.ClientRuntime> property to fit your requirements.  
  
 Typically, implementing an operation behavior (an object that implements the <xref:System.ServiceModel.Description.IOperationBehavior> interface) suffices, but you can also use endpoint behaviors and contract behaviors to accomplish the same thing by locating the <xref:System.ServiceModel.Description.OperationDescription> for a particular operation and attaching the behavior there. For details, see [Configuring and Extending the Runtime with Behaviors](../../../../docs/framework/wcf/extending/configuring-and-extending-the-runtime-with-behaviors.md).  
  
 To use your custom behavior from configuration, install your behavior using a custom behavior configuration section handler. You can also install your behavior by creating a custom attribute.  
  
 For examples that demonstrate interception across a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client, see [How to: Inspect or Modify Parameters](../../../../docs/framework/wcf/extending/how-to-inspect-or-modify-parameters.md).  
  
## See Also  
 <xref:System.ServiceModel.Dispatcher.ClientRuntime>  
 <xref:System.ServiceModel.Dispatcher.ClientOperation>  
 [How to: Inspect or Modify Messages on the Client](../../../../docs/framework/wcf/extending/how-to-inspect-or-modify-messages-on-the-client.md)  
 [How to: Inspect or Modify Parameters](../../../../docs/framework/wcf/extending/how-to-inspect-or-modify-parameters.md)
