---
title: "Distributed Application Security"
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
  - "distributed application security [WCF]"
  - "security [WCF], transfer"
ms.assetid: 53928a10-e474-46d0-ab90-5f98f8d7b668
caps.latest.revision: 32
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Distributed Application Security
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] security is broken into three major functional areas: transfer security, access control, and auditing. Transfer security provides integrity, confidentiality, and authentication. Transfer security is provided by one of the following: transport security, message security, or `TransportWithMessageCredential`.  
  
 For an overview of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] message security, see [Security Overview](../../../../docs/framework/wcf/feature-details/security-overview.md). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the other two pieces of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security, see [Authorization](../../../../docs/framework/wcf/feature-details/authorization-in-wcf.md) and [Auditing](../../../../docs/framework/wcf/feature-details/auditing-security-events.md).  
  
## Transfer Security Scenarios  
 Common scenarios that employ [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] transfer security include the following:  
  
-   Secure transfer using Windows. A [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client and service are deployed in a Windows domain (or a Windows forest). The messages contain personal data, so requirements include mutual authentication of the client and service, message integrity, and message confidentiality. In addition, proof is required that a particular transaction occurred, for example, the receiver of the message should record the signature information.  
  
-   Secure transfer using `UserName` and HTTPS. A [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client and service need to be developed to work across the Internet. The client credentials authenticate against a database of user name/password pairs. The service is deployed at an HTTPS address using a trusted Secure Sockets Layer (SSL) certificate. Because the messages travel over the Internet, the client and service need to be mutually authenticated, and the messages' confidentiality and integrity must be preserved during transfer.  
  
-   Secure transfer using certificates. A [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client and service need to be developed to work over the public internet. The client and service both have certificates that can be used to secure the messages. The client and service use the Internet to communicate with each other and to perform high-value transactions that require message integrity, confidentiality, and mutual authentication.  
  
## Integrity, Confidentiality, and Authentication  
 Three functions—integrity, confidentiality and authentication—are together called transfer security. Transfer security provides the functions that help to mitigate the threats to a distributed application. The following table briefly describes the three functions that make up transfer security.  
  
|Function|Description|  
|--------------|-----------------|  
|Integrity|*Integrity* is the assurance that data is complete and accurate, especially after it has traversed from one point to another, and possibly been read by many actors. Integrity must be maintained to prevent tampering with the data, and is usually achieved by digital signing of a message.|  
|Confidentiality|*Confidentiality* is the assurance that a message has not been read by anyone other than the intended reader. For example, a credit card number must be kept confidential as it is sent over the Internet. Confidentiality is often provided by the encryption of data using a public key/private key scheme.|  
|Authentication|*Authentication* is the verification of a claimed identity. For example, when using a bank account, it is imperative that only the actual owner of the account be allowed to withdraw funds. Authentication can be provided by a variety of means. One common method is the user/password system. A second is the use of an X.509 certificate that is provided by a third party.|  
  
## Security Modes  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] has several modes of transfer security, which are described in the following table.  
  
|Mode|Description|  
|----------|-----------------|  
|None|No security is provided at the transport layer or at the message layer. None of the predefined bindings use this mode by default except the [\<basicHttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/basichttpbinding.md) element or, when using code, the <xref:System.ServiceModel.BasicHttpBinding> class.|  
|Transport|Uses a secure transport such as HTTPS for integrity, confidentiality, and mutual authentication.|  
|Message|Uses SOAP-message security for integrity, confidentiality, and mutual authentication. SOAP messages are secured according to the WS-Security standards.|  
|Mixed Mode|Uses transport security for integrity, confidentiality, and server authentication. Uses message security (WS-Security and other standards) for client authentication.<br /><br /> (This enumeration for this mode is `TransportWithMessageCredential`.)|  
|Both|Performs protection and authentication at both levels. This mode is available only in the [\<netMsmqBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/netmsmqbinding.md) element.|  
  
## Credentials and Transfer Security  
 A *credential* is data that is presented to establish either a claimed identity or capabilities. Presenting a credential involves presenting both the data and proof of possession of the data. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports a variety of credential types at both the transport and message security levels. You can specify a type of credential for a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] binding.  
  
 In many countries or regions, a driver’s license is an example of a credential. A license contains data representing one's identity and capabilities. It contains proof of possession in the form of the possessor's picture. The license is issued by a trusted authority, usually a governmental licensing department. The license is sealed, and can contain a hologram, showing that it has not been tampered with or counterfeited.  
  
 As an example, consider two types of credentials supported in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]: user name and (X.509) certificate credentials.  
  
 For the user name credential, the user name represents the claimed identity and the password presents the proof of possession. The trusted authority in this case is the system that validates the user name and password.  
  
 In the certificate credential, the subject name, subject alternative name, or specific fields within the certificate can be used to represent the claimed identity and/or capabilities. Proof of possession of the data in the credential is established by using the associated private key to generate a signature.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] programming transfer security and specifying credentials, see [Bindings and Security](../../../../docs/framework/wcf/feature-details/bindings-and-security.md) and [Security Behaviors](../../../../docs/framework/wcf/feature-details/security-behaviors-in-wcf.md).  
  
