---
title: MemoryStream.InternalGetOriginAndLength Method (System.IO)
author: mairaw
ms.author: mairaw
ms.date: 11/19/2019
topic_type:
  - "apiref"
api_name:
  - "System.IO.MemoryStream.InternalGetOriginAndLength"
api_location:
  - "mscorlib.dll"
api_type:
  - "Assembly"
---
# MemoryStream.InternalGetOriginAndLength method

Gets the internal values of origin and length of the memory stream.

```csharp
internal void InternalGetOriginAndLength(out int origin, out int length)
```

## Parameters

- `origin` <xref:System.Int32>\
  When this method returns, the offset of the byte array specified when creating a new <xref:System.IO.MemoryStream> object. Contains 0 if the byte array was created by <xref:System.IO.MemoryStream>.

- `length` <xref:System.Int32>\
  When this method returns, the number of bytes within the memory stream.

## Remarks

> [!WARNING]
> The `MemoryStream.InternalGetOriginAndLength` method is internal and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this method in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.IO>

**Assembly:** mscorlib.dll (in mscorlib.dll)

**.NET Framework versions:** Available since 2.0.
