---
title: "Extending ServiceHost and the Service Model Layer"
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
  - "extending service models [WCF]"
ms.assetid: 954c138a-1cd0-45a0-8abe-e4d2b8ff5400
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Extending ServiceHost and the Service Model Layer
The service model layer is responsible for pulling incoming messages out of the underlying channels, translating them into method invocations in application code, and sending the results back to the caller. Service model extensions modify or implement execution or communication behavior and features involving client or dispatcher functionality, custom behaviors, message and parameter interception, and other extensibility functionality.  
  
## In This Section  
 [Extending Clients](../../../../docs/framework/wcf/extending/extending-clients.md)  
 Describes the interfaces that can intercept and modify the client runtime, as well as the classes into which you can insert your custom extensions in client applications. For example, you can perform custom client message logging, perform custom message serialization, and so on.  
  
 [Extending Dispatchers](../../../../docs/framework/wcf/extending/extending-dispatchers.md)  
 Describes the interfaces that can intercept and modify the service runtime, as well as the classes into which you can insert your custom extensions in service applications. For example, you can perform custom service logging, service-side message validation, custom dispatching, and so on.  
  
 [Extensible Objects](../../../../docs/framework/wcf/extending/extensible-objects.md)  
 Describes the five extensible objects and the <xref:System.ServiceModel.IExtensibleObject%601> pattern. The extensible object pattern is used to either extend existing runtime classes with new functionality or to add new state to an object. Extensions, attached to one of the extensible objects, enable behaviors at very different stages in processing to access shared state and functionality attached to a common extensible object that they can access.  
  
 [Configuring and Extending the Runtime with Behaviors](../../../../docs/framework/wcf/extending/configuring-and-extending-the-runtime-with-behaviors.md)  
 To change settings on or insert extensions in the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] runtime, you use Behaviors. WCF includes system-implemented behaviors for controlling throttling, instancing, and many other aspects of services and operations. This section describes how to create your own custom behaviors and how to make them available for use both programmatically and using configuration files.  
  
 [Extending Hosting Using ServiceHostFactory](../../../../docs/framework/wcf/extending/extending-hosting-using-servicehostfactory.md)  
 Describes how to extend <xref:System.ServiceModel.ServiceHostBase?displayProperty=nameWithType>, <xref:System.ServiceModel.ServiceHost?displayProperty=nameWithType>, and use the <xref:System.ServiceModel.Activation.ServiceHostFactory?displayProperty=nameWithType> classes to customize the host environment.  
  
## Reference  
  
## Related Sections
