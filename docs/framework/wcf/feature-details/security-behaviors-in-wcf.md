---
description: "Learn more about: Security Behaviors in WCF"
title: "Security Behaviors in WCF"
ms.date: "03/30/2017"
ms.assetid: 513232c0-39fd-4409-bda6-5ebd5e0ea7b0
---
# Security Behaviors in WCF

In Windows Communication Foundation (WCF), behaviors modify run-time behavior at the service level or at the endpoint level. (For more information about behaviors in general, see [Specifying Service Run-Time Behavior](../specifying-service-run-time-behavior.md).) *Security behaviors* allow control over credentials, authentication, authorization, and auditing logs. You can use behaviors either by programming or through configuration. This topic focuses on configuring the following behaviors related to security functions:  
  
- [\<serviceCredentials>](../../configure-apps/file-schema/wcf/servicecredentials.md).  
  
- [\<clientCredentials>](../../configure-apps/file-schema/wcf/clientcredentials.md).  
  
- [\<serviceAuthorization>](../../configure-apps/file-schema/wcf/serviceauthorization-element.md).  
  
- [\<serviceSecurityAudit>](../../configure-apps/file-schema/wcf/servicesecurityaudit.md).  
  
- [\<serviceMetadata>](../../configure-apps/file-schema/wcf/servicemetadata.md), which also enables you to specify a secure endpoint that clients can access for metadata.  
  
## Setting Credentials with Behaviors  

 Use the [\<serviceCredentials>](../../configure-apps/file-schema/wcf/servicecredentials.md) and [\<clientCredentials>](../../configure-apps/file-schema/wcf/clientcredentials.md) to set credential values for a service or client. The underlying binding configuration determines whether a credential has to be set. For example, if the security mode is set to `None`, both clients and services do not authenticate each other and require no credentials of any type.  
  
 On the other hand, the service binding can require a client credential type. In that case, you may have to set a credential value using a behavior. (For more information about the possible types of credentials, see [Selecting a Credential Type](selecting-a-credential-type.md).) In some cases, such as when Windows credentials are used to authenticate, the environment automatically establishes the actual credential value and you do not need to explicitly set the credential value (unless you want to specify a different set of credentials).  
  
 All service credentials are found as child elements of the [\<serviceBehaviors>](../../configure-apps/file-schema/wcf/servicebehaviors.md). The following example shows a certificate used as a service credential.  
  
```xml  
<configuration>  
 <system.serviceModel>  
  <behaviors>  
   <serviceBehaviors>  
    <behavior name="ServiceBehavior1">  
     <serviceCredentials>  
      <serviceCertificate findValue="000000000000000000000000000"
                          storeLocation="CurrentUser"  
      storeName="Root" x509FindType="FindByThumbprint" />  
     </serviceCredentials>  
    </behavior>  
   </serviceBehaviors>  
  </behaviors>  
 </system.serviceModel>  
</configuration>  
```  
  
## Service Credentials  

 The [\<serviceCredentials>](../../configure-apps/file-schema/wcf/servicecredentials.md) contains four child elements. The elements and their usages are discussed in the following sections.  
  
### \<serviceCertificate> Element  

 Use this element to specify an X.509 certificate that is used to authenticate the service to clients using Message security mode. If you are using a certificate that is periodically renewed, then its thumbprint changes. In that case, use the subject name as the `X509FindType` because the certificate can be reissued with the same subject name.  
  
 For more information about using the element, see [How to: Specify Client Credential Values](../how-to-specify-client-credential-values.md).  
  
### \<certificate> of \<clientCertificate> Element  

 Use the [\<certificate>](../../configure-apps/file-schema/wcf/certificate-of-clientcertificate-element.md) element when the service must have the client's certificate in advance to communicate securely with the client. This occurs when using the duplex communication pattern. In the more typical request-reply pattern, the client includes its certificate in the request, which the service uses to secure its response back to the client. The duplex communication pattern, however, has no requests and replies. The service cannot infer the client's certificate from the communication and therefore the service requires the client's certificate in advance to secure the messages to the client. You must obtain the client's certificate in an out-of-band manner and specify the certificate using this element. For more information about duplex services, see [How to: Create a Duplex Contract](how-to-create-a-duplex-contract.md).  
  
