---
title: "Security Concepts Used in WCF"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3b9dfcf5-4bf1-4f35-9070-723171c823a1
caps.latest.revision: 15
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Security Concepts Used in WCF
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] security is built upon concepts already in use and deployed in various security infrastructures.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports some of those infrastructures, such as Secure Sockets Layer (SSL) over HTTP (HTTPS). However, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] goes beyond supporting existing security infrastructures by implementing newer interoperable security standards (such as WS-Security) over SOAP-encoded messages. Whether you are using existing mechanisms or new interoperable standards, the security concepts behind both are the same. Understanding the concepts behind existing infrastructures and the newer standards is central to implementing the best security model for an application.  
  
## Introduction to Security for WCF Web Services  
 The Microsoft Patterns and Practices group wrote an in-depth whitepaper on WCF security guidance which is available for download here: [WCF Security Guide](http://go.microsoft.com/fwlink/?LinkId=210210). This whitepaper describes the fundamental security concepts as they relate to web services, key WCF security concepts, intranet application scenarios, and internet application scenarios.  
  
## Industry-Wide Security Specifications  
  
### Public Key Infrastructure  
 Public Key Infrastructure (PKI) is a system of digital certificates, certification authorities, and other registration authorities that verify and authenticate each party involved in an electronic transaction through the use of public key cryptography. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Windows Server 2008 R2 Certificate Services](http://go.microsoft.com/fwlink/?LinkId=210211).  
  
### Kerberos Protocol  
 The *Kerberos protocol* is a specification for creating a security mechanism that authenticates users on a Windows domain. It allows a user to establish a secure context with other entities within a domain. Windows 2000 and later platforms use the Kerberos protocol by default. Understanding the mechanisms of the system is useful when creating a service that will interact with intranet clients. In addition, since the *Web Services Security Kerberos Binding* is widely published, you can use the Kerberos protocol to communicate with Internet clients (that is, the Kerberos protocol is interoperable). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] how the Kerberos protocol is implemented in Windows, see  [Microsoft Kerberos](http://go.microsoft.com/fwlink/?LinkId=210212).  
  
### X.509 Certificates  
 X.509 certificates are a primary credential form used in security applications. For more information on X.509 certificates see [X.509 Public Key Certificates](http://go.microsoft.com/fwlink/?LinkId=210213). X.509 certificates are stored within a certificate store. A computer running Windows has several kinds of certificate stores, each with a different purpose. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the different stores, see [Certificate Stores](http://go.microsoft.com/fwlink/?LinkID=87787).  
  
## Web Services Security Specifications  
 The system-defined bindings support many commonly used web services security specifications. For a complete list of system-provided bindings and the web services specifications they support see: [Web Services Protocols Supported by System-Provided Interoperability Bindings](../../../../docs/framework/wcf/feature-details/web-services-protocols-supported-by-system-provided-interoperability-bindings.md)  
  
## Access Control Mechanisms  
 WCF provides a number of ways to control access to a service or operation. Among them are  
  
1.  <xref:System.Security.Permissions.PrincipalPermissionAttribute>  
  
2.  ASP.NET Membership Provider  
  
3.  ASP.NET Role Provider  
  
4.  Authorization Manager  
  
5.  Identity Model  
  
 For more information on these topics see, [Access Control Mechanisms](../../../../docs/framework/wcf/feature-details/access-control-mechanisms.md)  
  
## See Also  
 [Security Overview](../../../../docs/framework/wcf/feature-details/security-overview.md)  
 [Security Model for Windows Server App Fabric](http://go.microsoft.com/fwlink/?LinkID=201279&clcid=0x409)
