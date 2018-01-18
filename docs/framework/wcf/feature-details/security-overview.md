---
title: "Security Overview1"
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
  - "Windows Communication Foundation, security"
  - "WCF, security"
ms.assetid: f478c80d-792d-4e7a-96bd-a2ff0b6f65f9
caps.latest.revision: 37
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Security Overview
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] is a SOAP message-based distributed programming platform, and securing messages between clients and services is essential to protecting data. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides a versatile and interoperable platform for exchanging secure messages based upon both the existing security infrastructure and the recognized security standards for SOAP messages.  
  
> [!NOTE]
>  For a comprehensive guide to WCF security, see [WCF Security Guidance](http://go.microsoft.com/fwlink/?LinkID=158912).  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses concepts that are familiar if you have built secure, distributed applications with existing technologies such as HTTPS, Windows integrated security, or user names and passwords to authenticate users. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] not only integrates with existing security infrastructures, but also extends distributed security beyond Windows-only domains by using secure SOAP messages. Consider [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] an implementation of existing security mechanisms with the major advantage of using SOAP as the protocol in addition to existing protocols. For example, credentials that identify a client or a service, such as user name and password or X.509 certificates, have interoperable XML-based SOAP profiles. Using these profiles, messages are exchanged securely by taking advantage of open specifications like XML digital signatures and XML encryption. For a list of specifications, see [Web Services Protocols Supported by System-Provided Interoperability Bindings](../../../../docs/framework/wcf/feature-details/web-services-protocols-supported-by-system-provided-interoperability-bindings.md).  
  
 Another parallel is the Component Object Model (COM) on the Windows platform, which enables secure, distributed applications. COM has a comprehensive security mechanism whereby security context can be flowed between components; this mechanism enforces integrity, confidentiality, and authentication. However COM does not enable cross-platform, secure messaging like [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does. Using [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], you can build services and clients that span from Windows domains across the Internet. The interoperable messages of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] are essential for building dynamic, business-driven services that help you feel confident in the security of your information.  
  
## Windows Communication Foundation Security Benefits  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is a distributed programming platform based on SOAP messages. Using [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], you can create applications that function as both services and service clients, creating and processing messages from an unlimited number of other services and clients. In such a distributed application, messages can flow from node to node, through firewalls, onto the Internet, and through numerous SOAP intermediaries. This introduces a variety of message security threats. The following examples illustrate some common threats that [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security can help mitigate when exchanging messages between entities:  
  
-   Observation of network traffic to obtain sensitive information. For example, in an online-banking scenario, a client requests the transfer of funds from one account to another. A malicious user intercepts the message and, having the account number and password, later performs a transfer of funds from the compromised account.  
  
-   Rogue entities acting as services without awareness of the client. In this scenario, a malicious user (the rogue) acts as an online service and intercepts messages from the client to obtain sensitive information. Then the rogue uses the stolen data to transfer funds from the compromised account. This attack is also known a *phishing attack*.  
  
-   Alteration of messages to obtain a different result than the caller intended. For example, altering the account number to which a deposit is made allows the funds to go to a rogue account.  
  
-   Hacker replays in which a nuisance hacker replays the same purchase order. For example, an online bookstore receives hundreds of orders and sends the books to a customer who has not ordered them.  
  
-   Inability of a service to authenticate a client. In this case, the service cannot assure that the appropriate person performed the transaction.  
  
 In summary, transfer security provides the following assurances:  
  
-   Service endpoint (respondent) authentication.  
  
-   Client principal (initiator) authentication.  
  
-   Message integrity.  
  
-   Message confidentiality.  
  
-   Replay detection.  
  
### Integration with Existing Security Infrastructures  
 Often, Web service deployments have existing security solutions in place, for example, Secure Sockets Layer (SSL) or the Kerberos protocol. Some take advantage of a security infrastructure that has already been deployed, such as Windows domains using Active Directory. It is often necessary to integrate with these existing technologies while evaluating and adopting newer ones.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security integrates with existing transport security models and can leverage existing infrastructure for newer transfer security models based on SOAP message security.  
  
### Integration with Existing Authentication Models  
 An important part of any communication security model is the ability to identify and authenticate entities in communication. These entities in communication use "digital identities," or credentials, to authenticate themselves with the communicating peers. As distributed communication platforms evolved, various credential authentication and related security models have been implemented. For example, on the Internet, the use of a user name and password to identify users is common. On the intranet, the use of a Kerberos domain controller to back up user and service authentication is becoming common. In certain scenarios, such as between two business partners, certificates may be used to mutually authenticate the partners.  
  
 Thus, in the world of Web services, where the same service might be exposed to internal corporate customers as well as to external partners or Internet customers, it is important that the infrastructure provide for integration with these existing security authentication models. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security supports a wide variety of credential types (authentication models) including:  
  
-   Anonymous caller.  
  
-   User name client credential.  
  
-   Certificate client credential.  
  
-   Windows (both Kerberos protocol and NT LanMan [NTLM]).  
  
### Standards and Interoperability  
 In a world with large existing deployments, homogeneity is rare. Distributed computing/communications platforms need to interoperate with the technologies different vendors offer. Likewise, security must also be interoperable.  
  
 To enable interoperable security systems, companies active in the Web services industry have authored a variety of standards. Specifically regarding security, a few notable standards have been proposed: WS-Security: SOAP Message Security (accepted by the OASIS standards body and formerly known as WS-Security), WS-Trust, WS-SecureConversation, and WS-SecurityPolicy.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports a wide variety of interoperability scenarios. The <xref:System.ServiceModel.BasicHttpBinding> class is targeted at the Basic Security Profile (BSP) and the <xref:System.ServiceModel.WSHttpBinding> class is targeted at the latest security standards, such as WS-Security 1.1 and WS-SecureConversation. By adhering to these standards, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security can interoperate and integrate with Web services that are hosted on operating systems and platforms other than Microsoft Windows.  
  
## WCF Security Functional Areas  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security is divided into three functional areas: transfer security, access control, and auditing. The following sections briefly discuss these areas and provide links for more information.  
  
### Transfer Security  
 Transfer security encompasses three major security functions: integrity, confidentiality, and authentication. *Integrity* is the ability to detect whether a message has been tampered with. *Confidentiality* is the ability to keep a message unreadable by anyone other than the intended recipient; this is achieved through cryptography. *Authentication* is the ability to verify a claimed identity. Together, these three functions help to ensure that messages securely arrive from one point to another.  
  
#### Transport and Message Security Modes  
 Two main mechanisms are used to implement transfer security in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]: *transport* security mode and *message* security mode.  
  
