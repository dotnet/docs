---
title: "Unsupported Scenarios"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 72027d0f-146d-40c5-9d72-e94392c8bb40
caps.latest.revision: 43
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Unsupported Scenarios
For various reasons, [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] does not support some specific security scenarios. For example, [!INCLUDE[wxp](../../../../includes/wxp-md.md)] Home Edition does not implement the SSPI or Kerberos authentication protocols, and therefore [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not support running a service with Windows authentication on that platform. Other authentication mechanisms, such as username/password and HTTP/HTTPS integrated authentication are supported when running [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] under Windows XP Home Edition.  
  
## Impersonation Scenarios  
  
### Impersonated Identity Might Not Flow When Clients Make Asynchronous Calls  
 When a WCF client makes asynchronous calls to a WCF service using Windows authentication under impersonation, authentication might occur with the identity of the client process instead of the impersonated identity.  
  
### Windows XP and Secure Context Token Cookie Enabled  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not support impersonation and an <xref:System.InvalidOperationException> is thrown when the following conditions exist:  
  
-   The operating system is [!INCLUDE[wxp](../../../../includes/wxp-md.md)].  
  
-   The authentication mode results in a Windows identity.  
  
-   The <xref:System.ServiceModel.OperationBehaviorAttribute.Impersonation%2A> property of the <xref:System.ServiceModel.OperationBehaviorAttribute> is set to <xref:System.ServiceModel.ImpersonationOption.Required>.  
  
-   A state-based security context token (SCT) is created (by default, creation is disabled).  
  
 The state-based SCT can only be created using a custom binding. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [How to: Create a Security Context Token for a Secure Session](../../../../docs/framework/wcf/feature-details/how-to-create-a-security-context-token-for-a-secure-session.md).) In code, the token is enabled by creating a security binding element (either <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement> or <xref:System.ServiceModel.Channels.AsymmetricSecurityBindingElement>) using the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateSspiNegotiationBindingElement%28System.Boolean%29?displayProperty=nameWithType> or the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateSecureConversationBindingElement%28System.ServiceModel.Channels.SecurityBindingElement%2CSystem.Boolean%29?displayProperty=nameWithType> method and setting the `requireCancellation` parameter to `false`. The parameter refers to the caching of the SCT. Setting the value to `false` enables the state-based SCT feature.  
  
 Alternatively, in configuration, the token is enabled by creating a <`customBinding`>, then adding a <`security`> element, and setting the `authenticationMode` attribute to SecureConversation and the `requireSecurityContextCancellation` attribute to `true`.  
  
> [!NOTE]
>  The preceding requirements are specific. For example, the <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateKerberosBindingElement%2A> creates a binding element that results in a Windows identity, but does not establish an SCT. Therefore, you can use it with the `Required` option on [!INCLUDE[wxp](../../../../includes/wxp-md.md)].  
  
### Possible ASP.NET Conflict  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] and [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] can both enable or disable impersonation. When [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] hosts an [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] application, a conflict may exist between the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] and [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] configuration settings. In case of conflict, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] setting takes precedence, unless the <xref:System.ServiceModel.OperationBehaviorAttribute.Impersonation%2A> property is set to <xref:System.ServiceModel.ImpersonationOption.NotAllowed>, in which case the [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] impersonation setting takes precedence.  
  
### Assembly Loads May Fail Under Impersonation  
 If the impersonated context does not have access rights to load an assembly and if it is the first time the common language runtime (CLR) is attempting to load the assembly for that AppDomain, the <xref:System.AppDomain> caches the failure. Subsequent attempts to load that assembly (or assemblies) fail, even after reverting the impersonation, and even if the reverted context has access rights to load the assembly. This is because the CLR does not re-attempt the load after the user context is changed. You must restart the application domain to recover from the failure.  
  
> [!NOTE]
>  The default value for the <xref:System.ServiceModel.Security.WindowsClientCredential.AllowedImpersonationLevel%2A> property of the <xref:System.ServiceModel.Security.WindowsClientCredential> class is <xref:System.Security.Principal.TokenImpersonationLevel.Identification>. In most cases, an identification-level impersonation context has no rights to load any additional assemblies. This is the default value, so this is a very common condition to be aware of. Identification-level impersonation also occurs when the impersonating process does not have the `SeImpersonate` privilege. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Delegation and Impersonation](../../../../docs/framework/wcf/feature-details/delegation-and-impersonation-with-wcf.md).  
  
### Delegation Requires Credential Negotiation  
 To use the Kerberos authentication protocol with delegation, you must implement the Kerberos protocol with credential negotiation (sometimes called multi-leg or multi-step Kerberos). If you implement Kerberos authentication without credential negotiation (sometimes called one-shot or single-leg Kerberos), an exception is thrown. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] how to implement credential negotiation, see [Debugging Windows Authentication Errors](../../../../docs/framework/wcf/feature-details/debugging-windows-authentication-errors.md).  
  
## Cryptography  
  
