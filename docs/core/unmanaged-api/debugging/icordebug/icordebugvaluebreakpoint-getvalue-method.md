---
description: "Learn more about: ICorDebugValueBreakpoint::GetValue Method"
title: "ICorDebugValueBreakpoint::GetValue Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugValueBreakpoint.GetValue"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugValueBreakpoint::GetValue"
helpviewer_keywords:
  - "GetValue method, ICorDebugValueBreakpoint interface [.NET debugging]"
  - "ICorDebugValueBreakpoint::GetValue method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugValueBreakpoint::GetValue Method

Gets an interface pointer to an "ICorDebugValue" object that represents the value of the object on which the breakpoint is set.

## Syntax

```cpp
HRESULT GetValue (
    [out] ICorDebugValue   **ppValue
);
```

## Parameters

 `ppValue`
 [out] A pointer to the address of an `ICorDebugValue` object.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also
