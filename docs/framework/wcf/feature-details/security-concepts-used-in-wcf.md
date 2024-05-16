---
description: "Learn more about: Security Concepts Used in WCF"
title: "Security Concepts Used in WCF"
ms.date: "03/30/2017"
ms.assetid: 3b9dfcf5-4bf1-4f35-9070-723171c823a1
---
# Security Concepts Used in WCF

Windows Communication Foundation (WCF) security is built upon concepts already in use and deployed in various security infrastructures.  
  
 WCF supports some of those infrastructures, such as Secure Sockets Layer (SSL) over HTTP (HTTPS). However, WCF goes beyond supporting existing security infrastructures by implementing newer interoperable security standards (such as WS-Security) over SOAP-encoded messages. Whether you are using existing mechanisms or new interoperable standards, the security concepts behind both are the same. Understanding the concepts behind existing infrastructures and the newer standards is central to implementing the best security model for an application.
  
## Industry-Wide Security Specifications  
  
### Public Key Infrastructure  

Public Key Infrastructure (PKI) is a system of digital certificates, certification authorities, and other registration authorities that verify and authenticate each party involved in an electronic transaction through the use of public-key cryptography.
  
### Kerberos Protocol  

 The *Kerberos protocol* is a specification for creating a security mechanism that authenticates users on a Windows domain. It allows a user to establish a secure context with other entities within a domain. Windows uses the Kerberos protocol by default. Understanding the mechanisms of the system is useful when creating a service that will interact with intranet clients. In addition, since the *Web Services Security Kerberos Binding* is widely published, you can use the Kerberos protocol to communicate with Internet clients (that is, the Kerberos protocol is interoperable). For more information about how the Kerberos protocol is implemented in Windows, see  [Microsoft Kerberos](/windows/win32/secauthn/microsoft-kerberos).  
  
### X.509 Certificates  

 X.509 certificates are a primary credential form used in security applications. For more information on X.509 certificates see [X.509 Public Key Certificates](/windows/win32/seccertenroll/about-x-509-public-key-certificates). X.509 certificates are stored within a certificate store. A computer running Windows has several kinds of certificate stores, each with a different purpose. For more information about the different stores, see [Certificate Stores](/previous-versions/windows/it-pro/windows-server-2003/cc757138(v=ws.10)).  
  
## Web Services Security Specifications  

 The system-defined bindings support many commonly used web services security specifications. For a complete list of system-provided bindings and the web services specifications they support see: [Web Services Protocols Supported by System-Provided Interoperability Bindings](web-services-protocols-supported-by-system-provided-interoperability-bindings.md)  
  
## Access Control Mechanisms  

WCF provides a number of ways to control access to a service or operation:
  
- <xref:System.Security.Permissions.PrincipalPermissionAttribute>  
  
- ASP.NET Membership Provider  
  
- ASP.NET Role Provider  
  
- Authorization Manager  
  
- Identity Model  
  
For more information on these topics see, [Access Control Mechanisms](access-control-mechanisms.md)  
  
## See also

- [Security Overview](security-overview.md)
- [Security Model for Windows Server App Fabric](/previous-versions/appfabric/ee677202(v=azure.10))
