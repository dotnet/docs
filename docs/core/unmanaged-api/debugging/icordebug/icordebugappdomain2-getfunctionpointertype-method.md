---
description: "Learn more about: ICorDebugAppDomain2::GetFunctionPointerType Method"
title: "ICorDebugAppDomain2::GetFunctionPointerType Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAppDomain2.GetFunctionPointerType"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAppDomain2::GetFunctionPointerType"
helpviewer_keywords:
  - "ICorDebugAppDomain2::GetFunctionPointerType method [.NET debugging]"
  - "GetFunctionPointerType method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugAppDomain2::GetFunctionPointerType Method

Gets a pointer to a function that has a given signature.

## Syntax

```cpp
HRESULT GetFunctionPointerType (
    [in] ULONG32                             nTypeArgs,
    [in, size_is(nTypeArgs)] ICorDebugType   *ppTypeArgs[],
    [out] ICorDebugType                      **ppType
);
```

## Parameters

 `nTypeArgs`
 [in] The number of type arguments for the function.

 `ppTypeArgs`
 [in] An array of pointers, each of which points to an ICorDebugType object that represents a type argument of the function. The first element is the return type; each of the other elements is a parameter type.

 `ppType`
 [out] A pointer to the address of an `ICorDebugType` object that represents the pointer to the function.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
