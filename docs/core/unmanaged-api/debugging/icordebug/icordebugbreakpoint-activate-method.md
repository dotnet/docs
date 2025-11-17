---
description: "Learn more about: ICorDebugBreakpoint::Activate Method"
title: "ICorDebugBreakpoint::Activate Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugBreakpoint.Activate"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugBreakpoint::Activate"
helpviewer_keywords:
  - "ICorDebugBreakpoint::Activate method [.NET debugging]"
  - "Activate method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugBreakpoint::Activate Method

Sets the active state of this `ICorDebugBreakpoint`.

## Syntax

```cpp
HRESULT Activate (
    [in] BOOL bActive
);
```

## Parameters

 `bActive`
 [in] Set this value to `true` to specify the state as active; otherwise, set this value to `false`.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
