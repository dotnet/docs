---
title: "Service Identity and Authentication"
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
helpviewer_keywords: 
  - "authentication [WCF], specifying the identity of a service"
ms.assetid: a4c8f52c-5b30-45c4-a545-63244aba82be
caps.latest.revision: 32
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Service Identity and Authentication
A service's *endpoint identity*is a value generated from the service Web Services Description Language (WSDL). This value, propagated to any client, is used to authenticate the service. After the client initiates a communication to an endpoint and the service authenticates itself to the client, the client compares the endpoint identity value with the actual value the endpoint authentication process returned. If they match, the client is assured it has contacted the expected service endpoint. This functions as a protection against *phishing* by preventing a client from being redirected to an endpoint hosted by a malicious service.  
  
 For a sample application that demonstrates identity setting, see [Service Identity Sample](../../../../docs/framework/wcf/samples/service-identity-sample.md). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] endpoints and endpoint addresses, see [Addresses](../../../../docs/framework/wcf/feature-details/endpoint-addresses.md).  
  
> [!NOTE]
>  When you use NT LanMan (NTLM) for authentication, the service identity is not checked because, under NTLM, the client is unable to authenticate the server. NTLM is used when computers are part of a Windows workgroup, or when running an older version of Windows that does not support Kerberos authentication.  
  
 When the client initiates a secure channel to send a message to a service over it, the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] infrastructure authenticates the service, and only sends the message if the service identity matches the identity specified in the endpoint address the client uses.  
  
 Identity processing consists of the following stages:  
  
-   At design time, the client developer determines the service's identity from the endpoint's metadata (exposed through WSDL).  
  
-   At runtime, the client application checks the claims of the service's security credentials before sending any messages to the service.  
  
 Identity processing on the client is analogous to client authentication on the service. A secure service does not execute code until the client's credentials have been authenticated. Likewise, the client does not send messages to the service until the service's credentials have been authenticated based on what is known in advance from the service's metadata.  
  
 The <xref:System.ServiceModel.EndpointAddress.Identity%2A> property of the <xref:System.ServiceModel.EndpointAddress> class represents the identity of the service called by the client. The service publishes the <xref:System.ServiceModel.EndpointAddress.Identity%2A> in its metadata. When the client developer runs the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) against the service endpoint, the generated configuration contains the value of the service's <xref:System.ServiceModel.EndpointAddress.Identity%2A> property. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] infrastructure (if configured with security) verifies that the service possesses the identity specified.  
  
> [!IMPORTANT]
>  The metadata contains the expected identity of the service, so it is recommended that you expose the service metadata through secure means, for example, by creating an HTTPS endpoint for the service. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [How to: Secure Metadata Endpoints](../../../../docs/framework/wcf/feature-details/how-to-secure-metadata-endpoints.md).  
  
## Identity Types  
 A service can provide six types of identities. Each identity type corresponds to an element that can be contained inside the `<identity>` element in configuration. The type used depends on the scenario and the service's security requirements. The following table describes each identity type.  
  
