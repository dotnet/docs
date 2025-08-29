---
description: "Learn more about: ICorDebugBreakpointEnum::Next Method"
title: "ICorDebugBreakpointEnum::Next Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugBreakpointEnum.Next"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugBreakpointEnum::Next"
helpviewer_keywords:
  - "Next method, ICorDebugBreakpointEnum interface [.NET debugging]"
  - "ICorDebugBreakpointEnum::Next method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugBreakpointEnum::Next Method

Gets the specified number of ICorDebugBreakpoint instances from the enumeration, starting at the current position.

## Syntax

```cpp
HRESULT Next (
    [in] ULONG  celt,
    [out, size_is(celt), length_is(*pceltFetched)]
        ICorDebugBreakpoint *breakpoints[],
    [out] ULONG *pceltFetched
);
```

## Parameters

 `celt`
 [in] The number of `ICorDebugBreakpoint` instances to be retrieved.

 `breakpoints`
 [out] An array of pointers, each of which points to an `ICorDebugBreakpoint` object that represents a breakpoint.

 `pceltFetched`
 [out] A pointer to the number of `ICorDebugBreakpoint` instances actually returned. This value may be null if `celt` is one.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
