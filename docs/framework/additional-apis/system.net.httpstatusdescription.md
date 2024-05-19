---
description: "Learn more about: HttpStatusDescription class"
title: HttpStatusDescription class (System.Net)
ms.date: 06/12/2020
ms.subservice: networking
topic_type:
  - apiref
api_name:
  - System.Net.HttpStatusDescription
  - System.Net.HttpStatusDescription.Get
api_location:
  - System.dll
api_type:
  - Assembly
---
# HttpStatusDescription class

Provides standard HTTP status descriptions. This class cannot be inherited.

```csharp
internal static class HttpStatusDescription
```

> [!WARNING]
> This class is internal and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this class in a production application under any circumstance.

## Get method

Returns the description associated with the specified HTTP status code.

```csharp
internal static string Get(int code)
```

### Parameters

`code` <xref:System.Int32>

The HTTP status code, for example, `404`.

### Return value

<xref:System.String?displayProperty=nameWithType>

The HTTP status description.

## Requirements

**Namespace:** <xref:System.Net>

**Assembly:** System (in System.dll)
