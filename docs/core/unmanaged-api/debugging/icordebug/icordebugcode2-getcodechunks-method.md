---
description: "Learn more about: ICorDebugCode2::GetCodeChunks Method"
title: "ICorDebugCode2::GetCodeChunks Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugCode2.GetCodeChunks"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugCode2::GetCodeChunks"
helpviewer_keywords:
  - "GetCodeChunks method [.NET debugging]"
  - "ICorDebugCode2::GetCodeChunks method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugCode2::GetCodeChunks Method

Gets the chunks of code that this code object is composed of.

## Syntax

```cpp
HRESULT GetCodeChunks (
    [in]  ULONG32     cbufSize,
    [out] ULONG32     *pcnumChunks,
    [out, size_is(cbufSize), length_is(*pcnumChunks)]
        CodeChunkInfo chunks[]
);
```

## Parameters

`cbufSize`
[in] Size of the `chunks` array.

`pcnumChunks`
[out] The number of chunks returned in the `chunks` array.

`chunks`
[out] An array of "CodeChunkInfo" structures, each of which represents a single chunk of code. If the value of `cbufSize` is 0, this parameter can be null.

## Remarks

The code chunks will never overlap, and they will follow the order in which they would have been concatenated by [ICorDebugCode::GetCode](icordebugcode-getcode-method.md). A common intermediate language (CIL) code object in the .NET Framework version 2.0 will comprise a single code chunk.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** CorDebug.idl, CorDebug.h

**Library:** CorGuids.lib

**.NET versions:** Available since .NET Framework 2.0
