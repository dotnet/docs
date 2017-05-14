---
title: "&lt;routing&gt; | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a210c209-3940-4288-9a8e-39b1e62606bc
caps.latest.revision: 4
author: "Erikre"
ms.author: "erikre"
manager: "erikre"
---
# &lt;routing&gt;
Represents a configuration section for defining a set of routing filters, which determine the type of [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)]<xref:System.ServiceModel.Dispatcher.MessageFilter> to be used when evaluating incoming messages, as well as routing tables that define the target endpoints to send messages to when a filter matches.  
  
 \<system.serviceModel>  
\<routing>  
  
## Syntax  
  
```vb  
   <routing>      <filters>        <filter customType="String"                filterData="String"                filterType="Action/Address/AddressPrefix/And/Custom/Endpoint/MatchAll/XPath"                 name="String" />      </filters>      <routingTables>        <table name="String">          <entries>            <add endpoint="String"                  filterName="String"                  priority="Integer" />          </entries>        </table>      </routingTables></routing>  
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
|[\<filters>](../../../../../docs/framework/configure-apps/file-schema/wcf/filters-of-routing.md)|Contains a set of routing filters that determine the type of [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] MessageFilter will be used when evaluating incoming messages.|  
|[\<filterTables>](../../../../../docs/framework/configure-apps/file-schema/wcf/filtertables.md)|Contains mappings between the routing filters and the target endpoints to specify which endpoint to use when the filter matches.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|system.ServiceModel|The root element of all WCF configuration elements.|  
  
## See Also  
 <xref:System.ServiceModel.Routing.Configuration.RoutingSection?displayProperty=fullName>    
