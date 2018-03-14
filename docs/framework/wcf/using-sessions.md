---
title: "Using Sessions"
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
helpviewer_keywords: 
  - "sessions [WCF]"
ms.assetid: 864ba12f-3331-4359-a359-6d6d387f1035
caps.latest.revision: 32
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using Sessions
In [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] applications, a *session* correlates a group of messages into a conversation. [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] sessions are different than the session object available in [!INCLUDE[vstecasp](../../../includes/vstecasp-md.md)] applications, support different behaviors, and are controlled in different ways. This topic describes the features that sessions enable in [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] applications and how to use them.  
  
## Sessions in Windows Communication Foundation Applications  
 When a service contract specifies that it requires a session, that contract is specifying that all calls (that is, the underlying message exchanges that support the calls) must be part of the same conversation. If a contract specifies that it allows sessions but does not require one, clients can connect and either establish a session or not establish a session. If the session ends and a message is sent through the same channel an exception is thrown.  
  
 [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] sessions have the following main conceptual features:  
  
-   They are explicitly initiated and terminated by the calling application (the WCF client).  
  
-   Messages delivered during a session are processed in the order in which they are received.  
  
-   Sessions correlate a group of messages into a conversation. Different types of correlation are possible. For instance, one session-based channel may correlate messages based on a shared network connection while another session-based channel may correlate messages based on a shared tag in the message body. The features that can be derived from the session depend on the nature of the correlation.  
  
-   There is no general data store associated with a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] session.  
  
 If you are familiar with the <xref:System.Web.SessionState.HttpSessionState?displayProperty=nameWithType> class in [!INCLUDE[vstecasp](../../../includes/vstecasp-md.md)] applications and the functionality it provides, you might notice the following differences between that kind of session and [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] sessions:  
  
-   [!INCLUDE[vstecasp](../../../includes/vstecasp-md.md)] sessions are always server-initiated.  
  
-   [!INCLUDE[vstecasp](../../../includes/vstecasp-md.md)] sessions are implicitly unordered.  
  
-   [!INCLUDE[vstecasp](../../../includes/vstecasp-md.md)] sessions provide a general data storage mechanism across requests.  
  
 This topic describes:  
  
-   The default execution behavior when using session-based bindings in the service model layer.  
  
-   The types of features that the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] session-based, system-provided bindings provide.  
  
-   How to create a contract that declares a session requirement.  
  
-   How to understand and control the creation and termination of the session and the relationship of the session to the service instance.  
  
## Default Execution Behavior Using Sessions  
 A binding that attempts to initiate a session is called a *session-based* binding. Service contracts specify that they require, permit, or refuse session-based bindings by setting the <xref:System.ServiceModel.ServiceContractAttribute.SessionMode%2A?displayProperty=nameWithType> property on the service contract interface (or class) to one of the <xref:System.ServiceModel.SessionMode?displayProperty=nameWithType> enumeration values. By default, the value of this property is <xref:System.ServiceModel.SessionMode.Allowed>, which means that if a client uses a session-based binding with a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service implementation, the service establishes and uses the session provided.  
  
 When a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service accepts a client session, the following features are enabled by default:  
  
1.  All calls between a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client object are handled by the same service instance.  
  
2.  Different session-based bindings provide additional features.  
  
## System-Provided Session Types  
 A session-based binding supports the default association of a service instance with a particular session. However, different session-based bindings support different features in addition to enabling the session-based instancing control previously described.  
  
 [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] provides the following types of session-based application behavior:  
  
-   The <xref:System.ServiceModel.Channels.SecurityBindingElement?displayProperty=nameWithType> supports security-based sessions, in which both ends of communication have agreed upon a specific secure conversation. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Securing Services](../../../docs/framework/wcf/securing-services.md). For example, the <xref:System.ServiceModel.WSHttpBinding?displayProperty=nameWithType> binding, which contains support for both security sessions and reliable sessions, by default uses only a secure session that encrypts and digitally signs messages.  
  
-   The <xref:System.ServiceModel.NetTcpBinding?displayProperty=nameWithType> binding supports TCP/IP-based sessions to ensure that all messages are correlated by the connection at the socket level.  
  
-   The <xref:System.ServiceModel.Channels.ReliableSessionBindingElement?displayProperty=nameWithType> element, which implements the WS-ReliableMessaging specification, provides support for reliable sessions in which messages can be configured to be delivered in order and exactly once, ensuring messages are received even when messages travel across multiple nodes during the conversation. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Reliable Sessions](../../../docs/framework/wcf/feature-details/reliable-sessions.md).  
  
