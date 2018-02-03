---
title: "Sessions, Instancing, and Concurrency"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 50797a3b-7678-44ed-8138-49ac1602f35b
caps.latest.revision: 16
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Sessions, Instancing, and Concurrency
A *session* is a correlation of all messages sent between two endpoints. *Instancing* refers to controlling the lifetime of user-defined service objects and their related <xref:System.ServiceModel.InstanceContext> objects. *Concurrency* is the term given to the control of the number of threads executing in an <xref:System.ServiceModel.InstanceContext> at the same time.  
  
 This topic describes these settings, how to use them, and the various interactions between them.  
  
## Sessions  
 When a service contract sets the <xref:System.ServiceModel.ServiceContractAttribute.SessionMode%2A?displayProperty=nameWithType> property to <xref:System.ServiceModel.SessionMode.Required?displayProperty=nameWithType>, that contract is saying that all calls (that is, the underlying message exchanges that support the calls) must be part of the same conversation. If a contract specifies that it allows sessions but does not require one, clients can connect and either establish a session or not. If the session ends and a message is sent over the same session-based channel an exception is thrown.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] sessions have the following main conceptual features:  
  
-   They are explicitly initiated and terminated by the calling application.  
  
-   Messages delivered during a session are processed in the order in which they are received.  
  
-   Sessions correlate a group of messages into a conversation. The meaning of that correlation is an abstraction. For instance, one session-based channel may correlate messages based on a shared network connection while another session-based channel may correlate messages based on a shared tag in the message body. The features that can be derived from the session depend on the nature of the correlation.  
  
-   There is no general data store associated with a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] session.  
  
 If you are familiar with the <xref:System.Web.SessionState.HttpSessionState?displayProperty=nameWithType> class in [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] applications and the functionality it provides, you might notice the following differences between that kind of session and [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] sessions:  
  
-   [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] sessions are always server-initiated.  
  
-   [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] sessions are implicitly unordered.  
  
-   [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] sessions provide a general data storage mechanism across requests.  
  
 Client applications and service applications interact with sessions in different ways. Client applications initiate sessions and then receive and process the messages sent within the session. Service applications can use sessions as an extensibility point to add additional behavior. This is done by working directly with the <xref:System.ServiceModel.InstanceContext> or implementing a custom instance context provider.  
  
## Instancing  
 The instancing behavior (set by using the <xref:System.ServiceModel.ServiceBehaviorAttribute.InstanceContextMode%2A?displayProperty=nameWithType> property) controls how the <xref:System.ServiceModel.InstanceContext> is created in response to incoming messages. By default, each <xref:System.ServiceModel.InstanceContext> is associated with one user-defined service object, so (in the default case) setting the <xref:System.ServiceModel.ServiceBehaviorAttribute.InstanceContextMode%2A> property also controls the instancing of user-defined service objects. The <xref:System.ServiceModel.InstanceContextMode> enumeration defines the instancing modes.  
  
 The following instancing modes are available:  
  
-   <xref:System.ServiceModel.InstanceContextMode.PerCall>: A new <xref:System.ServiceModel.InstanceContext> (and therefore service object) is created for each client request.  
  
-   <xref:System.ServiceModel.InstanceContextMode.PerSession>: A new <xref:System.ServiceModel.InstanceContext> (and therefore service object) is created for each new client session and maintained for the lifetime of that session (this requires a binding that supports sessions).  
  
-   <xref:System.ServiceModel.InstanceContextMode.Single>: A single <xref:System.ServiceModel.InstanceContext> (and therefore service object) handles all client requests for the lifetime of the application.  
  
 The following code example shows the default <xref:System.ServiceModel.InstanceContextMode> value, <xref:System.ServiceModel.InstanceContextMode.PerSession> being explicitly set on a service class.  
  
