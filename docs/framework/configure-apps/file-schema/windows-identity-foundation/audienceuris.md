---
title: "&lt;audienceUris&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 7a3d8515-d756-4afe-a22d-07cbe2217ee3
caps.latest.revision: 8
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# &lt;audienceUris&gt;
Specifies the set of URIs that are acceptable identifiers of the relying party (RP). Tokens will not be accepted unless they are scoped for one of the allowed audience URIs.  
  
 \<system.identityModel>  
\<identityConfiguration>  
\<securityTokenHandlers>  
\<securityTokenHandlerConfiguration>  
\<audienceUris>  
  
## Syntax  
  
```xml  
<system.identityModel>  
  <identityConfiguration>  
    <securityTokenHandlers>  
      <securityTokenHandlerConfiguration>  
        <audienceUris mode=xs:string>  
          <add value=xs:string />  
          <clear />  
          <remove value=xs:string />  
        </audienceUris>  
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
|mode|An <xref:System.IdentityModel.Selectors.AudienceUriMode> value that specifies whether the audience restriction should be applied to an incoming token. The possible values are "Always", "Never", and "BearerKeyOnly". The default is "Always". Optional.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`<add value=xs:string>`|Adds the URI specified by the `value` attribute to the audienceUris collection. The `value` attribute is required. The URI is case-sensitive.|  
|`<clear>`|Clears the audienceUris collection. All identifiers are removed from the collection.|  
|`<remove value=xs:string>`|Removes the URI specified by the `value` attribute from the audienceUris collection. The `value` attribute is required. The URI is case-sensitive.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<securityTokenHandlerConfiguration>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/securitytokenhandlerconfiguration.md)|Provides configuration for a collection of security token handlers.|  
  
## Remarks  
 By default, the collection is empty; use `<add>`, `<clear>`, and `<remove>` elements to modify the collection. <xref:System.IdentityModel.Tokens.SamlSecurityTokenHandler> and <xref:System.IdentityModel.Tokens.Saml2SecurityTokenHandler> objects use the values in the audience URI collection to configure any allowed audience URI restrictions in <xref:System.IdentityModel.Tokens.SamlSecurityTokenRequirement> objects.  
  
 The `<audienceUris>` element is represented by the <xref:System.IdentityModel.Configuration.AudienceUriElementCollection> class. An individual URI added to the collection is represented by the <xref:System.IdentityModel.Configuration.AudienceUriElement> class.  
  
> [!NOTE]
>  The use of the `<audienceUris>` element as a child element of the [\<identityConfiguration>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/identityconfiguration.md) element has been deprecated, but is still supported for backward compatibility. Settings on the `<securityTokenHandlerConfiguration>` element override those on the `<identityConfiguration>` element.  
  
## Example  
 The following XML shows how to configure the acceptable audience URIs for an application. This example configures a single URI. Tokens scoped for this URI will be accepted, all others will be rejected.  
  
```xml  
<audienceUris>  
  <add value="http://localhost:19851/"/>  
</audienceUris>  
```
