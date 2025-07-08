---
description: "Learn more about: SqlStreamChars.CanSeek Property"
title: SqlStreamChars.CanSeek Property (System.Data.SqlTypes)
author: stevestein
ms.date: 12/19/2018
ms.subservice: "data-access"
topic_type:
  - "apiref"
api_name:
  - "System.Data.SqlTypes.SqlStreamChars.CanSeek"
  - "System.Data.SqlTypes.SqlStreamChars.get_CanSeek"
api_location:
  - "System.Data.dll"
api_type:
  - "Assembly"
---
# SqlStreamChars.CanSeek Property

When overridden in a derived class, gets a value that indicates whether the current steam supports the seek operation. The assembly that contains this property has a friend relationship with SQLAccess.dll. It's intended for use by SQL Server. For other databases, use the hosting mechanism provided by that database.

```csharp
public abstract bool CanSeek { get; }
```

## Property value

<xref:System.Boolean>\
`true` if the current steam supports the seek operation; otherwise, `false`.

## Remarks

> [!WARNING]
> The `SqlStreamChars.CanSeek` property is private and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this property in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.Data.SqlTypes>

**Assembly:** System.Data (in System.Data.dll)

**.NET Framework versions:** Available since 2.0.
