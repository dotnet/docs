---
title: Message.BodyToString Method (System.ServiceModel.Channels)
author: mairaw
ms.author: mairaw
ms.date: 11/01/2019
topic_type:
  - "apiref"
api_name:
  - "System.ServiceModel.Channels.Message.BodyToString"
api_location:
  - "system.servicemodel.dll"
api_type:
  - "Assembly"
---
# Message.BodyToString Method

Converts the message body into a string by calling the <xref:System.ServiceModel.Channels.Message.OnBodyToString%2A?displayProperty=nameWithType> method.

```csharp
internal void BodyToString(XmlDictionaryWriter writer);
```

## Parameters

- `writer` <xref:System.Xml.XmlDictionaryWriter>\
  The writer that is used to convert the message body to a string.

## Remarks

> [!WARNING]
> The `Message.BodyToString` method is internal and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this method in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.ServiceModel.Channels>

**Assembly:** System.ServiceModel.dll

**.NET Framework versions:** Available since 3.0.
