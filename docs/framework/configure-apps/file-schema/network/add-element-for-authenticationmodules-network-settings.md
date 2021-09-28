---
title: "<add> Element for authenticationModules (Network Settings)"
description: The <add> network settings element for connectionManagement adds an IP address or DNS name to the connection management list in the .NET Framework.
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#add"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/authenticationModules/add"
helpviewer_keywords: 
  - "authenticationModules, add element"
  - "add element, authenticationModules"
  - "<authenticationModules>, add element"
  - "<add> element, authenticationModules"
ms.assetid: 333c5fb0-a2ab-4db8-8531-a7fe37bb9b5b
---
# \<add> Element for authenticationModules (Network Settings)

Adds an authentication module to the application.  

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.net>**](system-net-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<authenticationModules>**](authenticationmodules-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<add>**

## Syntax  
  
```xml  
<add
  type="type_fullname, assembly_fullname"
/>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|**Attribute**|**Description**|  
|-------------------|---------------------|  
|`type`|The fully qualified type name (indicated by the <xref:System.Type.FullName%2A> property) and the assembly name (indicated by the <xref:System.Reflection.Assembly.FullName%2A> property), separated by a comma.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[authenticationModules](authenticationmodules-element-network-settings.md)|Specifies modules used to authenticate network requests.|  
  
## Remarks  

 The `add` element adds an authentication module to the end of the list of registered authentication modules. Authentication modules are called in the order in which they were added to the list.  
  
 The value for the `type` attribute should be a valid type name and corresponding assembly name, separated by a comma.  
  
## Configuration Files  

 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  

 The following example enables the default authentication modules. You should replace the values for Version and PublicKeyToken with the correct values for the specified module.  
  
```xml  
<configuration>  
  <system.net>  
        <authenticationModules>  
            <add type="System.Net.DigestClient, System, Version=2.0.3600.0,  
                 Culture=neutral, PublicKeyToken=b77a5c561934e089" />  
            <add type="System.Net.NegotiateClient, System, Version=2.0.3600.0,  
                 Culture=neutral, PublicKeyToken=b77a5c561934e089" />  
            <add type="System.Net.KerberosClient, System, Version=2.0.3600.0,  
                 Culture=neutral, PublicKeyToken=b77a5c561934e089" />  
            <add type="System.Net.NtlmClient, System, Version=2.0.3600.0,  
                 Culture=neutral, PublicKeyToken=b77a5c561934e089" />  
            <add type="System.Net.BasicClient, System, Version=2.0.3600.0,  
                 Culture=neutral, PublicKeyToken=b77a5c561934e089" />  
        </authenticationModules>  
  </system.net>  
</configuration>  
```  
  
## See also

- <xref:System.Net.IAuthenticationModule>
- <xref:System.Net.AuthenticationManager>
- [Network Settings Schema](index.md)
