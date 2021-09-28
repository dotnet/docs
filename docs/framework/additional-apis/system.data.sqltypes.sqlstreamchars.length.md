---
description: "Learn more about: SqlStreamChars.Length Property"
title: SqlStreamChars.Length Property (System.Data.SqlTypes)
author: stevestein
ms.date: 12/19/2018
ms.technology: "dotnet-data"
topic_type:
  - "apiref"
api_name:
  - "System.Data.SqlTypes.SqlStreamChars.Length"
  - "System.Data.SqlTypes.SqlStreamChars.get_Length"
api_location:
  - "System.Data.dll"
api_type:
  - "Assembly"
---
# SqlStreamChars.Length Property

When overridden in a derived class, gets the length of the current stream. The assembly that contains this property has a friend relationship with SQLAccess.dll. It's intended for use by SQL Server. For other databases, use the hosting mechanism provided by that database.

## Syntax

```csharp
public abstract long Length { get; }
```

## Property value

<xref:System.Int64>\
The length of the stream.

## Remarks

> [!WARNING]
> The `SqlStreamChars.Length` property is private and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this property in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.Data.SqlTypes>

**Assembly:** System.Data (in System.Data.dll)

**.NET Framework versions:** Available since 2.0.
