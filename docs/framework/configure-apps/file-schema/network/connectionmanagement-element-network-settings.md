---
title: "<connectionManagement> Element (Network Settings)"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/connectionManagement"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#connectionManagement"
helpviewer_keywords: 
  - "<connectionManagement> element"
  - "connectionManagement element"
ms.assetid: bedccaab-12a2-4511-8f67-e961f249aec6
---
# \<connectionManagement> Element (Network Settings)
Specifies the maximum number of connections to a network host.  
  
[**\<configuration>**](../configuration-element.md)  
&nbsp;&nbsp;[**\<system.net>**](system-net-element-network-settings.md)  
&nbsp;&nbsp;&nbsp;&nbsp;**\<connectionManagement>**  
  
## Syntax  
  
```xml  
<connectionManagement>   
</connectionManagement>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[add](add-element-for-connectionmanagement-network-settings.md)|Adds an IP address or DNS name to the connection management list.|  
|[clear](clear-element-for-connectionmanagement-network-settings.md)|Clears the connection management list.|  
|[remove](remove-element-for-connectionmanagement-network-settings.md)|Removes an IP address or DNS name from the connection management list.|  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[system.net](system-net-element-network-settings.md)|Contains settings that specify how the .NET Framework connects to the network.|  
  
## Remarks  
 The `connectionManagement` element defines the maximum number of connections to a server or group of servers.  
  
## Configuration Files  
 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  
 The following example configures an application to use four connections to the server `www.contoso.com` and two connections to all other servers.  
  
```xml  
<configuration>  
  <system.net>  
    <connectionManagement>  
      <add address = "http://www.contoso.com" maxconnection = "4" />  
      <add address = "*" maxconnection = "2" />  
    </connectionManagement>  
  </system.net>  
</configuration>  
```  
  
## See also

- <xref:System.Net.ServicePoint>
- <xref:System.Net.ServicePointManager>
- [Network Settings Schema](index.md)
