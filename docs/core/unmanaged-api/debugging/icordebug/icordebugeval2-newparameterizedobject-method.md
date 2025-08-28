---
description: "Learn more about: ICorDebugEval2::NewParameterizedObject Method"
title: "ICorDebugEval2::NewParameterizedObject Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugEval2.NewParameterizedObject"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugEval2::NewParameterizedObject"
helpviewer_keywords:
  - "NewParameterizedObject method [.NET debugging]"
  - "ICorDebugEval2::NewParameterizedObject method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugEval2::NewParameterizedObject Method

Instantiates a new parameterized type object and calls the object's constructor method.

## Syntax

```cpp
HRESULT NewParameterizedObject (
    [in] ICorDebugFunction     *pConstructor,
    [in] ULONG32               nTypeArgs,
    [in, size_is(nTypeArgs)] ICorDebugType *ppTypeArgs[],
    [in] ULONG32               nArgs,
    [in, size_is(nArgs)] ICorDebugValue *ppArgs[]
);
```

## Parameters

 `pConstructor`
 [in] A pointer to an ICorDebugFunction object that represents the constructor of the object to be instantiated.

 `nTypeArgs`
 [in] The number of type arguments passed.

 `ppTypeArgs`
 [in] An array of pointers, each of which points to an ICorDebugType object that represents a type argument for the object that is being instantiated.

 `nArgs`
 [in] The number of arguments passed to the constructor.

 `ppArgs`
 [in] An array of pointers, each of which points to an ICorDebugValue object that represents an argument value that is passed to the constructor.

## Remarks

 The object's constructor may take <xref:System.Type> parameters.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
