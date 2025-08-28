---
description: "Learn more about: ICorDebugFunction::GetNativeCode Method"
title: "ICorDebugFunction::GetNativeCode Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugFunction.GetNativeCode"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugFunction::GetNativeCode"
helpviewer_keywords:
  - "GetNativeCode method [.NET debugging]"
  - "ICorDebugFunction::GetNativeCode method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugFunction::GetNativeCode Method

Gets the native code for the function that is represented by this ICorDebugFunction instance.

## Syntax

```cpp
HRESULT GetNativeCode (
    [out] ICorDebugCode **ppCode
);
```

## Parameters

 `ppCode`
 [out] A pointer to the ICorDebugCode instance that represents the native code for this function, or null, if this function is common intermediate language (CIL) code that has not been just-in-time (JIT) compiled.

## Remarks

 If the function that is represented by this `ICorDebugFunction` instance has been JIT-compiled more than once, as in the case of generic types, `GetNativeCode` returns a random native code object.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
