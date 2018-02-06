---
title: "&lt;ipv6&gt; Element (Network Settings)"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/settings/ipv6"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#ipv6"
helpviewer_keywords: 
  - "<ipv6> element"
  - "ipv6 element"
ms.assetid: 10b79aef-327b-4718-a892-e11f55e4d169
caps.latest.revision: 19
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;ipv6&gt; Element (Network Settings)
Enables Internet Protocol version 6 (IPv6) responses from obsolete members of the <xref:System.Net.Dns> class.  
  
 \<configuration>  
\<system.net>  
\<settings>  
\<ipv6>  
  
## Syntax  
  
```xml  
<ipv6  
  enabled="true|false"  
/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|**Attribute**|**Description**|  
|-------------------|---------------------|  
|`enabled`|Specifies whether members of the <xref:System.Net.Dns> class return Internet Protocol version 6 (IPv6) addresses. The default value is `false`.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[settings](../../../../../docs/framework/configure-apps/file-schema/network/settings-element-network-settings.md)|Configures basic network options for the <xref:System.Net> namespace.|  
  
## Remarks  
 This setting enables IPv6 support for the obsolete members of the <xref:System.Net.Dns> class: <xref:System.Net.Dns.BeginGetHostByName%2A>, <xref:System.Net.Dns.BeginResolve%2A>, <xref:System.Net.Dns.EndGetHostByName%2A>, <xref:System.Net.Dns.EndResolve%2A>, <xref:System.Net.Dns.GetHostByAddress%2A>, <xref:System.Net.Dns.GetHostByName%2A>, and <xref:System.Net.Dns.Resolve%2A>. For other members of the <xref:System.Net?displayProperty=nameWithType> namespace, IPv6 addresses may be returned if IPv6 is enabled in the operating system.  
  
## Configuration Files  
 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  
 The following example shows how to enable IPv6 support for the <xref:System.Net.Dns> class.  
  
```xml  
<configuration>  
  <system.net>  
    <settings>  
      <ipv6 enabled="true"/>  
    </settings>  
  </system.net>  
</configuration>  
```  
  
## See Also  
 <xref:System.Net?displayProperty=nameWithType>  
 <xref:System.Net.Dns?displayProperty=nameWithType>  
 <xref:System.Net.Sockets.Socket.OSSupportsIPv6%2A?displayProperty=nameWithType>  
 [Network Settings Schema](../../../../../docs/framework/configure-apps/file-schema/network/index.md)
