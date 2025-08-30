---
description: "Learn more about: ICorDebugObjectEnum::Next Method"
title: "ICorDebugObjectEnum::Next Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugObjectEnum.Next"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugObjectEnum::Next"
helpviewer_keywords:
  - "Next method, ICorDebugObjectEnum interface [.NET debugging]"
  - "ICorDebugObjectEnum::Next method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugObjectEnum::Next Method

Gets the relative virtual addresses (RVAs) of the specified number of objects from the enumeration, starting at the current position.

## Syntax

```cpp
HRESULT Next (
    [in] ULONG celt,
    [out, size_is(celt), length_is(*pceltFetched)]
        CORDB_ADDRESS objects[],
    [out] ULONG *pceltFetched
);
```

## Parameters

 `celt`
 [in] The number of objects to be retrieved.

 `objects`
 [out] An array of pointers, each of which points to a CORDB_ADDRESS object.

 `pceltFetched`
 [out] Pointer to the number of objects actually returned. This value may be null if `celt` is one.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also
