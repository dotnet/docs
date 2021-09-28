---
description: "Learn more about: <namespaceTable>"
title: "<namespaceTable>"
ms.date: "03/30/2017"
ms.assetid: 64801766-01b7-4c65-9ce6-70ad5af67689
---

# \<namespaceTable>

Represents a configuration section for defining a set of elements that contain namespace to prefix mappings that can then be used in XPath filters for routing.

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<routing>**](routing.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<namespaceTable>**  
  
## Syntax  
  
```xml  
<system.serviceModel>
  <routing>
    <namespaceTable>
      <add namespace="String"
           prefix="String" />
    </namespaceTable>
  </routing>
</system.serviceModel>
```  
  
## Attributes and elements

The following sections describe attributes, child elements, and parent elements.

### Attributes

None

### Child elements

|     | Description |
| --- | ----------- |
| [**\<filter>**](filter.md) | Defines a namespace prefix mapping used for XPath expressions. |

### Parent elements

|     | Description |
| --- | ----------- |
| [**\<routing>**](routing.md) | Represents a configuration section for defining a set of routing filters, which determine the type of Windows Communication Foundation (WCF)<xref:System.ServiceModel.Dispatcher.MessageFilter> to be used when evaluating incoming messages, as well as routing tables that define the target endpoints to send messages to when a filter matches. |

## See also

- <xref:System.ServiceModel.Routing.Configuration.NamespaceElementCollection?displayProperty=nameWithType>
