---
title: SqlStreamChars.IsNull Property (System.Data.SqlTypes)
author: stevestein
ms.author: sstein
ms.date: 12/19/2018
ms.technology: "dotnet-data"
topic_type:
  - "apiref"
api_name:
  - "System.Data.SqlTypes.SqlStreamChars.IsNull"
  - "System.Data.SqlTypes.SqlStreamChars.get_IsNull"
api_location:
  - "System.Data.dll"
api_type:
  - "Assembly"
---
# SqlStreamChars.IsNull Property

When overridden in a derived class, gets a value that indicates whether the stream is `null`. The assembly that contains this property has a friend relationship with SQLAccess.dll. It's intended for use by SQL Server. For other databases, use the hosting mechanism provided by that database.

## Syntax

```csharp
public abstract bool IsNull { get; }
```

## Property value

<xref:System.Boolean>\
`true` if the stream is `null`; otherwise, `false`.

## Remarks

> [!WARNING]
> The `SqlStreamChars.IsNull` property is private and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this field in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.Data.SqlTypes>

**Assembly:** System.Data (in System.Data.dll)

**.NET Framework versions:** Available since 2.0.
