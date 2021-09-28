---
description: "Learn more about: <authenticationModules> Element (Network Settings)"
title: "<authenticationModules> Element (Network Settings)"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#authenticationModules"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/authenticationModules"
helpviewer_keywords: 
  - "authenticationModules element"
  - "<authenticationModules> element"
ms.assetid: 10fcfaad-82ef-4692-871a-0aec9dfbe75e
---
# \<authenticationModules> Element (Network Settings)

Specifies modules used to authenticate network requests.  

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.net>**](system-net-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<authenticationModules>**

## Syntax  
  
```xml  
<authenticationModules>
</authenticationModules>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  

 None.  
  
### Child Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[add](add-element-for-authenticationmodules-network-settings.md)|Adds an authentication module to the application.|  
|[clear](clear-element-for-authenticationmodules-network-settings.md)|Clears all authentication modules from the application.|  
|[remove](remove-element-for-authenticationmodules-network-settings.md)|Removes an authentication module from the application.|  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[system.net](system-net-element-network-settings.md)|Contains settings that specify how the .NET Framework connects to the network.|  
  
## Remarks  

 The `authenticationModule` element specifies the authentication modules that conduct the authentication process with a server. An authentication module must implement the <xref:System.Net.IAuthenticationModule> interface.  
  
## Configuration Files  

 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  

 The following example enables an authentication module. You should replace the values for Version and PublicKeyToken with the correct values for the specified module.  
  
```xml  
<configuration>  
  <system.net>  
    <authenticationModules>  
      <add type="System.Net.DigestClient, System, Version=2.0.3600.0,  
                 Culture=neutral, PublicKeyToken=b77a5c561934e089" />  
    </authenticationModules>  
  </system.net>  
</configuration>  
```  
  
## See also

- <xref:System.Net.IAuthenticationModule>
- <xref:System.Net.AuthenticationManager>
- [Network Settings Schema](index.md)
