---
title: "How to: Configure Credentials on a Federation Service"
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
  - "WCF, federation"
  - "federation"
ms.assetid: 149ab165-0ef3-490a-83a9-4322a07bd98a
caps.latest.revision: 21
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Configure Credentials on a Federation Service
In [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)], creating a federated service consists of the following main procedures:  
  
1.  Configuring a <xref:System.ServiceModel.WSFederationHttpBinding> or similar custom binding. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] creating an appropriate binding, see [How to: Create a WSFederationHttpBinding](../../../../docs/framework/wcf/feature-details/how-to-create-a-wsfederationhttpbinding.md).  
  
2.  Configuring the <xref:System.ServiceModel.Security.IssuedTokenServiceCredential> that controls how issued tokens presented to the service are authenticated.  
  
 This topic provides details about the second step. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] how a federated service works, see [Federation](../../../../docs/framework/wcf/feature-details/federation.md).  
  
### To set the properties of IssuedTokenServiceCredential in code  
  
1.  Use the <xref:System.ServiceModel.Description.ServiceCredentials.IssuedTokenAuthentication%2A> property of the <xref:System.ServiceModel.Description.ServiceCredentials> class to return a reference to an <xref:System.ServiceModel.Security.IssuedTokenServiceCredential> instance. The property is accessed from the <xref:System.ServiceModel.ServiceHostBase.Credentials%2A> property of the <xref:System.ServiceModel.ServiceHostBase> class.  
  
2.  Set the <xref:System.ServiceModel.Security.IssuedTokenServiceCredential.AllowUntrustedRsaIssuers%2A> property to `true` if self-issued tokens such as [!INCLUDE[infocard](../../../../includes/infocard-md.md)] cards are to be authenticated. The default is `false`.  
  
3.  Populate the collection returned by the <xref:System.ServiceModel.Security.IssuedTokenServiceCredential.KnownCertificates%2A> property with instances of the <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> class. Each instance represents an issuer from which the service will authenticate tokens.  
  
    > [!NOTE]
    >  Unlike the client-side collection returned by the <xref:System.ServiceModel.Security.X509CertificateRecipientClientCredential.ScopedCertificates%2A> property, the known certificates collection is not a keyed collection. The service accepts the tokens that the specified certificates issue regardless of the address of the client that sent the message containing the issued token (subject to the further constraints, which are described later in this topic).  
  
4.  Set the <xref:System.ServiceModel.Security.IssuedTokenServiceCredential.CertificateValidationMode%2A> property to one of the <xref:System.ServiceModel.Security.X509CertificateValidationMode> enumeration values. This can be done only in code. The default is <xref:System.IdentityModel.Selectors.X509CertificateValidator.ChainTrust%2A>.  
  
5.  If the <xref:System.ServiceModel.Security.IssuedTokenServiceCredential.CertificateValidationMode%2A> property is set to <xref:System.ServiceModel.Security.X509CertificateValidationMode.Custom>, then assign an instance of the custom <xref:System.IdentityModel.Selectors.X509CertificateValidator> class to the <xref:System.ServiceModel.Security.X509ServiceCertificateAuthentication.CustomCertificateValidator%2A> property.  
  
6.  If the <xref:System.ServiceModel.Security.IssuedTokenServiceCredential.CertificateValidationMode%2A> is set to `ChainTrust` or `PeerOrChainTrust`, set the <xref:System.ServiceModel.Security.IssuedTokenServiceCredential.RevocationMode%2A> property to an appropriate value from the <xref:System.Security.Cryptography.X509Certificates.X509RevocationMode> enumeration. Note that the revocation mode is not used in `PeerTrust` or `Custom` validation modes.  
  
7.  If needed, assign an instance of a custom <xref:System.IdentityModel.Tokens.SamlSerializer> class to the <xref:System.ServiceModel.Security.IssuedTokenServiceCredential.SamlSerializer%2A> property. A custom Security Assertions Markup Language (SAML) serializer is needed, for example, for parsing custom SAML assertions.  
  
### To set the properties of IssuedTokenServiceCredential in configuration  
  
1.  Create an `<issuedTokenAuthentication>` element as a child of a <`serviceCredentials`> element.  
  
2.  Set the `allowUntrustedRsaIssuers` attribute of the `<issuedTokenAuthentication>` element to `true` if authenticating a self-issued token, such as an [!INCLUDE[infocard](../../../../includes/infocard-md.md)] card.  
  
