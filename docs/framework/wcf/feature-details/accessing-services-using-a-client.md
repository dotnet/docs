---
title: "Accessing Services Using a Client"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: c8329832-bf66-4064-9034-bf39f153fc2d
caps.latest.revision: 15
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Accessing Services Using a Client
Client applications must create, configure, and use [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client or channel objects to communicate with services. The [WCF Client Overview](../../../../docs/framework/wcf/wcf-client-overview.md) topic provides an overview of the objects and steps involved in creating basic client and channel objects and using them.  
  
 This topic provides in-depth information about some of the issues with client applications and client and channel objects that may be useful depending upon your scenario.  
  
## Overview  
 This topic describes behavior and issues relating to:  
  
-   Channel and session lifetimes.  
  
-   Handling exceptions.  
  
-   Understanding blocking issues.  
  
-   Initializing channels interactively.  
  
### Channel and Session Lifetimes  
 [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] applications includes two categories of channels, datagram and sessionful.  
  
 A *datagram* channel is a channel in which all messages are uncorrelated. With a datagram channel, if an input or output operation fails, the next operation is typically unaffected, and the same channel can be reused. Because of this, datagram channels typically do not fault.  
  
 *Sessionful* channels, however, are channels with a connection to the other endpoint. Messages in a session on one side are always correlated with the same session on the other side. In addition, both participants in a session must agree that the requirements of their conversation were met for that session to be considered successful. If they cannot agree, the sessionful channel may fault.  
  
 Open clients explicitly or implicitly by calling the first operation.  
  
> [!NOTE]
>  Trying to explicitly detect faulted sessionful channels is not typically useful, because when you are notified depends upon the session implementation. For example, because the <xref:System.ServiceModel.NetTcpBinding?displayProperty=nameWithType> (with the reliable session disabled) surfaces the session of the TCP connection, if you listen to the <xref:System.ServiceModel.ICommunicationObject.Faulted?displayProperty=nameWithType> event on the service or the client you are likely to be notified quickly in the event of a network failure. But reliable sessions (established by bindings in which the <xref:System.ServiceModel.Channels.ReliableSessionBindingElement?displayProperty=nameWithType> is enabled) are designed to insulate services from small network failures. If the session can be reestablished within a reasonable period of time, the same binding—configured for reliable sessions—might not fault until the interruption continued for a longer period of time.  
  
 Most of the system-provided bindings (which expose channels to the application layer) use sessions by default, but the <xref:System.ServiceModel.BasicHttpBinding?displayProperty=nameWithType> does not. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Using Sessions](../../../../docs/framework/wcf/using-sessions.md).  
  
### The Proper Use of Sessions  
 Sessions provide a way to know if the entire message exchange is complete, and if both sides considered it successful. It is recommended that a calling application open the channel, use it, and close the channel inside one try block. If a session channel is open, and the <xref:System.ServiceModel.ICommunicationObject.Close%2A?displayProperty=nameWithType> method is called once, and that call returns successfully, then the session was successful. Successful in this case means that all delivery guarantees the binding specified were met, and the other side did not call <xref:System.ServiceModel.ICommunicationObject.Abort%2A?displayProperty=nameWithType> on the channel before calling <xref:System.ServiceModel.ICommunicationObject.Close%2A>.  
  
 The following section provides an example of this client approach.  
  
### Handling Exceptions  
 Handling exceptions in client applications is straightforward. If a channel is opened, used, and closed inside a try block, then the conversation has succeeded, unless an exception is thrown. Typically, if an exception is thrown the conversation is aborted.  
  
