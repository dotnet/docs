---
title: Exception.PrepForRemoting Method (System)
author: mairaw
ms.author: mairaw
ms.date: 10/08/2019
topic_type:
  - "apiref"
api_name:
  - "System.Exception.PrepForRemoting"
api_location:
  - "mscorlib.dll"
api_type:
  - "Assembly"
---
# Exception.PrepForRemoting Method

Preserves the server-side stack trace by appending it to the message before the exception is rethrown at the client call site.

```csharp
internal Exception PrepForRemoting();
```

## Returns

<xref:System.Exception>  
This <xref:System.Exception> instance.

## Remarks

> [!WARNING]
> The `Exception.PrepForRemoting` method is internal and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this method in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System>

**Assembly:** mscorlib.dll (in mscorlib.dll)

**.NET Framework versions:** Available since 1.0.