```  
[ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]   
public class CalculatorService : ICalculatorInstance   
{   
    ...  
}  
```  
  
 And while the <xref:System.ServiceModel.ServiceBehaviorAttribute.InstanceContextMode%2A?displayProperty=nameWithType> property controls how often the <xref:System.ServiceModel.InstanceContext> is released, the <xref:System.ServiceModel.OperationBehaviorAttribute.ReleaseInstanceMode%2A?displayProperty=nameWithType> and <xref:System.ServiceModel.ServiceBehaviorAttribute.ReleaseServiceInstanceOnTransactionComplete%2A?displayProperty=nameWithType> properties control when the service object is released.  
  
### Well-Known Singleton Services  
 One variation on single instance service objects is sometimes useful: you can create a service object yourself and create the service host using that object. To do so, you must also set the <xref:System.ServiceModel.ServiceBehaviorAttribute.InstanceContextMode%2A?displayProperty=nameWithType> property to <xref:System.ServiceModel.InstanceContextMode.Single> or an exception is thrown when the service host is opened.  
  
 Use the <xref:System.ServiceModel.ServiceHost.%23ctor%28System.Object%2CSystem.Uri%5B%5D%29?displayProperty=nameWithType> constructor to create such a service. It provides an alternative to implementing a custom <xref:System.ServiceModel.Dispatcher.IInstanceContextInitializer?displayProperty=nameWithType> when you wish to provide a specific object instance for use by a singleton service. You can use this overload when your service implementation type is difficult to construct (for example, if it does not implement a default parameterless public constructor).  
  
 Note that when an object is provided to this constructor, some features related to the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] instancing behavior work differently. For example, calling <xref:System.ServiceModel.InstanceContext.ReleaseServiceInstance%2A?displayProperty=nameWithType> has no effect when a singleton object instance is provided. Similarly, any other instance-release mechanism is ignored. The <xref:System.ServiceModel.ServiceHost> always behaves as if the <xref:System.ServiceModel.OperationBehaviorAttribute.ReleaseInstanceMode%2A?displayProperty=nameWithType> property is set to <xref:System.ServiceModel.ReleaseInstanceMode.None?displayProperty=nameWithType> for all operations.  
  
### Sharing InstanceContext Objects  
 You can also control which sessionful channel or call is associated with which <xref:System.ServiceModel.InstanceContext> object by performing that association yourself.  
  
## Concurrency  
 Concurrency is the control of the number of threads active in an <xref:System.ServiceModel.InstanceContext> at any one time. This is controlled by using the <xref:System.ServiceModel.ServiceBehaviorAttribute.ConcurrencyMode%2A?displayProperty=nameWithType> with the <xref:System.ServiceModel.ConcurrencyMode> enumeration.  
  
 The following three concurrency modes are available:  
  
-   <xref:System.ServiceModel.ConcurrencyMode.Single>: Each instance context is allowed to have a maximum of one thread processing messages in the instance context at a time. Other threads wishing to use the same instance context must block until the original thread exits the instance context.  
  
-   <xref:System.ServiceModel.ConcurrencyMode.Multiple>: Each service instance can have multiple threads processing messages concurrently. The service implementation must be thread-safe to use this concurrency mode.  
  
-   <xref:System.ServiceModel.ConcurrencyMode.Reentrant>: Each service instance processes one message at a time, but accepts re-entrant operation calls. The service only accepts these calls when it is calling out through a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client object.  
  
> [!NOTE]
>  Understanding and developing code that safely uses more than one thread can be difficult to write successfully. Before using <xref:System.ServiceModel.ConcurrencyMode.Multiple> or <xref:System.ServiceModel.ConcurrencyMode.Reentrant> values, ensure that your service is properly designed for these modes. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] <xref:System.ServiceModel.ServiceBehaviorAttribute.ConcurrencyMode%2A>.  
  
 The use of concurrency is related to the instancing mode. In <xref:System.ServiceModel.InstanceContextMode.PerCall> instancing, concurrency is not relevant, because each message is processed by a new <xref:System.ServiceModel.InstanceContext> and, therefore, never more than one thread is active in the <xref:System.ServiceModel.InstanceContext>.  
  
 The following code example demonstrates setting the <xref:System.ServiceModel.ServiceBehaviorAttribute.ConcurrencyMode%2A> property to <xref:System.ServiceModel.ConcurrencyMode.Multiple>.  
  
