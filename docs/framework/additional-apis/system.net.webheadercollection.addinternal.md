---
description: "Learn more about: WebHeaderCollection.AddInternal method"
title: WebHeaderCollection.AddInternal method (System.Net)
ms.date: 06/12/2020
ms.subservice: networking
topic_type:
  - apiref
api_name:
  - System.Net.WebHeaderCollection.AddInternal
api_location:
  - System.dll
api_type:
  - Assembly
---
# WebHeaderCollection.AddInternal method

Adds a new header with the specified name and value to the collection, bypassing checks.

```csharp
internal void AddInternal(string name, string value)
```

> [!WARNING]
> This method is internal and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this method in a production application under any circumstance.

## Parameters

- `name` <xref:System.String>

  The name of the header.

- `value` <xref:System.String>

  The value of the header.

## Requirements

**Namespace:** <xref:System.Net>

**Assembly:** System (in System.dll)
