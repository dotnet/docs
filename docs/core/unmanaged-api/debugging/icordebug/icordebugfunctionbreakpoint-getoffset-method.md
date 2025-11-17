---
description: "Learn more about: ICorDebugFunctionBreakpoint::GetOffset Method"
title: "ICorDebugFunctionBreakpoint::GetOffset Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugFunctionBreakpoint.GetOffset"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugFunctionBreakpoint::GetOffset"
helpviewer_keywords:
  - "ICorDebugFunctionBreakpoint::GetOffset method [.NET debugging]"
  - "GetOffset method, ICorDebugFunctionBreakpoint interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugFunctionBreakpoint::GetOffset Method

Gets the offset of the breakpoint within the function.

## Syntax

```cpp
HRESULT GetOffset (
    [out] ULONG32  *pnOffset
);
```

## Parameters

 `pnOffset`
 [out] A pointer to the offset of the breakpoint.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
