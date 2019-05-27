---
title: "<clear> Element for authenticationModules (Network Settings)"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/authenticationModules/clear"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#clear"
helpviewer_keywords: 
  - "clear element, authenticationModules"
  - "<authenticationModules>, clear element"
  - "<clear> element, authenticationModules"
  - "authenticationModules, clear element"
ms.assetid: dc522c45-4a80-4831-8955-f7b68a47edfd
---
# \<clear> Element for authenticationModules (Network Settings)
Clears all authentication modules from the application.  
  
 \<configuration>  
\<system.net>  
\<authenticationModules>  
\<clear>  
  
## Syntax  
  
```xml  
<clear/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[authenticationModules](../../../../../docs/framework/configure-apps/file-schema/network/authenticationmodules-element-network-settings.md)|Specifies modules used to authenticate network requests.|  
  
## Remarks  
 The `clear` element removes all authentication modules that were defined earlier in the configuration file or at a higher level in the configuration hierarchy.  
  
## Configuration Files  
 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  
 The following example removes all configured authentication modules.  
  
```xml  
<configuration>  
  <system.net>  
    <authenticationModules>  
      <clear/>  
    </authenticationModules>  
  </system.net>  
</configuration>  
```  
  
## See also

- <xref:System.Net.IAuthenticationModule>
- <xref:System.Net.AuthenticationManager>
- [Network Settings Schema](../../../../../docs/framework/configure-apps/file-schema/network/index.md)
