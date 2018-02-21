---
title: "SecurityBindingElement Authentication Modes"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 12300bf4-c730-4405-9f65-d286f68b5a43
caps.latest.revision: 13
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# SecurityBindingElement Authentication Modes
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] provides several modes by which clients and services authenticate to one another. You can create security binding elements for these authentication modes by using static methods on the <xref:System.ServiceModel.Channels.SecurityBindingElement> class or through configuration. This topic briefly describes the 18 authentication modes.  
  
 For an example of using the element for one of the authentication modes, see [How to: Create a SecurityBindingElement for a Specified Authentication Mode](../../../../docs/framework/wcf/feature-details/how-to-create-a-securitybindingelement-for-a-specified-authentication-mode.md).  
  
## Basic Configuration Programming  
 The following procedure describes how to set the authentication mode in a configuration file.  
  
#### To set the authentication mode in configuration  
  
1.  To the [\<bindings>](../../../../docs/framework/configure-apps/file-schema/wcf/bindings.md) element, add a [\<customBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md).  
  
2.  As a child element, add a [\<binding>](../../../../docs/framework/misc/binding.md) element to the `<customBinding>` element.  
  
3.  Add a `<security>` element to the `<binding>` element.  
  
4.  Set the `authenticationMode` attribute to one of the values described below. For example, the following code sets the mode to `AnonymousForCertificate`.  
  
    ```xml  
    <bindings>  
      <customBinding>  
        <binding name="SecureCustomBinding">  
         <security authenticationMode ="AnonymousForCertificate" />  
        </binding>  
      </customBinding>  
    </bindings>  
    ```  
  
#### To set the mode programmatically  
  
1.  Determine the return type, which can be one of the following: <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement>, <xref:System.ServiceModel.Channels.TransportSecurityBindingElement>, <xref:System.ServiceModel.Channels.AsymmetricSecurityBindingElement>, or <xref:System.ServiceModel.Channels.SecurityBindingElement>.  
  
