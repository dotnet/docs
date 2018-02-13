---
title: "Introduction to Extensibility"
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
  - "WCF [WCF], extensibility"
  - "Windows Communication Foundation [WCF], extensibility"
  - "extensibility [WCF]"
ms.assetid: ef56c251-d63c-4b3f-944f-b0c67bfb0f68
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Introduction to Extensibility
The [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] application model is designed to solve the greater part of the communication requirements of any distributed application. But there are always scenarios that the default application model and system-provided implementations do not support. The [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] extensibility model is intended to support custom scenarios by enabling you to modify system behavior at every level, even to the point of replacing the entire application model. This topic outlines the various areas of extension and points to more information about each.  
  
## Areas to Extend  
 You can extend:  
  
-   The application runtime. This extends the dispatching and the processing of messages for the application. This area also includes extending the security system, the metadata system, the serialization system, and the bindings and binding elements that connect the application with the underlying channel system.  
  
-   The channel and channel runtime. This extends the system that functions at the message level, providing protocol, transport, and encoding support.  
  
-   The host runtime. This extends the relationship of the hosting application domain to the channel and application runtime.  
  
### Extending the Application Runtime  
 In [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] applications, there is a distinction between messages that are destined for a corresponding channel and messages that are destined for the application itself. Channel messages support some channel-related functionality, such as establishing a secure conversation or establishing a reliable session. These messages are not available to the application runtime; they are processed before the application layer is involved.  
  
 Application messages contain data that is destined for a client or service operation that you or your customer has created. These messages are available to the application-level extension system in message or object form, depending upon your needs.  
  
 All messages pass through the channel system; only application messages are passed from the channel system into the application. To create new channel-level functionality, you must extend the channel system. To create new application-level functionality, you must extend the service or client runtime (dispatchers and channel factories, respectively). [!INCLUDE[crabout](../../../includes/crabout-md.md)] extending the application runtime, see [Extending ServiceHost and the Service Model Layer](../../../docs/framework/wcf/extending/extending-servicehost-and-the-service-model-layer.md).  
  
#### Extending Security  
 To build custom security mechanisms such as tokens and credentials, you must extend the security system. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Extending Security](../../../docs/framework/wcf/extending/extending-security.md).  
  
#### Extending Metadata  
 To expose your metadata in differently than the default, you must extend the metadata system. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Extending the Metadata System](../../../docs/framework/wcf/extending/extending-the-metadata-system.md).  
  
#### Extending Serialization  
 To build custom encoders, provide data surrogates, or other work involving the customization of transferred data, you must extend the serialization system. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Extending Encoders and Serializers](../../../docs/framework/wcf/extending/extending-encoders-and-serializers.md).  
  
#### Extending Bindings  
 To associate transport or protocol channels with the application layer, you must extend the binding system. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Extending Bindings](../../../docs/framework/wcf/extending/extending-bindings.md).  
  
### Extending the Channel System  
 To create channels that support custom transports or protocol functionality, see [Extending the Channel Layer](../../../docs/framework/wcf/extending/extending-the-channel-layer.md).  
  
### Extending the Service Hosting System  
 To modify the service-wide application model, you must extend <xref:System.ServiceModel.ServiceHostBase?displayProperty=nameWithType> class. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Extending ServiceHost and the Service Model Layer](../../../docs/framework/wcf/extending/extending-servicehost-and-the-service-model-layer.md).  
  
 To modify the relationship between the hosting application domain and the service host, you must extend the <xref:System.ServiceModel.Activation.ServiceHostFactory?displayProperty=nameWithType> class. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Extending Hosting Using ServiceHostFactory](../../../docs/framework/wcf/extending/extending-hosting-using-servicehostfactory.md).  
  
## See Also  
 [Extending WCF](../../../docs/framework/wcf/extending/index.md)
