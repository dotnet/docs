---
description: "Learn more about: ICorDebugEval2::NewParameterizedObjectNoConstructor Method"
title: "ICorDebugEval2::NewParameterizedObjectNoConstructor Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugEval2.NewParameterizedObjectNoConstructor"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugEval2::NewParameterizedObjectNoConstructor"
helpviewer_keywords:
  - "NewParameterizedObjectNoConstructor method [.NET debugging]"
  - "ICorDebugEval2::NewParameterizedObjectNoConstructor method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugEval2::NewParameterizedObjectNoConstructor Method

Instantiates a new parameterized type object of the specified class without attempting to call a constructor method.

## Syntax

```cpp
HRESULT NewParameterizedObjectNoConstructor (
    [in] ICorDebugClass        *pClass,
    [in] ULONG32               nTypeArgs,
    [in, size_is(nTypeArgs)] ICorDebugType *ppTypeArgs[]
);
```

## Parameters

 `pClass`
 [in] A pointer to an ICorDebugClass object that represents the class of the object to be instantiated.

 `nTypeArgs`
 [in] The number of type arguments passed.

 `ppTypeArgs`
 [in] An array of pointers, each of which points to an ICorDebugType object that represents a type argument for the object that is being instantiated.

## Remarks

The `NewParameterizedObjectNoConstructor` method will fail if an incorrect number of type arguments or the wrong types of type arguments are passed.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
