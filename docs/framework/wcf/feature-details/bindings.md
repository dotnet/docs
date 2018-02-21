---
title: "Windows Communcation Foundation Bindings"
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
  - "WCF [WCF], bindings"
  - "Windows Communication Foundation [WCF], bindings"
  - "bindings [WCF]"
ms.assetid: 83639133-89f7-43f0-b4ef-8d9e57c08d25
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Windows Communcation Foundation Bindings
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] separates how the software for an application is written from how it communicates with other software. Bindings are used to specify the transport, encoding, and protocol details required for clients and services to communicate with each other. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses bindings to generate the underlying wire representation of the endpoint, so most of the binding details must be agreed upon by the parties that are communicating. The easiest way to achieve this is for clients of a service to use the same binding that the endpoint for the service uses. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] how to do this, see [Using Bindings to Configure Windows Communication Foundation Services and Clients](http://msdn.microsoft.com/library/bd8b277b-932f-472f-a42a-b02bb5257dfb).  
  
 A binding is made up of a collection of binding elements. Each element describes some aspect of how the endpoint communicates with clients. A binding must include at least one transport binding element, at least one message-encoding binding element (which the transport binding element can provide by default), and any number of other protocol binding elements. The process that builds a runtime out of this description allows each binding element to contribute code to that runtime.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides bindings that contain common selections of binding elements. These can be used with their default settings or you can modify those default values according to user requirements. These system-provided bindings have properties that allow direct control over the binding elements and their settings. You can also easily work side-by-side with multiple versions of a binding by giving each version of the binding its own name. For details, see [Configuring System-Provided Bindings](../../../../docs/framework/wcf/feature-details/configuring-system-provided-bindings.md).  
  
 If you need a collection of binding elements not provided by one of these system-provided bindings, you can create a custom binding that consists of the collection of binding elements required. These custom bindings are easy to create and do not require a new class, but they do not provide properties for controlling the binding elements or their settings. You can access the binding elements and modify their settings through the collection that contains them. For details, see [Custom Bindings](../../../../docs/framework/wcf/extending/custom-bindings.md).  
  
## In This Section  
 [Configuring System-Provided Bindings](../../../../docs/framework/wcf/feature-details/configuring-system-provided-bindings.md)  
 Describes how to use and modify the bindings that [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides to support common scenarios.  
  
 [Using Bindings to Configure Windows Communication Foundation Services and Clients](http://msdn.microsoft.com/library/bd8b277b-932f-472f-a42a-b02bb5257dfb)  
 Describes how to define [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] bindings for services and clients imperatively in code and declaratively using configuration.  
  
 [Custom Bindings](../../../../docs/framework/wcf/extending/custom-bindings.md)  
 Describes what a <xref:System.ServiceModel.Channels.CustomBinding> is and when it is used.  
  
## Reference  
 <xref:System.ServiceModel.Channels.Binding>  
  
 <xref:System.ServiceModel.Channels.BindingElement>  
  
 <xref:System.ServiceModel.Channels.CustomBinding>  
  
## Related Sections  
 [Extending Bindings](../../../../docs/framework/wcf/extending/extending-bindings.md)
