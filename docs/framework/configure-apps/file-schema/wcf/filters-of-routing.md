---
title: "&lt;filters&gt; of &lt;routing&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 7993cf90-9afd-4c3c-9608-184d5da1105c
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# &lt;filters&gt; of &lt;routing&gt;

Represents a configuration section for defining a set of routing filters, which determine the type of [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] <xref:System.ServiceModel.Dispatcher.MessageFilter> to be used when evaluating incoming messages.

[**\<system.serviceModel>**](system-servicemodel.md)   
&nbsp;&nbsp;[**\<routing>**](routing.md)   
&nbsp;&nbsp;&nbsp;&nbsp;**\<filters>**

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
| [**\<filter>**](../../../../../docs/framework/configure-apps/file-schema/wcf/filter.md) | Contains a routing filter that determines the type of [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)]<xref:System.ServiceModel.Dispatcher.MessageFilter> will be used when evaluating incoming messages. |

### Parent elements

|     | Description |
| --- | ----------- |
| [**\<routing>**](../../../../../docs/framework/configure-apps/file-schema/wcf/routing.md) | Represents a configuration section for defining a set of routing filters, which determine the type of [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)]<xref:System.ServiceModel.Dispatcher.MessageFilter> to be used when evaluating incoming messages, as well as routing tables that define the target endpoints to send messages to when a filter matches. |

## See also

<xref:System.ServiceModel.Routing.Configuration.FilterElement?displayProperty=nameWithType>