-   The <xref:System.ServiceModel.NetMsmqBinding?displayProperty=nameWithType> binding provides MSMQ datagram sessions. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Queues in WCF](../../../docs/framework/wcf/feature-details/queues-in-wcf.md).  
  
 Setting the <xref:System.ServiceModel.ServiceContractAttribute.SessionMode%2A> property does not specify the type of session the contract requires, only that it requires one.  
  
## Creating a Contract That Requires a Session  
 Creating a contract that requires a session states that the group of operations that the service contract declares must all be executed within the same session and that messages must be delivered in order. To assert the level of session support that a service contract requires, set the <xref:System.ServiceModel.ServiceContractAttribute.SessionMode%2A?displayProperty=nameWithType> property on your service contract interface or class to the value of the <xref:System.ServiceModel.SessionMode?displayProperty=nameWithType> enumeration to specify whether the contract:  
  
-   Requires a session.  
  
-   Allows a client to establish a session.  
  
-   Prohibits a session.  
  
 Setting the <xref:System.ServiceModel.ServiceContractAttribute.SessionMode%2A> property does not, however, specify the type of session-based behavior the contract requires. It instructs [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] to confirm at runtime that the configured binding (which creates the communication channel) for the service does, does not, or can establish a session when implementing a service. Again, the binding can satisfy that requirement with any type of session-based behavior it chooses—security, transport, reliable, or some combination. The exact behavior depends on the <xref:System.ServiceModel.SessionMode?displayProperty=nameWithType> value selected. If the configured binding of the service does not conform to the value of <xref:System.ServiceModel.ServiceContractAttribute.SessionMode%2A>, an exception is thrown. Bindings and the channels they create that support sessions are said to be session-based.  
  
 The following service contract specifies that all operations in the `ICalculatorSession` must be exchanged within a session. None of the operations returns a value to the caller except the `Equals` method. However, the `Equals` method takes no parameters and, therefore, can only return a non-zero value inside a session in which data has already been passed to the other operations. This contract requires a session to function properly. Without a session associated with a specific client, the service instance has no way of knowing what previous data this client has sent.  
  
 [!code-csharp[S_Service_Session#1](../../../samples/snippets/csharp/VS_Snippets_CFX/s_service_session/cs/service.cs#1)]
 [!code-vb[S_Service_Session#1](../../../samples/snippets/visualbasic/VS_Snippets_CFX/s_service_session/vb/service.vb#1)]  
  
 If a service allows a session, then a session is established and used if the client initiates one; otherwise, no session is established.  
  
## Sessions and Service Instances  
 If you use the default instancing behavior in [!INCLUDE[indigo2](../../../includes/indigo2-md.md)], all calls between a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client object are handled by the same service instance. Therefore, at the application level, you can think of a session as enabling application behavior similar to local call behavior. For example, when you create a local object:  
  
-   A constructor is called.  
  
-   All subsequent calls made to the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client object reference are processed by the same object instance.  
  
-   A destructor is called when the object reference is destroyed.  
  
 Sessions enable a similar behavior between clients and services as long as the default service instance behavior is used. If a service contract requires or supports sessions, one or more contract operations can be marked as initiating or terminating a session by setting the <xref:System.ServiceModel.OperationContractAttribute.IsInitiating%2A> and <xref:System.ServiceModel.OperationContractAttribute.IsTerminating%2A> properties.  
  
 *Initiating operations* are those that must be called as the first operation of a new session. Non-initiating operations can be called only after at least one initiating operation has been called. You can therefore create a kind of session constructor for your service by declaring initiating operations designed to take input from clients appropriate to the beginning of the service instance. (The state is associated with the session, however, and not the service object.)  
  
 *Terminating operations*, conversely, are those that must be called as the last message in an existing session. In the default case, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] recycles the service object and its context after the session with which the service was associated is closed. You can, therefore, create a kind of destructor by declaring terminating operations designed to perform a function appropriate to the end of the service instance.  
  
> [!NOTE]
>  Although the default behavior bears a resemblance to local constructors and destructors, it is only a resemblance. Any [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service operation can be an initiating or terminating operation, or both at the same time. In addition, in the default case, initiating operations can be called any number of times in any order; no additional sessions are created once the session is established and associated with an instance unless you explicitly control the lifetime of the service instance (by manipulating the <xref:System.ServiceModel.InstanceContext?displayProperty=nameWithType> object). Finally, the state is associated with the session and not the service object.  
  
 For example, the `ICalculatorSession` contract used in the preceding example requires that the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client object first call the `Clear` operation prior to any other operation and that the session with this [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client object should terminate when it calls the `Equals` operation. The following code example shows a contract that enforces these requirements. `Clear` must be called first to initiate a session, and that session ends when `Equals` is called.  
  
 [!code-csharp[SCA.IsInitiatingIsTerminating#1](../../../samples/snippets/csharp/VS_Snippets_CFX/sca.isinitiatingisterminating/cs/service.cs#1)]
 [!code-vb[SCA.IsInitiatingIsTerminating#1](../../../samples/snippets/visualbasic/VS_Snippets_CFX/sca.isinitiatingisterminating/vb/service.vb#1)]  
  
 Services do not start sessions with clients. In [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client applications, a direct relationship exists between the lifetime of the session-based channel and the lifetime of the session itself. As such, clients create new sessions by creating new session-based channels and tear down existing sessions by closing session-based channels gracefully. A client starts a session with a service endpoint by calling one of the following:  
  
-   <xref:System.ServiceModel.ICommunicationObject.Open%2A?displayProperty=nameWithType> on the channel returned by a call to <xref:System.ServiceModel.ChannelFactory%601.CreateChannel%2A?displayProperty=nameWithType>.  
  
-   <xref:System.ServiceModel.ClientBase%601.Open%2A?displayProperty=nameWithType> on the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client object generated by the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md).  
  
-   An initiating operation on either type of [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client object (by default, all operations are initiating). When the first operation is called, the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client object automatically opens the channel and initiates a session.  
  
 Typically a client ends a session with a service endpoint by calling one of the following:  
  
-   <xref:System.ServiceModel.ICommunicationObject.Close%2A?displayProperty=nameWithType> on the channel returned by a call to <xref:System.ServiceModel.ChannelFactory%601.CreateChannel%2A?displayProperty=nameWithType>.  
  
-   <xref:System.ServiceModel.ClientBase%601.Close%2A?displayProperty=nameWithType> on the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client object generated by Svcutil.exe.  
  
-   A terminating operation on either type of [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client object (by default, no operations are terminating; the contract must explicitly specify a terminating operation). When the first operation is called, the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client object automatically opens the channel and initiates a session.  
  
 For examples, see [How to: Create a Service That Requires Sessions](../../../docs/framework/wcf/feature-details/how-to-create-a-service-that-requires-sessions.md) as well as the [Default Service Behavior](../../../docs/framework/wcf/samples/default-service-behavior.md) and [Instancing](../../../docs/framework/wcf/samples/instancing.md) samples.  
  
 [!INCLUDE[crabout](../../../includes/crabout-md.md)] clients and sessions, see [Accessing Services Using a WCF Client](../../../docs/framework/wcf/feature-details/accessing-services-using-a-client.md).  
  
## Sessions Interact with InstanceContext Settings  
 There is an interaction between the <xref:System.ServiceModel.SessionMode> enumeration in a contract and the <xref:System.ServiceModel.ServiceBehaviorAttribute.InstanceContextMode%2A?displayProperty=nameWithType> property, which controls the association between channels and specific service objects. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Sessions, Instancing, and Concurrency](../../../docs/framework/wcf/feature-details/sessions-instancing-and-concurrency.md).  
  
### Sharing InstanceContext Objects  
 You can also control which session-based channel or call is associated with which <xref:System.ServiceModel.InstanceContext> object by performing that association yourself. For a complete example, see [InstanceContextSharing](http://msdn.microsoft.com/library/4a6a46d7-b7d7-4bb5-a0dd-03ffa3cbc230).  
  
## Sessions and Streaming  
 When you have a large amount of data to transfer, the streaming transfer mode in [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] is a feasible alternative to the default behavior of buffering and processing messages in memory in their entirety. You may get unexpected behavior when streaming calls with a session-based binding. All streaming calls are made through a single channel (the datagram channel) that does not support sessions even if the binding being used is configured to use sessions. If multiple clients make streaming calls to the same service object over a session-based binding, and the service object's concurrency mode is set to single and its instance context mode is set to `PerSession`, all calls must go through the datagram channel and so only one call is processed at a time. One or more clients may then time out. You can work around this issue by either setting the service object's `InstanceContextMode` to `PerCall` or Concurrency to multiple.  
  
> [!NOTE]
>  MaxConcurrentSessions have no effect in this case because there is only one "session" available.  
  
## See Also  
 <xref:System.ServiceModel.OperationContractAttribute.IsInitiating%2A>  
 <xref:System.ServiceModel.OperationContractAttribute.IsTerminating%2A>
