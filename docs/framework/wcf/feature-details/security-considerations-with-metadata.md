---
title: "Security Considerations with Metadata"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e78ef8ab-4f63-4656-ab93-b1deab2666d5
caps.latest.revision: 10
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Security Considerations with Metadata
When using the metadata features in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)], consider the security implications of publishing, retrieving, and using service metadata.  
  
## When to Publish Metadata  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services do not publish metadata by default. To publish metadata for a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service you must explicitly enable metadata publishing by adding metadata endpoints to your service (see [Publishing Metadata](../../../../docs/framework/wcf/feature-details/publishing-metadata.md)). Leaving metadata publishing disabled reduces the attack surface for your service and lowers the risk of unintentional information disclosure. Not all services must publish metadata. If you do not have to publish metadata, consider leaving it turned off. Note that you can still generate metadata and client code directly from your service assemblies using the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] using Svcutil.exe to export metadata, see [How to: Use Svcutil.exe to Export Metadata from Compiled Service Code](../../../../docs/framework/wcf/feature-details/how-to-use-svcutil-exe-to-export-metadata-from-compiled-service-code.md).  
  
## Publishing Metadata Using a Secure Binding  
 The default metadata bindings that [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides are not secure and they allow anonymous access to the metadata. The service metadata that a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service publishes contains a detailed description about the service and may intentionally or unintentionally contain sensitive information. For example, service metadata may contain information about infrastructure operations that was not intended to be broadcast publicly. To protect service metadata from unauthorized access, you can use a secure binding for your metadata endpoint. Metadata endpoints respond to HTTP/GET requests that can use Secure Sockets Layer (SSL) to secure the metadata. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [How to: Secure Metadata Endpoints](../../../../docs/framework/wcf/feature-details/how-to-secure-metadata-endpoints.md).  
  
 Securing your metadata endpoints also provides a way for requesters to securely retrieve service metadata without the risk of tampering or spoofing.  
  
## Using Only Trusted Metadata  
 You can use service metadata to automatically construct the run-time components required to call the service. You can also use metadata at design time to develop a client application or at runtime to dynamically update the binding a client uses to call a service.  
  
 Service metadata can be tampered with or spoofed when retrieved in an insecure manner. Tampered metadata can redirect your client to a malicious service, contain compromised security settings, or contain malicious XML structures. Metadata documents can be large and are frequently saved to the file system. To protect against tampering and spoofing, use a secure binding to request service metadata when one is available.  
  
## Using Safe Techniques for Processing Metadata  
 Service metadata is frequently retrieved from a service over a network using standardized protocols such as WS-MetadataExchange (MEX). Many metadata formats include referencing mechanisms for pointing to additional metadata. The <xref:System.ServiceModel.Description.MetadataExchangeClient> type automatically processes references for you in Web Services Description Language (WSDL) documents, XML Schema, and MEX documents. The size of the <xref:System.ServiceModel.Description.MetadataSet> object created from the retrieved metadata is directly proportional to the <xref:System.ServiceModel.Description.MetadataExchangeClient.MaximumResolvedReferences%2A> value for the <xref:System.ServiceModel.Description.MetadataExchangeClient> instance that is used and the `MaxReceivedMessageSize` value for the binding being used by that <xref:System.ServiceModel.Description.MetadataExchangeClient> instance. Set these quotas to appropriate values as dictated by your scenario.  
  
 In [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], service metadata is processed as XML. When processing XML documents, applications should protect themselves against malicious XML structures. Use the `XmlDictionaryReader` with appropriate quotas when processing XML and also set the <xref:System.Xml.XmlTextReader.DtdProcessing%2A> property to `Prohibit`.  
  
 The metadata system in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is extensible and metadata extensions can be registered in your application configuration file (see [Extending the Metadata System](../../../../docs/framework/wcf/extending/extending-the-metadata-system.md)). Metadata extensions can run arbitrary code, so you should protect your application configuration file with appropriate access control lists (ACLs) and register only trusted metadata extension implementations.  
  
## Validating Generated Clients  
 When generating client code from metadata retrieved from a source that is not trusted, validate the generated client code to ensure that the generated client conforms to your client applications security policies. You can use a validating behavior to check settings on your client binding or visually inspect code generated by tools. For an example of how to implement a client that validates behaviors, see [Client Validation](../../../../docs/framework/wcf/samples/client-validation.md).  
  
## Protecting Application Configuration Files  
 A service's application configuration file may control how and if metadata is published. It is a good idea to protect the application configuration file with appropriate access control lists (ACLs) to ensure an attacker cannot modify such settings.  
  
## See Also  
 [How to: Secure Metadata Endpoints](../../../../docs/framework/wcf/feature-details/how-to-secure-metadata-endpoints.md)  
 [Security](../../../../docs/framework/wcf/feature-details/security.md)
