---
description: "Learn more about: Securing Services and Clients"
title: "Securing Services and Clients"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "message security [WCF]"
ms.assetid: e681f3bd-0c09-4a58-b0e4-0ecbdf1aa6c7
ms.topic: concept-article
---
# Securing Services and Clients

The information in this section focuses on programming security in Windows Communication Foundation (WCF). Generally, this includes selecting an appropriate system-provided binding, setting the properties of the security element, and then setting properties of the service behaviors that govern how credentials are retrieved for use by either the service or the client. These techniques cover the security requirements of most users for most scenarios, as shown in [Common Security Scenarios](common-security-scenarios.md). If your scenario requires more capabilities, first see [Security Capabilities with Custom Bindings](security-capabilities-with-custom-bindings.md); if a solution is not apparent, see [Extending Security](../extending/extending-security.md). If you are creating (or interoperating with) a system that uses rich claims, see the topics in [Authorization](authorization-in-wcf.md).  
  
## In This Section  

 [Programming WCF Security](programming-wcf-security.md)  
 An overview of the programming model used to secure messages.  
  
 [Transport Security Overview](transport-security-overview.md)  
 An overview of how to secure messages through the transport layer.  
  
 [Message Security](message-security-in-wcf.md)  
 Summarizes reasons for using message-level security in Windows Communication Foundation (WCF).  
  
 [Secure Sessions](secure-sessions.md)  
 A discussion of the considerations required when securing a WCF session.  
  
 [Working with Certificates](working-with-certificates.md)  
 An explanation of some of the common tasks required when using X.509 certificates.  
  
## Reference  

 <xref:System.ServiceModel>  
  
 <xref:System.ServiceModel.Channels>  
  
 <xref:System.ServiceModel.Security>  
  
## Related Sections  

 [Security Concepts](security-concepts.md)  
  
 [Extending Security](../extending/extending-security.md)  
  
 [Common Security Scenarios](common-security-scenarios.md)  
  
 [Bindings and Security](bindings-and-security.md)  
  
 [Security Capabilities with Custom Bindings](security-capabilities-with-custom-bindings.md)  
  
 [Extending Security](../extending/extending-security.md)  
  
 [Authorization](authorization-in-wcf.md)  
  
## See also

- [Basic WCF Programming](../basic-wcf-programming.md)
- [Security Model for Windows Server App Fabric](/previous-versions/appfabric/ee677202(v=azure.10))
