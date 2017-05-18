---
title: "&lt;entries&gt; | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 202e430c-c1b9-4343-abe2-ac78c181a3b7
caps.latest.revision: 5
author: "Erikre"
ms.author: "erikre"
manager: "erikre"
---
# &lt;entries&gt;
A routing entry that contain mappings between the routing filters and the target endpoints to send messages to when the filter matches.  
  
 \<system.serviceModel>  
\<routing>  
\<routingTables>  
\<table>  
\<entries>  
  
## Syntax  
  
```vb  
   <routing>      <filterTables>        <filterTable name="String">          <entries>            <add backupList="String"                 endpointName="String"                  filterName="String"                  priority="Integer" />          </entries>        </table>      </routingTables></routing>  
```  
  
```csharp  
  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<filters>](../../../../../docs/framework/configure-apps/file-schema/wcf/filters-of-routing.md)|Maps a filter to a client endpoint that was previously defined. Messages matching this filter will be sent to this destination.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<routing>](../../../../../docs/framework/configure-apps/file-schema/wcf/routing.md)|A configuration section that contains a routing table.|  
  
## See Also  
 <xref:System.ServiceModel.Routing.Configuration.RoutingSection?displayProperty=fullName>       
 <xref:System.ServiceModel.Routing.Configuration.FilterTableEntryElement?displayProperty=fullName>    
