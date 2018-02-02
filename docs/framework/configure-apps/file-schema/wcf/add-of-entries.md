---
title: "&lt;add&gt; of &lt;entries&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3af4805b-dc72-4f68-b168-da4fba8c6170
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;add&gt; of &lt;entries&gt;
Represents a routing entry that maps a filter to a client endpoint that was previously defined. Messages matching this filter will be sent to this destination.  
  
 \<system.serviceModel>  
\<routing>  
\<routingTables>  
\<table>  
\<entries>  
\<add>  
  
## Syntax  
  
```xml
   <routing>      <filterTables>        <filterTable name="String">          <entries>            <add backupList="String"                 endpointName="String"                  filterName="String"                  priority="Integer" />          </entries>        </table>      </routingTables></routing>  
```  
  
```csharp  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|backupList|A string that specifies a reference to a backup list of endpoints.|  
|endpoint|A string that specifies a reference to a client endpoint that will receive messages that match the filter specified by the `filterName` attribute.|  
|filterName|A string that specifies a reference to a filter element.|  
|priority|An integer that specifies the priority of this entry.<br /><br /> Entries in the routing table will be evaluated based on priority, with 0 being the lowest priority. All entries for a specific priority are evaluated simultaneously, if no matching entry is found for the current priority, the next priority level will be evaluated.<br /><br /> This value is optional.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<routing>](../../../../../docs/framework/configure-apps/file-schema/wcf/routing.md)|A configuration section that contains routing mapping entries.|  
  
## See Also  
 <xref:System.ServiceModel.Routing.Configuration.RoutingSection?displayProperty=nameWithType>      
 <xref:System.ServiceModel.Routing.Configuration.FilterTableEntryElement?displayProperty=nameWithType> 