|Identity type|Description|Typical scenario|  
|-------------------|-----------------|----------------------|  
|Domain Name System (DNS)|Use this element with X.509 certificates or Windows accounts. It compares the DNS name specified in the credential with the value specified in this element.|A DNS check enables you to use certificates with DNS or subject names. If a certificate is reissued with the same DNS or subject name, then the identity check is still valid. When a certificate is reissued, it gets a new RSA key but retains the same DNS or subject name. This means that clients do not have to update their identity information about the service.|  
|Certificate. The default when `ClientCredentialType` is set to Certificate.|This element specifies a Base64-encoded X.509 certificate value to compare with the client.<br /><br /> Also use this element when using a [!INCLUDE[infocard](../../../../includes/infocard-md.md)] as a credential to authenticate the service.|This element restricts authentication to a single certificate based upon its thumbprint value. This enables stricter authentication because thumbprint values are unique. This comes with one caveat: If the certificate is reissued with the same Subject name, it also has a new Thumbprint. Therefore, clients are not able to validate the service unless the new thumbprint is known. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] finding a certificate's thumbprint, see [How to: Retrieve the Thumbprint of a Certificate](../../../../docs/framework/wcf/feature-details/how-to-retrieve-the-thumbprint-of-a-certificate.md).|  
|Certificate Reference|Identical to the Certificate option described previously. However, this element enables you to specify a certificate name and store location from which to retrieve the certificate.|Same as the Certificate scenario described previously.<br /><br /> The benefit is that the certificate store location can change.|  
|RSA|This element specifies an RSA key value to compare with the client. This is similar to the certificate option but rather than using the certificate's thumbprint, the certificate's RSA key is used instead.|An RSA check enables you to specifically restrict authentication to a single certificate based upon its RSA key. This enables stricter authentication of a specific RSA key at the expense of the service, which no longer works with existing clients if the RSA key value changes.|  
|User principal name (UPN). The default when the `ClientCredentialType` is set to Windows and the service process is not running under one of the system accounts.|This element specifies the UPN that the service is running under. See the Kerberos Protocol and Identity section of [Overriding the Identity of a Service for Authentication](../../../../docs/framework/wcf/extending/overriding-the-identity-of-a-service-for-authentication.md).|This ensures that the service is running under a specific Windows user account. The user account can be either the current logged-on user or the service running under a particular user account.<br /><br /> This setting takes advantage of Windows Kerberos security if the service is running under a domain account within an Active Directory environment.|  
|Service principal name (SPN). The default when the `ClientCredentialType` is set to Windows and the service process is running under one of the system accounts—LocalService, LocalSystem, or NetworkService.|This element specifies the SPN associated with the service's account. See the Kerberos Protocol and Identity section of [Overriding the Identity of a Service for Authentication](../../../../docs/framework/wcf/extending/overriding-the-identity-of-a-service-for-authentication.md).|This ensures that the SPN and the specific Windows account associated with the SPN identify the service.<br /><br /> You can use the Setspn.exe tool to associate a machine account for the service's user account.<br /><br /> This setting takes advantage of Windows Kerberos security if the service is running under one of the system accounts or under a domain account that has an associated SPN name with it and the computer is a member of a domain within an Active Directory environment.|  
  
## Specifying Identity at the Service  
 Typically, you do not have to set the identity on a service because the selection of a client credential type dictates the type of identity exposed in the service metadata. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] how to override or specify service identity, see [Overriding the Identity of a Service for Authentication](../../../../docs/framework/wcf/extending/overriding-the-identity-of-a-service-for-authentication.md).  
  
## Using the \<identity> Element in Configuration  
 If you change the client credential type in the binding previously shown to `Certificate,` then the generated WSDL contains a Base64 serialized X.509 certificate for the identity value as shown in the following code. This is the default for all client credential types other than Windows.  
  
  
  
 You can change the value of the default service identity or change the type of the identity by using the `<identity>` element in configuration or by setting the identity in code. The following configuration code sets a domain name system (DNS) identity with the value `contoso.com`.  
  
  
  
## Setting Identity Programmatically  
 Your service does not have to explicitly specify an identity, because [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] automatically determines it. However, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] allows you to specify an identity on an endpoint, if required. The following code adds a new service endpoint with a specific DNS identity.  
  
 [!code-csharp[C_Identity#5](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_identity/cs/source.cs#5)]
 [!code-vb[C_Identity#5](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_identity/vb/source.vb#5)]  
  
## Specifying Identity at the Client  
 At design time, a client developer typically uses the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) to generate client configuration. The generated configuration file (intended for use by the client) contains the server's identity. For example, the following code is generated from a service that specifies a DNS identity, as shown in the preceding example. Note that the client's endpoint identity value matches that of the service. In this case, when the client receives the Windows (Kerberos) credentials for the service, it expects the value to be `contoso.com`.  
  
  
  
 If, instead of Windows, the service specifies a certificate as the client credential type, then the certificate's DNS property is expected to be the value `contoso.com`. (Or if the DNS property is `null`, the certificate's subject name must be `contoso.com`.)  
  
#### Using a Specific Value for Identity  
 The following client configuration file shows how the service's identity is expected to be a specific value. In the following example, the client can communicate with two endpoints. The first is identified with a certificate thumbprint and the second with a certificate RSA key. That is, a certificate that contains only a public key/private key pair, but is not issued by a trusted authority.  
  
  
  
## Identity Checking at Run Time  
 At design time, a client developer determines the server's identity through its metadata. At runtime, the identity check is performed before calling any endpoints on the service.  
  
 The identity value is tied to the type of authentication specified by metadata; in other words, the type of credentials used for the service.  
  
 If the channel is configured to authenticate using message- or transport-level Secure Sockets Layer (SSL) with X.509 certificates for authentication, the following identity values are valid:  
  
-   DNS. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] ensures that the certificate provided during the SSL handshake contains a DNS or `CommonName` (CN) attribute equal to the value specified in the DNS identity on the client. Note that these checks are done in addition to determining the validity of the server certificate. By default, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] validates that the server certificate is issued by a trusted root authority.  
  
