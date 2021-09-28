---
description: "Learn more about: <add> Element for bypasslist (Network Settings)"
title: "<add> Element for bypasslist (Network Settings)"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/defaultProxy/bypasslist/add"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#add"
helpviewer_keywords: 
  - "<bypasslist>, add element"
  - "bypasslist, add element"
  - "<add> element, bypasslist"
  - "add element, bypasslist"
ms.assetid: a0b86e28-86b4-4497-abe8-d5fd614c7926
---
# \<add> Element for bypasslist (Network Settings)

Adds an IP address or DNS name to the proxy bypass list.  
  
[**\<configuration>**](../configuration-element.md)  
&nbsp;&nbsp;[**\<system.net>**](system-net-element-network-settings.md)  
&nbsp;&nbsp;&nbsp;&nbsp;[**\<defaultProxy>**](defaultproxy-element-network-settings.md)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<bypasslist>**](bypasslist-element-network-settings.md)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<add>**  
  
## Syntax  
  
```xml  
<add
  address="regular expression"
/>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|**Attribute**|**Description**|  
|-------------------|---------------------|  
|**address**|A regular expression describing an IP address or DNS name.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[bypasslist](bypasslist-element-network-settings.md)|Provides a set of regular expressions that describe addresses that do not use a proxy.|  
  
## Remarks  

 The `add` element inserts regular expressions describing IP addresses or DNS server names to the list of addresses that bypass a proxy server.  
  
 The value of the `address` attribute should be a regular expression that describes a set of IP addresses or host names.  
  
 You should use caution when specifying a regular expression for this element. The regular expression "[a-z]+\\.contoso\\.com" matches any host in the contoso.com domain, but it also matches any host in the contoso.com.cpandl.com domain. To match only a host in the contoso.com domain, use an anchor ("$"): "[a-z]+\\.contoso\\.com$".  
  
 For more information about regular expressions, see .[.NET Framework Regular Expressions](../../../../standard/base-types/regular-expressions.md).  
  
## Configuration Files  

 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  

 The following example adds two addresses to the bypass list. The first bypasses the proxy for all servers in the contoso.com domain; the second bypasses the proxy for all servers whose IP address begins with 192.168.  
  
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