2.  Call the appropriate static method of the <xref:System.ServiceModel.Channels.SecurityBindingElement> class. For example, the following code calls the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateAnonymousForCertificateBindingElement%2A> method.  
  
     [!code-csharp[c_CustomBindingsAuthMode#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_custombindingsauthmode/cs/source.cs#3)]
     [!code-vb[c_CustomBindingsAuthMode#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_custombindingsauthmode/vb/source.vb#3)]  
  
3.  Use the binding element to create the custom binding. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Custom Bindings](../../../../docs/framework/wcf/extending/custom-bindings.md).  
  
## Mode Descriptions  
  
### AnonymousForCertificate  
 With this authentication mode, the client is anonymous and the service is authenticated using an X.509 certificate. The security binding element is a <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement> returned by the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateAnonymousForCertificateBindingElement%2A> method. Alternatively, set the `authenticationMode` attribute of the <`security`> element to `AnonymousForCertificate`.  
  
### AnonymousForSslNegotiated  
 With this authentication mode, the client is anonymous and the service is authenticated using an X.509 certificate that is negotiated at run time. The security binding element is a <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement> returned by the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateSslNegotiationBindingElement%2A> method when a value of `false` is passed for the first parameter. Alternatively, set the `authenticationMode` attribute to `AnonymousForSslNegotiated`.  
  
### CertificateOverTransport  
 With this authentication mode, the client authenticates using an X.509 certificate that appears at the SOAP layer as an endorsing supporting token; that is, a token that signs the message signature. The service is authenticated using an X.509 certificate at the transport layer. The security binding element is a <xref:System.ServiceModel.Channels.TransportSecurityBindingElement> returned by the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateCertificateOverTransportBindingElement%2A> method. Alternatively, set the `authenticationMode` attribute to `CertificateOverTransport`.  
  
### IssuedToken  
 With this authentication mode, the client does not authenticate to the service, as such; instead, the client authenticates to a security token service and receives a SAML token, which it then presents to the server to prove its knowledge of a shared key. The service is not authenticated to the client, as such, but the security token service encrypts the shared key as part of the issued token so that only the service can decrypt the key. The security binding element is a <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement> returned by the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateIssuedTokenBindingElement%2A> method. Alternatively, set the `authenticationMode` attribute to `IssuedToken`.  
  
### IssuedTokenForCertificate  
 With this authentication mode, the client does not authenticate to the service, as such; instead, the client authenticates to a security token service and receives a SAML token, which it then presents to the server to prove its knowledge of a shared key. The issued token appears at the SOAP layer as either an endorsing supporting token or a bearer token; that is, a token that signs the message signature. The service authenticates to the client using an X.509 certificate. The security binding element is a <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement> returned by the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateIssuedTokenForCertificateBindingElement%2A> method. Alternatively, set the `authenticationMode` attribute to `IssuedTokenForCertificate`.  
  
### IssuedTokenForSslNegotiated  
 With this authentication mode, the client does not authenticate to the service, as such; instead, the client authenticates to a security token service and receives a SAML token, which it then presents to the server to prove its knowledge of a shared key. The issued token appears at the SOAP layer as either an endorsing supporting token or a bearer token; that is, a token that signs the message signature. The service is authenticated using an X.509 certificate. The security binding element is a <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement> returned by the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateIssuedTokenForSslBindingElement%2A> method. Alternatively, set the `authenticationMode` attribute to `IssuedTokenForSslnegotiated`.  
  
### IssuedTokenOverTransport  
 With this authentication mode, the client does not authenticate to the service, as such; instead, the client authenticates to a security token service and receives a SAML token, which it then presents to the server to prove its knowledge of a shared key. The issued token appears at the SOAP layer as either an endorsing supporting token or a bearer token; that is, a token that signs the message signature. The service is authenticated using an X.509 certificate at the transport layer. The security binding element is a `TransportSecurityBindingElement` returned by the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateIssuedTokenOverTransportBindingElement%2A> method. Alternatively, set the `authenticationMode` attribute to `IssuedTokenOverTransport`.  
  
### Kerberos  
 With this authentication mode, the client authenticates to the service using a Kerberos ticket. That same ticket also provides server authentication. The security binding element is a `SymmetricSecurityBindingElement` returned by the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateKerberosBindingElement%2A> method. Alternatively, set the `authenticationMode` attribute to `Kerberos`.  
  
> [!NOTE]
>  In order to use this authentication mode, the service account must be associated with a service principal name (SPN). To do this, run the service under the NETWORK SERVICE account or the LOCAL SYSTEM account. Alternatively, use the SetSpn.exe tool to create an SPN for the service account. In either case, the client must use the correct SPN in the [\<servicePrincipalName>](../../../../docs/framework/configure-apps/file-schema/wcf/serviceprincipalname.md) element, or by using the <xref:System.ServiceModel.EndpointAddress> constructor. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Service Identity and Authentication](../../../../docs/framework/wcf/feature-details/service-identity-and-authentication.md).  
  
> [!NOTE]
>  When the `Kerberos` authentication mode is used, the <xref:System.Security.Principal.TokenImpersonationLevel.Anonymous> and <xref:System.Security.Principal.TokenImpersonationLevel.Delegation> impersonation levels are not supported.  
  
### KerberosOverTransport  
 With this authentication mode, the client authenticates to the service using a Kerberos ticket. The Kerberos token appears at the SOAP layer as an endorsing supporting token; that is, a token that signs the message signature. The service is authenticated using an X.509 certificate at the transport layer. The security binding element is a `TransportSecurityBindingElement` returned by the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateKerberosOverTransportBindingElement%2A> method. Alternatively, set the `authenticationMode` attribute to `KerberosOverTransport`.  
  
> [!NOTE]
>  In order to use this authentication mode, the service account must be associated with an SPN. To do this, run the service under the NETWORK SERVICE account or the LOCAL SYSTEM account. Alternatively, use the SetSpn.exe tool to create an SPN for the service account. In either case, the client must use the correct SPN in the [\<servicePrincipalName>](../../../../docs/framework/configure-apps/file-schema/wcf/serviceprincipalname.md) element, or by using the <xref:System.ServiceModel.EndpointAddress> constructor. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Service Identity and Authentication](../../../../docs/framework/wcf/feature-details/service-identity-and-authentication.md).  
  
### MutualCertificate  
 With this authentication mode, the client authenticates using an X.509 certificate that appears at the SOAP layer as an endorsing supporting token; that is, a token that signs the message signature. The service is also authenticated using an X.509 certificate. The security binding element is a `SymmetricSecurityBindingElement` returned by the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateMutualCertificateBindingElement%2A> method. Alternatively, set the `authenticationMode` attribute to `MutualCertificate`.  
  
### MutualCertificateDuplex  
 With this authentication mode, the client authenticates using an X.509 certificate that appears at the SOAP layer as an endorsing supporting token; that is, a token that signs the message signature. The service is also authenticated using an X.509 certificate. The binding is a `AsymmetricSecurityBindingElement` returned by the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateMutualCertificateDuplexBindingElement%2A> method. Alternatively, set the `authenticationMode` attribute to `MutualCertificateDuplex`.  
  
### MutalSslNegotiation  
 With this authentication mode, the client and the service authenticate using X.509 certificates. The security binding element is a `SymmetricSecurityBindingElement` returned by the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateSslNegotiationBindingElement%2A> method when a value of `true` is passed for the first parameter. Alternatively, set the `authenticationMode` attribute to `MutualSslNegotiated`.  
  
### SecureConversation  
 The security binding element is a `SymmetricSecurityBindingElement` returned by the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateSecureConversationBindingElement%2A> method. This method takes a <xref:System.ServiceModel.Channels.SecurityBindingElement> as a parameter, which is used during initialization to establish the secure session. Alternatively, set the `authenticationMode` attribute to `SecureConversation`.  
  
 If no bootstrap binding is specified, then the `SspiNegotiated` authentication mode is used for bootstrap.  
  
### SspiNegotiation  
 With this authentication mode, a negotiation protocol is used to perform client and server authentication. Kerberos is used if possible; otherwise, NT LanMan (NTLM) is used. The security binding element is a `SymmetricSecurityBindingElement` returned by the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateSspiNegotiationBindingElement%2A> method. Alternatively, set the `authenticationMode` attribute to `SspiNegotiated`.  
  
### SspiNegotiatedOverTransport  
 With this authentication mode, a negotiation protocol is used to perform client and server authentication. Kerberos protocol is used if possible; otherwise, NTLM is used. The resulting token appears at the SOAP layer as an endorsing supporting token; that is, a token that signs the message signature. The service is additionally authenticated at the transport layer by an X.509 certificate. The security binding element is a `TransportSecurityBindingElement` returned by the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateSspiNegotiationOverTransportBindingElement%2A> method. Alternatively, set the `authenticationMode` attribute to `SspiNegotiatedOverTransport`.  
  
### UserNameForCertificate  
 With this authentication mode, the client authenticates to the service using a Username Token that appears at the SOAP layer as a signed supporting token; that is, a token that is signed by the message signature. The service authenticates to the client using an X.509 certificate. The security binding element is a `SymmetricSecurityBindingElement` returned by the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateUserNameForCertificateBindingElement%2A> method. Alternatively, set the `authenticationMode` attribute to `UserNameForCertificate`.  
  
 For the `UserNameForCertificate` authentication mode, both the client and service must be using WS-Security 1.1.  
  
### UserNameForSslNegotiated  
 With this authentication mode, the client is authenticates using a Username Token which appears at the SOAP layer as a signed supporting token; that is, a token that is signed by the message signature. The service is authenticated using an X.509 certificate. The security binding element is a `SymmetricSecurityBindingElement` returned by the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateUserNameForSslBindingElement%2A> method. Alternatively, set the `authenticationMode` attribute to `UserNameForSslNegotiated`.  
  
### UserNameOverTransport  
 With this authentication mode, the client authenticates using a Username Token that appears at the SOAP layer as a signed supporting token; that is, a token that is signed by the message signature. The service is authenticated using an X.509 certificate at the transport layer. The security binding element is a `TransportSecurityBindingElement` returned by the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateUserNameOverTransportBindingElement%2A> method. Alternatively, set the `authenticationMode` attribute to `UserNameOverTransport`.  
  
## See Also  
 <xref:System.ServiceModel.Channels.SecurityBindingElement>  
 [How to: Create a SecurityBindingElement for a Specified Authentication Mode](../../../../docs/framework/wcf/feature-details/how-to-create-a-securitybindingelement-for-a-specified-authentication-mode.md)
