---
title: "<securityTokenHandlerConfiguration>"
ms.date: "03/30/2017"
ms.assetid: 28724cc6-020c-4a06-9a1f-d7594f315019
author: "BrucePerlerMS"
---
# \<securityTokenHandlerConfiguration>
Provides configuration for the collection of token handlers.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.identityModel>**](system-identitymodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<identityConfiguration>**](identityconfiguration.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<securityTokenHandlers>**](securitytokenhandlers.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<securityTokenHandlerConfiguration>**  
  
## Syntax  
  
```xml  
<system.identityModel>  
  <identityConfiguration>  
    <securityTokenHandlers>  
      <securityTokenHandlerConfiguration saveBootstrapContext=xs:boolean  
          maximumClockSkew=TimeSpan>  
      </securityTokenHandlerConfiguration>  
    </securityTokenHandlers>  
  </identityConfiguration>  
</system.identityModel>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|saveBootstrapContext|Specifies whether bootstrap tokens should be included in the session token. The value may also be set on a token handler collection by setting the `saveBootstrapContext` attribute on the [\<identityConfiguration>](identityconfiguration.md) element. A value set on the token handler collection overrides the value set on the service.|  
|maximumClockSkew|A <xref:System.TimeSpan> that specifies the maximum allowed clock skew. Controls the maximum allowed clock skew when performing time-sensitive operations, such as validating the expiration time of a sign-in session. The default is 5 minutes, "00:05:00". For more information about how to specify <xref:System.TimeSpan> values, see [Timespan Values](../windows-workflow-foundation/index.md). The maximum clock skew may also be set at the service level by setting the `maximumClockSkew` attribute on the [\<identityConfiguration>](identityconfiguration.md) element. A value set on the token handler collection overrides the value set on the service.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<audienceUris>](audienceuris.md)|Specifies the set of URIs that are acceptable identifiers of this relying party. Optional.|  
|[\<caches>](caches.md)|Registers the caches used for session tokens and token replay detection. Can be specified at the service-level or on a security token handler collection. Optional.|  
|[\<certificateValidation>](certificatevalidation.md)|Controls the settings that token handlers use to validate certificates. Can be specified at the service-level or on a security token handler collection. These settings are overridden if a specific handler is configured with its own validator. Optional.|  
|[\<issuerNameRegistry>](issuernameregistry.md)|Configures the issuer name registry that is used by handlers in the token handler collection. Optional.|  
|[\<issuerTokenResolver>](issuertokenresolver.md)|Registers the issuer token resolver that is used by handlers in the token handler collection. The issuer token resolver is used to resolve the signing token on incoming tokens and messages. Optional.|  
|[\<serviceTokenResolver>](servicetokenresolver.md)|Registers the service token resolver that is used by handlers in the token handler collection. The service token resolver is used to resolve the encryption token on incoming tokens and messages. Optional.|  
|[\<tokenReplayDetection>](tokenreplaydetection.md)|Enables token replay detection and specifies the expiration time for tokens. Can be specified at the service-level or on a security token handler collection. Optional.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<securityTokenHandlers>](securitytokenhandlers.md)|Specifies a collection of security token handlers that are registered with the endpoint.|  
  
## Remarks  
 This section provides property values for a <xref:System.IdentityModel.Tokens.SecurityTokenHandlerConfiguration> object. Settings configured in this section override those configured on the service. Some of these settings can, in turn, be overridden by settings that are specified when a handler is added to the security token handler collection.  
  
## Example  
  
```xml  
<system.identityModel>  
  <identityConfiguration>  
    <securityTokenHandlers>   
      <securityTokenHandlerConfiguration>  
  
        <audienceUris>  
          <clear/>  
          <add value="http://www.example.com/myapp/" />  
        </audienceUris>  
  
        <issuerNameRegistry type="System.IdentityModel.Tokens.ConfigurationBasedIssuerNameRegistry, System.IdentityModel">  
          <trustedIssuers>  
            <add thumbprint="97249e1a … 4c9158de" name="contoso.com" />  
          </trustedIssuers>  
        </issuerNameRegistry>  
  
        <issuerTokenResolver type="MyNamespace.CustomTokenResolver, MyAssembly" />  
  
        <serviceTokenResolver type="MyNamespace.CustomTokenResolver, MyAssembly" />  
  
      </securityTokenHandlerConfiguration>  
    </securityTokenHandlers>  
  </identityConfiguration>  
</system.identityModel>  
```
