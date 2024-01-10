---
description: "Learn more about: SqlStreamChars.SetLength(Int64) Method"
title: SqlStreamChars.SetLength(Int64) Method (System.Data.SqlTypes)
author: stevestein
ms.date: 12/20/2018
ms.subservice: "data-access"
topic_type:
  - "apiref"
api_name:
  - "System.Data.SqlTypes.SqlStreamChars.SetLength"
api_location:
  - "System.Data.dll"
api_type:
  - "Assembly"
---
# SqlStreamChars.SetLength(Int64) Method

When overridden in a derived class, releases the resources used by the stream. The assembly that contains this method has a friend relationship with SQLAccess.dll. It's intended for use by SQL Server. For other databases, use the hosting mechanism provided by that database.

```csharp
public abstract void SetLength (long value);
```

## Parameters

`value`\
The desired length of the current stream in bytes.

## Remarks

> [!WARNING]
> The `SqlStreamChars.SetLength` method is private and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this method in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.Data.SqlTypes>

**Assembly:** System.Data (in System.Data.dll)

**.NET Framework versions:** Available since 2.0.