### Transport Client Credential Types  
 The following table shows the possible values used when creating an application that uses transfer security. You can use these values in either code or binding settings.  
  
|Setting|Description|  
|-------------|-----------------|  
|None|Specifies that the client does not need to present any credential. This translates to an anonymous client.|  
|Basic|Specifies basic authentication.  For additional information, see RFC2617, "[HTTP Authentication: Basic and Digest Authentication](http://go.microsoft.com/fwlink/?LinkId=88313)."|  
|Digest|Specifies digest authentication.  For additional information, see RFC2617, "[HTTP Authentication: Basic and Digest Authentication](http://go.microsoft.com/fwlink/?LinkId=88313)."|  
|Ntlm|Specifies Windows authentication using SSPI negotiation on a Windows domain.<br /><br /> SSPI negotiation results in using either the Kerberos protocol or NT LanMan (NTLM).|  
|Windows|Specifies Windows authentication using SSPI on a Windows domain. SSPI picks from either the Kerberos protocol or NTLM as authentication service.<br /><br /> SSPI tries Kerberos protocol first; if that fails, it then uses NTLM.|  
|Certificate|Performs client authentication using a certificate, typically X.509.|  
  
### Message Client Credential Types  
 The following table shows the possible values used when creating an application that uses message security. You can use these values in either code or binding settings.  
  
|Setting|Description|  
|-------------|-----------------|  
|None|Allows the service to interact with anonymous clients.|  
|Windows|Allows SOAP message exchanges to occur under the authenticated context of a Windows credential. Uses SSPI negotiation mechanism to pick from either the Kerberos protocol or NTLM as an authentication service.|  
|Username|Allows the service to require that the client be authenticated with a user name credential. Note that [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not allow any cryptographic operations with the user name, such as generating a signature or encrypting data. As such, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] enforces that the transport is secured when using user name credentials.|  
|Certificate|Allows the service to require that the client be authenticated using a certificate.|  
|[!INCLUDE[infocard](../../../../includes/infocard-md.md)]|Allows the service to require that the client be authenticated using an [!INCLUDE[infocard](../../../../includes/infocard-md.md)].|  
  
### Programming Credentials  
 For each of the client credential types, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] programming model allows you to specify the credential values and credential validators by using service behaviors and channel behaviors.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security has two types of credentials: service credential behaviors and channel credential behaviors. Credential behaviors in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] specify the actual data, namely, credentials used to meet the security requirements expressed through bindings. In [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], a client class is the run-time component that converts between operation invocation and messages. All clients inherit from the <xref:System.ServiceModel.ClientBase%601> class. The <xref:System.ServiceModel.ClientBase%601.ClientCredentials%2A> property on the base class allows you to specify various values of client credentials.  
  
 In [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], service behaviors are attributes applied to the class implementing a service contract (interface) to programmatically control the service. The <xref:System.ServiceModel.Description.ServiceCredentials> class allows you to specify certificates for service credential and client validation settings for various client credential types.  
  
### Negotiation Model for Message Security  
 The message security mode allows you to perform transfer security so that the service credential is configured at the client out of band. For example, if you are using a certificate stored in the Windows certificate store, you must use a tool such as a Microsoft Management Console (MMC) snap-in.  
  
 The message security mode also allows you to perform transfer security so that the service credential is exchanged with the client as part of an initial negotiation. To enable negotiation, set the <xref:System.ServiceModel.MessageSecurityOverHttp.NegotiateServiceCredential%2A> property to `true`.  
  
## See Also  
 [Endpoint Creation Overview](../../../../docs/framework/wcf/endpoint-creation-overview.md)  
 [System-Provided Bindings](../../../../docs/framework/wcf/system-provided-bindings.md)  
 [Security Overview](../../../../docs/framework/wcf/feature-details/security-overview.md)  
 [Security Model for Windows Server App Fabric](http://go.microsoft.com/fwlink/?LinkID=201279&clcid=0x409)
