---
title: "&lt;remove&gt; Element for bypasslist (Network Settings) | Microsoft Docs"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/defaultProxy/bypasslist/remove"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#remove"
dev_langs: 
  - "VB"
  - "CSharp"
  - "C++"
  - "jsharp"
helpviewer_keywords: 
  - "<bypasslist>, remove element"
  - "remove elemment, bypasslist"
  - "bypasslist, remove element"
  - "remove element, bypasslist"
ms.assetid: 61dcfb4a-e3d9-4abf-a2cd-7d685fe2f64b
caps.latest.revision: 16
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
---
# &lt;remove&gt; Element for bypasslist (Network Settings)
Removes an IP address or DNS name from the proxy bypass list.  
  
 \<configuration>  
\<system.net>  
\<defaultProxy>  
\<bypasslist>  
\<remove>  
  
## Syntax  
  
```  
  
      <remove   
   name = "regular expression"   
/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|**Attribute**|**Description**|  
|-------------------|---------------------|  
|`name`|A regular expression describing an IP address or DNS name.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[bypasslist](../../../../../docs/framework/configure-apps/file-schema/network/bypasslist-element-network-settings.md)|Provides a set of regular expressions that describe addresses that do not use a proxy.|  
  
## Remarks  
 The `remove` element removes regular expressions describing IP addresses or DNS server names from the list of addresses that bypass a proxy server. The addresses were defined earlier in the configuration file or at a higher level in the configuration hierarchy.  
  
 The value for the `name` attribute should be a regular expression that describes a set of IP addresses or host names.  
  
 For more information about regular expressions, see .[.NET Framework Regular Expressions](../../../../../docs/standard/base-types/regular-expressions.md).  
  
## Configuration Files  
 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  
 The following code example removes any previous definition for the adventure-works.com domain, and then adds the contoso.com domain to the bypass list.  
  
```  
<configuration>  
  <system.net>  
    <defaultProxy>  
      <bypasslist>  
        <remove name = "[a-z]+\.adventure-works\.com$" />  
        <add address="[a-z]+\.contoso\.com$" />  
      </bypasslist>  
    </defaultProxy>  
  </system.net>  
</configuration>  
```  
  
## See Also  
 <xref:System.Net.WebProxy?displayProperty=fullName>   
 [Network Settings Schema](../../../../../docs/framework/configure-apps/file-schema/network/index.md)
