---
title: "&lt;connectionManagement&gt; Element (Network Settings)"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/connectionManagement"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#connectionManagement"
helpviewer_keywords: 
  - "<connectionManagement> element"
  - "connectionManagement element"
ms.assetid: bedccaab-12a2-4511-8f67-e961f249aec6
caps.latest.revision: 14
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;connectionManagement&gt; Element (Network Settings)
Specifies the maximum number of connections to a network host.  
  
 \<configuration>  
\<system.net>  
\<connectionManagement>  
  
## Syntax  
  
```xml  
<connectionManagement>   
</connectionManagement>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[add](../../../../../docs/framework/configure-apps/file-schema/network/add-element-for-connectionmanagement-network-settings.md)|Adds an IP address or DNS name to the connection management list.|  
|[clear](../../../../../docs/framework/configure-apps/file-schema/network/clear-element-for-connectionmanagement-network-settings.md)|Clears the connection management list.|  
|[remove](../../../../../docs/framework/configure-apps/file-schema/network/remove-element-for-connectionmanagement-network-settings.md)|Removes an IP address or DNS name from the connection management list.|  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[system.net](../../../../../docs/framework/configure-apps/file-schema/network/system-net-element-network-settings.md)|Contains settings that specify how the .NET Framework connects to the network.|  
  
## Remarks  
 The `connectionManagement` element defines the maximum number of connections to a server or group of servers.  
  
## Configuration Files  
 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  
 The following example configures an application to use four connections to the server www.contoso.com and two connections to all other servers.  
  
```xml  
<configuration>  
  <system.net>  
    <connectionManagement>  
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
