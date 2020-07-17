---
title: "Extending WCF"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "WCF, extensibility"
  - "extensibility [WCF]"
  - "Windows Communication Foundation, extensibility"
ms.assetid: c145e2f6-f402-41f5-8b5a-eee03978737b
---
# Extending WCF
Windows Communication Foundation (WCF) allows you to modify and extend run time components to precisely control and extend service-based applications. The topics in this section go in depth about the extensibility architecture. For more information about basic programming, see [Basic WCF Programming](../basic-wcf-programming.md).  
  
## In This Section  
 [Extending ServiceHost and the Service Model Layer](extending-servicehost-and-the-service-model-layer.md)  
 The service model layer is responsible for pulling incoming messages out of the underlying channels, translating them into method invocations in application code, and sending the results back to the caller.  Service model extensions modify or implement execution or communication behavior and features involving dispatcher functionality, custom behaviors, message and parameter interception, and other extensibility functionality.  
  
 [Extending Bindings](extending-bindings.md)  
 Bindings are objects that describe the communication details required to connect to an endpoint. Binding extensions or custom bindings implement custom communication functionality required to support application features.  
  
 [Extending the Channel Layer](extending-the-channel-layer.md)  
 The channel layer sits beneath the service model layer and is responsible for the exchange of messages between clients and services. Channel extensions can implement new protocol functionality, such as security. Channel extensions also transport functionality, such as implementing a new network transport to carry SOAP messages.  
  
 [Extending Security](extending-security.md)  
 Security in WCF consists of transfer security (integrity, confidentiality, and authentication), access control (authorization) and auditing. The classes found in the `IdentityModel` namespace are used by WCF for access control. Understanding the security architecture allows you to create custom claim types to accommodate custom access control systems.  
  
 [Extending the Metadata System](extending-the-metadata-system.md)  
 The WCF metadata system is a group of classes and interfaces that represent metadata required to implement service-based applications. Modify or extend the classes or implement and configure the interfaces to export and import custom metadata such as Web Services Description Language (WSDL) extensions or custom WS-PolicyAttachments assertions.  
  
 [Extending Encoders and Serializers](extending-encoders-and-serializers.md)  
 Encoders and serializers translate data from one form to another. The topics in this section discuss how to extend the supplied classes to meet special requirements.  
  
## Reference  
 <xref:System.ServiceModel>  
  
 <xref:System.ServiceModel.Channels>  
  
 <xref:System.ServiceModel.Description>  
  
 <xref:System.IdentityModel.Claims>  
  
 <xref:System.IdentityModel.Policy>  
  
 <xref:System.IdentityModel.Selectors>  
  
 <xref:System.IdentityModel.Tokens>  
  
## Related Sections  
 [Basic WCF Programming](../basic-wcf-programming.md)  
  
 [WCF Feature Details](../feature-details/index.md)  
  
 [Guidelines and Best Practices](../guidelines-and-best-practices.md)
