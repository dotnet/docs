---
title: "Selecting a Credential Type"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: bf707063-3f30-4304-ab53-0e63413728a8
caps.latest.revision: 25
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Selecting a Credential Type
*Credentials* are the data [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] uses to establish either a claimed identity or capabilities. For example, a passport is a credential a government issues to prove citizenship in a country or region. In [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], credentials can take many forms, such as user name tokens and X.509 certificates. This topic discusses credentials, how they are used in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], and how to select the right credential for your application.  
  
 In many countries and regions, a driver’s license is an example of a credential. A license contains data that represents a person's identity and capabilities. It contains proof of possession in the form of the possessor's picture. The license is issued by a trusted authority, usually a governmental department of licensing. The license is sealed, and can contain a hologram, showing that it has not been tampered with or counterfeited.  
  
 Presenting a credential involves presenting both the data and proof of possession of the data. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports a variety of credential types at both the transport and message security levels. For example, consider two types of credentials supported in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]: user name and (X.509) certificate credentials.  
  
 For the user name credential, the user name represents the claimed identity and the password provides proof of possession. The trusted authority in this case is the system that validates the user name and password.  
  
 With an X.509 certificate credential, the subject name, subject alternative name or specific fields within the certificate can be used as claims of identity, while other fields, such as the `Valid From` and `Valid To` fields, specify the validity of the certificate.  
  
## Transport Credential Types  
 The following table shows the possible types of client credentials that can be used by a binding in transport security mode. When creating a service, set the `ClientCredentialType` property to one of these values to specify the type of credential that the client must supply to communicate with your service. You can set the types in either code or configuration files.  
  
|Setting|Description|  
|-------------|-----------------|  
|None|Specifies that the client does not need to present any credential. This translates to an anonymous client.|  
|Basic|Specifies basic authentication for the client. For additional information, see RFC2617—[HTTP Authentication: Basic and Digest Authentication](http://go.microsoft.com/fwlink/?LinkID=88313).|  
|Digest|Specifies digest authentication for the client. For additional information, see RFC2617—[HTTP Authentication: Basic and Digest Authentication](http://go.microsoft.com/fwlink/?LinkID=88313).|  
|Ntlm|Specifies NT LAN Manager (NTLM) authentication. This is used when you cannot use Kerberos authentication for some reason. You can also disable its use as a fallback by setting the <xref:System.ServiceModel.Security.WindowsClientCredential.AllowNtlm%2A> property to `false`, which causes [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] to make a best-effort to throw an exception if NTLM is used. Note that setting this property to `false` may not prevent NTLM credentials from being sent over the wire.|  
|Windows|Specifies Windows authentication. To specify only the Kerberos protocol on a Windows domain, set the <xref:System.ServiceModel.Security.WindowsClientCredential.AllowNtlm%2A> property to `false` (the default is `true`).|  
|Certificate|Performs client authentication using an X.509 certificate.|  
|Password|User must supply a user name and password. Validate the user name/password pair using Windows authentication or another custom solution.|  
  
### Message Client Credential Types  
 The following table shows the possible credential types that you can use when creating an application that uses message security. You can use these values in either code or configuration files.  
  
|Setting|Description|  
|-------------|-----------------|  
|None|Specifies that the client does not need to present a credential. This translates to an anonymous client.|  
|Windows|Allows SOAP message exchanges to occur under the security context established with a Windows credential.|  
|Username|Allows the service to require that the client be authenticated with a user name credential. Note that [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not allow any cryptographic operations with user names, such as generating a signature or encrypting data. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] ensures that the transport is secured when using user name credentials.|  
|Certificate|Allows the service to require that the client be authenticated using an X.509 certificate.|  
|Issued Token|A custom token type configured according to a security policy. The default token type is Security Assertions Markup Language (SAML). The token is issued by a secure token service. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Federation and Issued Tokens](../../../../docs/framework/wcf/feature-details/federation-and-issued-tokens.md).|  
  
### Negotiation Model of Service Credentials  
 *Negotiation* is the process of establishing trust between a client and a service by exchanging credentials. The process is performed iteratively between the client and the service, so as to disclose only the information necessary for the next step in the negotiation process. In practice, the end result is the delivery of a service's credential to the client to be used in subsequent operations.  
  
 With one exception, by default the system-provided bindings in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] negotiate the service credential automatically when using message-level security. (The exception is the <xref:System.ServiceModel.BasicHttpBinding>, which does not enable security by default.) To disable this behavior, see the <xref:System.ServiceModel.MessageSecurityOverHttp.NegotiateServiceCredential%2A> and <xref:System.ServiceModel.FederatedMessageSecurityOverHttp.NegotiateServiceCredential%2A> properties.  
  
