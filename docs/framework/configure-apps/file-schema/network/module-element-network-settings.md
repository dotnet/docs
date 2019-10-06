---
title: "<module> Element (Network Settings)"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#module"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/defaultProxy/module"
helpviewer_keywords: 
  - "module element"
  - "<module> element"
ms.assetid: 10318725-9666-4d65-ab61-b94c64e59f13
---
# \<module> Element (Network Settings)
Adds a new proxy module to the application.  
  
[**\<configuration>**](../configuration-element.md)  
&nbsp;&nbsp;[**\<system.net>**](system-net-element-network-settings.md)  
&nbsp;&nbsp;&nbsp;&nbsp;[**\<defaultProxy>**](defaultproxy-element-network-settings.md)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<module>**  
  
## Syntax  
  
```xml  
<module   
  type="type_fullname, assembly_fullname"   
/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|**Attribute**|**Description**|  
|-------------------|---------------------|  
|`type`|The fully qualified type name (indicated by the <xref:System.Type.FullName%2A> property) and the assembly name (indicated by the <xref:System.Reflection.Assembly.FullName%2A> property), separated by a comma, that implements the proxy.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[defaultProxy](defaultproxy-element-network-settings.md)|Configures the Hypertext Transfer Protocol (HTTP) proxy server.|  
  
## Remarks  
 The `module` element registers proxy classes that implement the <xref:System.Net.IWebProxy> interface. After registering the proxy class, `module` can be used to request information through the supported proxy.  
  
 The value for the `type` attribute should be the class name of the module and the name of its corresponding Dynamic Link Library (DLL).  
  
## Configuration Files  
 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  
 The following example registers a custom proxy class.  
  
```xml  
<configuration>  
  <system.net>  
    <defaultProxy>  
      <module  
        type="Test.CustomWebProxy, TestProxy, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b23a5c561934e385"  
      />  
    </defaultProxy>  
  </system.net>  
</configuration>  
```  
  
## See also

- <xref:System.Net.IWebProxy?displayProperty=nameWithType>
- [Network Settings Schema](index.md)
