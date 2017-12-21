---
title: "&lt;cookieHandler&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: bfdc127f-8d94-4566-8bef-f583c6ae7398
caps.latest.revision: 5
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# &lt;cookieHandler&gt;
Configures the <xref:System.IdentityModel.Services.CookieHandler> that the <xref:System.IdentityModel.Services.SessionAuthenticationModule> (SAM) uses to read and write cookies.  
  
 \<system.identityModel.services>  
\<federationConfiguration>  
\<cookieHandler>  
  
## Syntax  
  
```xml  
<system.identityModel.services>  
  <federationConfiguration>  
    <cookieHandler name=xs:string  
        path=Path  
        mode="Chunked||Custom||Default"  
        persistentSessionLifetime=xs:string  
        hideFromScript=xs:boolean  
        requireSSL=xs:boolean  
        domain=xs:string  
      <chunkedCookieHandler size=xs:int />  
      <customCookieHandler type="MyNamespace.MyCustomCookieHandler, MyAssembly" />  
    </cookieHandler>  
  </federationConfiguration>  
</system.identityModel.services>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|name|Specifies the base name for any cookies written. The default is "FedAuth".|  
|path|Specifies the path value for any cookies written. The default is "HttpRuntime.AppDomainAppVirtualPath".|  
|mode|One of the <xref:System.IdentityModel.Services.CookieHandlerMode> values that specifies the kind of cookie handler used by the SAM. The following values may be used:<br /><br /> -   "Default" — The same as "Chunked".<br />-   "Chunked" — Uses an instance of the <xref:System.IdentityModel.Services.ChunkedCookieHandler> class. This cookie handler ensures that individual cookies do not exceed a set maximum size. It accomplishes this by potentially "chunking" one logical cookie into a number of cookies on-the-wire.<br />-   "Custom" — Uses an instance of a custom class derived from <xref:System.IdentityModel.Services.CookieHandler>. The derived class is referenced by the `<customCookieHandler>` child element.<br /><br /> The default is "Default".|  
|persistentSessionLifetime|Specifies the lifetime of persistent sessions. If zero, transient sessions are always used. The default value is "0:0:0", which specifies a transient session. The maximum value is "365:0:0", which specifies a session of 365 days. The value should be specified according to the following restriction: `<xs:pattern value="([0-9.]+:){0,1}([0-9]+:){0,1}[0-9.]+" />`, where the leftmost value specifies days, the middle value (if present) specifies hours, and the rightmost value (if present) specifies minutes.|  
|requireSsl|Specifies whether the "Secure" flag is emitted for any cookies written. If this value is set, the sign-in session cookies will only be available over HTTPS. The default is "true".|  
|hideFromScript|Controls whether the "HttpOnly" flag is emitted for any cookies written. Certain web browsers honor this flag by keeping client-side script from accessing the cookie value. The default is "true".|  
|domain|The domain value for any cookies written. The default is "".|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<chunkedCookieHandler>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/chunkedcookiehandler.md)|Configures the <xref:System.IdentityModel.Services.ChunkedCookieHandler>. This element may only be present if the `mode` attribute of the `<cookieHandler>` element is "Default" or "Chunked".|  
|[\<customCookieHandler>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/customcookiehandler.md)|Sets the custom cookie handler type. This element must be present if the `mode` attribute of the `<cookieHandler>` element is "Custom". It cannot be present for any other values of the `mode` attribute. The custom type must be derived from the <xref:System.IdentityModel.Services.CookieHandler> class.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<federationConfiguration>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/federationconfiguration.md)|Contains the settings that configure the <xref:System.IdentityModel.Services.WSFederationAuthenticationModule> (WSFAM) and the <xref:System.IdentityModel.Services.SessionAuthenticationModule> (SAM).|  
  
## Remarks  
 The <xref:System.IdentityModel.Services.CookieHandler> is responsible for reading and writing raw cookies at the HTTP protocol level. You can configure either a <xref:System.IdentityModel.Services.ChunkedCookieHandler> or a custom cookie handler derived from the <xref:System.IdentityModel.Services.CookieHandler> class.  
  
 To configure a chunked cookie handler, set the mode attribute to "Chunked" or "Default". The default chunk size is 2000 bytes, but you may optionally specify a different chunk size by including a `<chunkedCookieHandler>` child element.  
  
 To configure a custom cookie handler, set the mode attribute to "Custom". You must also specify a `<customCookieHandler>` child element that references the type of your custom handler.  
  
 The `<cookieHandler>` element is represented by the <xref:System.IdentityModel.Services.CookieHandlerElement> class. The cookie handler that was specified in configuration is available from the <xref:System.IdentityModel.Services.Configuration.FederationConfiguration.CookieHandler%2A> property of the <xref:System.IdentityModel.Services.Configuration.FederationConfiguration> object set on the <xref:System.IdentityModel.Services.FederatedAuthentication.FederationConfiguration%2A?displayProperty=nameWithType> property.  
  
## Example  
 The following XML shows a `<cookieHandler>` element. In this example, because the `mode` attribute is not specified, the default cookie handler will be used by the SAM. This is an instance of the <xref:System.IdentityModel.Services.ChunkedCookieHandler> class. Because the `<chunkedCookieHandler>` child element is not specified, the default chunk size will be used. HTTPS will not be required because the `requireSsl` attribute is set `false`.  
  
> [!WARNING]
>  In this example, HTTPS is not required to write session cookies. This is because the `requireSsl` attribute on the `<cookieHandler>` element is set to `false`. This setting is not recommended for most production environments as it may present a security risk.  
  
```xml  
<cookieHandler requireSsl="false" />  
```  
  
## See Also  
 <xref:System.IdentityModel.Services.CookieHandler>  
 <xref:System.IdentityModel.Services.ChunkedCookieHandler>  
 <xref:System.IdentityModel.Services.SessionAuthenticationModule>
