---
description: "Learn more about: <remove> Element for authenticationModules (Network Settings)"
title: "<remove> Element for authenticationModules (Network Settings)"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/authenticationModules/remove"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#remove"
helpviewer_keywords: 
  - "remove element, authenticationModules"
  - "<authenticationModules>, remove element"
  - "<remove> element, authenticationModules"
  - "authenticationModules, remove element"
ms.assetid: abf79949-b05c-465a-b51c-bbeda9a74173
---
# \<remove> Element for authenticationModules (Network Settings)

Removes an authentication module from the application.  

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.net>**](system-net-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<authenticationModules>**](authenticationmodules-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<remove>**

## Syntax  
  
```xml  
<remove
   type="authentication module name"
/>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|**Attribute**|**Description**|  
|-------------------|---------------------|  
|**type**|The name of the authentication module to remove.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[authenticationModules](authenticationmodules-element-network-settings.md)|Specifies modules used to authenticate network requests.|  
  
## Remarks  

 The `remove` element removes authentication modules that were defined earlier in the configuration file or at a higher level in the configuration hierarchy.  
  
 The value for the `type` attribute should be a valid class name.  
  
## Configuration Files  

 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  

 The following example removes an authentication module.  
  
```xml  
<configuration>  
  <system.net>  
    <authenticationModules>  
      <remove type="System.Net.NtlmClient" />  
    </authenticationModules>  
  </system.net>  
</configuration>  
```  
  
## See also

- <xref:System.Net.IAuthenticationModule>
- <xref:System.Net.AuthenticationManager>
- [Network Settings Schema](index.md)