> [!NOTE]
>  When SSL security is used with .NET Framework 3.5 and later, a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client uses both the intermediate certificates in its certificate store and the intermediate certificates received during SSL negotiation to perform certificate chain validation on the service's certificate. .NET Framework 3.0 only uses the intermediate certificates installed in the local certificate store.  
  
#### Out-of-Band Negotiation  
 If automatic negotiation is disabled, the service credential must be provisioned at the client prior to sending any messages to the service. This is also known as an *out-of-band* provisioning. For example, if the specified credential type is a certificate, and automatic negotiation is disabled, the client must contact the service owner to receive and install the certificate on the computer running the client application. This can be done, for example, when you want to strictly control which clients can access a service in a business-to-business scenario. This out-of-band-negotiation can be done in email, and the X.509 certificate is stored in Windows certificate store, using a tool such as the Microsoft Management Console (MMC) Certificates snap-in.  
  
> [!NOTE]
>  The <xref:System.ServiceModel.ClientBase%601.ClientCredentials%2A> property is used to provide the service with a certificate that was attained through out-of-band negotiation. This is necessary when using the <xref:System.ServiceModel.BasicHttpBinding> class because the binding does not allow automated negotiation. The property is also used in an uncorrelated duplex scenario. This is a scenario where a server sends a message to the client without requiring the client to send a request to the server first. Because the server does not have a request from the client, it must use the client's certificate to encrypt the message to the client.  
  
## Setting Credential Values  
 Once you select a security mode, you must specify the actual credentials. For example, if the credential type is set to "certificate," then you must associate a specific credential (such as a specific X.509 certificate) with the service or client.  
  
 Depending on whether you are programming a service or a client, the method for setting the credential value differs slightly.  
  
### Setting Service Credentials  
 If you are using transport mode, and you are using HTTP as the transport, you must use either Internet Information Services (IIS) or configure the port with a certificate. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Transport Security Overview](../../../../docs/framework/wcf/feature-details/transport-security-overview.md) and [HTTP Transport Security](../../../../docs/framework/wcf/feature-details/http-transport-security.md).  
  
 To provision a service with credentials in code, create an instance of the <xref:System.ServiceModel.ServiceHost> class and specify the appropriate credential using the <xref:System.ServiceModel.Description.ServiceCredentials> class, accessed through the <xref:System.ServiceModel.ServiceHostBase.Credentials%2A> property.  
  
#### Setting a Certificate  
 To provision a service with an X.509 certificate to be used to authenticate the service to clients, use the <xref:System.ServiceModel.Security.X509CertificateInitiatorServiceCredential.SetCertificate%2A> method of the <xref:System.ServiceModel.Security.X509CertificateRecipientServiceCredential> class.  
  
 To provision a service with a client certificate, use the <xref:System.ServiceModel.Security.X509CertificateInitiatorClientCredential.SetCertificate%2A> method of the <xref:System.ServiceModel.Security.X509CertificateInitiatorServiceCredential> class.  
  
#### Setting Windows Credentials  
 If the client specifies a valid user name and password, that credential is used to authenticate the client. Otherwise, the current logged-on user's credentials are used.  
  
### Setting Client Credentials  
 In [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], client applications use a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client to connect to services. Every client derives from the <xref:System.ServiceModel.ClientBase%601> class, and the <xref:System.ServiceModel.ClientBase%601.ClientCredentials%2A> property on the client allows the specification of various values of client credentials.  
  
