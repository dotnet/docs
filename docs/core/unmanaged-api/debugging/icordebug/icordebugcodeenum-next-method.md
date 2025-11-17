---
description: "Learn more about: ICorDebugCodeEnum::Next Method"
title: "ICorDebugCodeEnum::Next Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugCodeEnum.Next"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugCodeEnum::Next"
helpviewer_keywords:
  - "ICorDebugCodeEnum::Next method [.NET debugging]"
  - "Next method, ICorDebugEnum interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugCodeEnum::Next Method

Gets the specified number of "ICorDebugCode" instances from the enumeration, starting at the current position.

## Syntax

```cpp
HRESULT Next (
    [in] ULONG  celt,
    [out, size_is(celt), length_is(*pceltFetched)]
        ICorDebugCode *values[],
    [out] ULONG *pceltFetched
);
```

## Parameters

`celt`
[in] The number of `ICorDebugCode` instances to be retrieved.

`values`
[out] An array of pointers, each of which points to an `ICorDebugCode` object.

`pceltFetched`
[out] A pointer to the number of `ICorDebugCode` instances actually returned. This value may be null if `celt` is one.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** CorDebug.idl, CorDebug.h

**Library:** CorGuids.lib

**.NET versions:** Available since .NET Framework 2.0
