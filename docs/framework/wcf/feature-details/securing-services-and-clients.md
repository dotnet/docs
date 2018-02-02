---
title: "Securing Services and Clients"
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
  - "message security [WCF]"
ms.assetid: e681f3bd-0c09-4a58-b0e4-0ecbdf1aa6c7
caps.latest.revision: 13
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Securing Services and Clients
The information in this section focuses on programming security in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)]. Generally, this includes selecting an appropriate system-provided binding, setting the properties of the security element, and then setting properties of the service behaviors that govern how credentials are retrieved for use by either the service or the client. These techniques cover the security requirements of most users for most scenarios, as shown in [Common Security Scenarios](../../../../docs/framework/wcf/feature-details/common-security-scenarios.md). If your scenario requires more capabilities, first see [Security Capabilities with Custom Bindings](../../../../docs/framework/wcf/feature-details/security-capabilities-with-custom-bindings.md); if a solution is not apparent, see [Extending Security](../../../../docs/framework/wcf/extending/extending-security.md). If you are creating (or interoperating with) a system that uses rich claims, see the topics in [Authorization](../../../../docs/framework/wcf/feature-details/authorization-in-wcf.md).  
  
## In This Section  
 [Programming WCF Security](../../../../docs/framework/wcf/feature-details/programming-wcf-security.md)  
 An overview of the programming model used to secure messages.  
  
 [Transport Security Overview](../../../../docs/framework/wcf/feature-details/transport-security-overview.md)  
 An overview of how to secure messages through the transport layer.  
  
 [Message Security](../../../../docs/framework/wcf/feature-details/message-security-in-wcf.md)  
 Summarizes reasons for using message-level security in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)].  
  
 [Secure Sessions](../../../../docs/framework/wcf/feature-details/secure-sessions.md)  
 A discussion of the considerations required when securing a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] session.  
  
 [Working with Certificates](../../../../docs/framework/wcf/feature-details/working-with-certificates.md)  
 An explanation of some of the common tasks required when using X.509 certificates.  
  
## Reference  
 <xref:System.ServiceModel>  
  
 <xref:System.ServiceModel.Channels>  
  
 <xref:System.ServiceModel.Security>  
  
## Related Sections  
 [Security Concepts](../../../../docs/framework/wcf/feature-details/security-concepts.md)  
  
 [Extending Security](../../../../docs/framework/wcf/extending/extending-security.md)  
  
 [Common Security Scenarios](../../../../docs/framework/wcf/feature-details/common-security-scenarios.md)  
  
 [Bindings and Security](../../../../docs/framework/wcf/feature-details/bindings-and-security.md)  
  
 [Security Capabilities with Custom Bindings](../../../../docs/framework/wcf/feature-details/security-capabilities-with-custom-bindings.md)  
  
 [Extending Security](../../../../docs/framework/wcf/extending/extending-security.md)  
  
 [Authorization](../../../../docs/framework/wcf/feature-details/authorization-in-wcf.md)  
  
## See Also  
 [Basic WCF Programming](../../../../docs/framework/wcf/basic-wcf-programming.md)  
 [Security Model for Windows Server App Fabric](http://go.microsoft.com/fwlink/?LinkID=201279&clcid=0x409)
