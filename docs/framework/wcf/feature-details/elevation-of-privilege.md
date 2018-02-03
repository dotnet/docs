---
title: "Elevation of Privilege"
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
  - "elevation of privilege [WCF]"
  - "security [WCF], elevation of privilege"
ms.assetid: 146e1c66-2a76-4ed3-98a5-fd77851a06d9
caps.latest.revision: 16
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Elevation of Privilege
*Elevation of privilege* results from giving an attacker authorization permissions beyond those initially granted. For example, an attacker with a privilege set of "read only" permissions somehow elevates the set to include "read and write."  
  
## Trusted STS Should Sign SAML Token Claims  
 A Security Assertions Markup Language (SAML) token is a generic XML token that is the default type for issued tokens. A SAML token can be constructed by a Security Token Service (STS) that the end Web service trusts in a typical exchange. SAML tokens contain claims in statements. An attacker may copy the claims from a valid token, create a new SAML token, and sign it with a different issuer. The intent is to determine whether the server is validating issuers and, if not, utilize the weakness to construct SAML tokens that allow privileges beyond those intended by a trusted STS.  
  
 The <xref:System.IdentityModel.Tokens.SamlAssertion> class verifies the digital signature contained within a SAML token, and the default <xref:System.IdentityModel.Selectors.SamlSecurityTokenAuthenticator> requires that SAML tokens be signed by an X.509 certificate that is valid when the <xref:System.ServiceModel.Security.IssuedTokenServiceCredential.CertificateValidationMode%2A> of the <xref:System.ServiceModel.Security.IssuedTokenServiceCredential> class is set to <xref:System.ServiceModel.Security.X509CertificateValidationMode.ChainTrust>. `ChainTrust` mode alone is insufficient to determine whether the issuer of the SAML token is trusted. Services that require a more granular trust model can either use authorization and enforcement policies to check the issuer of the claim sets produced by issued token authentication or use the X.509 validation settings on <xref:System.ServiceModel.Security.IssuedTokenServiceCredential> to restrict the set of allowed signing certificates. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Managing Claims and Authorization with the Identity Model](../../../../docs/framework/wcf/feature-details/managing-claims-and-authorization-with-the-identity-model.md) and [Federation and Issued Tokens](../../../../docs/framework/wcf/feature-details/federation-and-issued-tokens.md).  
  
## Switching Identity Without a Security Context  
 The following applies only to [!INCLUDE[vstecwinfx](../../../../includes/vstecwinfx-md.md)].  
  
 When a connection is established between a client and server, the identity of the client does not change, except in one situation: after the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client is opened, if all of the following conditions are true:  
  
-   The procedures to establish a security context (using a transport security session or message security session) is switched off (<xref:System.ServiceModel.NonDualMessageSecurityOverHttp.EstablishSecurityContext%2A> property is set to `false` in case of message security or transport not capable of establishing security sessions is used in transport security case. HTTPS is one example of such transport).  
  
-   You are using Windows authentication.  
  
-   You do not explicitly set the credential.  
  
-   You are calling the service under the impersonated security context.  
  
 If these conditions are true, the identity used to authenticate the client to the service might change (it might not be the impersonated identity but the process identity instead) after the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client is opened. This occurs because the Windows credential used to authenticate the client to the service is transmitted with every message, and the credential used for authentication is obtained from the current thread's Windows identity. If the Windows identity of the current thread changes (for example, by impersonating a different caller), the credential that is attached to the message and used to authenticate the client to the service might also change.  
  
 If you want to have deterministic behavior when using Windows authentication together with impersonation you need to explicitly set the Windows credential or you need to establish a security context with the service. To do this, use a message security session or a transport security session. For example, the net.tcp transport can provide a transport security session. Additionally, you must use only a synchronous version of client operations when calling the service. If you establish a message security context, you should not keep the connection to the service open longer than the configured session renewal period, because the identity can also change during the session renewal process.  
  
### Credentials Capture  
 The following applies to [!INCLUDE[netfx35_long](../../../../includes/netfx35-long-md.md)], and subsequent versions.  
  
 Credentials used by the client or the service are based on the current context thread. The credentials are obtained when the `Open` method (or `BeginOpen`, for asynchronous calls) of the client or service is called. For both the <xref:System.ServiceModel.ServiceHost> and <xref:System.ServiceModel.ClientBase%601> classes, the `Open` and `BeginOpen` methods inherit from the <xref:System.ServiceModel.Channels.CommunicationObject.Open%2A> and <xref:System.ServiceModel.Channels.CommunicationObject.BeginOpen%2A> methods of the <xref:System.ServiceModel.Channels.CommunicationObject> class.  
  
