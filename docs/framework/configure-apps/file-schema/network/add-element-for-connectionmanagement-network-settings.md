---
description: "Learn more about: <add> Element for connectionManagement (Network Settings)"
title: "<add> Element for connectionManagement (Network Settings)"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#add"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/connectionManagement/add"
helpviewer_keywords: 
  - "<add> element, connectionManagement"
  - "<connectionManagement>, add element"
  - "add element, connectionManagement"
  - "connectionManagement, add element"
ms.assetid: 856bf57d-1c63-46c7-a178-03d97b0a4149
---
# \<add> Element for connectionManagement (Network Settings)

Adds an IP address or DNS name to the connection management list.  

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.net>**](system-net-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<connectionManagement>**](connectionmanagement-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<add>**

## Syntax  
  
```xml  
<add
  address="address expression"
  maxconnection="integer"
/>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|**Attribute**|**Description**|  
|-------------------|---------------------|  
|`address`|A string describing an IP address or DNS name.|  
|`maxconnection`|The maximum number of connections allowed to a server. If not supplied, the default is 2.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[connectionManagement](connectionmanagement-element-network-settings.md)|Specifies the maximum number of connections to a network host.|  
  
## Remarks  

 The value of the `address` attribute should be either an asterisk to indicate all connections, or a string of the form `<schema>://<idn_hostname>[:<port>]`.  
  
 If the URI passed to any HTTP APIs contains Unicode, the name will be converted internally using <xref:System.Uri.DnsSafeHost%2A> which might return a punicode string (behavior dependent on the current IDN configuration).  
  
## Configuration Files  

 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  

 The following example configures an application to use four connections to the server `www.contoso.com` and two connections to all other servers.  
  
```xml  
<configuration>  
  <system.net>  
    <connectionManagement>  
      <add address="http://www.contoso.com" maxconnection="4" />  
      <add address="*" maxconnection="2" />  
    </connectionManagement>  
  </system.net>  
</configuration>  
```  
  
## See also

- <xref:System.Net.ServicePoint>
- <xref:System.Net.ServicePointManager>
- [Network Settings Schema](index.md)
