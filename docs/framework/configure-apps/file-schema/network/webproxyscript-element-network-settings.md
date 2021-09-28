---
description: "Learn more about: <webProxyScript> Element (Network Settings)"
title: "<webProxyScript> Element (Network Settings)"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#webProxyScript"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/settings/webProxyScript"
helpviewer_keywords: 
  - "<webProxyScript> element"
  - "webProxyScript element"
ms.assetid: a13c26db-6218-4af3-9696-38f24b23bfac
---
# \<webProxyScript> Element (Network Settings)

Configures the characteristics of the script used to discover Web proxies.  

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.net>**](system-net-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<settings>**](settings-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<webProxyScript>**

## Syntax  
  
```xml  
<webProxyScript  
  downloadTimeout="hh:mm:ss"  
/>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`downloadTimeout`|Specifies the maximum time to download the script in hours, minutes, and seconds. The default value is one minute.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[settings](settings-element-network-settings.md)|Configures basic network options for the <xref:System.Net> namespace.|  
  
## Remarks  
  
## Configuration Files  

 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## See also

- [Network Settings Schema](index.md)
