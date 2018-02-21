---
title: "&lt;remove&gt; Element for connectionManagement (Network Settings)"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/connectionManagement/remove"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#remove"
helpviewer_keywords: 
  - "connectionManagement, remove element"
  - "<remove> element, connectionManagement"
  - "<connectionManagement>, remove element"
  - "remove element, connectionManagement"
ms.assetid: 94b81775-5a22-4975-8c47-8620c40c3f35
caps.latest.revision: 12
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;remove&gt; Element for connectionManagement (Network Settings)
Removes an IP address or DNS name from the connection management list.  
  
 \<configuration>  
\<system.net>  
\<connectionManagement>  
\<remove>  
  
## Syntax  
  
```xml  
<remove   
  address="server name or IP address"   
/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|**Attribute**|**Description**|  
|-------------------|---------------------|  
|`address`|An IP address or DNS name.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[connectionManagement](../../../../../docs/framework/configure-apps/file-schema/network/connectionmanagement-element-network-settings.md)|Specifies the maximum number of connections to a network host.|  
  
## Remarks  
 The `remove` element removes the connection management list entry for the specified server.  
  
 The value of the `address` attribute should be a valid IP address or host name.  
  
## Configuration Files  
 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  
 The following example removes any connection management list entries for the server www.adventure-works.com and then configures an application to use four connections to the server www.contoso.com and two connections to all other servers.  
  
```xml  
<configuration>  
  <system.net>  
    <connectionManagement>  
      <remove address="http://www.adventure-works.com" />  
      <add address="http://www.contoso.com" maxconnection="4" />  
      <add address="*" maxconnection="2" />  
    </connectionManagement>  
  </system.net>  
</configuration>  
```  
  
## See Also  
 <xref:System.Net.ServicePoint>  
 <xref:System.Net.ServicePointManager>  
 [Network Settings Schema](../../../../../docs/framework/configure-apps/file-schema/network/index.md)
