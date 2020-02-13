---
title: Message.WriteStartHeaders Method (System.ServiceModel.Channels)
author: mairaw
ms.author: mairaw
ms.date: 11/01/2019
topic_type:
  - "apiref"
api_name:
  - "System.ServiceModel.Channels.Message.WriteStartHeaders"
api_location:
  - "system.servicemodel.dll"
api_type:
  - "Assembly"
---
# Message.WriteStartHeaders Method

Writes the start header into an XML file by calling the <xref:System.ServiceModel.Channels.Message.OnWriteStartHeaders%2A?displayProperty=nameWithType> method.

```csharp
internal void WriteStartHeaders(XmlDictionaryWriter writer)
```

## Parameters

- `writer` <xref:System.Xml.XmlDictionaryWriter>\
  The writer that is used to write the start header into an XML file.

## Remarks

> [!WARNING]
> The `Message.WriteStartHeaders` method is internal and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this method in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.ServiceModel.Channels>

**Assembly:** System.ServiceModel.dll

**.NET Framework versions:** Available since 3.0.
