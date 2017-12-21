---
title: "How to: Create a Federated Client"
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
ms.assetid: 56ece47e-98bf-4346-b92b-fda1fc3b4d9c
caps.latest.revision: 21
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Create a Federated Client
In [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)], creating a client for a *federated service* consists of three main steps:  
  
1.  Configure a [\<wsFederationHttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/wsfederationhttpbinding.md) or similar custom binding. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] creating an appropriate binding, see [How to: Create a WSFederationHttpBinding](../../../../docs/framework/wcf/feature-details/how-to-create-a-wsfederationhttpbinding.md). Alternatively, run the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) against the metadata endpoint of the federated service to generate a configuration file for communicating with the federated service and one or more security token services.  
  
2.  Set the properties of the <xref:System.ServiceModel.Security.IssuedTokenClientCredential> that controls various aspects of a client's interaction with a security token service.  
  
3.  Set the properties of the <xref:System.ServiceModel.Security.X509CertificateRecipientClientCredential>, which allows certificates needed to communicate securely with given endpoints, such as security token services.  
  
> [!NOTE]
>  A <xref:System.Security.Cryptography.CryptographicException> might be thrown when a client uses impersonated credentials, the <xref:System.ServiceModel.WSFederationHttpBinding> binding or a custom-issued token, and asymmetric keys. Asymmetric keys are used with the <xref:System.ServiceModel.WSFederationHttpBinding> binding and custom-issued tokens when the <xref:System.ServiceModel.FederatedMessageSecurityOverHttp.IssuedKeyType%2A> and <xref:System.ServiceModel.Security.Tokens.IssuedSecurityTokenParameters.KeyType%2A> properties, respectively, are set to <xref:System.IdentityModel.Tokens.SecurityKeyType.AsymmetricKey>. The <xref:System.Security.Cryptography.CryptographicException> is thrown when the client attempts to send a message and a user profile doesn’t exist for the identity that the client is impersonating. To mitigate this issue, log on to the client computer or call `LoadUserProfile` before sending the message.  
  
 This topic provides detailed information about these procedures. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] creating an appropriate binding, see [How to: Create a WSFederationHttpBinding](../../../../docs/framework/wcf/feature-details/how-to-create-a-wsfederationhttpbinding.md). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] how a federated service works, see [Federation](../../../../docs/framework/wcf/feature-details/federation.md).  
  
### To generate and examine the configuration for a federated service  
  
1.  Run the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) with the address of the metadata URL of the service as a command-line parameter.  
  
2.  Open the generated configuration file in an appropriate editor.  
  
3.  Examine the attributes and content of any generated [\<issuer>](../../../../docs/framework/configure-apps/file-schema/wcf/issuer.md) and [\<issuerMetadata>](../../../../docs/framework/configure-apps/file-schema/wcf/issuermetadata.md) elements. These are located within the [\<security>](../../../../docs/framework/configure-apps/file-schema/wcf/security-of-wsfederationhttpbinding.md) elements for the [\<wsFederationHttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/wsfederationhttpbinding.md) or custom bindings elements. Ensure that the addresses contain the expected domain names or other address information. It is important to check this information because the client authenticates to these addresses and may disclose information such as user name/password pairs. If the address is not the expected address, this could result in information disclosure to an unintended recipient.  
  
4.  Examine any additional [\<issuedTokenParameters>](../../../../docs/framework/configure-apps/file-schema/wcf/issuedtokenparameters.md) elements inside the commented out <`alternativeIssuedTokenParameters`> element. When using the Svcutil.exe tool to generate configuration for a federated service, if the federated service or any intermediate security token services do not specify an issuer address, but rather specify a metadata address for a security token service that exposes multiple endpoints, the resulting configuration file refers to the first endpoint. Additional endpoints are in the configuration file as commented-out <`alternativeIssuedTokenParameters`> elements.  
  
     Determine whether one of these <`issuedTokenParameters`> is preferable to the one already present in the configuration. For example, the client may prefer to authenticate to a security token service using a Windows [!INCLUDE[infocard](../../../../includes/infocard-md.md)] token rather than a user name/password pair.  
  
    > [!NOTE]
    >  Where multiple security token services must be traversed before communicating with the service, it is possible for an intermediate security token service to direct the client to an incorrect security token service. Therefore, ensure that the endpoint for the security token service in the [\<issuedTokenParameters>](../../../../docs/framework/configure-apps/file-schema/wcf/issuedtokenparameters.md) is the expected security token service and not an unknown security token service.  
  
### To configure an IssuedTokenClientCredential in code  
  