### \<authentication> of \<clientCertificate> Element  

 The [\<authentication>](../../configure-apps/file-schema/wcf/authentication-of-clientcertificate-element.md) element enables you to customize how clients are authenticated. You can set the `CertificateValidationMode` attribute to `None`, `ChainTrust`, `PeerOrChainTrust`, `PeerTrust`, or `Custom`. By default, the level is set to `ChainTrust`, which specifies that each certificate must be found in a hierarchy of certificates ending in a *root authority* at the top of the chain. This is the most secure mode. You can also set the value to `PeerOrChainTrust`, which specifies that self-issued certificates (peer trust) are accepted as well as certificates that are in a trusted chain. This value is used when developing and debugging clients and services because self-issued certificates need not be purchased from a trusted authority. When deploying a client, use the `ChainTrust` value instead. You can also set the value to `Custom`. When set to the `Custom` value, you must also set the `CustomCertificateValidatorType` attribute to an assembly and type used to validate the certificate. To create your own custom validator, you must inherit from the abstract <xref:System.IdentityModel.Selectors.X509CertificateValidator> class.  
  
### \<issuedTokenAuthentication> Element  

 The issued token scenario has three stages. In the first stage, a client trying to access a service is referred to a *secure token service* (STS). The STS then authenticates the client and subsequently issues the client a token, typically a Security Assertions Markup Language (SAML) token. The client then returns to the service with the token. The service examines the token for data that allows the service to authenticate the token and therefore the client. To authenticate the token, the certificate that the secure token service uses must be known to the service. The [\<issuedTokenAuthentication>](../../configure-apps/file-schema/wcf/issuedtokenauthentication-of-servicecredentials.md) element is the repository for any such secure token service certificates. To add certificates, use the [\<knownCertificates>](../../configure-apps/file-schema/wcf/knowncertificates.md). Insert an [\<add>](../../configure-apps/file-schema/wcf/add-of-knowncertificates.md) for each certificate, as shown in the following example.  
  
```xml  
<issuedTokenAuthentication>  
   <knownCertificates>  
      <add findValue="www.contoso.com"
           storeLocation="LocalMachine" storeName="My"
           X509FindType="FindBySubjectName" />  
    </knownCertificates>  
</issuedTokenAuthentication>  
```  
  
 By default, the certificates must be obtained from a secure token service. These "known" certificates ensure that only legitimate clients can access a service.  
  
 You should use the [\<allowedAudienceUris>](../../configure-apps/file-schema/wcf/allowedaudienceuris.md) collection in a federated application that utilizes a *secure token service* (STS) that issues `SamlSecurityToken` security tokens. When the STS issues the security token, it can specify the URI of the Web services for which the security token is intended by adding a `SamlAudienceRestrictionCondition` to the security token. That allows the `SamlSecurityTokenAuthenticator` for the recipient Web service to verify that the issued security token is intended for this Web service by specifying that this check should happen by doing the following:  
  
- Set the `audienceUriMode` attribute of [\<issuedTokenAuthentication>](../../configure-apps/file-schema/wcf/issuedtokenauthentication-of-servicecredentials.md) to `Always` or `BearerKeyOnly`.  
  
- Specify the set of valid URIs, by adding the URIs to this collection. To do this, insert an [\<add>](../../configure-apps/file-schema/wcf/add-of-allowedaudienceuris.md) for each URI  
  
 For more information, see <xref:System.IdentityModel.Selectors.SamlSecurityTokenAuthenticator>.  
  
 For more information about using this configuration element, see [How to: Configure Credentials on a Federation Service](how-to-configure-credentials-on-a-federation-service.md).  
  
#### Allowing Anonymous CardSpace Users  

 Setting the `AllowUntrustedRsaIssuers` attribute of the `<IssuedTokenAuthentication>` element to `true` explicitly allows any client to present a self-issued token signed with an arbitrary RSA key pair. The issuer is *untrusted* because the key has no issuer data associated with it. A CardSpace user can create a self-issued card that includes self-provided claims of identity. Use this capability with caution. To use this feature, think of the RSA public key as a more secure password that should be stored in a database along with a user name. Before allowing a client access to the service, verify the client-presented RSA public key by comparing it with the stored public key for the presented user name. This presumes that you have established a registration process whereby users can register their user names and associate them with the self-issued RSA public keys.  
  
