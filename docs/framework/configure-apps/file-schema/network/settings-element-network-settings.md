---
title: "&lt;settings&gt; Element (Network Settings)"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#settings"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/settings"
helpviewer_keywords: 
  - "settings element"
  - "<settings> element"
ms.assetid: 189ce989-c39b-427d-b004-6b82a668b931
caps.latest.revision: 21
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;settings&gt; Element (Network Settings)
Configures basic network options for the <xref:System.Net?displayProperty=nameWithType> namespace.  
  
 \<configuration>  
\<system.net>  
\<settings>  
  
## Syntax  
  
```xml  
<settings>  
  <httpListener> … </httpListener>  
  <httpWebRequest> … </httpWebRequest>  
  <ipv6> … </ipv6>  
  <performanceCounters> … </performanceCounters>  
  <servicePointManager> … </servicePointManager>  
  <socket> … </socket>  
  <webProxyScript> … </webProxyScript>  
</settings>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[httpListener](../../../../../docs/framework/configure-apps/file-schema/network/httplistener-element-network-settings.md)|Customizes parameters used by the <xref:System.Net.HttpListener> class.|  
|[httpWebRequest](../../../../../docs/framework/configure-apps/file-schema/network/httpwebrequest-element-network-settings.md)|Customizes Web request parameters.|  
|[ipv6](../../../../../docs/framework/configure-apps/file-schema/network/ipv6-element-network-settings.md)|Enables Internet Protocol version 6 (IPv6) support.|  
|[\<performanceCounter> Element (Network Settings)](../../../../../docs/framework/configure-apps/file-schema/network/performancecounter-element-network-settings.md)|Enables network performance counters.|  
|[servicePointManager](../../../../../docs/framework/configure-apps/file-schema/network/servicepointmanager-element-network-settings.md)|Configures connections to network resources.|  
|[socket](../../../../../docs/framework/configure-apps/file-schema/network/socket-element-network-settings.md)|Specifies whether socket operations use completion ports.|  
|[\<webProxyScript> Element (Network Settings)](../../../../../docs/framework/configure-apps/file-schema/network/webproxyscript-element-network-settings.md)|Configures the characteristics of the script used to discover Web proxies.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[system.net](../../../../../docs/framework/configure-apps/file-schema/network/system-net-element-network-settings.md)|Contains settings that specify how the .NET Framework connects to the network.|  
  
## Remarks  
  
## Configuration Files  
 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## See Also  
 <xref:System.Net?displayProperty=nameWithType>  
 [Network Settings Schema](../../../../../docs/framework/configure-apps/file-schema/network/index.md)
