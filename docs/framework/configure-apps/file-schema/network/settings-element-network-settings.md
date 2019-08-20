---
title: "<settings> Element (Network Settings)"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#settings"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/settings"
helpviewer_keywords: 
  - "settings element"
  - "<settings> element"
ms.assetid: 189ce989-c39b-427d-b004-6b82a668b931
---
# \<settings> Element (Network Settings)
Configures basic network options for the <xref:System.Net?displayProperty=nameWithType> namespace.  
  
 \<configuration>  
\<system.net>  
\<settings>  
  
## Syntax  
  
```xml  
<settings>  
  <httpListener>...</httpListener>  
  <httpWebRequest>...</httpWebRequest>  
  <ipv6>...</ipv6>  
  <performanceCounters>...</performanceCounters>  
  <servicePointManager>...</servicePointManager>  
  <socket>...</socket>  
  <webProxyScript>...</webProxyScript>  
</settings>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[httpListener](httplistener-element-network-settings.md)|Customizes parameters used by the <xref:System.Net.HttpListener> class.|  
|[httpWebRequest](httpwebrequest-element-network-settings.md)|Customizes Web request parameters.|  
|[ipv6](ipv6-element-network-settings.md)|Enables Internet Protocol version 6 (IPv6) support.|  
|[\<performanceCounter> Element (Network Settings)](performancecounter-element-network-settings.md)|Enables network performance counters.|  
|[servicePointManager](servicepointmanager-element-network-settings.md)|Configures connections to network resources.|  
|[socket](socket-element-network-settings.md)|Specifies whether socket operations use completion ports.|  
|[\<webProxyScript> Element (Network Settings)](webproxyscript-element-network-settings.md)|Configures the characteristics of the script used to discover Web proxies.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[system.net](system-net-element-network-settings.md)|Contains settings that specify how the .NET Framework connects to the network.|  
  
## Remarks  
  
## Configuration Files  
 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## See also

- <xref:System.Net?displayProperty=nameWithType>
- [Network Settings Schema](index.md)
