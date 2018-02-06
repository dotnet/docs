---
title: "&lt;filterTable&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e9f05441-3ad1-49b9-a267-71724aa094b4
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;filterTable&gt;
Represents a routing table that contains a list of filters to evaluate messages against and the client endpoint to route messages to if the filter evaluates to true.  
  
 \<system.serviceModel>  
\<routing>  
\<routingTables>  
\<table>  
  
## Syntax  
  
```xml
   <routing>      <filterTables>        <filterTable name="String">          <entries>            <add backupList="String"                 endpointName="String"                  filterName="String"                  priority="Integer" />          </entries>        </table>      </routingTables></routing>  
```

## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Element|Description|  
|-------------|-----------------|  
|name|A string that contains the unique name of this configuration element.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<filters>](../../../../../docs/framework/configure-apps/file-schema/wcf/filters-of-routing.md)|Mappings between the routing filters and the target endpoints to send messages to when the filter matches.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<routing>](../../../../../docs/framework/configure-apps/file-schema/wcf/routing.md)|A configuration section that contains routing tables.|  
  
## See Also  
 <xref:System.ServiceModel.Routing.Configuration.RoutingSection?displayProperty=nameWithType>    
