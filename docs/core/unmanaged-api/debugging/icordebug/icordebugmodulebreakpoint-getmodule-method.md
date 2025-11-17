---
description: "Learn more about: ICorDebugModuleBreakpoint::GetModule Method"
title: "ICorDebugModuleBreakpoint::GetModule Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugModuleBreakpoint.GetModule"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugModuleBreakpoint::GetModule"
helpviewer_keywords:
  - "ICorDebugModuleBreakpoint::GetModule method [.NET debugging]"
  - "GetModule method, ICorDebugModuleBreakpoint interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugModuleBreakpoint::GetModule Method

Gets an interface pointer to an "ICorDebugModule" that references the module in which this breakpoint is set.

## Syntax

```cpp
HRESULT GetModule (
    [out] ICorDebugModule   **ppModule
);
```

## Parameters

 `ppModule`
 [out] A pointer to the address of an `ICorDebugModule` interface that references the module in which the breakpoint is set.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also