-   *Transport security mode* uses a transport-level protocol, such as HTTPS, to achieve transfer security. Transport mode has the advantage of being widely adopted, available on many platforms, and less computationally complex. However, it has the disadvantage of securing messages only from point-to-point.  
  
-   *Message security mode*, on the other hand, uses WS-Security (and other specifications) to implement transfer security. Because the message security is applied directly to the SOAP messages and is contained inside the SOAP envelopes, together with the application data, it has the advantage of being transport protocol-independent, more extensible, and ensuring end-to-end security (versus point-to-point); it has the disadvantage of being several times slower than transport security mode because it has to deal with the XML nature of the SOAP messages.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] these differences, see [Securing Services and Clients](../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md).  
  
 A third security mode uses both previous modes and brings advantages of both. This mode is called `TransportWithMessageCredential`. In this mode, message security is used to authenticate the client and transport security is used to authenticate the server and provide message confidentiality and integrity. Thanks to this, the `TransportWithMessageCredential` security mode is almost as fast as transport security mode and provides client authentication extensibility in the same way as message security. However, unlike message security mode, it does not provide complete end-to-end security.  
  
### Access Control  
 *Access control* is also known as authorization. *Authorization* allows different users to have different privileges to view data. For example, because a company's human resources files contain sensitive employee data, only managers are allowed to view employee data. Further, managers can view only data for their direct reports. In this case, access control is based on both the role ("manager") as well as the specific identity of the manager (to prevent one manager from looking at another manager's employee records).  
  
 In [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], access control features are provided through integration with the common language runtime (CLR) <xref:System.Security.Permissions.PrincipalPermissionAttribute> and through a set of APIs known as the *identity model*. For details about access control and claims-based authorization, see [Extending Security](../../../../docs/framework/wcf/extending/extending-security.md).  
  
### Auditing  
 *Auditing* is the logging of security events to the Windows event log. You can log security-related events, such as authentication failures (or successes). [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Auditing](../../../../docs/framework/wcf/feature-details/auditing-security-events.md). For programming details, see [How to: Audit Security Events](../../../../docs/framework/wcf/feature-details/how-to-audit-wcf-security-events.md).  
  
## See Also  
 <xref:System.Security.Permissions.PrincipalPermissionAttribute>  
 [Securing Services](../../../../docs/framework/wcf/securing-services.md)  
 [Common Security Scenarios](../../../../docs/framework/wcf/feature-details/common-security-scenarios.md)  
 [Bindings and Security](../../../../docs/framework/wcf/feature-details/bindings-and-security.md)  
 [Securing Services and Clients](../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)  
 [Authentication](../../../../docs/framework/wcf/feature-details/authentication-in-wcf.md)  
 [Authorization](../../../../docs/framework/wcf/feature-details/authorization-in-wcf.md)  
 [Federation and Issued Tokens](../../../../docs/framework/wcf/feature-details/federation-and-issued-tokens.md)  
 [Auditing](../../../../docs/framework/wcf/feature-details/auditing-security-events.md)  
 [Security Guidance and Best Practices](../../../../docs/framework/wcf/feature-details/security-guidance-and-best-practices.md)  
 [Configuring Services Using Configuration Files](../../../../docs/framework/wcf/configuring-services-using-configuration-files.md)  
 [System-Provided Bindings](../../../../docs/framework/wcf/system-provided-bindings.md)  
 [Endpoint Creation Overview](../../../../docs/framework/wcf/endpoint-creation-overview.md)  
 [Extending Security](../../../../docs/framework/wcf/extending/extending-security.md)  
 [Security Model for Windows Server App Fabric](http://go.microsoft.com/fwlink/?LinkID=201279&clcid=0x409)
