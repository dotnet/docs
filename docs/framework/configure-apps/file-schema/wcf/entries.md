---
description: "Learn more about: <entries>"
title: "<entries>"
ms.date: "03/30/2017"
ms.assetid: 202e430c-c1b9-4343-abe2-ac78c181a3b7
---
# \<entries>

A routing entry that contain mappings between the routing filters and the target endpoints to send messages to when the filter matches.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<routing>**](routing.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<filterTables>**](filtertables.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<filterTable>**](filtertable.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<entries>**  
  
## Syntax  
  
```xml  
<routing>
  <filterTables>
    <filterTable name="String">
      <entries>
        <add backupList="String"
             endpointName="String"
             filterName="String"
             priority="Integer" />
      </entries>
    </filterTable>
  </filterTables>
</routing>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  

 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<filters>](filters-of-routing.md)|Maps a filter to a client endpoint that was previously defined. Messages matching this filter will be sent to this destination.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<routing>](routing.md)|A configuration section that contains a routing table.|  
  
## See also

- <xref:System.ServiceModel.Routing.Configuration.RoutingSection?displayProperty=nameWithType>
- <xref:System.ServiceModel.Routing.Configuration.FilterTableEntryElement?displayProperty=nameWithType>
