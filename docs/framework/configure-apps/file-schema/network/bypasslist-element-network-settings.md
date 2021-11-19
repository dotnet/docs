---
title: "<bypasslist> Element (Network Settings)"
description: The <bypasslist> network settings element provides a set of regular expressions that describe addresses that do not use a proxy in the .NET Framework.
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#bypasslist"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/defaultProxy/bypasslist"
helpviewer_keywords: 
  - "bypasslist element"
  - "<bypasslist> element"
ms.assetid: 124446b7-abb1-4e5e-a492-b64398f268f1
---
# \<bypasslist> Element (Network Settings)

Provides a set of regular expressions that describe addresses that do not use a proxy.  

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.net>**](system-net-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<defaultProxy>**](defaultproxy-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<bypasslist>**

## Syntax  
  
```xml  
<bypasslist>
</bypasslist>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  

 None.  
  
### Child Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[add](add-element-for-bypasslist-network-settings.md)|Adds an IP address or DNS name to the proxy bypass list.|  
|[clear](clear-element-for-bypasslist-network-settings.md)|Clears the bypass list.|  
|[remove](remove-element-for-bypasslist-network-settings.md)|Removes an IP address or DNS name from the proxy bypass list.|  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[defaultProxy](defaultproxy-element-network-settings.md)|Configures the Hypertext Transfer Protocol (HTTP) proxy server.|  
  
## Remarks  

 The bypass list contains regular expressions that describe URIs that <xref:System.Net.WebRequest> instances access directly instead of through the proxy server.  
  
 You should use caution when specifying a regular expression for this element. The regular expression `[a-z]+\\.contoso\\.com` matches any host in the contoso.com domain, but it also matches any host in the contoso.com.cpandl.com domain. To match only a host in the contoso.com domain, use an anchor (`$`): `[a-z]+\\.contoso\\.com$`.
  
 For more information about regular expressions, see .[.NET Framework Regular Expressions](../../../../standard/base-types/regular-expressions.md).  
  
## Configuration Files  

 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  

 The following example adds two addresses to the bypass list. The first bypasses the proxy for all servers in the contoso.com domain; the second bypasses the proxy for all servers whose IP addresses begin with 192.168.  
  
```xml  
<configuration>  
  <system.net>  
    <defaultProxy>  
      <bypasslist>  
        <add address="[a-z]+\.contoso\.com$" />  
        <add address="192\.168\.\d{1,3}\.\d{1,3}" />  
      </bypasslist>  
    </defaultProxy>  
  </system.net>  
</configuration>  
```  
  
## See also

- <xref:System.Net.WebProxy?displayProperty=nameWithType>
- [Network Settings Schema](index.md)
