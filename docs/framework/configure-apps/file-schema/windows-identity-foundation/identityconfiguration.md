---
title: "&lt;identityConfiguration&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1db76253-07da-447b-9e7a-3705c7228cf4
caps.latest.revision: 13
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# &lt;identityConfiguration&gt;
Specifies service-level identity settings.  
  
 \<system.identityModel>  
\<identityConfiguration>  
  
## Syntax  
  
```xml  
<system.identityModel>  
  <identityConfiguration  
      name=xs:string  
      saveBootstrapContext=xs:boolean>  
      maximumClockSkew=TimeSpan >  
  </identityConfiguration>  
</system.identityModel>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|name|The name of the identity configuration section. You can use this name to reference a specific configuration section. If no `name` attribute is specified, the section defines the default configuration. The default configuration is always used for passive federation scenarios. For more information, see the [\<federationConfiguration>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/federationconfiguration.md) element.|  
|saveBootstrapContext|Specifies whether bootstrap tokens should be included in the session token. The value may also be set on a token handler collection by setting the `saveBootstrapContext` attribute on the [\<securityTokenHandlerConfiguration>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/securitytokenhandlerconfiguration.md) element. A value set on the token handler collection overrides the value set on the service.|  
|maximumClockSkew|A <xref:System.TimeSpan> that specifies the maximum allowed clock skew. Controls the maximum allowed clock skew when performing time-sensitive operations, such as validating the expiration time of a sign-in session. The default is 5 minutes, "00:05:00". For more information about how to specify <xref:System.TimeSpan> values, see [Timespan Values](../../../../../docs/framework/configure-apps/file-schema/windows-workflow-foundation/index.md). The maximum clock skew may also be set on a token handler collection by setting the `maximumClockSkew` attribute on the [\<securityTokenHandlerConfiguration>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/securitytokenhandlerconfiguration.md) element. A value set on the token handler collection overrides the value set on the service.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<caches>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/caches.md)|Registers the caches used for session tokens and token replay detection. Can be specified at the service-level or on a security token handler collection. Optional.|  
|[\<certificateValidation>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/certificatevalidation.md)|Controls the settings that token handlers use to validate certificates. Can be specified at the service-level or on a security token handler collection. Optional.|  
|[\<claimsAuthenticationManager>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/claimsauthenticationmanager.md)|Registers a claims authentication manager for the incoming claims. Optional.|  
|[\<claimsAuthorizationManager>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/claimsauthorizationmanager.md)|Registers a claims authorization manager for the incoming claims. Optional.|  
|[\<claimTypeRequired>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/claimtyperequired.md)|Specifies the set of required claims for incoming security tokens. Optional.|  
|[\<securityTokenHandlers>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/securitytokenhandlers.md)|Specifies a collection of security token handlers. Zero or more collections of security token handlers can be specified. Optional.|  
|[\<tokenReplayDetection>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/tokenreplaydetection.md)|Enables token replay detection and specifies the expiration time for tokens. Can be specified at the service-level or on a security token handler collection. Optional.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<system.identityModel>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/system-identitymodel.md)|Provides configuration for enabling Windows Identity Foundation (WIF) options in applications.|  
  
## Remarks  
 Multiple identity configurations may be defined, each with a unique name. The behavior is as follows:  
  
1.  If no `<identityConfiguration>` element is specified. A default identity configuration is created at runtime and populated with default values.  
  
2.  If a single `<identityConfiguration>` element is specified. It is the default identity configuration. It does not matter whether it is named or unnamed.  
  
3.  If multiple `<identityConfiguration>` elements are specified. The unnamed element specifies the default identity configuration. It is recommended that when you specify multiple `<identityConfiguration>` elements, one of them should be unnamed.  
  
> [!WARNING]
>  If you specify multiple `<identityConfiguration>` elements, one of them should be unnamed. The unnamed element will be the default identity configuration.  
  
 Some of the settings specified in the `<identityConfiguration>` element can be overridden by settings on a security token handler collection or by settings on individual security token handlers.  
  
> [!IMPORTANT]
>  When using the <xref:System.IdentityModel.Services.ClaimsPrincipalPermission> or the <xref:System.IdentityModel.Services.ClaimsPrincipalPermissionAttribute> class to provide claims-based access control in your code, the identity configuration that is referenced by the `<federationConfiguration>` element configures the claims authorization manager and policy that is used to make authorization decisions. This is true, even in scenarios that are not passive Web scenarios, for example Windows Communication Foundation (WCF) applications or an application that is not Web-based. If the application is not a passive Web application, the [\<claimsAuthorizationManager>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/claimsauthorizationmanager.md) element (and its child policy elements, if present) of the referenced identity configuration are the only settings applied. All other settings are ignored. For more information, see the [\<federationConfiguration>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/federationconfiguration.md) element.  
  
 The `<identityConfiguration>` element is represented by the <xref:System.IdentityModel.Configuration.IdentityConfigurationElement> class. An identity configuration section is represented by the <xref:System.IdentityModel.Configuration.IdentityConfiguration> class.  
  
> [!IMPORTANT]
>  Specifying the following elements as child elements of the `<identityConfiguration>` element has been deprecated, although the behavior is still supported for backward compatibility. These elements should, instead, be specified under the [\<securityTokenHandlerConfiguration>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/securitytokenhandlerconfiguration.md) element.  
>   
>  -   [\<audienceUris>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/audienceuris.md)  
> -   [\<issuerNameRegistry>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/issuernameregistry.md)  
> -   [\<issuerTokenResolver>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/issuertokenresolver.md)  
> -   [\<serviceTokenResolver>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/servicetokenresolver.md)  
  
## Example  
 The following example creates an identity configuration named "alternateConfiguration". The identity configuration specifies default settings.  
  
```xml  
<system.identityModel>  
    <identityConfiguration name="alternateConfiguration"/>  
</system.identityModel>  
```  
  
## See Also  
 <xref:System.IdentityModel.Configuration.IdentityConfiguration>  
 <xref:System.IdentityModel.Configuration.IdentityConfigurationElement>
