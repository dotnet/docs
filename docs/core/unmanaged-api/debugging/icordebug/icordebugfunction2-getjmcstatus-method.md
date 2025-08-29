---
description: "Learn more about: ICorDebugFunction2::GetJMCStatus Method"
title: "ICorDebugFunction2::GetJMCStatus Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugFunction2.GetJMCStatus"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugFunction2::GetJMCStatus"
helpviewer_keywords:
  - "ICorDebugFunction2::GetJMCStatus method [.NET debugging]"
  - "GetJMCStatus method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugFunction2::GetJMCStatus Method

Gets a value that indicates whether the function that is represented by this ICorDebugFunction2 object is marked as user code.

## Syntax

```cpp
HRESULT GetJMCStatus (
    [out] BOOL   *pbIsJustMyCode
);
```

## Parameters

 `pbIsJustMyCode`
 [out] A pointer to a Boolean value that is `true`, if this function is marked as user code; otherwise, the value is `false`.

## Remarks

If the function represented by this `ICorDebugFunction2` cannot be debugged, `pbIsJustMyCode` will always be `false`.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
