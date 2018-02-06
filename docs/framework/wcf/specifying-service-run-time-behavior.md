---
title: "Specifying Service Run-Time Behavior"
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
ms.assetid: 5c5450ea-6af1-4b75-a267-613d0ac54707
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Specifying Service Run-Time Behavior
Once you have designed a service contract ([Designing Service Contracts](../../../docs/framework/wcf/designing-service-contracts.md)) and implemented your service contract ([Implementing Service Contracts](../../../docs/framework/wcf/implementing-service-contracts.md)) you can configure the operation behavior of the service runtime. This topic discusses system-provided service and operation behaviors and describes where to find more information to create new behaviors. While some behaviors are applied as attributes, many are applied using an application configuration file or programmatically. [!INCLUDE[crabout](../../../includes/crabout-md.md)] configuring your service application, see [Configuring Services](../../../docs/framework/wcf/configuring-services.md).  
  
## Overview  
 The contract defines the inputs, outputs, data types, and capabilities of a service of that type. Implementing a service contract creates a class that, when configured with a binding at an address, fulfills the contract it implements. Contractual, binding, and address information are all known by the client; without them, the client cannot make use of the service.  
  
 However, operation specifics, such as threading issues or instance management, are opaque to clients. Once you have implemented your service contract, you can configure a large number of operation characteristics by using *behaviors*. Behaviors are objects that modify the [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] runtime by either setting a runtime property or by inserting a customization type into the runtime. [!INCLUDE[crabout](../../../includes/crabout-md.md)] modifying the runtime by creating user-defined behaviors, see [Extending ServiceHost and the Service Model Layer](../../../docs/framework/wcf/extending/extending-servicehost-and-the-service-model-layer.md).  
  
 The <xref:System.ServiceModel.ServiceBehaviorAttribute?displayProperty=nameWithType> and <xref:System.ServiceModel.OperationBehaviorAttribute?displayProperty=nameWithType> attributes are the most widely useful behaviors and expose the most commonly requested operation features. Because they are attributes, you apply them to the service or operation implementation. Other behaviors, such as the <xref:System.ServiceModel.Description.ServiceMetadataBehavior?displayProperty=nameWithType> or <xref:System.ServiceModel.Description.ServiceDebugBehavior?displayProperty=nameWithType>, are typically applied using an application configuration file, although you can use them programmatically.  
  
 This topic provides an overview of the <xref:System.ServiceModel.ServiceBehaviorAttribute> and <xref:System.ServiceModel.OperationBehaviorAttribute> attributes, describes the various scopes at which behaviors can operate, and provides a quick description of many of the system-provided behaviors at the various scopes that may be of interest to [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] developers.  
  
## ServiceBehaviorAttribute and OperationBehaviorAttribute  
 The most important behaviors are the <xref:System.ServiceModel.ServiceBehaviorAttribute> and <xref:System.ServiceModel.OperationBehaviorAttribute> attributes, which you can use to control:  
  
-   Instance lifetimes  
  
-   Concurrency and synchronization support  
  
-   Configuration behavior  
  
-   Transaction behavior  
  
-   Serialization behavior  
  
-   Metadata transformation  
  
-   Session lifetime  
  
-   Address filtering and header processing  
  
-   Impersonation  
  
