---
title: "Custom Message Formatters"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c07435f3-5214-4791-8961-2c2b61306d71
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Custom Message Formatters
The content in a message is often in the form of XML, which is usually not a convenient format for an application. Applications manipulate objects, getting and setting their properties. [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] uses the *Data Contract* to convert a <xref:System.ServiceModel.Channels.Message> object into an object easily handled by an application. These processes are called serialization and deserialization. Note that these same terms are used to describe the serialization and deserialization done by the transport layer to and from the message wire format, which is an unrelated process.  
  
 You can use a custom message formatter if you need to implement a specialized conversion between messages and objects that you cannot accomplish by means of a Data Contract. Do this by modifying or extending the execution behavior of a specific contract operation on a client or a service.  
  
## Custom Message Formatters on the Client  
 The <xref:System.ServiceModel.Dispatcher.IClientMessageFormatter> interface defines methods that are used to control the conversion of messages into objects and objects into messages for client applications.  
  
 You must implement this interface. First override the <xref:System.ServiceModel.Dispatcher.IClientMessageFormatter.DeserializeReply%2A> method to deserialize a message. This method is called after an incoming message is received, but before it is dispatched to the client operation.  
  
 Next, override the <xref:System.ServiceModel.Dispatcher.IClientMessageFormatter.SerializeRequest%2A> method to serialize an object. This method is called prior to sending an outgoing message.  
  
 To insert the custom formatter into the service application, assign the <xref:System.ServiceModel.Dispatcher.IClientMessageFormatter> object to the <xref:System.ServiceModel.Dispatcher.ClientOperation.Formatter%2A> property using an operation behavior. For information about behaviors, see [Configuring and Extending the Runtime with Behaviors](../../../../docs/framework/wcf/extending/configuring-and-extending-the-runtime-with-behaviors.md).  
  
## Custom Message Formatters on the Service  
 The <xref:System.ServiceModel.Dispatcher.IDispatchMessageFormatter> interface defines methods that convert a <xref:System.ServiceModel.Channels.Message> object into parameters for an operation and from parameters into a <xref:System.ServiceModel.Channels.Message> object in a service application.  
  
 You must implement this interface. First override the <xref:System.ServiceModel.Dispatcher.IClientMessageFormatter.DeserializeReply%2A> method to deserialize a message. This method is called after an incoming message is received, but before it is dispatched to the client operation.  
  
 Next, override the <xref:System.ServiceModel.Dispatcher.IClientMessageFormatter.SerializeRequest%2A> method to serialize an object. This method is called prior to sending an outgoing message.  
  
 To insert the custom formatter into the service application, assign the <xref:System.ServiceModel.Dispatcher.IDispatchMessageFormatter> object to the <xref:System.ServiceModel.Dispatcher.DispatchOperation.Formatter%2A> property using an operation behavior. For information about behaviors, see [Configuring and Extending the Runtime with Behaviors](../../../../docs/framework/wcf/extending/configuring-and-extending-the-runtime-with-behaviors.md).  
  
## See Also  
 <xref:System.ServiceModel.Dispatcher.IClientMessageFormatter>  
 <xref:System.ServiceModel.Dispatcher.IDispatchMessageFormatter>  
 [Configuring and Extending the Runtime with Behaviors](../../../../docs/framework/wcf/extending/configuring-and-extending-the-runtime-with-behaviors.md)
