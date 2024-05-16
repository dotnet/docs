---
description: "Learn more about: SqlStreamChars.Flush Method"
title: SqlStreamChars.Flush Method (System.Data.SqlTypes)
author: stevestein
ms.date: 12/20/2018
ms.subservice: "data-access"
topic_type:
  - "apiref"
api_name:
  - "System.Data.SqlTypes.SqlStreamChars.Flush"
api_location:
  - "System.Data.dll"
api_type:
  - "Assembly"
---
# SqlStreamChars.Flush Method

When overridden in a derived class, clears all buffers for this stream and causes any buffered data to be written to the underlying device. The assembly that contains this method has a friend relationship with SQLAccess.dll. It's intended for use by SQL Server. For other databases, use the hosting mechanism provided by that database.

## Syntax

```csharp
public abstract void Flush ();
```

## Remarks

> [!WARNING]
> The `SqlStreamChars.Flush` method is private and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this method in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.Data.SqlTypes>

**Assembly:** System.Data (in System.Data.dll)

**.NET Framework versions:** Available since 2.0.
