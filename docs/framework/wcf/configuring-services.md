---
title: "Configuring Services"
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
  - "configuration [WCF]"
ms.assetid: beac771e-f28e-4f84-9ff1-ad9251c726d3
caps.latest.revision: 19
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Configuring Services
Once you have designed and implemented your service contract, you are ready to configure your service. This is where you define and customize how your service is exposed to clients, including specifying the address where it can be found, the transport and message encoding it uses to send and receive messages, and the type of security it requires.  
  
 Configuration as used here includes all the ways, imperatively in code or by using a configuration file, in which you can define and customize the various aspects of a service, such as specifying its endpoint addresses, the transports used, and its security schemes. In practice, writing configuration is a major part of programming [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] applications.  
  
## In This Section  
 [Simplified Configuration](../../../docs/framework/wcf/simplified-configuration.md)  
 Starting with [!INCLUDE[netfx40_long](../../../includes/netfx40-long-md.md)], [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] comes with a new default configuration model that simplifies [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] configuration requirements. If you do not provide any [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] configuration for a particular service, the runtime automatically configures your service with default endpoints, bindings, and behaviors.  
  
 [Configuring Services Using Configuration Files](../../../docs/framework/wcf/configuring-services-using-configuration-files.md)  
 A [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] service is configurable using the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] configuration technology. Most commonly, XML elements are added to the Web.config file for an Internet Information Services (IIS) site that hosts a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service. The elements allow you to change details, such as the endpoint addresses (the actual addresses used to communicate with the service) on a machine-by-machine basis.  
  
 [Bindings](../../../docs/framework/wcf/bindings.md)  
 In addition, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] includes several system-provided common configurations in the form of bindings that allow you to quickly select the most basic features for how a client and service communicate, such as the transports, security, and message encodings used.  
  
 [Endpoints](../../../docs/framework/wcf/endpoints.md)  
 All communication with a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service occurs through the *endpoints* of the service. Endpoints contain the contract, the configuration information that is specified in the bindings, and the addresses that indicate where to find the service or where to obtain information about the service.  
  
 [Securing Services](../../../docs/framework/wcf/securing-services.md)  
 Using [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] and existing security mechanisms, you can implement confidentiality, integrity, authentication, and authorization into any service. You can also audit for security successes and failures.  
  
 [Creating WS-I Basic Profile 1.1 Interoperable Services](../../../docs/framework/wcf/creating-ws-i-basic-profile-1-1-interoperable-services.md)  
 The requirements for deploying a service that is interoperable with services and clients on any other platform or operating system are outlined in the WS-I Basic Profile 1.1 specification.  
  
## Reference  
 <xref:System.ServiceModel>  
  
 <xref:System.ServiceModel.Channels>  
  
 <xref:System.ServiceModel.Description>  
  
## Related Sections  
 [Basic Programming Lifecycle](../../../docs/framework/wcf/basic-programming-lifecycle.md)  
  
 [Designing and Implementing Services](../../../docs/framework/wcf/designing-and-implementing-services.md)  
  
 [Hosting Services](../../../docs/framework/wcf/hosting-services.md)  
  
 [Building Clients](../../../docs/framework/wcf/building-clients.md)  
  
 [Introduction to Extensibility](../../../docs/framework/wcf/introduction-to-extensibility.md)  
  
 [Administration and Diagnostics](../../../docs/framework/wcf/diagnostics/index.md)  
  
## See Also  
 [Basic WCF Programming](../../../docs/framework/wcf/basic-wcf-programming.md)  
 [Conceptual Overview](../../../docs/framework/wcf/conceptual-overview.md)  
 [WCF Feature Details](../../../docs/framework/wcf/feature-details/index.md)
