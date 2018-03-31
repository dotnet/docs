---
title: "Working with Certificates"
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
  - "certificates [WCF]"
ms.assetid: 6ffb8682-8f07-4a45-afbb-8d2487e9dbc3
caps.latest.revision: 26
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Working with Certificates
To program [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] security, X.509 digital certificates are commonly used to authenticate clients and servers, encrypt, and digitally sign messages. This topic briefly explains X.509 digital certificate features and how to use them in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], and includes links to topics that explain these concepts further or that show how to accomplish common tasks using [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] and certificates.  
  
 In brief, a digital certificate is a part of a *public key infrastructure* (PKI), which is a system of digital certificates, certificate authorities, and other registration authorities that verify and authenticate the validity of each party involved in an electronic transaction through the use of public key cryptography. A certification authority issues certificates and each certificate has a set of fields that contain data, such as *subject* (the entity to which the certificate is issued), validity dates (when the certificate is valid), issuer (the entity that issued the certificate), and a public key. In [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], each of these properties is processed as a <xref:System.IdentityModel.Claims.Claim>, and each claim is further divided into two types: identity and right. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] X.509 certificates see [X.509 Public Key Certificates](http://go.microsoft.com/fwlink/?LinkId=209952)[!INCLUDE[crabout](../../../../includes/crabout-md.md)] Claims and Authorization in WCF see [Managing Claims and Authorization with the Identity Model](../../../../docs/framework/wcf/feature-details/managing-claims-and-authorization-with-the-identity-model.md). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] implementing a PKI, see [Windows Server 2008 R2 - Certificate Services](http://go.microsoft.com/fwlink/?LinkId=209949).  
  
 A primary function of the certificate is to authenticate the identity of the owner of the certificate to others. A certificate contains the *public key* of the owner, while the owner retains the private key. The public key can be used to encrypt messages sent to the owner of the certificate. Only the owner has access to the private key, so only the owner can decrypt those messages.  
  
 Certificates must be issued by a certification authority, which is often a third-party  issuer of certificates. On a Windows domain, a certification authority is included that can be used to issue certificates to computers on the domain.  
  
## Viewing Certificates  
 To work with certificates, it is often necessary to view them and examine their properties. This is easily done with the Microsoft Management Console (MMC) snap-in tool. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [How to: View Certificates with the MMC Snap-in](../../../../docs/framework/wcf/feature-details/how-to-view-certificates-with-the-mmc-snap-in.md).  
  
## Certificate Stores  
 Certificates are found in stores. Two major store locations exist that are further divided into sub-stores. If you are the administrator on a computer, you can view both major stores by using the MMC snap-in tool. Non-administrators can view only the current user store.  
  
-   **The local machine store**. This contains the certificates accessed by machine processes, such as [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)]. Use this location to store certificates that authenticate the server to clients.  
  
-   **The current user store**. Interactive applications typically place certificates here for the computer's current user. If you are creating a client application, this is where you typically place certificates that authenticate a user to a service.  
  
 These two stores are further divided into sub-stores. The most important of these when programming with [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] include:  
  
-   **Trusted Root Certification Authorities**. You can use the certificates in this store to create a chain of certificates, which can be traced back to a certification authority certificate in this store.  
  
    > [!IMPORTANT]
    >  The local computer implicitly trusts any certificate placed in this store, even if the certificate does not come from a trusted third-party certification authority. For this reason, do not place any certificate into this store unless you fully trust the issuer and understand the consequences.  
  
