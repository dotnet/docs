---
title: "<proxy> Element (Network Settings)"
description: The <proxy> network settings element defines the proxy server options in the .NET Framework. This article includes an example.
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/defaultProxy/proxy"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#proxy"
helpviewer_keywords: 
  - "<proxy> element"
  - "proxy element"
ms.assetid: 37a548d8-fade-4ac5-82ec-b49b6c6cb22a
---
# \<proxy> Element (Network Settings)

Defines a proxy server.  

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.net>**](system-net-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<defaultProxy>**](defaultproxy-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<proxy>**

## Syntax  
  
```xml  
<proxy
  autoDetect="True|False|Unspecified"
  bypassonlocal="True|False|Unspecified"
  proxyaddress="uriString"
  scriptLocation="uriString"
  usesystemdefault="True|False|Unspecified"
/>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|**Attribute**|**Description**|  
|-------------------|---------------------|  
|`autoDetect`|Specifies whether the proxy is automatically detected. The default value is `Unspecified`.|  
|`bypassonlocal`|Specifies whether the proxy is bypassed for local resources. Local resources include the local server (`http://localhost`, `http://loopback`, or `http://127.0.0.1`) and a URI without a period (`http://webserver`). The default value is `Unspecified`.|  
|`proxyaddress`|Specifies the proxy URI to use.|  
|`scriptLocation`|Specifies the location of the configuration script. Do not use the `bypassonlocal` attribute with this attribute. |  
|`usesystemdefault`|Specifies whether to use system proxy settings. If set to `True`, subsequent attributes will override system proxy settings. The default value is `Unspecified`.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[defaultProxy](defaultproxy-element-network-settings.md)|Configures the Hypertext Transfer Protocol (HTTP) proxy server.|  
  
## Text Value  
  
## Remarks  

 The `proxy` element defines a proxy server for an application. If this element is missing from the configuration file, then .NET Framework will use the system proxy settings.  
  
 The value for the `proxyaddress` attribute should be a well-formed Uniform Resource Indicator (URI).  
  
 The `scriptLocation` attribute refers to the automatic detection of proxy configuration scripts. The <xref:System.Net.WebProxy> class will attempt to locate a configuration script (usually named Wpad.dat) when the **Use automatic configuration script** option is selected for the connection in Internet properties. If `bypassonlocal` is set to any value, `scriptLocation` is ignored.
  
 An exception is thrown if the `proxyaddress` attribute specifies an invalid default proxy. The <xref:System.Exception.InnerException%2A> property on the exception should have more information about the root cause of the error.  
  
## Configuration Files  

 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  

 The following example uses the defaults from the system proxy, specifies the proxy address, and bypasses the proxy for local access.  
  
```xml  
<configuration>  
  <system.net>  
    <defaultProxy>  
      <proxy  
        usesystemdefault="True"  
        proxyaddress="http://192.168.1.10:3128"  
        bypassonlocal="True"  
      />  
    </defaultProxy>  
  </system.net>  
</configuration>  
```  
  
## See also

- <xref:System.Net.WebProxy?displayProperty=nameWithType>
- [Network Settings Schema](index.md)
