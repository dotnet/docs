---
title: "&lt;add&gt; Element for webRequestModules (Network Settings)"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/webRequestModules/add"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#add"
helpviewer_keywords: 
  - "<webRequestModules>, add element"
  - "webRequestModules, add element"
  - "add element, webRequestModules"
  - "<add> element, webRequestModules"
ms.assetid: 47ec4adc-f39f-4bcd-8680-1ec21fd26890
caps.latest.revision: 16
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;add&gt; Element for webRequestModules (Network Settings)
Adds a custom Web request module to the application.  
  
 \<configuration>  
\<system.net>  
\<webRequestModules>  
\<add>  
  
## Syntax  
  
```xml  
<add   
  prefix="URI prefix"   
  type="type_fullname, assembly_fullname"   
/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|**Attribute**|**Description**|  
|-------------------|---------------------|  
|`prefix`|The URI prefix for requests handled by this Web request module.|  
|`type`|The fully qualified type name (indicated by the <xref:System.Type.FullName%2A> property) and the assembly name (indicated by the <xref:System.Reflection.Assembly.FullName%2A> property), separated by a comma, that implements this Web request module.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[webRequestModules](../../../../../docs/framework/configure-apps/file-schema/network/webrequestmodules-element-network-settings.md)|Specifies modules to use to request information from network hosts.|  
  
## Remarks  
 The `prefix` attribute defines the URI prefix that uses the specified Web request module. Web request modules are typically registered to handle a specific protocol, such as HTTP or FTP, but can be registered to handle a request to a specific server or path on a server.  
  
 The Web request module is created when a URI matching prefix is passed to the <xref:System.Net.WebRequest.Create%2A?displayProperty=nameWithType> method.  
  
 The value for the `prefix` attribute should be the leading characters of a valid URI --for example, "http", or "http://www.contoso.com".  
  
 The value for the `type` attribute should be a valid type name and corresponding assembly name, separated by a comma .  
  
## Configuration Files  
 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  
 The following example registers a custom Web request module for HTTP. You should replace the values for Version and PublicKeyToken with the correct values for the specified module.  
  
```xml  
<configuration>  
  <system.net>  
    <webRequestModules>  
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