```  
[ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]   
public class CalculatorService : ICalculatorConcurrency   
{   
    ...  
}  
```  
  
## Sessions Interact with InstanceContext Settings  
 Sessions and <xref:System.ServiceModel.InstanceContext> interact depending upon the combination of the value of the <xref:System.ServiceModel.SessionMode> enumeration in a contract and the <xref:System.ServiceModel.ServiceBehaviorAttribute.InstanceContextMode%2A?displayProperty=nameWithType> property on the service implementation, which controls the association between channels and specific service objects.  
  
 The following table shows the result of an incoming channel either supporting sessions or not supporting sessions given a service's combination of the values of the <xref:System.ServiceModel.ServiceContractAttribute.SessionMode%2A?displayProperty=nameWithType> property and the <xref:System.ServiceModel.ServiceBehaviorAttribute.InstanceContextMode%2A?displayProperty=nameWithType> property.  
  
|InstanceContextMode value|<xref:System.ServiceModel.SessionMode.Required>|<xref:System.ServiceModel.SessionMode.Allowed>|<xref:System.ServiceModel.SessionMode.NotAllowed>|  
|-------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------|  
|PerCall|-   Behavior with sessionful channel: A session and <xref:System.ServiceModel.InstanceContext> for each call.<br />-   Behavior with sessionless channel: An exception is thrown.|-   Behavior with sessionful channel: A session and <xref:System.ServiceModel.InstanceContext> for each call.<br />-   Behavior with sessionless channel: An <xref:System.ServiceModel.InstanceContext> for each call.|-   Behavior with sessionful channel: An exception is thrown.<br />-   Behavior with sessionless channel: An <xref:System.ServiceModel.InstanceContext> for each call.|  
|PerSession|-   Behavior with sessionful channel: A session and <xref:System.ServiceModel.InstanceContext> for each channel.<br />-   Behavior with sessionless channel: An exception is thrown.|-   Behavior with sessionful channel: A session and <xref:System.ServiceModel.InstanceContext> for each channel.<br />-   Behavior with sessionless channel: An <xref:System.ServiceModel.InstanceContext> for each call.|-   Behavior with sessionful channel: An exception is thrown.<br />-   Behavior with sessionless channel: An <xref:System.ServiceModel.InstanceContext> for each call.|  
|Single|-   Behavior with sessionful channel: A session and one <xref:System.ServiceModel.InstanceContext> for all calls.<br />-   Behavior with sessionless channel: An exception is thrown.|-   Behavior with sessionful channel: A session and <xref:System.ServiceModel.InstanceContext> for the created or user-specified singleton.<br />-   Behavior with sessionless channel: An <xref:System.ServiceModel.InstanceContext> for the created or user-specified singleton.|-   Behavior with sessionful channel: An exception is thrown.<br />-   Behavior with sessionless channel: An <xref:System.ServiceModel.InstanceContext> for each created singleton or for the user-specified singleton.|  
  
## See Also  
 [Using Sessions](../../../../docs/framework/wcf/using-sessions.md)  
 [How to: Create a Service That Requires Sessions](../../../../docs/framework/wcf/feature-details/how-to-create-a-service-that-requires-sessions.md)  
 [How to: Control Service Instancing](../../../../docs/framework/wcf/feature-details/how-to-control-service-instancing.md)  
 [Concurrency](../../../../docs/framework/wcf/samples/concurrency.md)  
 [Instancing](../../../../docs/framework/wcf/samples/instancing.md)  
 [Session](../../../../docs/framework/wcf/samples/session.md)
