---
title: "&lt;wsFederation&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c537f770-68bd-4f82-96ad-6424ad91369f
caps.latest.revision: 8
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# &lt;wsFederation&gt;
Provides configuration for the <xref:System.IdentityModel.Services.WSFederationAuthenticationModule> (WSFAM).  
  
\<system.identityModel.services>  
\<federationConfiguration>  
\<wsFederation>  
  
## Syntax  
  
```xml
<system.identityModel.services>  
  <federationConfiguration>  
    <wsFederation authenticationType=xs:string (URI)  
                  freshness=xs:decimal  
                  homerealm=xs:string (URI)  
                  issuer=xs:string (URI)  
                  persistentCookiesOnPassiveRedirects=xs:boolean  
                  passiveRedirectEnabled=xs:boolean  
                  policy=xs:string (URI)  
                  realm=xs:string (URI)  
                  reply=xs:string (URI)  
                  request=xs:string (URI)  
                  requestPtr=xs:string (URI)  
                  requireHttps=xs:boolean  
                  resource=xs:string (URI)  
                  signInQueryString=xs:string  
                  signOutQueryString=xs:string  
                  signOutReply=xs:string (URL)  
    </wsFederation>  
  </federationConfiguration>  
</system.identityModel.services>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|authenticationType|A URI that specifies the authentication type. Sets the WS-Federation sign-in request wauth parameter. Optional. The default is an empty string, which specifies that the wauth parameter is not included in the request.|  
|freshness|The desired maximum age of authentication requests, in minutes. Sets the WS-Federation sign-in request wfresh parameter. Optional. The default is zero. Optional. **Warning:**  In the next release of .NET Framework 4.5, the `freshness` attribute will be of type `xs:string` and its default value will be `null`.|  
|homeRealm|The home realm of the identity provider (IP) to use for authentication. Sets the WS-Federation sign-in request whr parameter. Optional. The default is an empty string, which specifies that the whr parameter is not included in the request.|  
|issuer|The URI of the intended token issuer. Sets the base URL of WS-Federation sign-in requests and sign-out requests Required.|  
|persistentCookiesOnPassiveRedirects|Specifies whether persistent cookies are issued on authentication. Optional. The default is "false", cookies are not issued.|  
|passiveRedirectEnabled|Specifies whether the WSFAM is enabled to automatically redirect unauthorized requests to an STS. Optional. The default is "true", unauthorized requests are automatically redirected.|  
|policy|A URL that specifies the location of the relevant policy to use on sign-in requests. The default is an empty string. Sets the WS-Federation sign-in request wp parameter. Optional. The default is an empty string, which specifies that the wp parameter is not included in the request.|  
|realm|The URI of the requesting realm. (A URI that identifies the relying party (RP) to the security token service (STS).) Sets the request wtrealm WS-Federation sign-in request parameter. Required.|  
|reply|A URL that identifies the address at which the relying party (RP) application would like to receive replies from the Security Token Service (STS). Sets the WS-Federation sign-in request wreply parameter. Optional. The default is an empty string, which specifies that the wreply parameter is not included in the request.|  
|request|The token issuance request. Sets the WS-Federation sign-in request wreq parameter. Optional. The default is an empty string, which specifies that the wreq parameter is not included in the request. Not including the wreq or the wreqptr parameter in the request implies that the STS knows what kind of token to issue.|  
|requestPtr|A URL that specifies the location of the token issuance request. Sets the request wreqptr parameter. Optional. The default is an empty string, which specifies that the wreqptr parameter is not included in the request. Not including the wreq or the wreqptr parameter in the request implies that the STS knows what kind of token to issue.|  
|requireHttps|Specifies whether communication with the security token service (STS) must use HTTPS protocol. Optional. The default is "true", HTTPS must be used.|  
|resource|A URI that identifies the resource being accessed, the relying party (RP), to the to the security token service (STS). Optional. Sets the WS-Federation sign-in request wres parameter. Optional. The default is an empty string, which specifies that the wres parameter is not included in the request. **Note:**  wres is a legacy parameter. Specify the `realm` attribute to use the wtrealm parameter instead.|  
|signInQueryString|Provides an extensibility point to specify application defined query parameters in the WS-Federation sign-in request URL. Optional. The default is an empty string, which specifies that no additional parameters should be included in the request. The parameters are specified as a query string fragment using the following form: `"param1=value1&param2=value2&param3=value3"` and so on. **Note:**  In a configuration file the ‘&" character in the query string must be specified using its entity reference, `&`.|  
|signOutQueryString|Provides an extensibility point to specify application defined query parameters in the WS-Federation sign-in request URL. Optional. The default is an empty string, which specifies that no additional parameters should be included in the request. The parameters are specified as a query string fragment using the following form: `"param1=value1&param2=value2&param3=value3"` and so on. **Note:**  In a configuration file the ‘&" character in the query string must be specified using its entity reference, `&`.|  
|signOutReply|Specifies the URL to which the client should be redirected by the security token service (STS) during passive sign-out through the WS-Federation protocol. Sets the wreply parameter on a WS-Federation sign-out request. Optional. The default is an empty string, which specifies that no additional parameters should be included in the request.|  
  
### Child Elements  
 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<federationConfiguration>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/federationconfiguration.md)|Contains the settings that configure the <xref:System.IdentityModel.Services.WSFederationAuthenticationModule> (WSFAM) and the <xref:System.IdentityModel.Services.SessionAuthenticationModule> (SAM).|  
  
## Remarks  
 You can use the `<wsFederation>` element to configure default WS-Federation parameter settings and default behavior for the WSFAM. WS-Federation parameter settings defined under the `<wsFederation>` element set equivalent properties exposed by the <xref:System.IdentityModel.Services.WSFederationAuthenticationModule> class. These properties remain the same for every request issued by the WSFAM. You can change the WS-Federation parameters dynamically during request processing by adding event handlers for the events exposed by WSFAM; for example, the <xref:System.IdentityModel.Services.WSFederationAuthenticationModule.RedirectingToIdentityProvider> event. For more information, see the documentation for the <xref:System.IdentityModel.Services.WSFederationAuthenticationModule> class.  
  
 The `<wsFederation>` element is represented by the <xref:System.IdentityModel.Services.Configuration.WSFederationElement> class. The configuration object itself is represented by the <xref:System.IdentityModel.Services.Configuration.WsFederationConfiguration> class. A single <xref:System.IdentityModel.Services.Configuration.WsFederationConfiguration> instance is set on the <xref:System.IdentityModel.Services.Configuration.FederationConfiguration> object that is accessed through the <xref:System.IdentityModel.Services.FederatedAuthentication.FederationConfiguration%2A?displayProperty=nameWithType> property and provides configuration for the WSFAM.  
  
## Example  
 The following XML shows a `<wsFederation>` element that specifies settings for the WSFAM.  
  
> [!WARNING]
>  In this example, the WSFAM is not required to use HTTPS. This is because the `requireHttps` attribute on the `<wsFederation>` element is set `false`. This setting is not recommended for most production environments as it may present a security risk.  
  
```xml
<wsFederation passiveRedirectEnabled="true"   
              issuer="http://localhost:15839/wsFederationSTS/Issue"   
              realm="http://localhost:50969/"   
              reply="http://localhost:50969/"   
              requireHttps="false"   
              signOutReply="http://localhost:50969/SignedOutPage.html"   
              signOutQueryString="Param1=value2&Param2=value2"   
              persistentCookiesOnPassiveRedirects="true" />
```  
  
## See Also  
 <xref:System.IdentityModel.Services.WSFederationAuthenticationModule>  
 <xref:System.IdentityModel.Services.FederatedAuthentication.FederationConfiguration%2A?displayProperty=nameWithType>