> [!NOTE]
>  Use of the `using` statement (`Using` in [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)]) is not recommended. This is because the end of the `using` statement can cause exceptions that can mask other exceptions you may need to know about. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Avoiding Problems with the Using Statement](../../../../docs/framework/wcf/samples/avoiding-problems-with-the-using-statement.md).  
  
 The following code example shows the recommended client pattern using a try/catch block and not the `using` statement.  
  
 [!code-csharp[FaultContractAttribute#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/faultcontractattribute/cs/client.cs#3)]
 [!code-vb[FaultContractAttribute#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/faultcontractattribute/vb/client.vb#3)]  
  
> [!NOTE]
>  Checking the value of the <xref:System.ServiceModel.ICommunicationObject.State%2A?displayProperty=nameWithType> property is a race condition and is not recommended to determine whether to reuse or close a channel.  
  
 Datagram channels never fault even if exceptions occur when they are closed. In addition, non-duplex clients that fail to authenticate using a secure conversation typically throw a <xref:System.ServiceModel.Security.MessageSecurityException?displayProperty=nameWithType>. However if the duplex client using a secure conversation fails to authenticate, the client receives a <xref:System.TimeoutException?displayProperty=nameWithType> instead.  
  
 For more complete information about working with error information at the application level, see [Specifying and Handling Faults in Contracts and Services](../../../../docs/framework/wcf/specifying-and-handling-faults-in-contracts-and-services.md). [Expected Exceptions](../../../../docs/framework/wcf/samples/expected-exceptions.md) describes expected exceptions and shows how to handle them. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] how to handle errors when developing channels, see [Handling Exceptions and Faults](../../../../docs/framework/wcf/extending/handling-exceptions-and-faults.md).  
  
### Client Blocking and Performance  
 When an application synchronously calls a request-reply operation, the client blocks until a return value is received or an exception (such as a <xref:System.TimeoutException?displayProperty=nameWithType>) is thrown. This behavior is similar to local behavior. When an application synchronously invokes an operation on a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client object or channel, the client does not return until the channel layer can write the data to the network or until an exception is thrown. And while the one-way message exchange pattern (specified by marking an operation with <xref:System.ServiceModel.OperationContractAttribute.IsOneWay%2A?displayProperty=nameWithType> set to `true`) can make some clients more responsive, one-way operations can also block, depending upon the binding and what messages have already been sent. One-way operations are only about the message exchange, no more and no less. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [One-Way Services](../../../../docs/framework/wcf/feature-details/one-way-services.md).  
  
 Large data chunks can slow client processing no matter what the message exchange pattern. To understand how to handle these issues, see [Large Data and Streaming](../../../../docs/framework/wcf/feature-details/large-data-and-streaming.md).  
  
 If your application must do more work while an operation completes, you should create an asynchronous method pair on the service contract interface that your [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client implements. The easiest way to do this is to use the `/async` switch on the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md). For an example, see [How to: Call Service Operations Asynchronously](../../../../docs/framework/wcf/feature-details/how-to-call-wcf-service-operations-asynchronously.md).  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] increasing client performance, see [Middle-Tier Client Applications](../../../../docs/framework/wcf/feature-details/middle-tier-client-applications.md).  
  
### Enabling the User to Select Credentials Dynamically  
 The <xref:System.ServiceModel.Dispatcher.IInteractiveChannelInitializer> interface enables applications to display a user interface that enables the user to choose credentials with which a channel is created before the timeout timers start.  
  
 Application developers can make use of an inserted <xref:System.ServiceModel.Dispatcher.IInteractiveChannelInitializer> in two ways. The client application can call either <xref:System.ServiceModel.ClientBase%601.DisplayInitializationUI%2A?displayProperty=nameWithType> or <xref:System.ServiceModel.IClientChannel.DisplayInitializationUI%2A?displayProperty=nameWithType> (or an asynchronous version) prior to opening the channel (the *explicit* approach) or call the first operation (the *implicit* approach).  
  
 If using the implicit approach, the application must call the first operation on a <xref:System.ServiceModel.ClientBase%601> or <xref:System.ServiceModel.IClientChannel> extension. If it calls anything other than the first operation, an exception is thrown.  
  
 If using the explicit approach, the application must perform the following steps in order:  
  
1.  Call either <xref:System.ServiceModel.ClientBase%601.DisplayInitializationUI%2A?displayProperty=nameWithType> or <xref:System.ServiceModel.IClientChannel.DisplayInitializationUI%2A?displayProperty=nameWithType> (or an asynchronous version).  
  
2.  When the initializers have returned, call either the <xref:System.ServiceModel.ICommunicationObject.Open%2A> method on the <xref:System.ServiceModel.IClientChannel> object or on the <xref:System.ServiceModel.IClientChannel> object returned from the <xref:System.ServiceModel.ClientBase%601.InnerChannel%2A?displayProperty=nameWithType> property.  
  
3.  Call operations.  
  
 It is recommended that production-quality applications control the user-interface process by adopting the explicit approach.  
  
 Applications that use the implicit approach invoke the user-interface initializers, but if the user of the application fails to respond within the send timeout period of the binding, an exception is thrown when the user interface returns.  
  
## See Also  
 [Duplex Services](../../../../docs/framework/wcf/feature-details/duplex-services.md)  
 [How to: Access Services with One-Way and Request-Reply Contracts](../../../../docs/framework/wcf/feature-details/how-to-access-wcf-services-with-one-way-and-request-reply-contracts.md)  
 [How to: Access Services with a Duplex Contract](../../../../docs/framework/wcf/feature-details/how-to-access-services-with-a-duplex-contract.md)  
 [How to: Access a WSE 3.0 Service](../../../../docs/framework/wcf/feature-details/how-to-access-a-wse-3-0-service-with-a-wcf-client.md)  
 [How to: Use the ChannelFactory](../../../../docs/framework/wcf/feature-details/how-to-use-the-channelfactory.md)  
 [How to: Call Service Operations Asynchronously](../../../../docs/framework/wcf/feature-details/how-to-call-wcf-service-operations-asynchronously.md)  
 [Middle-Tier Client Applications](../../../../docs/framework/wcf/feature-details/middle-tier-client-applications.md)
