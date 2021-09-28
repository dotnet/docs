---
description: "Learn more about: <filter>"
title: "<filter>"
ms.date: "03/30/2017"
ms.assetid: 3266700b-904b-44e4-93a7-e06a1a445100
---

# \<filter>

Defines a routing filter, which determines the type of Windows Communication Foundation (WCF)<xref:System.ServiceModel.Dispatcher.MessageFilter> to be used when evaluating incoming messages, as well any supporting data or parameters required by the filter.

[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;[**\<routing>**](routing.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<filters>**](filters-of-routing.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<filter>**  
  
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
| [\<routing>](routing.md) | A configuration section for defining a set of routing filters, which determine the type of Windows Communication Foundation (WCF)<xref:System.ServiceModel.Dispatcher.MessageFilter> to be used when evaluating incoming messages. |

## See also

- <xref:System.ServiceModel.Routing.Configuration.FilterElement?displayProperty=nameWithType>
- <xref:System.ServiceModel.Routing.Configuration.FilterElement.FilterData%2A?displayProperty=nameWithType>
- <xref:System.ServiceModel.Routing.Configuration.FilterType?displayProperty=nameWithType>
