---
description: "Learn more about: ICorDebugFunction::GetILCode Method"
title: "ICorDebugFunction::GetILCode Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugFunction.GetILCode"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugFunction::GetILCode"
helpviewer_keywords:
  - "ICorDebugFunction::GetILCode method [.NET debugging]"
  - "GetILCode method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugFunction::GetILCode Method

Gets the ICorDebugCode instance that represents the common intermediate language (CIL) code associated with this ICorDebugFunction object.

## Syntax

```cpp
HRESULT GetILCode (
    [out] ICorDebugCode **ppCode
);
```

## Parameters

 `ppCode`
 [out] A pointer to the `ICorDebugCode` instance, or null, if the function was not compiled into CIL.

## Remarks

 If Edit and Continue has been allowed on this function, the `GetILCode` method will get the CIL code corresponding to this function's edited version of the code in the common language runtime (CLR).

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
