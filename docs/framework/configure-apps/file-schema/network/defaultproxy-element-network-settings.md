---
title: "&lt;defaultProxy&gt; Element (Network Settings)"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#defaultProxy"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/defaultProxy"
helpviewer_keywords: 
  - "defaultProxy element"
  - "<defaultProxy> element"
ms.assetid: 9d663c4b-07b4-4f6f-9b12-efbd3630354f
caps.latest.revision: 21
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;defaultProxy&gt; Element (Network Settings)
Configures the Hypertext Transfer Protocol (HTTP) proxy server.  
  
 \<configuration>  
\<system.net>  
\<defaultProxy>  
  
## Syntax  
  
```xml  
      <defaultProxy  
        enabled="true|false"  
        useDefaultCredentials="true|false">  
           <bypasslist> … </bypasslist>  
           <proxy> … </proxy>  
           <module> … </module>  
      </defaultProxy>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|`enabled`|Specifies whether a web proxy is used. The default value is `true`.|  
|`useDefaultCredentials`|Specifies whether the default credentials for this host are used to access the web proxy. The default value is `false`.|  
  
### Child Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[bypasslist](../../../../../docs/framework/configure-apps/file-schema/network/bypasslist-element-network-settings.md)|Provides a set of regular expressions that describe addresses that do not use the proxy.|  
|[module](../../../../../docs/framework/configure-apps/file-schema/network/module-element-network-settings.md)|Adds a new proxy module to the application.|  
|[proxy](../../../../../docs/framework/configure-apps/file-schema/network/proxy-element-network-settings.md)|Defines a proxy server.|  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[system.net](../../../../../docs/framework/configure-apps/file-schema/network/system-net-element-network-settings.md)|Contains settings that specify how the .NET Framework connects to the network.|  
  
## Remarks  
 If the defaultProxy element is empty, the proxy settings from Internet Explorer will be used. This behavior is different from version 1.1 of the .NET Framework.  
  
 An exception is thrown if the [module](../../../../../docs/framework/configure-apps/file-schema/network/module-element-network-settings.md) element specifies a non-public type, the type is not deriving from the <xref:System.Net.IWebProxy> class, an exception from the default constructor of this object occurred, or an exception occurred while retrieving the system-specified default proxy. The <xref:System.Exception.InnerException%2A> property on the exception should have more information about the root cause of the error.  
  
## Configuration Files  
 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  
 The following example uses the defaults from the Internet Explorer proxy, specifies the proxy address, and bypasses the proxy for local access and contoso.com.  
  
```xml  
<configuration>  
  <system.net>  
    <defaultProxy>  
      <proxy  
        usesystemdefault="true"  
        proxyaddress="http://192.168.1.10:3128"  
        bypassonlocal="true"  
      />  
      <bypasslist>  
        <add address="[a-z]+\.contoso\.com" />  
      </bypasslist>  
    </defaultProxy>  
  </system.net>  
</configuration>  
```  
  
## See Also  
 <xref:System.Net.WebProxy?displayProperty=nameWithType>  
 [Network Settings Schema](../../../../../docs/framework/configure-apps/file-schema/network/index.md)