1.  Access the <xref:System.ServiceModel.Security.IssuedTokenClientCredential> through the <xref:System.ServiceModel.Description.ClientCredentials.IssuedToken%2A> property of the <xref:System.ServiceModel.Description.ClientCredentials> class (returned by the <xref:System.ServiceModel.ClientBase%601.ClientCredentials%2A> property of the <xref:System.ServiceModel.ClientBase%601> class, or through the <xref:System.ServiceModel.ChannelFactory> class), as shown in the following example code.  
  
     [!code-csharp[c_CreateSTS#9](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_creatests/cs/source.cs#9)]
     [!code-vb[c_CreateSTS#9](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_creatests/vb/source.vb#9)]  
  
2.  If token caching is not required, set the <xref:System.ServiceModel.Security.IssuedTokenClientCredential.CacheIssuedTokens%2A> property to `false`. The <xref:System.ServiceModel.Security.IssuedTokenClientCredential.CacheIssuedTokens%2A> property controls whether such tokens from a security token service are cached. If this property is set to `false`, the client requests a new token from the security token service whenever it must re-authenticate itself to the federated service, regardless of whether a previous token is still valid. If this property is set to `true`, the client reuses an existing token whenever it must re-authenticate itself to the federated service (as long as the token has not expired). The default is `true`.  
  
3.  If a time limit is required on cached tokens, set the <xref:System.ServiceModel.Security.IssuedTokenClientCredential.MaxIssuedTokenCachingTime%2A> property to a <xref:System.TimeSpan> value. The property specifies how long a token can be cached. After the specified time span has elapsed, the token is removed from the client cache. By default, tokens are cached indefinitely. The following example sets the time span to 10 minutes.  
  
     [!code-csharp[c_CreateSTS#15](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_creatests/cs/source.cs#15)]
     [!code-vb[c_CreateSTS#15](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_creatests/vb/source.vb#15)]  
  
4.  Optional. Set the <xref:System.ServiceModel.Security.IssuedTokenClientCredential.IssuedTokenRenewalThresholdPercentage%2A> to a percentage. The default is 60 (percent). The property specifies a percentage of the token's validity period. For example, if the issued token is valid for 10 hours and <xref:System.ServiceModel.Security.IssuedTokenClientCredential.IssuedTokenRenewalThresholdPercentage%2A> is set to 80, then the token is renewed after eight hours. The following example sets the value to 80 percent.  
  
     [!code-csharp[c_CreateSTS#16](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_creatests/cs/source.cs#16)]
     [!code-vb[c_CreateSTS#16](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_creatests/vb/source.vb#16)]  
  
     The renewal interval determined by the token validity period and the `IssuedTokenRenewalThresholdPercentage` value is overridden by the `MaxIssuedTokenCachingTime` value in cases where the caching time is shorter than the renewal threshold time. For example, if the product of `IssuedTokenRenewalThresholdPercentage` and the token's duration is eight hours, and the `MaxIssuedTokenCachingTime` value is 10 minutes, the client contacts the security token service for an updated token every 10 minutes.  
  
5.  If a key entropy mode other than <xref:System.ServiceModel.Security.SecurityKeyEntropyMode.CombinedEntropy> is needed on a binding that does not use message security or transport security with message credentials (for example. the binding does not have a <xref:System.ServiceModel.Channels.SecurityBindingElement>), set the <xref:System.ServiceModel.Security.IssuedTokenClientCredential.DefaultKeyEntropyMode%2A> property to an appropriate value. The *entropy* mode determines whether symmetric keys can be controlled using the <xref:System.ServiceModel.Security.IssuedTokenClientCredential.DefaultKeyEntropyMode%2A> property. This default is <xref:System.ServiceModel.Security.SecurityKeyEntropyMode.CombinedEntropy>, where both the client and the token issuer provide data that is combined to produce the actual key. Other values are <xref:System.ServiceModel.Security.SecurityKeyEntropyMode.ClientEntropy> and <xref:System.ServiceModel.Security.SecurityKeyEntropyMode.ServerEntropy>, which means the entire key is specified by the client or the server, respectively. The following example sets the property to use only the server data for the key.  
  
     [!code-csharp[c_CreateSTS#17](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_creatests/cs/source.cs#17)]
     [!code-vb[c_CreateSTS#17](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_creatests/vb/source.vb#17)]  
  
    > [!NOTE]
    >  If a <xref:System.ServiceModel.Channels.SecurityBindingElement> is present in a security token service or service binding, the <xref:System.ServiceModel.Security.IssuedTokenClientCredential.DefaultKeyEntropyMode%2A> set on <xref:System.ServiceModel.Security.IssuedTokenClientCredential> is overridden by the <xref:System.ServiceModel.Channels.SecurityBindingElement.KeyEntropyMode%2A> property of the `SecurityBindingElement`.  
  
6.  Configure any issuer-specific endpoint behaviors by adding them to the collection returned by the <xref:System.ServiceModel.Security.IssuedTokenClientCredential.IssuerChannelBehaviors%2A> property.  
  
     [!code-csharp[c_CreateSTS#14](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_creatests/cs/source.cs#14)]
     [!code-vb[c_CreateSTS#14](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_creatests/vb/source.vb#14)]  
  
### To configure the IssuedTokenClientCredential in configuration  
  
1.  Create an [\<issuedToken>](../../../../docs/framework/configure-apps/file-schema/wcf/issuedtoken.md) element as a child of the [\<issuedToken>](../../../../docs/framework/configure-apps/file-schema/wcf/issuedtoken.md) element in an endpoint behavior.  
  
2.  If token caching is not required, set the `cacheIssuedTokens` attribute (of the <`issuedToken`> element) to `false`.  
  
3.  If a time limit is required on cached tokens, set the `maxIssuedTokenCachingTime` attribute on the <`issuedToken`> element to an appropriate value. For example:  
    `<issuedToken maxIssuedTokenCachingTime='00:10:00' />`  
  
4.  If a value other than the default is preferred, set the `issuedTokenRenewalThresholdPercentage` attribute on the <`issuedToken`> element to an appropriate value, for example:  
  
    ```xml  
    <issuedToken issuedTokenRenewalThresholdPercentage = "80" />  
    ```  
  
5.  If a key entropy mode other than `CombinedEntropy` is on a binding that does not use message security or transport security with message credentials (for example, the binding does not have a `SecurityBindingElement`), set the `defaultKeyEntropyMode` attribute on the `<issuedToken>` element to a either `ServerEntropy` or `ClientEntropy` as required.  
  
    ```xml  
    <issuedToken defaultKeyEntropyMode = "ServerEntropy" />  
    ```  
  
6.  Optional. Configure any issuer-specific custom endpoint behavior by creating an <`issuerChannelBehaviors`> element as a child of the <`issuedToken`> element. For each behavior, create an <`add`> element as a child of the <`issuerChannelBehaviors`> element. Specify the issuer address of the behavior by setting the `issuerAddress` attribute on the <`add`> element. Specify the behavior itself by setting the `behaviorConfiguration` attribute on the <`add`> element.  
  
    ```xml  
    <issuerChannelBehaviors>  
    <add issuerAddress="http://fabrikam.org/sts" behaviorConfiguration="FabrikamSTS" />  
    </issuerChannelBehaviors>  
    ```  
  
### To configure an X509CertificateRecipientClientCredential in code  
  
1.  Access the <xref:System.ServiceModel.Security.X509CertificateRecipientClientCredential> through the <xref:System.ServiceModel.Description.ClientCredentials.ServiceCertificate%2A> property of the <xref:System.ServiceModel.ClientBase%601.ClientCredentials%2A> property of the <xref:System.ServiceModel.ClientBase%601> class or the <xref:System.ServiceModel.ChannelFactory> property.  
  
     [!code-csharp[c_CreateSTS#18](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_creatests/cs/source.cs#18)]
     [!code-vb[c_CreateSTS#18](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_creatests/vb/source.vb#18)]  
  
2.  If an <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> instance is available for the certificate for a given endpoint, use the <xref:System.Collections.Generic.ICollection%601.Add%2A> method of the collection returned by the <xref:System.ServiceModel.Security.X509CertificateRecipientClientCredential.ScopedCertificates%2A> property.  
  
     [!code-csharp[c_CreateSTS#19](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_creatests/cs/source.cs#19)]
     [!code-vb[c_CreateSTS#19](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_creatests/vb/source.vb#19)]  
  
3.  If an <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> instance is not available, use the <xref:System.ServiceModel.Security.X509CertificateRecipientClientCredential.SetScopedCertificate%2A> method of the <xref:System.ServiceModel.Security.X509CertificateRecipientClientCredential> class as shown in the following example.  
  
     [!code-csharp[c_CreateSTS#20](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_creatests/cs/source.cs#20)]
     [!code-vb[c_CreateSTS#20](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_creatests/vb/source.vb#20)]  
  
### To configure an X509CertificateRecipientClientCredential in configuration  
  
1.  Create a [\<scopedCertificates>](../../../../docs/framework/configure-apps/file-schema/wcf/scopedcertificates-element.md) element as a child of the [\<serviceCertificate>](../../../../docs/framework/configure-apps/file-schema/wcf/servicecertificate-of-clientcredentials-element.md) element that is itself a child of the [\<clientCredentials>](../../../../docs/framework/configure-apps/file-schema/wcf/clientcredentials.md) element in an endpoint behavior.  
  
2.  Create an `<add>` element as a child of the `<scopedCertificates>` element. Specify values for the `storeLocation`, `storeName`, `x509FindType`, and `findValue` attributes to refer to the appropriate certificate. Set the `targetUri` attribute to a value that provides the address of the endpoint that the certificate is to be used for, as shown in the following example.  
  
    ```xml  
    <scopedCertificates>  
     <add targetUri="http://fabrikam.com/sts"   
          storeLocation="CurrentUser"  
          storeName="TrustedPeople"  
          x509FindType="FindBySubjectName"  
          findValue="FabrikamSTS" />  
    </scopedCertificates>  
    ```  
  
## Example  
 The following code sample configures an instance of the <xref:System.ServiceModel.Security.IssuedTokenClientCredential> class in code.  
  
 [!code-csharp[c_FederatedClient#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_federatedclient/cs/source.cs#2)]
 [!code-vb[c_FederatedClient#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_federatedclient/vb/source.vb#2)]  
  
## .NET Framework Security  
 To prevent possible information disclosure, clients that are running the Svcutil.exe tool to process metadata from federated endpoints should ensure that the resulting security token service addresses are what they expect. This is especially important when a security token service exposes multiple endpoints, because the Svcutil.exe tool generates the resulting configuration file to use the first such endpoint, which may not be the one the client should be using.  
  
## LocalIssuer Required  
 If clients are expected to always use a local issuer, note the following: the default output of Svcutil.exe results in the local issuer not being used if the second-to-last security token service in the chain specifies an issuer address or issuer metadata address.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] setting the <xref:System.ServiceModel.Security.IssuedTokenClientCredential.LocalIssuerAddress%2A>, <xref:System.ServiceModel.Security.IssuedTokenClientCredential.LocalIssuerBinding%2A>, and <xref:System.ServiceModel.Security.IssuedTokenClientCredential.LocalIssuerChannelBehaviors%2A> properties of the <xref:System.ServiceModel.Security.IssuedTokenClientCredential> class, see [How to: Configure a Local Issuer](../../../../docs/framework/wcf/feature-details/how-to-configure-a-local-issuer.md).  
  
## Scoped Certificates  
 If service certificates must be specified for communicating with any of the security token services, typically because certificate negotiation is not being used, they can be specified using the <xref:System.ServiceModel.Security.X509CertificateRecipientClientCredential.ScopedCertificates%2A> property of the <xref:System.ServiceModel.Security.X509CertificateRecipientClientCredential> class. The <xref:System.ServiceModel.Security.X509CertificateRecipientClientCredential.SetDefaultCertificate%2A> method takes a <xref:System.Uri> and an <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> as parameters. The specified certificate is used when communicating with endpoints at the specified URI. Alternatively, you can use the <xref:System.ServiceModel.Security.X509CertificateRecipientClientCredential.SetScopedCertificate%2A> method to add a certificate to the collection returned by the <xref:System.ServiceModel.Security.X509CertificateRecipientClientCredential.ScopedCertificates%2A> property.  
  
> [!NOTE]
>  The client idea of certificates that are scoped to a given URI applies only to applications that are making outbound calls to services that expose endpoints at those URIs. It does not apply to certificates that are used to sign issued tokens, such as those configured on the server in the collection returned by the <xref:System.ServiceModel.Security.IssuedTokenServiceCredential.KnownCertificates%2A> of the <xref:System.ServiceModel.Security.IssuedTokenServiceCredential> class. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [How to: Configure Credentials on a Federation Service](../../../../docs/framework/wcf/feature-details/how-to-configure-credentials-on-a-federation-service.md).  
  
## See Also  
 [Federation Sample](../../../../docs/framework/wcf/samples/federation-sample.md)  
 [How to: Disable Secure Sessions on a WSFederationHttpBinding](../../../../docs/framework/wcf/feature-details/how-to-disable-secure-sessions-on-a-wsfederationhttpbinding.md)  
 [How to: Create a WSFederationHttpBinding](../../../../docs/framework/wcf/feature-details/how-to-create-a-wsfederationhttpbinding.md)  
 [How to: Configure Credentials on a Federation Service](../../../../docs/framework/wcf/feature-details/how-to-configure-credentials-on-a-federation-service.md)  
 [How to: Configure a Local Issuer](../../../../docs/framework/wcf/feature-details/how-to-configure-a-local-issuer.md)  
 [Security Considerations with Metadata](../../../../docs/framework/wcf/feature-details/security-considerations-with-metadata.md)  
 [How to: Secure Metadata Endpoints](../../../../docs/framework/wcf/feature-details/how-to-secure-metadata-endpoints.md)