-   Certificate. During the SSL handshake, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] ensures that the remote endpoint provides the exact certificate value specified in the identity.  
  
-   Certificate Reference. Same as Certificate.  
  
-   RSA. During the SSL handshake, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] ensures that the remote endpoint provides the exact RSA key specified in the identity.  
  
 If the service authenticates using message- or transport-level SSL with a Windows credential for authentication, and negotiates the credential, the following identity values are valid:  
  
-   DNS. The negotiation passes the service's SPN so that the DNS name can be checked. The SPN is in the form `host/<dns name>`.  
  
-   SPN. An explicit service SPN is returned, for example, `host/myservice`.  
  
-   UPN. The UPN of the service account. The UPN is in the form `username`@`domain`. For example, when the service is running in a user account, it may be `username@contoso.com`.  
  
 Specifying the identity programmatically (using the <xref:System.ServiceModel.EndpointAddress.Identity%2A> property) is optional. If no identity is specified, and the client credential type is Windows, the default is SPN with the value set to the hostname part of the service endpoint address prefixed with the "host/" literal. If no identity is specified, and the client credential type is a certificate, the default is `Certificate`. This applies to both message- and transport-level security.  
  
## Identity and Custom Bindings  
 Because the identity of a service depends on the binding type used, ensure that an appropriate identity is exposed when creating a custom binding. For example, in the following code example, the identity exposed is not compatible with the security type, because the identity for the secure conversation bootstrap binding does not match the identity for the binding on the endpoint. The secure conversation binding sets the DNS identity, while the <xref:System.ServiceModel.Channels.WindowsStreamSecurityBindingElement> sets the UPN or SPN identity.  
  
 [!code-csharp[C_Identity#8](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_identity/cs/source.cs#8)]
 [!code-vb[C_Identity#8](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_identity/vb/source.vb#8)]  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] how to stack binding elements correctly for a custom binding, see [Creating User-Defined Bindings](../../../../docs/framework/wcf/extending/creating-user-defined-bindings.md). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] creating a custom binding with the <xref:System.ServiceModel.Channels.SecurityBindingElement>, see [How to: Create a SecurityBindingElement for a Specified Authentication Mode](../../../../docs/framework/wcf/feature-details/how-to-create-a-securitybindingelement-for-a-specified-authentication-mode.md).  
  
## See Also  
 [How to: Create a Custom Binding Using the SecurityBindingElement](../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md)  
 [How to: Create a SecurityBindingElement for a Specified Authentication Mode](../../../../docs/framework/wcf/feature-details/how-to-create-a-securitybindingelement-for-a-specified-authentication-mode.md)  
 [How to: Create a Custom Client Identity Verifier](../../../../docs/framework/wcf/extending/how-to-create-a-custom-client-identity-verifier.md)  
 [Selecting a Credential Type](../../../../docs/framework/wcf/feature-details/selecting-a-credential-type.md)  
 [Working with Certificates](../../../../docs/framework/wcf/feature-details/working-with-certificates.md)  
 [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md)  
 [Creating User-Defined Bindings](../../../../docs/framework/wcf/extending/creating-user-defined-bindings.md)  
 [How to: Retrieve the Thumbprint of a Certificate](../../../../docs/framework/wcf/feature-details/how-to-retrieve-the-thumbprint-of-a-certificate.md)
