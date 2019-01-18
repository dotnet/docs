---
title: SqlStreamChars.Write(Char[], Int32, Int32) Method (System.Data.SqlTypes)
author: douglaslMS
ms.author: douglasl
ms.date: 12/20/2018
ms.technology:
  - "dotnet-data"
topic_type:
  - "apiref"
api_name:
  - "System.Data.SqlTypes.SqlStreamChars.Write"
api_location:
  - "System.Data.dll"
api_type:
  - "Assembly"
---
# SqlStreamChars.Write(Char[], Int32, Int32) Method

When overridden in a derived class, writes a sequence of characters to the current stream and advances the current position within this stream by the number of characters written. The assembly that contains this method has a friend relationship with SQLAccess.dll. It's intended for use by SQL Server. For other databases, use the hosting mechanism provided by that database.

```csharp
public abstract void Write (char[] buffer, int offset, int count);
```

## Parameters

`buffer`  
A char array to write.

`offset`  
An offset relative to origin.

`count`  
The number of characters to be written to the current stream.

## Remarks

> [!WARNING]
> The `SqlStreamChars.Write` method is private and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this field in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.Data.SqlTypes>

**Assembly:** System.Data (in System.Data.dll)

**.NET Framework versions:** Available since 2.0.