---
title: "<routing>"
ms.date: "03/30/2017"
ms.assetid: a210c209-3940-4288-9a8e-39b1e62606bc
---

# \<routing>

Represents a configuration section for defining a set of routing filters, which determine the type of Windows Communication Foundation (WCF) <xref:System.ServiceModel.Dispatcher.MessageFilter> to be used when evaluating incoming messages, as well as routing tables that define the target endpoints to send messages to when a filter matches.

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<routing>**
  
## Syntax  
  
```xml  
<system.serviceModel>
  <routing>
    <filters>
      <filter customType="String"
              filterData="String"
              filterType="Action/Address/AddressPrefix/And/Custom/Endpoint/MatchAll/XPath"
              name="String" />
    </filters>
    <routingTables>
      <table name="String">
        <entries>
          <add endpoint="String"
               filterName="String"
               priority="Integer" />
        </entries>
      </table>
    </routingTables>
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
| [**\<filters>**](filters-of-routing.md) | Contains a set of routing filters that determine the type of Windows Communication Foundation (WCF) MessageFilter will be used when evaluating incoming messages. |
| [**\<filterTables>**](filtertables.md) | Contains mappings between the routing filters and the target endpoints to specify which endpoint to use when the filter matches. |

### Parent elements

|     | Description |
| --- | ----------- |
| **\<system.ServiceModel>** | The root element of all WCF configuration elements. |

## See also

- <xref:System.ServiceModel.Routing.Configuration.RoutingSection?displayProperty=nameWithType>
