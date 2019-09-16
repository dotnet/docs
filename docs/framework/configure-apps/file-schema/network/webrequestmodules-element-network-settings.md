---
title: "<webRequestModules> Element (Network Settings)"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/webRequestModules"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#webRequestModules"
helpviewer_keywords: 
  - "webRequestModules element"
  - "<webRequestModules> element"
ms.assetid: 1263de11-3e0a-4f94-97c9-710b2ae53817
---
# \<webRequestModules> Element (Network Settings)
Specifies modules to use to request information from network hosts.  
  
 \<configuration>  
\<system.net>  
\<webRequestModules>  
  
## Syntax  
  
```xml  
<webRequestModules>   
</webRequestModules>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[add](add-element-for-webrequestmodules-network-settings.md)|Adds a custom Web request module to the application.|  
|[clear](clear-element-for-webrequestmodules-network-settings.md)|Removes all registered Web request modules from the application.|  
|[remove](remove-element-for-webrequestmodules-network-settings.md)|Removes a custom Web request module from the application.|  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[system.net](system-net-element-network-settings.md)|Contains settings that specify how the .NET Framework connects to the network.|  
  
## Remarks  
 The `webRequestModules` element registers descendants of the <xref:System.Net.WebRequest> class to handle information requests to network hosts. Web request modules must implement the <xref:System.Net.IWebRequestCreate> interface.  
  
 The .NET Framework includes Web request modules for URIs that begin with `http://`, `https://`, and `file://`. You can override the default modules only by registering a custom module in the configuration file.  
  
## Configuration Files  
 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  
 The following example registers the default HTTP module. You should replace the values for Version and PublicKeyToken with the correct values for the specified module.  
  
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
  
## See also

- <xref:System.Net.WebRequest>
- <xref:System.Net.IWebRequestCreate>
- [Network Settings Schema](index.md)
