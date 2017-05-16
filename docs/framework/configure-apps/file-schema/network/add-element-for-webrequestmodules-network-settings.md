---
title: "&lt;add&gt; Element for webRequestModules (Network Settings) | Microsoft Docs"
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
dev_langs: 
  - "VB"
  - "CSharp"
  - "C++"
  - "jsharp"
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
---
# &lt;add&gt; Element for webRequestModules (Network Settings)
Adds a custom Web request module to the application.  
  
 \<configuration>  
\<system.net>  
\<webRequestModules>  
\<add>  
  
## Syntax  
  
```  
  
      <add   
  prefix = "URI prefix"   
  type = "module name, Version, Culture, PublicKeyToken"   
/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|**Attribute**|**Description**|  
|-------------------|---------------------|  
|`prefix`|The URI prefix for requests handled by this Web request module.|  
|`type`|The assembly and class name of the module that implements this Web request module.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[webRequestModules](../../../../../docs/framework/configure-apps/file-schema/network/webrequestmodules-element-network-settings.md)|Specifies modules to use to request information from network hosts.|  
  
## Remarks  
 The `prefix` attribute defines the URI prefix that uses the specified Web request module. Web request modules are typically registered to handle a specific protocol, such as HTTP or FTP, but can be registered to handle a request to a specific server or path on a server.  
  
 The Web request module is created when a URI matching prefix is passed to the <xref:System.Net.WebRequest.Create%2A?displayProperty=fullName> method.  
  
 The value for the `prefix` attribute should be the leading characters of a valid UR --for example, "http", or "http://www.contoso.com".  
  
 The value for the `type` attribute should be a valid DLL name and corresponding class name, separated by a comma .  
  
## Configuration Files  
 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  
 The following code example registers a custom Web request module for HTTP. You should replace the values for Version and PublicKeyToken with the correct values for the specified module.  
  
```  
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
