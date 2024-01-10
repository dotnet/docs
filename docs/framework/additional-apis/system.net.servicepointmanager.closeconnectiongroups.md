---
description: "Learn more about: ServicePointManager.CloseConnectionGroups method"
title: ServicePointManager.CloseConnectionGroups method (System.Net)
ms.date: 06/12/2020
ms.subservice: networking
topic_type:
  - apiref
api_name:
  - System.Net.ServicePointManager.CloseConnectionGroups
api_location:
  - System.dll
api_type:
  - Assembly
---
# ServicePointManager.CloseConnectionGroups method

Iterates through all service points and closes connection groups that have the specified name.

```csharp
internal static void CloseConnectionGroups(string connectionGroupName)
```

> [!WARNING]
> This method is internal and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this method in a production application under any circumstance.

## Parameters

`connectionGroupName` <xref:System.String>

The name of the connection group to close.

## Requirements

**Namespace:** <xref:System.Net>

**Assembly:** System (in System.dll)
