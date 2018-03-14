---
title: "&lt;federationConfiguration&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8b14054c-6d07-46ab-ab58-03f14beac0f2
caps.latest.revision: 9
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# &lt;federationConfiguration&gt;
Configures the <xref:System.IdentityModel.Services.WSFederationAuthenticationModule> (WSFAM) and the <xref:System.IdentityModel.Services.SessionAuthenticationModule> (SAM) when using federated authentication through the WS-Federation protocol. Configures the <xref:System.Security.Claims.ClaimsAuthorizationManager> when using the <xref:System.IdentityModel.Services.ClaimsPrincipalPermission> or the <xref:System.IdentityModel.Services.ClaimsPrincipalPermissionAttribute> class to provide claims-based access control.  
  
 \<system.identityModel.services>  
\<federationConfiguration>  
  
## Syntax  
  
```xml  
<system.identityModel.services>  
  <federationConfiguration name=xs:string identityConfigurationName=xs:string>  
  </federationConfiguration>  
</system.identityModel.services>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|name|The name of this federation configuration element. This attribute primarily provides an extensibility point for future protocols. Optional.|  
|identityConfigurationName|The name of the identity configuration section as specified in an [\<identityConfiguration>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/identityconfiguration.md) element to use. If this attribute is not specified, the default identity configuration section is used. Optional.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<cookieHandler>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/cookiehandler.md)|Configures the cookie handler used by the SAM. Optional.|  
|[\<serviceCertificate>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/servicecertificate.md)|Configures the certificate that is used to encrypt and decrypt tokens. Optional.|  
|[\<wsFederation>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/wsfederation.md)|Configures the WS-Federation Authentication Module (WSFAM). Optional.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<system.identityModel.services>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/system-identitymodel-services.md)|Configuration section for authentication using the WS-Federation protocol.|  
  
## Remarks  
 The \<federationConfiguration> element provides settings in two different scenarios:  
  
-   When using WS-Federation in a passive Web application, the element contains settings that configure the <xref:System.IdentityModel.Services.WSFederationAuthenticationModule> (WSFAM) and the <xref:System.IdentityModel.Services.SessionAuthenticationModule> (SAM). It also references the identity configuration to be used to configure security token handlers and certificates, and components like the claims authorization manager and the claims authentication manager.  
  
-   When using the <xref:System.IdentityModel.Services.ClaimsPrincipalPermission> or the <xref:System.IdentityModel.Services.ClaimsPrincipalPermissionAttribute> class to provide claims-based access control in your code, the element references the identity configuration that configures the claims authorization manager and policy that is used to make authorization decisions. This is true, even in scenarios that are not passive Web scenarios; for example, Windows Communication Foundation (WCF) applications or an application that is not Web-based. If the application is not a passive Web application, the [\<claimsAuthorizationManager>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/claimsauthorizationmanager.md) element (and its child policy elements, if present) of the identity configuration referenced by the `<federationConfiguration>` element are the only settings applied. All others are ignored.  
  
 Regardless of the scenario, the runtime loads the default federation configuration. The behavior is defined as follows:  
  
1.  If there is no `<federationConfiguration>` element present, the runtime creates a federation configuration and populates it with default values. This default federation configuration will reference the default identity configuration.  
  
2.  If a single `<federationConfiguration>` element is present, it is the default federation configuration regardless of whether it is named or unnamed. If its `identityConfiguration` attribute is specified, the named identity configuration is referenced; otherwise, the default identity configuration is referenced.  
  
3.  If an unnamed `<federationConfiguration>` element is present, it is the default federation configuration. If its `identityConfiguration` attribute is specified, the named identity configuration is referenced; otherwise, the default identity configuration is referenced.  
  
4.  If multiple named `<federationConfiguration>` elements are present and no unnamed `<federationConfiguration>` element is present, an exception is thrown.  
  
 Typically, only a single `<federationConfiguration>` section is defined. This section is the default federation configuration. You may specify multiple, uniquely-named `<federationConfiguration>` elements; however, in this case, if you want to load a federation configuration other than the unnamed one, you must provide a handler for the. <xref:System.IdentityModel.Services.FederatedAuthentication.FederationConfigurationCreated> event and set the <xref:System.IdentityModel.Services.Configuration.FederationConfigurationCreatedEventArgs.FederationConfiguration%2A?displayProperty=nameWithType> property inside the handler to a <xref:System.IdentityModel.Services.Configuration.FederationConfiguration> object initialized with values from the appropriate `<federationConfiguration>` element in the configuration file.  
  
 The `<federationConfiguration>` element is represented by the <xref:System.IdentityModel.Services.Configuration.FederationConfigurationElement> class. The configuration object itself is represented by the <xref:System.IdentityModel.Services.Configuration.FederationConfiguration> class. A single <xref:System.IdentityModel.Services.Configuration.FederationConfiguration> instance is set on the <xref:System.IdentityModel.Services.FederatedAuthentication.FederationConfiguration%2A?displayProperty=nameWithType> property and provides federated configuration for the application.  
  
## Example  
 The following XML shows a `<federationConfiguration>` element that specifies settings for the WSFAM and specifies that the default cookie handler (an instance of the <xref:System.IdentityModel.Services.ChunkedCookieHandler> class) be used by the SAM.  
  
> [!WARNING]
>  In this example, neither the cookie handler nor WSFAM are required to use HTTPS. This is because the `requireHttps` attribute on the `<wsFederation>` element and the `requireSsl` attribute on the `<cookieHandlerElement>` are `false`. These settings are not recommended for most production environments as they may present a security risk.  
  
```xml  
<system.identityModel.services>  
  <federationConfiguration>  
    <wsFederation passiveRedirectEnabled="true"   
      issuer="http://localhost:15839/wsFederationSTS/Issue"   
      realm="http://localhost:50969/" reply="http://localhost:50969/"   
      requireHttps="false"   
      signOutReply="http://localhost:50969/SignedOutPage.html"   
      signOutQueryString="Param1=value2&Param2=value2"   
      persistentCookiesOnPassiveRedirects="true" />  
    <cookieHandler requireSsl="false" />  
  </federationConfiguration>  
</system.identityModel.services>  
```  
  
## See Also  
 <xref:System.IdentityModel.Services.WSFederationAuthenticationModule>  
 <xref:System.IdentityModel.Services.SessionAuthenticationModule>  
 <xref:System.IdentityModel.Services.FederatedAuthentication.FederationConfiguration%2A?displayProperty=nameWithType>  
 [\<identityConfiguration>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/identityconfiguration.md)