> [!NOTE]
>  When using the `BeginOpen` method, the credentials captured cannot be guaranteed to be the credentials of the process that calls the method.  
  
## Token Caches Allow Replay Using Obsolete Data  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses the local security authority (LSA) `LogonUser` function to authenticate users by user name and password. Because the logon function is a costly operation, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] allows you to cache tokens that represent authenticated users to increase performance. The caching mechanism saves the results from `LogonUser` for subsequent uses. This mechanism is disabled by default; to enable it, set the <xref:System.ServiceModel.Security.UserNamePasswordServiceCredential.CacheLogonTokens%2A> property to `true`, or use the `cacheLogonTokens` attribute of the [\<userNameAuthentication>](../../../../docs/framework/configure-apps/file-schema/wcf/usernameauthentication.md).  
  
 You can set a Time to Live (TTL) for the cached tokens by setting the <xref:System.ServiceModel.Security.UserNamePasswordServiceCredential.CachedLogonTokenLifetime%2A> property to a <xref:System.TimeSpan>, or use the `cachedLogonTokenLifetime` attribute of the `userNameAuthentication` element; the default is 15 minutes. Note that while a token is cached, any client that presents the same user name and password can use the token, even if the user account is deleted from Windows or if its password has been changed. Until the TTL expires and the token is removed from the cache, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] allows the (possibly malicious) user to authenticate.  
  
 To mitigate this: Decrease the attack window by setting the `cachedLogonTokenLifetime` value to the shortest time span your users need.  
  
## Issued Token Authorization: Expiration Reset to Large Value  
 Under certain conditions, the <xref:System.IdentityModel.Policy.AuthorizationContext.ExpirationTime%2A> property of the <xref:System.IdentityModel.Policy.AuthorizationContext> may be set to an unexpectedly larger value (the <xref:System.DateTime.MaxValue> field value minus one day, or December 20, 9999).  
  
 This occurs when using the <xref:System.ServiceModel.WSFederationHttpBinding> and any of the system-provided bindings that have an issued token as the client credential type.  
  
 This also occurs when you create custom bindings by using one of the following methods:  
  
-   <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateIssuedTokenBindingElement%2A>  
  
-   <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateIssuedTokenForCertificateBindingElement%2A>  
  
-   <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateIssuedTokenForSslBindingElement%2A>  
  
-   <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateIssuedTokenOverTransportBindingElement%2A>  
  
 To mitigate this, the authorization policy must check the action and the expiration time of each authorization policy.  
  
## The Service Uses a Different Certificate Than the Client Intended  
 Under certain conditions, a client can digitally sign a message with an X.509 certificate and have the service retrieve a different certificate than the intended one.  
  
 This can occur under the following circumstances:  
  
-   The client digitally signs a message using an X.509 certificate and does not attach the X.509 certificate to the message, but rather just references the certificate using its subject key identifier.  
  
-   The service's computer contains two or more certificates with the same public key, but they contain different information.  
  
-   The service retrieves a certificate that matches the subject key identifier, but it is not the one the client intended to use. When [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] receives the message and verifies the signature, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] maps the information in the unintended X.509 certificate to a set of claims that are different and potentially elevated from what the client expected.  
  
 To mitigate this, reference the X.509 certificate another way, such as using <xref:System.ServiceModel.Security.Tokens.X509KeyIdentifierClauseType.IssuerSerial>.  
  
## See Also  
 [Security Considerations](../../../../docs/framework/wcf/feature-details/security-considerations-in-wcf.md)  
 [Information Disclosure](../../../../docs/framework/wcf/feature-details/information-disclosure.md)  
 [Denial of Service](../../../../docs/framework/wcf/feature-details/denial-of-service.md)  
 [Replay Attacks](../../../../docs/framework/wcf/feature-details/replay-attacks.md)  
 [Tampering](../../../../docs/framework/wcf/feature-details/tampering.md)  
 [Unsupported Scenarios](../../../../docs/framework/wcf/feature-details/unsupported-scenarios.md)
