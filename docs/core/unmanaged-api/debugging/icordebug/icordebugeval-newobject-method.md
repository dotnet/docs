---
description: "Learn more about: ICorDebugEval::NewObject Method"
title: "ICorDebugEval::NewObject Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugEval.NewObject"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugEval::NewObject"
helpviewer_keywords:
  - "NewObject method [.NET debugging]"
  - "ICorDebugEval::NewObject method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugEval::NewObject Method

Allocates a new object instance and calls the specified constructor method.

This method is obsolete. Use [ICorDebugEval2::NewParameterizedObject](icordebugeval2-newparameterizedobject-method.md) instead.

## Syntax

```cpp
HRESULT NewObject (
    [in] ICorDebugFunction  *pConstructor,
    [in] ULONG32            nArgs,
    [in, size_is(nArgs)] ICorDebugValue *ppArgs[]
);
```

## Parameters

 `pConstructor`
 [in] The constructor to be called.

 `nArgs`
 [in] The size of the `ppArgs` array.

 `ppArgs`
 [in] An array of ICorDebugValue objects, each of which represents an argument to be passed to the constructor.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** 1.1, 1.0

## See also

- [NewParameterizedObject Method](icordebugeval2-newparameterizedobject-method.md)
