---
title: "&lt;remove&gt; Element for webRequestModules (Network Settings)"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/webRequestModules/remove"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#remove"
helpviewer_keywords: 
  - "remove element, webRequestModules"
  - "webRequestModules, remove element"
  - "<remove> element, webRequestModules"
  - "<webRequestModules>, remove element"
ms.assetid: dd84d2fe-2f4f-457a-9d3c-441d0d21cc10
caps.latest.revision: 13
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;remove&gt; Element for webRequestModules (Network Settings)
Removes a custom Web request module from the application.  
  
 \<configuration>  
\<system.net>  
\<webRequestModules>  
\<remove>  
  
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
|[webRequestModules](../../../../../docs/framework/configure-apps/file-schema/network/webrequestmodules-element-network-settings.md)|Specifies modules to use to request information from network hosts.|  
  
## Remarks  
 The `remove` element removes the registered Web request module for the specified URI prefix.  
  
 The value for the `prefix` attribute should be the leading characters of a valid URI -- for example, "http", or "http://www.contoso.com".  
  
## Configuration Files  
 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  
 The following example removes the existing Web request module for HTTP and then registers a new custom Web request module for HTTP requests to www.contoso.com.  
  
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
  
## See Also  
 <xref:System.Net.WebRequest>  
 [Network Settings Schema](../../../../../docs/framework/configure-apps/file-schema/network/index.md)
