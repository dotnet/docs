---
description: "Learn more about: Common Security Scenarios"
title: "Common Security Scenarios"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "security [WCF], scenarios"
ms.assetid: 201923b5-5162-4a8a-8d4c-e7bd242748d5
---
# Common Security Scenarios

The topics in this section catalog a number of possible client and service security configurations. Configurations vary according to a number of factors. For example, whether a service or client is on an intranet, or whether the security is provided by Windows or transport (such as HTTPS).  
  
## In This Section  

 [Internet Unsecured Client and Service](internet-unsecured-client-and-service.md)  
 An example of a public, unsecured client and service.  
  
 [Intranet Unsecured Client and Service](intranet-unsecured-client-and-service.md)  
 A basic Windows Communication Foundation (WCF) service developed to provide information on a secure private network to a WCF application.  
  
 [Transport Security with Basic Authentication](transport-security-with-basic-authentication.md)  
 The application allows clients to log on using custom authentication.  
  
 [Transport Security with Windows Authentication](transport-security-with-windows-authentication.md)  
 Shows a client and service secured by Windows security.  
  
 [Transport Security with an Anonymous Client](transport-security-with-an-anonymous-client.md)  
 This scenario uses transport security (such as HTTPS) to ensure confidentiality and integrity.  
  
 [Transport Security with Certificate Authentication](transport-security-with-certificate-authentication.md)  
 Shows a client and service secured by a certificate.  
  
 [Message Security with an Anonymous Client](message-security-with-an-anonymous-client.md)  
 Shows a client and service secured by WCF message security.  
  
 [Message Security with a User Name Client](message-security-with-a-user-name-client.md)  
 The client is a Windows Forms application that allows clients to log on using a domain user name and password.  
  
 [Message Security with a Certificate Client](message-security-with-a-certificate-client.md)  
 Servers have certificates, and each client has a certificate. A security context is established through Transport Layer Security (TLS) negotiation.  
  
 [Message Security with a Windows Client](message-security-with-a-windows-client.md)  
 A variation of the certificate client. Servers have certificates, and each client has a certificate. A security context is established through TLS negotiation.  
  
 [Message Security with a Windows Client without Credential Negotiation](message-security-with-a-windows-client-without-credential-negotiation.md)  
 Shows a client and service secured by a Kerberos domain.  
  
 [Message Security with Mutual Certificates](message-security-with-mutual-certificates.md)  
 Servers have certificates, and each client has a certificate. The server certificate is distributed with the application and is available out of band.  
  
 [Message Security with Issued Tokens](message-security-with-issued-tokens.md)  
 Federated security that enables the establishment of trust between independent domains.  
  
 [Trusted Subsystem](trusted-subsystem.md)  
 A client accesses one or more Web services that are distributed across a network. The Web services access additional resources (such as databases or other Web services) that must be secured.  
  
## Reference  

 <xref:System.ServiceModel>  
  
## Related Sections  

 [Authorization](authorization-in-wcf.md)  
  
 [Security Overview](security-overview.md)  
  
 [Security](security.md)  
  
 [Bindings and Security](bindings-and-security.md)  
  
 [Securing Services and Clients](securing-services-and-clients.md)  
  
 [Authentication](authentication-in-wcf.md)  
  
 [Authorization](authorization-in-wcf.md)  
  
 [Federation and Issued Tokens](federation-and-issued-tokens.md)  
  
 [Auditing](auditing-security-events.md)  
  
## See also

- [Security Guidance and Best Practices](security-guidance-and-best-practices.md)
- [Security Model for Windows Server App Fabric](/previous-versions/appfabric/ee677202(v=azure.10))