## Client Credentials  

 Client credentials are used to authenticate the client to services in cases where mutual authentication is required. You can use the section to specify service certificates for scenarios where the client must secure messages to a service with the service's certificate.  
  
 You can also configure a client as part of a federation scenario to use issued tokens from a secure token service or a local issuer of tokens. For more information about federated scenarios, see [Federation and Issued Tokens](federation-and-issued-tokens.md). All client credentials are found under the [\<endpointBehaviors>](../../configure-apps/file-schema/wcf/endpointbehaviors.md), as shown in the following code.  
  
```xml  
<behaviors>  
 <endpointBehaviors>  
  <behavior name="EndpointBehavior1">  
   <clientCredentials>  
    <clientCertificate findValue="cn=www.contoso.com"
        storeLocation="LocalMachine"  
        storeName="AuthRoot" x509FindType="FindBySubjectName" />  
    <serviceCertificate>  
     <defaultCertificate findValue="www.cohowinery.com"
                    storeLocation="LocalMachine"  
                    storeName="Root" x509FindType="FindByIssuerName" />  
    <authentication revocationMode="Online"  
                    trustedStoreLocation="LocalMachine" />  
    </serviceCertificate>  
   </clientCredentials>  
  </behavior>  
 </endpointBehaviors>  
</behaviors>  
```  
  
#### \<clientCertificate> Element  

 Set the certificate used to authenticate the client with this element. For more information, see [How to: Specify Client Credential Values](../how-to-specify-client-credential-values.md).  
  
#### \<httpDigest>  

 This feature must be enabled with Active Directory on Windows and Internet Information Services (IIS). For more information, see [Digest Authentication in IIS 6.0](/previous-versions/windows/it-pro/windows-server-2003/cc782661(v=ws.10)).  
  
#### \<issuedToken> Element  

 The [\<issuedToken>](../../configure-apps/file-schema/wcf/issuedtoken.md) contains the elements used to configure a local issuer of tokens, or behaviors used with an security token service. For instructions on configuring a client to use a local issuer, see [How to: Configure a Local Issuer](how-to-configure-a-local-issuer.md).  
  
#### \<localIssuerAddress>  

 Specifies a default security token service address. This is used when the <xref:System.ServiceModel.WSFederationHttpBinding> does not supply a URL for the security token service, or when the issuer address of a federated binding is `http://schemas.microsoft.com/2005/12/ServiceModel/Addressing/Anonymous` or `null`. In such cases, the <xref:System.ServiceModel.Description.ClientCredentials> must be configured with the address of the local issuer and the binding to use to communicate with that issuer.  
  
#### \<issuerChannelBehaviors>  

 Use the [\<issuerChannelBehaviors>](../../configure-apps/file-schema/wcf/issuerchannelbehaviors-element.md) to add WCF client behaviors used when communicating with a security token service. Define client behaviors in the [\<endpointBehaviors>](../../configure-apps/file-schema/wcf/endpointbehaviors.md) section. To use a defined behavior, add an <`add`> element to the `<issuerChannelBehaviors>` element with two attributes. Set the `issuerAddress` to the URL of the security token service and set the `behaviorConfiguration` attribute to the name of the defined endpoint behavior, as shown in the following example.  
  
```xml  
<clientCredentials>  
   <issuedToken>  
      <issuerChannelBehaviors>  
         <add issuerAddress="http://www.contoso.com"  
               behaviorConfiguration="clientBehavior1" />
      </issuerChannelBehaviors>  
   </issuedToken>  
</clientCredentials>
```  
  
#### \<serviceCertificate> Element  

 Use this element to control authentication of service certificates.  
  
 The [\<defaultCertificate>](../../configure-apps/file-schema/wcf/defaultcertificate-element.md) element can store a single certificate used when the service specifies no certificate.  
  
 Use the [\<scopedCertificates>](../../configure-apps/file-schema/wcf/scopedcertificates-element.md) and [\<add>](../../configure-apps/file-schema/wcf/add-of-scopedcertificates-element.md) to set service certificates that are associated with specific services. The `<add>` element includes a `targetUri` attribute that is used to associate the certificate with the service.  
  
 The [\<authentication>](../../configure-apps/file-schema/wcf/authentication-of-servicecertificate-element.md) element specifies the level of trust used to authenticate certificates. By default, the level is set to "ChainTrust," which specifies that each certificate must be found in a hierarchy of certificates ending in a trusted certification authority at the top of the chain. This is the most secure mode. You can also set the value to "PeerOrChainTrust", which specifies that self-issued certificates (peer trust) are accepted, as well as certificates that are in a trusted chain. This value is used when developing and debugging clients and services because self-issued certificates need not be purchased from a trusted authority. When deploying a client, use the "ChainTrust" value instead. You can also set the value to "Custom" or "None." To use the "Custom" value, you must also set the `CustomCertificateValidatorType` attribute to an assembly and type used to validate the certificate. To create your own custom validator, you must inherit from the abstract <xref:System.IdentityModel.Selectors.X509CertificateValidator> class. For more information, see [How to: Create a Service that Employs a Custom Certificate Validator](../extending/how-to-create-a-service-that-employs-a-custom-certificate-validator.md).  
  
 The [\<authentication>](../../configure-apps/file-schema/wcf/authentication-of-servicecertificate-element.md) element includes a `RevocationMode` attribute that specifies how certificates are checked for revocation. The default is "online", which indicates that certificates are automatically checked for revocation. For more information, see [Working with Certificates](working-with-certificates.md).  
  
