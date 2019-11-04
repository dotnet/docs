---
title: SqlStreamChars.Dispose(Boolean) Method (System.Data.SqlTypes)
author: stevestein
ms.author: sstein
ms.date: 12/20/2018
ms.technology: "dotnet-data"
topic_type:
  - "apiref"
api_name:
  - "System.Data.SqlTypes.SqlStreamChars.Dispose"
api_location:
  - "System.Data.dll"
api_type:
  - "Assembly"
---
# SqlStreamChars.Dispose(Boolean) Method

When overridden in a derived class, releases the resources used by the stream. The assembly that contains this method has a friend relationship with SQLAccess.dll. It's intended for use by SQL Server. For other databases, use the hosting mechanism provided by that database.

```csharp
protected virtual void Dispose (bool disposing);
```

## Parameters

`disposing`\
`true` to release both managed and unmanaged resources; `false` to release only unmanaged resources.

## Remarks

> [!WARNING]
> The `SqlStreamChars.Dispose` method is private and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this method in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.Data.SqlTypes>

**Assembly:** System.Data (in System.Data.dll)

**.NET Framework versions:** Available since 2.0.
