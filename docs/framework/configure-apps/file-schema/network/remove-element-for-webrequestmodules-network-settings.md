---
description: "Learn more about: <remove> Element for webRequestModules (Network Settings)"
title: "<remove> Element for webRequestModules (Network Settings)"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/webRequestModules/remove"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#remove"
helpviewer_keywords: 
  - "remove element, webRequestModules"
  - "webRequestModules, remove element"
  - "<remove> element, webRequestModules"
  - "<webRequestModules>, remove element"
ms.assetid: dd84d2fe-2f4f-457a-9d3c-441d0d21cc10
---
# \<remove> Element for webRequestModules (Network Settings)

Removes a custom Web request module from the application.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.net>**](system-net-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<webRequestModules>**](webrequestmodules-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<remove>**
  
## Syntax  
  
```xml  
<remove
  prefix="URI prefix"
/>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|**Attribute**|**Description**|  
|-------------------|---------------------|  
|`prefix`|The URI prefix for requests handled by this Web request module.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[webRequestModules](webrequestmodules-element-network-settings.md)|Specifies modules to use to request information from network hosts.|  
  
## Remarks  

 The `remove` element removes the registered Web request module for the specified URI prefix.  
  
 The value for the `prefix` attribute should be the leading characters of a valid URI -- for example, "`http`", or "`http://www.contoso.com`".  
  
## Configuration Files  

 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  

The following example removes the existing Web request module for HTTP and then registers a new custom Web request module for HTTP requests to `www.contoso.com`.
  
```xml  
<configuration>  
  <system.net>  
    <webRequestModules>  
      <remove prefix="http">  
      <add prefix="http"  
           type="System.Net.HttpRequestCreator, System, Version=2.0.3600.0,  
           Culture=neutral, PublicKeyToken=b77a5c561934e089"  
      />  
    </webRequestModules>  
  </system.net>  
</configuration>  
```  
  
## See also

- <xref:System.Net.WebRequest>
- [Network Settings Schema](index.md)
