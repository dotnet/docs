---
description: "Learn more about: ICorDebugAppDomain::EnumerateBreakpoints Method"
title: "ICorDebugAppDomain::EnumerateBreakpoints Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAppDomain.EnumerateBreakpoints"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAppDomain::EnumerateBreakpoints"
helpviewer_keywords:
  - "ICorDebugAppDomain::EnumerateBreakpoints method [.NET debugging]"
  - "EnumerateBreakpoints method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugAppDomain::EnumerateBreakpoints Method

Gets an enumerator for all active breakpoints in the application domain.

## Syntax

```cpp
HRESULT EnumerateBreakpoints (
    [out] ICorDebugBreakpointEnum   **ppBreakpoints
);
```

## Parameters

 `ppBreakpoints`
 [out] A pointer to the address of an ICorDebugBreakpointEnum object that is the enumerator for all active breakpoints in the application domain.

## Remarks

The enumerator includes all types of breakpoints, including function breakpoints and data breakpoints.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
