---
description: "Learn more about: ICorDebugThreadEnum::Next Method"
title: "ICorDebugThreadEnum::Next Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugThreadEnum.Next"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugThreadEnum::Next"
helpviewer_keywords:
  - "ICorDebugThreadEnum::Next method [.NET debugging]"
  - "Next method, ICorDebugThreadEnum interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugThreadEnum::Next Method

Gets the number of specified ICorDebugThread instances from the enumeration, starting at the current position.

## Syntax

```cpp
HRESULT Next (
    [in] ULONG celt,
    [out, size_is(celt), length_is(*pceltFetched)]
        ICorDebugThread *threads[],
    [out] ULONG *pceltFetched
);
```

## Parameters

 `celt`
 [in] The number of `ICorDebugThread` instances to be retrieved.

 `threads`
 [out] An array of pointers, each of which points to an `ICorDebugThread` object that represents a thread.

 `pceltFetched`
 [out] Pointer to the number of `ICorDebugThread` instances actually returned. This value may be null if `celt` is one.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
