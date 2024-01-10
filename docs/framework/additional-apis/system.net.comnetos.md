---
description: "Learn more about: ComNetOS class"
title: ComNetOS class (System.Net)
ms.date: 06/12/2020
ms.subservice: networking
topic_type:
  - apiref
api_name:
  - System.Net.ComNetOS
  - System.Net.ComNetOS.IsWin7orLater
api_location:
  - System.dll
api_type:
  - Assembly
---
# ComNetOS class

Provides information about the current operating system, such as its version and installation type (client or server). This class cannot be inherited.

```csharp
internal static class ComNetOS
```

> [!WARNING]
> This class is internal and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this class in a production application under any circumstance.

## IsWin7orLater field

Specifies whether the operating system version is Windows 7 or later.

```csharp
internal static readonly bool IsWin7orLater
```

## Requirements

**Namespace:** <xref:System.Net>

**Assembly:** System (in System.dll)
