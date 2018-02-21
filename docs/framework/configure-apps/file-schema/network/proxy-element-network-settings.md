---
title: "&lt;proxy&gt; Element (Network Settings)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/defaultProxy/proxy"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#proxy"
helpviewer_keywords: 
  - "<proxy> element"
  - "proxy element"
ms.assetid: 37a548d8-fade-4ac5-82ec-b49b6c6cb22a
caps.latest.revision: 20
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;proxy&gt; Element (Network Settings)
Defines a proxy server.  
  
 \<configuration>  
\<system.net>  
\<defaultProxy>  
\<proxy>  
  
## Syntax  
  
```xml  
<proxy
  autoDetect="true|false|unspecified" 
  bypassonlocal="true|false|unspecified"
  proxyaddress="uriString"
  scriptLocation="uriString"
  usesystemdefault="true|false|unspecified"
/>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|**Attribute**|**Description**|  
|-------------------|---------------------|  
|`autoDetect`|Specifies whether the proxy is automatically detected. The default value is `unspecified`.|  
|`bypassonlocal`|Specifies whether the proxy is bypassed for local resources. Local resources include the local server (http://localhost, http://loopback, or http://127.0.0.1) and a URI without a period (http://webserver). The default value is `unspecified`.|  
|`proxyaddress`|Specifies the proxy URI to use.|  
|`scriptLocation`|Specifies the location of the configuration script.|  
|`usesystemdefault`|Specifies whether to use Internet Explorer proxy settings. If set to `true`, subsequent attributes will override Internet Explorer proxy settings. The default value is `unspecified`.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[defaultProxy](../../../../../docs/framework/configure-apps/file-schema/network/defaultproxy-element-network-settings.md)|Configures the Hypertext Transfer Protocol (HTTP) proxy server.|  
  
## Text Value  
  
## Remarks  
 The `proxy` element defines a proxy server for an application. If this element is missing from the configuration file, then the .NET Framework will use the proxy settings in Internet Explorer.  
  
 The value for the `proxyaddress` attribute should be a well-formed Uniform Resource Indicator (URI).  
  
 The `scriptLocation` attribute refers to the automatic detection of proxy configuration scripts. The <xref:System.Net.WebProxy> class will attempt to locate a configuration script (usually named Wpad.dat) when the **Use automatic configuration script** option is selected in Internet Explorer.  
  
 Use the `usesystemdefault` attribute for .NET Framework version 1.1 applications that are migrating to version 2.0.  
  
 An exception is thrown if the `proxyaddress` attribute specifies an invalid default proxy. The <xref:System.Exception.InnerException%2A> property on the exception should have more information about the root cause of the error.  
  
## Configuration Files  
 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  
 The following example uses the defaults from the Internet Explorer proxy, specifies the proxy address, and bypasses the proxy for local access.  
  
```xml  
<configuration>  
  <system.net>  
    <defaultProxy>  
      <proxy  
        usesystemdefault="true"  
        proxyaddress="http://192.168.1.10:3128"  
        bypassonlocal="true"  
      />  
    </defaultProxy>  
  </system.net>  
</configuration>  
```  
  
## See Also  
 <xref:System.Net.WebProxy?displayProperty=nameWithType>  
 [Network Settings Schema](../../../../../docs/framework/configure-apps/file-schema/network/index.md)