-   To use these attributes, mark the service or operation implementation with the attribute appropriate to that scope and set the properties. For example, the following code example shows an operation implementation that uses the <xref:System.ServiceModel.OperationBehaviorAttribute.Impersonation%2A?displayProperty=nameWithType> property to require that callers of this operation support impersonation.  
  
 [!code-csharp[OperationBehaviorAttribute_Impersonation#1](../../../samples/snippets/csharp/VS_Snippets_CFX/operationbehaviorattribute_impersonation/cs/services.cs#1)]
 [!code-vb[OperationBehaviorAttribute_Impersonation#1](../../../samples/snippets/visualbasic/VS_Snippets_CFX/operationbehaviorattribute_impersonation/vb/services.vb#1)]  
  
 Many of the properties require additional support from the binding. For example, an operation that requires a transaction from the client must be configured to use a binding that supports flowed transactions.  
  
### Well-Known Singleton Services  
 You can use the <xref:System.ServiceModel.ServiceBehaviorAttribute> and <xref:System.ServiceModel.OperationBehaviorAttribute> attributes to control certain lifetimes, both of the <xref:System.ServiceModel.InstanceContext> and of the service objects that implement the operations.  
  
 For example, the <xref:System.ServiceModel.ServiceBehaviorAttribute.InstanceContextMode%2A?displayProperty=nameWithType> property controls how often the <xref:System.ServiceModel.InstanceContext> is released, and the <xref:System.ServiceModel.OperationBehaviorAttribute.ReleaseInstanceMode%2A?displayProperty=nameWithType> and <xref:System.ServiceModel.ServiceBehaviorAttribute.ReleaseServiceInstanceOnTransactionComplete%2A?displayProperty=nameWithType> properties control when the service object is released.  
  
 However, you can also create a service object yourself and create the service host using that object. To do so, you must also set the <xref:System.ServiceModel.ServiceBehaviorAttribute.InstanceContextMode%2A?displayProperty=nameWithType> property to <xref:System.ServiceModel.InstanceContextMode.Single> or an exception is thrown when the service host is opened.  
  
 Use the <xref:System.ServiceModel.ServiceHost.%23ctor%28System.Object%2CSystem.Uri%5B%5D%29?displayProperty=nameWithType> constructor to create such a service. It provides an alternative to implementing a custom <xref:System.ServiceModel.Dispatcher.IInstanceContextInitializer?displayProperty=nameWithType> when you wish to provide a specific object instance for use by a singleton service. You can use this overload when your service implementation type is difficult to construct (for example, if it does not implement a default public constructor that has no parameters).  
  
 Note that when an object is provided to this constructor, some features related to the [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] instancing behavior work differently. For example, calling <xref:System.ServiceModel.InstanceContext.ReleaseServiceInstance%2A?displayProperty=nameWithType> has no effect when a well-known object instance is provided. Similarly, any other instance release mechanism is ignored. The <xref:System.ServiceModel.ServiceHost> class always behaves as if the <xref:System.ServiceModel.OperationBehaviorAttribute.ReleaseInstanceMode%2A?displayProperty=nameWithType> property is set to <xref:System.ServiceModel.ReleaseInstanceMode.None?displayProperty=nameWithType> for all operations.  
  
## Other Service, Endpoint, Contract, and Operation Behaviors  
 Service behaviors, such as the <xref:System.ServiceModel.ServiceBehaviorAttribute> attribute, operate across an entire service. For example, if you set the <xref:System.ServiceModel.ServiceBehaviorAttribute.ConcurrencyMode%2A?displayProperty=nameWithType> property to <xref:System.ServiceModel.ConcurrencyMode.Multiple?displayProperty=nameWithType> you must handle thread synchronization issues inside each operation in that service yourself. Endpoint behaviors operate across an endpoint; many of the system-provided endpoint behaviors are for client functionality. Contract behaviors operate at the contract level, and operation behaviors modify operation delivery.  
  
 Many of these behaviors are implemented on attributes, and you make use of them as you do the <xref:System.ServiceModel.ServiceBehaviorAttribute> and <xref:System.ServiceModel.OperationBehaviorAttribute> attributes—by applying them to the appropriate service class or operation implementation. Other behaviors, such as the <xref:System.ServiceModel.Description.ServiceMetadataBehavior> or <xref:System.ServiceModel.Description.ServiceDebugBehavior> objects, are typically applied using an application configuration file, although they can also be used programmatically.  
  
 For example, the publication of metadata is configured by using the <xref:System.ServiceModel.Description.ServiceMetadataBehavior> object. The following application configuration file shows the most common usage.  
  
 [!code-csharp[ServiceMetadataBehavior#1](../../../samples/snippets/csharp/VS_Snippets_CFX/servicemetadatabehavior/cs/hostapplication.cs#1)]  
  
 The following sections describe many of the most useful system-provided behaviors that you can use to modify the runtime delivery of your service or client. See the reference topic to determine how to use each one.  
  
### Service Behaviors  
 The following behaviors operate on services.  
  
-   <xref:System.ServiceModel.Activation.AspNetCompatibilityRequirementsAttribute>. Applied to a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service to indicate whether that service can be run in [!INCLUDE[vstecasp](../../../includes/vstecasp-md.md)] Compatibility Mode.  
  
-   <xref:System.ServiceModel.Description.ServiceAuthorizationBehavior>. Controls how the service authorizes client claims.  
  
-   <xref:System.ServiceModel.Description.ServiceCredentials>. Configures a service credential. Use this class to specify the credential for the service, such as an X.509 certificate.  
  
-   <xref:System.ServiceModel.Description.ServiceDebugBehavior>. Enables debugging and Help information features for a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service.  
  
-   <xref:System.ServiceModel.Description.ServiceMetadataBehavior>. Controls the publication of service metadata and associated information.  
  
-   <xref:System.ServiceModel.Description.ServiceSecurityAuditBehavior>. Specifies the audit behavior of security events.  
  
-   <xref:System.ServiceModel.Description.ServiceThrottlingBehavior>. Configures run-time throughput settings that enable you to tune service performance.  
  
### Endpoint Behaviors  
 The following behaviors operate on endpoints. Many of these behaviors are used in client applications.  
  
-   <xref:System.ServiceModel.CallbackBehaviorAttribute>. Configures a callback service implementation in a duplex client application.  
  
-   <xref:System.ServiceModel.Description.CallbackDebugBehavior>. Enables service debugging for a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] callback object.  
  
-   <xref:System.ServiceModel.Description.ClientCredentials>. Allows the user to configure client and service credentials as well as service credential authentication settings for use on the client.  
  
-   <xref:System.ServiceModel.Description.ClientViaBehavior>. Used by clients to specify the Uniform Resource Identifier (URI) for which the transport channel should be created.  
  
-   <xref:System.ServiceModel.Description.MustUnderstandBehavior>. Instructs [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] to disable the `MustUnderstand` processing.  
  
-   <xref:System.ServiceModel.Description.SynchronousReceiveBehavior>. Instructs the runtime to use a synchronous receive process for channels.  
  
-   <xref:System.ServiceModel.Description.TransactedBatchingBehavior>. Optimizes the receive operations for transports that support transactional receives.  
  
### Contract Behaviors  
 <xref:System.ServiceModel.DeliveryRequirementsAttribute>. Specifies the feature requirements that bindings must provide to the service or client implementation.  
  
### Operation Behaviors  
 The following operation behaviors specify serialization and transaction controls for operations.  
  
-   <xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior>. Represents the run-time behavior of the <xref:System.Runtime.Serialization.DataContractSerializer?displayProperty=nameWithType>.  
  
-   <xref:System.ServiceModel.Description.XmlSerializerOperationBehavior>. Controls run-time behavior of the `XmlSerializer` and associates it with an operation.  
  
-   <xref:System.ServiceModel.TransactionFlowAttribute>. Specifies the level in which a service operation accepts a transaction header.  
  
## See Also  
 [Configuring Services](../../../docs/framework/wcf/configuring-services.md)  
 [How to: Control Service Instancing](../../../docs/framework/wcf/feature-details/how-to-control-service-instancing.md)