-   **Personal**. This store is used for certificates associated with a user of a computer. Typically this store is used for certificates issued by one of the certification authority certificates found in the Trusted Root Certification Authorities store. Alternatively, a certificate found here may be self-issued and trusted by an application.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] certificate stores, see [Certificate Stores](http://go.microsoft.com/fwlink/?LinkId=88912).  
  
### Selecting a Store  
 Selecting where to store a certificate depends how and when the service or client runs. The following general rules apply:  
  
-   If the WCF service is hosted in a Windows service use the **local machine** store. Note that administrator privileges are required to install certificates into the local machine store.  
  
-   If the service or client is an application that runs under a user account, then use the **current user** store.  
  
### Accessing Stores  
 Stores are protected by access control lists (ACLs), just like folders on a computer. When creating a service hosted by Internet Information Services (IIS), the [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] process runs under the [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] account. That account must have access to the store that contains the certificates a service uses. Each of the major stores is protected with a default access list, but the lists can be modified. If you create a separate role to access a store, you must grant that role access permission. To learn how to modify the access list using the WinHttpCertConfig.exe tool, see [How to: Create Temporary Certificates for Use During Development](../../../../docs/framework/wcf/feature-details/how-to-create-temporary-certificates-for-use-during-development.md). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] using client certificates with IIS, see [How to call a Web service by using a client certificate for authentication in an ASP.NET Web application](http://go.microsoft.com/fwlink/?LinkId=88914).  
  
## Chain Trust and Certificate Authorities  
 Certificates are created in a hierarchy where each individual certificate is linked to the CA that issued the certificate. This link is to the CA’s certificate. The CA’s certificate then links to the CA that issued the orginal CA’s certificate. This process is repeated up until the Root CA’s certificate is reached. The Root CA’s certificate is inherently trusted.  
  
 Digital certificates are used to authenticate an entity by relying this hierarchy, also called a *chain of trust*. You can view any certificate's chain using the MMC snap-in by double-clicking any certificate, then clicking the **Certificate Path** tab. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] importing certificate chains for a Certification authority, see [How to: Specify the Certificate Authority Certificate Chain Used to Verify Signatures](../../../../docs/framework/wcf/feature-details/specify-the-certificate-authority-chain-verify-signatures-wcf.md).  
  
> [!NOTE]
>  Any issuer can be designated a trusted root authority by placing the issuer's certificate in the trusted root authority certificate store.  
  
### Disabling Chain Trust  
 When creating a new service, you may be using a certificate that is not issued by a trusted root certificate, or the issuing certificate itself may not be in the Trusted Root Certification Authorities store. For development purposes only, you can temporarily disable the mechanism that checks the chain of trust for a certificate. To do this, set the `CertificateValidationMode` property to either `PeerTrust` or `PeerOrChainTrust`. Either mode specifies that the certificate can either be self-issued (peer trust) or part of a chain of trust. You can set the property on any of the following classes.  
  
|Class|Property|  
|-----------|--------------|  
|<xref:System.ServiceModel.Security.X509ClientCertificateAuthentication>|<xref:System.ServiceModel.Security.X509ClientCertificateAuthentication.CertificateValidationMode%2A?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Security.X509PeerCertificateAuthentication>|<xref:System.ServiceModel.Security.X509PeerCertificateAuthentication.CertificateValidationMode%2A?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Security.X509ServiceCertificateAuthentication>|<xref:System.ServiceModel.Security.X509ServiceCertificateAuthentication.CertificateValidationMode%2A?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Security.IssuedTokenServiceCredential>|<xref:System.ServiceModel.Security.IssuedTokenServiceCredential.CertificateValidationMode%2A?displayProperty=nameWithType>|  
  
 You can also set the property using configuration. The following elements are used to specify the validation mode:  
  
-   [\<authentication>](../../../../docs/framework/configure-apps/file-schema/wcf/authentication-of-servicecertificate-element.md)  
  
-   [\<peerAuthentication>](../../../../docs/framework/configure-apps/file-schema/wcf/peerauthentication-element.md)  
  
-   [\<messageSenderAuthentication>](../../../../docs/framework/configure-apps/file-schema/wcf/messagesenderauthentication-element.md)  
  
## Custom Authentication  
 The `CertificateValidationMode` property also enables you to customize how certificates are authenticated. By default, the level is set to `ChainTrust`. To use the <xref:System.ServiceModel.Security.X509CertificateValidationMode.Custom> value, you must also set the `CustomCertificateValidatorType` attribute to an assembly and type used to validate the certificate. To create a custom validator, you must inherit from the abstract <xref:System.IdentityModel.Selectors.X509CertificateValidator> class.  
  
 When creating a custom authenticator, the most important method to override is the <xref:System.IdentityModel.Selectors.X509CertificateValidator.Validate%2A> method. For an example of custom authentication, see the [X.509 Certificate Validator](../../../../docs/framework/wcf/samples/x-509-certificate-validator.md) sample. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Custom Credential and Credential Validation](../../../../docs/framework/wcf/extending/custom-credential-and-credential-validation.md).  
  
