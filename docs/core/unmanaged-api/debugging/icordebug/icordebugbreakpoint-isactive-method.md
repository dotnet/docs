---
description: "Learn more about: ICorDebugBreakpoint::IsActive Method"
title: "ICorDebugBreakpoint::IsActive Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugBreakpoint.IsActive"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugBreakpoint::IsActive"
helpviewer_keywords:
  - "ICorDebugBreakpoint::IsActive method [.NET debugging]"
  - "IsActive method, ICorDebugBreakpoint interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugBreakpoint::IsActive Method

Gets a value that indicates whether this `ICorDebugBreakpoint` is active.

## Syntax

```cpp
HRESULT IsActive (
    [out] BOOL *pbActive
);
```

## Parameters

 `pbActive`
 [out] `true` if this breakpoint is active; otherwise, `false`.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