3.  Create a `<knownCertificates>` element as a child of the `<issuedTokenAuthentication>` element.  
  
4.  Create zero or more `<add>` elements as children of the `<knownCertificates>` element, and specify how to locate the certificate using the `storeLocation`, `storeName`, `x509FindType`, and `findValue` attributes.  
  
5.  If necessary, set the `samlSerializer` attribute of the <`issuedTokenAuthentication`> element to the type name of the custom <xref:System.IdentityModel.Tokens.SamlSerializer> class.  
  
## Example  
 The following example sets the properties of an <xref:System.ServiceModel.Security.IssuedTokenServiceCredential> in code.  
  
 [!code-csharp[C_FederatedService#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_federatedservice/cs/source.cs#2)]
 [!code-vb[C_FederatedService#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_federatedservice/vb/source.vb#2)]  
  
 In order for a federated service to authenticate a client, the following must be true about the issued token:  
  
-   When the issued token’s digital signature uses an RSA security key identifier, the <xref:System.ServiceModel.Security.IssuedTokenServiceCredential.AllowUntrustedRsaIssuers%2A> property must be `true`.  
  
-   When the issued token’s signature uses an X.509 issuer serial number, X.509 subject key identifier, or X.509 thumbprint security identifier, the issued token must be signed by a certificate in the collection returned by the <xref:System.ServiceModel.Security.IssuedTokenServiceCredential.KnownCertificates%2A> property of the <xref:System.ServiceModel.Security.IssuedTokenServiceCredential> class.  
  
-   When the issued token is signed using an X.509 certificate, the certificate must validate per the semantics specified by the value of the <xref:System.ServiceModel.Security.X509ServiceCertificateAuthentication.CertificateValidationMode%2A> property, regardless of whether the certificate was sent to the relying party as a <xref:System.IdentityModel.Tokens.X509RawDataKeyIdentifierClause> or was obtained from the <xref:System.ServiceModel.Security.IssuedTokenServiceCredential.KnownCertificates%2A> property. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] X.509 certificate validation, see [Working with Certificates](../../../../docs/framework/wcf/feature-details/working-with-certificates.md).  
  
 For example, setting the <xref:System.ServiceModel.Security.IssuedTokenServiceCredential.CertificateValidationMode%2A> to <xref:System.ServiceModel.Security.X509CertificateValidationMode.PeerTrust> would authenticate any issued token whose signing certificate is in the `TrustedPeople` certificate store. In that case, set the <xref:System.ServiceModel.Security.IssuedTokenServiceCredential.TrustedStoreLocation%2A> property to either <xref:System.Security.Cryptography.X509Certificates.StoreLocation.CurrentUser> or <xref:System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine>. You can select other modes, including <xref:System.ServiceModel.Security.X509CertificateValidationMode.Custom>. When `Custom` is selected, you must assign an instance of the <xref:System.IdentityModel.Selectors.X509CertificateValidator> class to the <xref:System.ServiceModel.Security.IssuedTokenServiceCredential.CustomCertificateValidator%2A> property. The custom validator can validate certificates using any criteria it likes. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [How to: Create a Service that Employs a Custom Certificate Validator](../../../../docs/framework/wcf/extending/how-to-create-a-service-that-employs-a-custom-certificate-validator.md).  
  
## See Also  
 [Federation](../../../../docs/framework/wcf/feature-details/federation.md)  
 [Federation and Trust](../../../../docs/framework/wcf/feature-details/federation-and-trust.md)  
 [Federation Sample](../../../../docs/framework/wcf/samples/federation-sample.md)  
 [How to: Disable Secure Sessions on a WSFederationHttpBinding](../../../../docs/framework/wcf/feature-details/how-to-disable-secure-sessions-on-a-wsfederationhttpbinding.md)  
 [How to: Create a WSFederationHttpBinding](../../../../docs/framework/wcf/feature-details/how-to-create-a-wsfederationhttpbinding.md)  
 [How to: Create a Federated Client](../../../../docs/framework/wcf/feature-details/how-to-create-a-federated-client.md)  
 [Working with Certificates](../../../../docs/framework/wcf/feature-details/working-with-certificates.md)  
 [SecurityBindingElement Authentication Modes](../../../../docs/framework/wcf/feature-details/securitybindingelement-authentication-modes.md)
