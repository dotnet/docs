---
title: SqlStreamChars.Read(Char[], Int32, Int32) Method (System.Data.SqlTypes)
author: stevestein
ms.author: sstein
ms.date: 12/20/2018
ms.technology:
  - "dotnet-data"
topic_type:
  - "apiref"
api_name:
  - "System.Data.SqlTypes.SqlStreamChars.Read"
api_location:
  - "System.Data.dll"
api_type:
  - "Assembly"
---
# SqlStreamChars.Read(Char[], Int32, Int32) Method

When overridden in a derived class, reads the next set of characters from the input stream. The assembly that contains this method has a friend relationship with SQLAccess.dll. It's intended for use by SQL Server. For other databases, use the hosting mechanism provided by that database.

```csharp
public abstract int Read (char[] buffer, int offset, int count);
```

## Parameters

`buffer`\
A char array to read.

`offset`\
An offset relative to origin.

`count`\
The number of characters to be read from the current stream.

## Returns

<xref:System.Int32>\
The total number of characters read into the buffer.

## Remarks

> [!WARNING]
> The `SqlStreamChars.Read` method is private and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this field in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.Data.SqlTypes>

**Assembly:** System.Data (in System.Data.dll)

**.NET Framework versions:** Available since 2.0.