---
description: "Learn more about: CodeChunkInfo Structure"
title: "CodeChunkInfo Structure"
ms.date: "03/30/2017"
api_name:
  - "CodeChunkInfo"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "CodeChunkInfo"
helpviewer_keywords:
  - "CodeChunkInfo structure [.NET debugging]"
topic_type:
  - "apiref"
---
# CodeChunkInfo Structure

Represents a single chunk of code in memory.

## Syntax

```cpp
typedef struct _CodeChunkInfo {
    CORDB_ADDRESS startAddr;
    ULONG32       length;
} CodeChunkInfo;
```

## Members

| Member      | Description                                                               |
|-------------|---------------------------------------------------------------------------|
| `startAddr` | A `CORDB_ADDRESS` value that specifies the starting address of the chunk. |
| `length`    | The size, in bytes, of the chunk.                                         |

## Remarks

 The single chunk of code is a region of native code that is part of a code object such as a function.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [GetCodeChunks Method](icordebugcode2-getcodechunks-method.md)
