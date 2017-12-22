---
title: "&lt;filter&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3266700b-904b-44e4-93a7-e06a1a445100
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# &lt;filter&gt;

Defines a routing filter, which determines the type of [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)]<xref:System.ServiceModel.Dispatcher.MessageFilter> to be used when evaluating incoming messages, as well any supporting data or parameters required by the filter.

\<system.serviceModel>
\<routing>
\<filters>
\<filter>

## Syntax

```xml
<routing>
  <filters>
    <filter customType="String" 
            filterData="String" 
            filterType="Action/Address/AddressPrefix/And/Custom/Endpoint/MatchAll/XPath" 
            name="String" />
  </filters>
</routing>
```

## Attributes and elements

The following sections describe attributes, child elements, and parent elements.

### Attributes

| Attribute  | Description |
| ---------- | ----------- |
| customType | A string containing the fully qualified type name of the custom type to be used as a filter. If `filterType` is set to `custom`, this attribute contains the fully qualified type name of the class to create.  `filterData` may also contain values to be used during evaluation of the custom type filter. |
| filterData | A string containing the filter data. For more information on how to specify this attribute, see <xref:System.ServiceModel.Routing.Configuration.FilterElement.FilterData%2A>. |
| filterType | A string containing the filter type. This attribute is of <xref:System.ServiceModel.Routing.Configuration.FilterType> type.  For more information on how this works with the `filterData` attribute, see <xref:System.ServiceModel.Routing.Configuration.FilterElement.FilterData%2A>. |
| name       | A string containing the unique name of this filter element. |

### Child elements

None.

### Parent elements

| Element | Description |
| ------- | ----------- |
| [\<routing>](../../../../../docs/framework/configure-apps/file-schema/wcf/routing.md) | A configuration section for defining a set of routing filters, which determine the type of [!INCLUDE[ indigo1](../../../../../includes/indigo1-md.md)]<xref:System.ServiceModel.Dispatcher.MessageFilter> to be used when evaluating incoming messages. |

## See also

<xref:System.ServiceModel.Routing.Configuration.FilterElement?displayProperty=nameWithType>    
<xref:System.ServiceModel.Routing.Configuration.FilterElement.FilterData%2A?displayProperty=nameWithType>   
<xref:System.ServiceModel.Routing.Configuration.FilterType?displayProperty=nameWithType>   