## Using Makecert.exe to Build a Certificate Chain  
 The Certificate Creation Tool (Makecert.exe) creates X.509 certificates and private key/public key pairs. You can save the private key to disk and then use it to issue and sign new certificates, thus simulating a hierarchy of chained certificates. The tool is intended for use only as an aid when developing services and should never be used to create certificates for actual deployment. When developing an [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service, use the following steps to build a chain of trust with Makecert.exe.  
  
#### To build a chain of trust with Makecert.exe  
  
1.  Create a temporary root authority (self-signed) certificate using the MakeCert.exe tool. Save the private key to the disk.  
  
2.  Use the new certificate to issue another certificate that contains the public key.  
  
3.  Import the root authority certificate into the Trusted Root Certification Authorities store.  
  
4.  For step-by-step instructions, see [How to: Create Temporary Certificates for Use During Development](../../../../docs/framework/wcf/feature-details/how-to-create-temporary-certificates-for-use-during-development.md).  
  
## Which Certificate to Use?  
 Common questions about certificates are which certificate to use, and why. The answer depends on whether you are programming a client or service. The following information provides a general guideline and is not an exhaustive answer to these questions.  
  
### Service Certificates  
 Service certificates have the primary task of authenticating the server to clients. One of the initial checks when a client authenticates a server is to compare the value of the **Subject** field to the Uniform Resource Identifier (URI) used to contact the service: the DNS of both must match. For example, if the URI of the service is "http://www.contoso.com/endpoint/" then the **Subject** field must also contain the value "www.contoso.com".  
  
 Note that the field can contain several values, each prefixed with an initialization to indicate the value. Most commonly, the initialization is "CN" for common name, for example, "CN = www.contoso.com". It is also possible for the **Subject** field to be blank, in which case the **Subject Alternative Name** field can contain the **DNS Name** value.  
  
 Also note the value of the **Intended Purposes** field of the certificate should include an appropriate value, such as "Server Authentication" or "Client Authentication".  
  
### Client Certificates  
 Client certificates are not typically issued by a third-party certification authority. Instead, the Personal store of the current user location typically contains certificates placed there by a root authority, with an intended purpose of "Client Authentication". The client can use such a certificate when mutual authentication is required.  
  
## Online Revocation and Offline Revocation  
  
### Certificate Validity  
 Every certificate is valid only for a given period of time, called the *validity period*. The validity period is defined by the **Valid from** and **Valid to** fields of an X.509 certificate. During authentication, the certificate is checked to determine whether the certificate is still within the validity period.  
  
### Certificate Revocation List  
 At any time during the validity period, the certification authority can revoke a certificate. This can occur for many reasons, such as a compromise of the private key of the certificate.  
  
 When this occurs, any chains that descend from the revoked certificate are also invalid, and are not trusted during authentication procedures. To find out which certificates are revoked, each issuer publishes a time- and date-stamped *certificate revocation list* (CRL). The list can be checked using either online revocation or offline revocation by setting the `RevocationMode` or `DefaultRevocationMode` property of the following classes to one of the <xref:System.Security.Cryptography.X509Certificates.X509RevocationMode> enumeration values: <xref:System.ServiceModel.Security.X509ClientCertificateAuthentication>, <xref:System.ServiceModel.Security.X509PeerCertificateAuthentication>, <xref:System.ServiceModel.Security.X509ServiceCertificateAuthentication>, and the <xref:System.ServiceModel.Security.IssuedTokenServiceCredential> classes. The default value for all properties is `Online`.  
  
 You can also set the mode in configuration using the `revocationMode` attribute of both the [\<authentication>](../../../../docs/framework/configure-apps/file-schema/wcf/authentication-of-clientcertificate-element.md) (of the [\<serviceBehaviors>](../../../../docs/framework/configure-apps/file-schema/wcf/servicebehaviors.md)) and the [\<authentication>](../../../../docs/framework/configure-apps/file-schema/wcf/authentication-of-clientcertificate-element.md) (of the [\<endpointBehaviors>](../../../../docs/framework/configure-apps/file-schema/wcf/endpointbehaviors.md)).  
  
## The SetCertificate Method  
 In [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], you must often specify a certificate or set of certificates a service or client is to use to authenticate, encrypt, or digitally sign a message. You can do this programmatically by using the `SetCertificate` method of various classes that represent X.509 certificates. The following classes use the `SetCertificate` method to specify a certificate.  
  
|Class|Method|  
|-----------|------------|  
|<xref:System.ServiceModel.Security.PeerCredential>|<xref:System.ServiceModel.Security.PeerCredential.SetCertificate%2A>|  
|<xref:System.ServiceModel.Security.X509CertificateInitiatorClientCredential>|<xref:System.ServiceModel.Security.X509CertificateInitiatorClientCredential.SetCertificate%2A>|  
|<xref:System.ServiceModel.Security.X509CertificateRecipientServiceCredential>|<xref:System.ServiceModel.Security.X509CertificateRecipientServiceCredential.SetCertificate%2A>|  
|<xref:System.ServiceModel.Security.X509CertificateInitiatorServiceCredential>|  
|<xref:System.ServiceModel.Security.X509CertificateInitiatorServiceCredential.SetCertificate%2A>|  
  
 The `SetCertificate` method works by designating a store location and store, a "find" type (`x509FindType` parameter) that specifies a field of the certificate, and a value to find in the field. For example, the following code creates a <xref:System.ServiceModel.ServiceHost> instance and sets the service certificate used to authenticate the service to clients with the `SetCertificate` method.  
  
 [!code-csharp[c_WorkingWithCertificates#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_workingwithcertificates/cs/source.cs#1)]
 [!code-vb[c_WorkingWithCertificates#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_workingwithcertificates/vb/source.vb#1)]  
  
### Multiple Certificates with the Same Value  
 A store may contain multiple certificates with the same subject name. This means that if you specify that the `x509FindType` is <xref:System.Security.Cryptography.X509Certificates.X509FindType.FindBySubjectName> or <xref:System.Security.Cryptography.X509Certificates.X509FindType.FindBySubjectDistinguishedName>, and more than one certificate has the same value, an exception is thrown because there is no way to distinguish which certificate is required. You can mitigate this by setting the `x509FindType` to <xref:System.Security.Cryptography.X509Certificates.X509FindType.FindByThumbprint>. The thumbprint field contains a unique value that can be used to find a specific certificate in a store. However, this has its own disadvantage: if the certificate is revoked or renewed, the `SetCertificate` method fails because the thumbprint is also gone. Or, if the certificate is no longer valid, authentication fails. The way to mitigate this is to set the `x590FindType` parameter to <xref:System.Security.Cryptography.X509Certificates.X509FindType.FindByIssuerName> and specify the issuer's name. If no particular issuer is required, you can also set one of the other <xref:System.Security.Cryptography.X509Certificates.X509FindType> enumeration values, such as <xref:System.Security.Cryptography.X509Certificates.X509FindType.FindByTimeValid>.  
  
## Certificates in Configuration  
 You can also set certificates by using configuration. If you are creating a service, credentials, including certificates, are specified under the [\<serviceBehaviors>](../../../../docs/framework/configure-apps/file-schema/wcf/servicebehaviors.md). When you are programming a client, certificates are specified under the [\<endpointBehaviors>](../../../../docs/framework/configure-apps/file-schema/wcf/endpointbehaviors.md).  
  
## Mapping a Certificate to a User Account  
 A feature of IIS and Active Directory is the ability to map a certificate to a Windows user account. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the feature, see [Map certificates to user accounts](http://go.microsoft.com/fwlink/?LinkId=88917).  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] using Active Directory mapping, see [Mapping Client Certificates with Directory Service Mapping](http://go.microsoft.com/fwlink/?LinkId=88918).  
  
 With this capability enabled, you can set the <xref:System.ServiceModel.Security.X509ClientCertificateAuthentication.MapClientCertificateToWindowsAccount%2A> property of the <xref:System.ServiceModel.Security.X509ClientCertificateAuthentication> class to `true`. In configuration, you can set the `mapClientCertificateToWindowsAccount` attribute of the [\<authentication>](../../../../docs/framework/configure-apps/file-schema/wcf/authentication-of-servicecertificate-element.md) element to `true`, as shown in the following code.  
  
```xml  
<serviceBehaviors>  
 <behavior name="MappingBehavior">  
  <serviceCredentials>  
   <clientCertificate>  
    <authentication certificateValidationMode="None" mapClientCertificateToWindowsAccount="true" />  
   </clientCertificate>  
  </serviceCredentials>  
 </behavior>  
</serviceBehaviors>  
```  
  
 Mapping an X.509 certificate to the token that represents a Windows user account is considered an elevation of privilege because, once mapped, the Windows token can be used to gain access to protected resources. Therefore, domain policy requires the X.509 certificate to comply with its policy prior to mapping. The *SChannel* security package enforces this requirement.  
  
 When using [!INCLUDE[netfx35_long](../../../../includes/netfx35-long-md.md)] or later, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] ensures the certificate conforms to domain policy before it is mapped to a Windows account.  
  
 In the first release of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], mapping is done without consulting the domain policy. Therefore it is possible that older applications that used to work when running under the first release, fails if the mapping is enabled and the X.509 certificate does not satisfy the domain policy.  
  
## See Also  
 <xref:System.ServiceModel.Channels>  
 <xref:System.ServiceModel.Security>  
 <xref:System.ServiceModel>  
 <xref:System.Security.Cryptography.X509Certificates.X509FindType>  
 [Securing Services and Clients](../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)
