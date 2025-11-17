---
description: "Learn more about: ICorDebugFunctionBreakpoint::GetFunction Method"
title: "ICorDebugFunctionBreakpoint::GetFunction Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugFunctionBreakpoint.GetFunction"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugFunctionBreakpoint::GetFunction"
helpviewer_keywords:
  - "ICorDebugFunctionBreakpoint::GetFunction method [.NET debugging]"
  - "GetFunction method, ICorDebugFunctionBreakpoint interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugFunctionBreakpoint::GetFunction Method

Gets an interface pointer to an ICorDebugFunction that references the function in which the breakpoint is set.

## Syntax

```cpp
HRESULT GetFunction (
    [out] ICorDebugFunction  **ppFunction
);
```

## Parameters

 `ppFunction`
 [out] A pointer to the address of the function in which the breakpoint is set.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