#### Setting a Certificate  
 To provision a service with an X.509 certificate that is used to authenticate the client to a service, use the <xref:System.ServiceModel.Security.X509CertificateInitiatorClientCredential.SetCertificate%2A> method of the <xref:System.ServiceModel.Security.X509CertificateInitiatorClientCredential> class.  
  
## How Client Credentials Are Used to Authenticate a Client to the Service  
 Client credential information required to communicate with a service is provided using either the <xref:System.ServiceModel.ClientBase%601.ClientCredentials%2A> property or the <xref:System.ServiceModel.ChannelFactory.Credentials%2A> property. The security channel uses this information to authenticate the client to the service. Authentication is accomplished through one of two modes:  
  
-   The client credentials are used once before the first message is sent, using the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client instance to establish a security context. All application messages are then secured through the security context.  
  
-   The client credentials are used to authenticate every application message sent to the service. In this case, no context is established between the client and the service.  
  
### Established Identities Cannot Be Changed  
 When the first method is used, the established context is permanently associated with the client identity. That is, once the security context has been established, the identity associated with the client cannot be changed.  
  
> [!IMPORTANT]
>  There is a situation to be aware of when the identity cannot be switched (that is, when establish security context is on, the default behavior). If you create a service that communicates with a second service, the identity used to open the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client to the second service cannot be changed. This becomes a problem if multiple clients are allowed to use the first service and the service impersonates the clients when accessing the second service. If the service reuses the same client for all callers, all calls to the second service are done under the identity of the first caller that was used to open the client to the second service. In other words, the service uses the identity of the first client for all its clients to communicate with the second service. This can lead to the elevation of privilege. If this is not the desired behavior of your service, you must track each caller and create a new client to the second service for every distinct caller, and ensure that the service uses only the right client for the right caller to communicate with the second service.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] credentials and secure sessions, see [Security Considerations for Secure Sessions](../../../../docs/framework/wcf/feature-details/security-considerations-for-secure-sessions.md).  
  
## See Also  
 <xref:System.ServiceModel.ClientBase%601?displayProperty=nameWithType>  
 <xref:System.ServiceModel.ClientBase%601.ClientCredentials%2A?displayProperty=nameWithType>  
 <xref:System.ServiceModel.Description.ClientCredentials.ClientCertificate%2A?displayProperty=nameWithType>  
 <xref:System.ServiceModel.BasicHttpMessageSecurity.ClientCredentialType%2A?displayProperty=nameWithType>  
 <xref:System.ServiceModel.HttpTransportSecurity.ClientCredentialType%2A?displayProperty=nameWithType>  
 <xref:System.ServiceModel.MessageSecurityOverHttp.ClientCredentialType%2A?displayProperty=nameWithType>  
 <xref:System.ServiceModel.MessageSecurityOverMsmq.ClientCredentialType%2A?displayProperty=nameWithType>  
 <xref:System.ServiceModel.MessageSecurityOverTcp.ClientCredentialType%2A?displayProperty=nameWithType>  
 <xref:System.ServiceModel.TcpTransportSecurity.ClientCredentialType%2A?displayProperty=nameWithType>  
 <xref:System.ServiceModel.Security.X509CertificateInitiatorClientCredential.SetCertificate%2A?displayProperty=nameWithType>  
 <xref:System.ServiceModel.Security.X509CertificateInitiatorClientCredential.SetCertificate%2A?displayProperty=nameWithType>  
 <xref:System.ServiceModel.Security.X509CertificateInitiatorServiceCredential.SetCertificate%2A?displayProperty=nameWithType>  
 [Security Concepts](../../../../docs/framework/wcf/feature-details/security-concepts.md)  
 [Securing Services and Clients](../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)  
 [Programming WCF Security](../../../../docs/framework/wcf/feature-details/programming-wcf-security.md)  
 [HTTP Transport Security](../../../../docs/framework/wcf/feature-details/http-transport-security.md)
