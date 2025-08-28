---
description: "Learn more about: ICorDebugFunction2::SetJMCStatus Method"
title: "ICorDebugFunction2::SetJMCStatus Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugFunction2.SetJMCStatus"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugFunction2::SetJMCStatus"
helpviewer_keywords:
  - "ICorDebugFunction2::SetJMCStatus method [.NET debugging]"
  - "SetJMCStatus method, ICorDebugFunction2 interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugFunction2::SetJMCStatus Method

Marks the function represented by this ICorDebugFunction2 for Just My Code stepping.

## Syntax

```cpp
HRESULT SetJMCStatus (
    [in] BOOL   bIsJustMyCode
);
```

## Parameters

 `bIsJustMyCode`
 [in] Set to `true` to mark the function as user code; otherwise, set to `false`.

## Return Values

|HRESULT|Description|
|-------------|-----------------|
|`S_OK`|The function was successfully marked.|
|`CORDBG_E_FUNCTION_NOT_DEBUGGABLE`|The function could not be marked as user code because it cannot be debugged.|

## Remarks

 A Just My Code stepper will skip non-user code. User code must be a subset of debuggable code.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
