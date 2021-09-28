---
description: "Learn more about: <remove> Element for bypasslist (Network Settings)"
title: "<remove> Element for bypasslist (Network Settings)"
ms.date: "03/30/2017"
f1_keywords:
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/defaultProxy/bypasslist/remove"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#remove"
helpviewer_keywords:
  - "<bypasslist>, remove element"
  - "remove element, bypasslist"
  - "bypasslist, remove element"
  - "remove element, bypasslist"
ms.assetid: 61dcfb4a-e3d9-4abf-a2cd-7d685fe2f64b
---

# \<remove> Element for bypasslist (Network Settings)

Removes an IP address or DNS name from the proxy bypass list.

[**\<configuration>**](../configuration-element.md)  
&nbsp;&nbsp;[**\<system.net>**](system-net-element-network-settings.md)  
&nbsp;&nbsp;&nbsp;&nbsp;[**\<defaultProxy>**](defaultproxy-element-network-settings.md)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<bypasslist>**](bypasslist-element-network-settings.md)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<remove>**  

## Syntax

```xml
<remove
  address="regular expression"
/>
```

## Attributes and Elements

The following sections describe attributes, child elements, and parent elements.

### Attributes

|**Attribute**|**Description**|
|-------------------|---------------------|
|`address`|A regular expression describing an IP address or DNS name.|

### Child Elements

None.

### Parent Elements

|**Element**|**Description**|
|-----------------|---------------------|
|[bypasslist](bypasslist-element-network-settings.md)|Provides a set of regular expressions that describe addresses that do not use a proxy.|

## Remarks

The `remove` element removes regular expressions describing IP addresses or DNS server names from the list of addresses that bypass a proxy server. The addresses were defined earlier in the configuration file or at a higher level in the configuration hierarchy.

The value for the `address` attribute should be a regular expression that describes a set of IP addresses or host names.

For more information about regular expressions, see .[.NET Framework Regular Expressions](../../../../standard/base-types/regular-expressions.md).

## Configuration Files

This element can be used in the application configuration file or the machine configuration file (Machine.config).

## Example

The following example removes any previous definition for the adventure-works.com domain, and then adds the contoso.com domain to the bypass list.

```xml
<configuration>
  <system.net>
    <defaultProxy>
      <bypasslist>
        <remove address="[a-z]+\.adventure-works\.com$" />
        <add address="[a-z]+\.contoso\.com$" />
      </bypasslist>
    </defaultProxy>
  </system.net>
</configuration>
```

## See also

- <xref:System.Net.WebProxy?displayProperty=nameWithType>
- [Network Settings Schema](index.md)
