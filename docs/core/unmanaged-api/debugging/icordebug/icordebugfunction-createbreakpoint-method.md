---
description: "Learn more about: ICorDebugFunction::CreateBreakpoint Method"
title: "ICorDebugFunction::CreateBreakpoint Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugFunction.CreateBreakpoint"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugFunction::CreateBreakpoint"
helpviewer_keywords:
  - "ICorDebugFunction::CreateBreakpoint method [.NET debugging]"
  - "CreateBreakpoint method, ICorDebugFunction interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugFunction::CreateBreakpoint Method

Creates a breakpoint at the beginning of this function.

## Syntax

```cpp
HRESULT CreateBreakpoint (
    [out] ICorDebugFunctionBreakpoint **ppBreakpoint
);
```

## Parameters

 `ppBreakpoint`
 [out] A pointer to the address of an ICorDebugFunctionBreakpoint object that represents the new breakpoint for the function.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
