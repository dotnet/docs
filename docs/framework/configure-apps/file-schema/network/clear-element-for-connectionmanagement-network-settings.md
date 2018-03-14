---
title: "&lt;clear&gt; Element for connectionManagement (Network Settings)"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/connectionManagement/clear"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#clear"
helpviewer_keywords: 
  - "<clear> element, connectionManagement"
  - "connectionManagement, clear element"
  - "clear element, connectionManagement"
  - "<connectionManagement>, clear element"
ms.assetid: fb259282-84c4-4dc4-a226-78d904a6edc3
caps.latest.revision: 13
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;clear&gt; Element for connectionManagement (Network Settings)
Clears the connection management list.  
  
 \<configuration>  
\<system.net>  
\<connectionManagement>  
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
|[connectionManagement](../../../../../docs/framework/configure-apps/file-schema/network/connectionmanagement-element-network-settings.md)|Specifies the maximum number of connections to a network host.|  
  
## Remarks  
 The `clear` element clears all entries from the connection management list.  
  
## Configuration Files  
 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  
 The following example clears the connection management list and then adds new connection management entries for the server www.contoso.com and all other network hosts.  
  
```xml  
<configuration>  
  <system.net>  
    <connectionManagement>  
      <clear/>  
      <add address = "http://www.contoso.com" maxconnection = "4" />  
      <add address = "*" maxconnection = "2" />  
    </connectionManagement>  
  </system.net>  
</configuration>  
```  
  
## See Also  
 <xref:System.Net.ServicePoint>  
 <xref:System.Net.ServicePointManager>  
 [Network Settings Schema](../../../../../docs/framework/configure-apps/file-schema/network/index.md)
