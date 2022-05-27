---
description: "Learn more about: SqlChars.Stream Property"
title: SqlChars.Stream Property (System.Data.SqlTypes)
author: stevestein
ms.date: 12/19/2018
ms.technology: "dotnet-data"
topic_type:
  - "apiref"
api_name:
  - "System.Data.SqlTypes.SqlChars.Stream"
  - "System.Data.SqlTypes.SqlChars.get_Stream"
  - "System.Data.SqlTypes.SqlChars.set_Stream"
api_location:
  - "System.Data.dll"
api_type:
  - "Assembly"
---
# SqlChars.Stream Property

Gets or sets the character stream. The assembly that contains this property has a friend relationship with SQLAccess.dll. It's intended for use by SQL Server. For other databases, use the hosting mechanism provided by that database.

```csharp
internal SqlStreamChars Stream { get; set; }
```

## Property value

`System.Data.SqlTypes.SqlStreamChars`\
The character stream.

## Remarks

> [!WARNING]
> The `SqlChars.Stream` property is internal and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this property in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.Data.SqlTypes>

**Assembly:** System.Data (in System.Data.dll)

**.NET Framework versions:** Available since 2.0.