## ServiceAuthorization  

 The [\<serviceAuthorization>](../../configure-apps/file-schema/wcf/serviceauthorization-element.md) element contains elements that affect authorization, custom role providers, and impersonation.  
  
 The <xref:System.Security.Permissions.PrincipalPermissionAttribute> class is applied to a service method. The attribute specifies the groups of users to use when authorizing use of a protected method. The default value is "UseWindowsGroups" and specifies that Windows groups, such as "Administrators" or "Users," are searched for an identity trying to access a resource. You can also specify "UseAspNetRoles" to use a custom role provider that is configured under the <`system.web` > element, as shown in the following code.  
  
```xml  
<system.web>  
  <membership defaultProvider="SqlProvider"
   userIsOnlineTimeWindow="15">  
     <providers>  
       <clear />  
       <add
          name="SqlProvider"
          type="System.Web.Security.SqlMembershipProvider"
          connectionStringName="SqlConn"  
          applicationName="MembershipProvider"  
          enablePasswordRetrieval="false"  
          enablePasswordReset="false"  
          requiresQuestionAndAnswer="false"  
          requiresUniqueEmail="true"  
          passwordFormat="Hashed" />  
     </providers>  
   </membership>  
  <!-- Other configuration code not shown.-->  
</system.web>  
```  
  
 The following code shows the `roleProviderName` used with the `principalPermissionMode` attribute.  
  
```xml  
<behaviors>  
 <behavior name="ServiceBehaviour">
  <serviceAuthorization principalPermissionMode ="UseAspNetRoles"
                        roleProviderName ="SqlProvider" />  
</behavior>
   <!-- Other configuration code not shown. -->  
</behaviors>  
```  
  
## Configuring Security Audits  

 Use the [\<serviceSecurityAudit>](../../configure-apps/file-schema/wcf/servicesecurityaudit.md) to specify the log written to, and what types of events to log. For more information, see [Auditing](auditing-security-events.md).  
  
```xml  
<behaviors>
 <serviceBehaviors>  
  <behavior name="NewBehavior">  
    <serviceSecurityAudit auditLogLocation="Application"
             suppressAuditFailure="true"  
             serviceAuthorizationAuditLevel="Success"
             messageAuthenticationAuditLevel="Success" />  
  </behavior>  
 </serviceBehaviors>  
</behaviors>  
```  
  
## Secure Metadata Exchange  

 Exporting metadata to clients is convenient for service and client developers, as it enables downloads of configuration and client code. To reduce the exposure of a service to malicious users, it is possible to secure the transfer using the SSL over HTTP (HTTPS) mechanism. To do so, you must first bind a suitable X.509 certificate to a specific port on the computer that is hosting the service. (For more information, see [Working with Certificates](working-with-certificates.md).) Second, add a [\<serviceMetadata>](../../configure-apps/file-schema/wcf/servicemetadata.md) to the service configuration and set the `HttpsGetEnabled` attribute to `true`. Finally, set the `HttpsGetUrl` attribute to the URL of the service metadata endpoint, as shown in the following example.  
  
```xml  
<behaviors>  
 <serviceBehaviors>  
  <behavior name="NewBehavior">  
    <serviceMetadata httpsGetEnabled="true"
     httpsGetUrl="https://myComputerName/myEndpoint" />  
  </behavior>  
 </serviceBehaviors>  
</behaviors>  
```  
  
## See also

- [Auditing](auditing-security-events.md)
- [Security Model for Windows Server App Fabric](/previous-versions/appfabric/ee677202(v=azure.10))