### SHA-256 Supported Only for Symmetric Key Usages  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports a variety of encryption and signature digest creation algorithms that you can specify using the algorithm suite in the system-provided bindings. For improved security, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports Secure Hash Algorithm (SHA) 2 algorithms, specifically SHA-256, for creating signature digest hashes. This release supports SHA-256 only for symmetric key usages, such as Kerberos keys, and where an X.509 certificate is not used to sign the message. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not support RSA signatures (used in X.509 certificates) using SHA-256 hash due to the current lack of support for RSA-SHA256 in the [!INCLUDE[vstecwinfx](../../../../includes/vstecwinfx-md.md)].  
  
### FIPS-Compliant SHA-256 Hashes not Supported  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not support SHA-256 FIPS-compliant hashes, so algorithm suites that use SHA-256 are not supported by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] on systems where use of FIPS compliant algorithms is required.  
  
### FIPS-Compliant Algorithms May Fail if Registry Is Edited  
 You can enable and disable Federal Information Processing Standards (FIPS)-compliant algorithms by using the Local Security Settings Microsoft Management Console (MMC) snap-in. You can also access the setting in the registry. Note, however, that [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not support using the registry to reset the setting. If the value is set to anything other than 1 or 0, inconsistent results can occur between the CLR and the operating system.  
  
### FIPS-Compliant AES Encryption Limitation  
 FIPS compliant AES encryption does not work in duplex callbacks under identification level impersonation.  
  
### CNG/KSP Certificates  
 *Cryptography API: Next Generation (CNG)* is the long-term replacement for the CryptoAPI. This API is available in unmanaged code on [!INCLUDE[wv](../../../../includes/wv-md.md)],  [!INCLUDE[lserver](../../../../includes/lserver-md.md)] and later Windows versions.  
  
 .NET Framework 4.6.1 and earlier versions do not support these certificates because they use the legacy CryptoAPI to handle CNG/KSP certificates. The use of these certificates with   .NET Framework 4.6.1 and earlier versions will cause an exception.  
  
 There are two possible ways to tell if a certificate uses KSP:  
  
-   Do a `p/invoke` of `CertGetCertificateContextProperty`, and inspect `dwProvType` on the returned `CertGetCertificateContextProperty`.  
  
-   Use the  `certutil` command from the command line for querying certificates. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Certutil tasks for troubleshooting certificates](http://go.microsoft.com/fwlink/?LinkId=120056).  
  
## Message Security Fails if Using ASP.NET Impersonation and ASP.NET Compatibility Is Required  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not support the following combination of settings because they can prevent client authentication from occurring:  
  
-   [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] Impersonation is enabled. This is done in the Web.config file by setting the `impersonate` attribute of the <`identity`> element to `true`.  
  
-   [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] compatibility mode is enabled by setting the `aspNetCompatibilityEnabled` attribute of the [\<serviceHostingEnvironment>](../../../../docs/framework/configure-apps/file-schema/wcf/servicehostingenvironment.md) to `true`.  
  
-   Message mode security is used.  
  
 The work-around is to turn off the [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] compatibility mode. Or, if the [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] compatibility mode is required, disable the [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] impersonation feature and use [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]-provided impersonation instead. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Delegation and Impersonation](../../../../docs/framework/wcf/feature-details/delegation-and-impersonation-with-wcf.md).  
  
## IPv6 Literal Address Failure  
 Security requests fail when the client and service are on the same machine, and IPv6 literal addresses are used for the service.  
  
 Literal IPv6 addresses work if the service and client are on different machines.  
  
## WSDL Retrieval Failures with Federated Trust  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] requires exactly one WSDL document for each node in the federated trust chain. Be careful not to set up a loop when specifying endpoints. One way in which loops can arise is using a WSDL download of federated trust chains with two or more links in the same WSDL document. A common scenario that can produce this problem is a federated service where the Security Token Server and the service are contained inside the same ServiceHost.  
  
 An example of this situation is a service with the following three endpoint addresses:  
  
-   http://localhost/CalculatorService/service (the service)  
  
-   http://localhost/CalculatorService/issue_ticket (the STS)  
  
-   http://localhost/CalculatorService/mex (the metadata endpoint)  
  
 This throws an exception.  
  
 You can make this scenario work by putting the `issue_ticket` endpoint elsewhere.  
  
## WSDL Import Attributes can be Lost  
 WCF loses track of the attributes on a `<wst:Claims>` element in an `RST` template when doing a WSDL import. This happens during a WSDL import if you specify `<Claims>` directly in `WSFederationHttpBinding.Security.Message.TokenRequestParameters` or `IssuedSecurityTokenRequestParameters.AdditionalRequestParameters` instead of using the claim type collections directly.  Since the import loses the attributes, the binding does not round trip properly through WSDL and hence is incorrect on the client side.  
  
 The fix is to modify the binding directly on the client after doing the import.  
  
## See Also  
 [Security Considerations](../../../../docs/framework/wcf/feature-details/security-considerations-in-wcf.md)  
 [Information Disclosure](../../../../docs/framework/wcf/feature-details/information-disclosure.md)  
 [Elevation of Privilege](../../../../docs/framework/wcf/feature-details/elevation-of-privilege.md)  
 [Denial of Service](../../../../docs/framework/wcf/feature-details/denial-of-service.md)  
 [Tampering](../../../../docs/framework/wcf/feature-details/tampering.md)  
 [Replay Attacks](../../../../docs/framework/wcf/feature-details/replay-attacks.md)
