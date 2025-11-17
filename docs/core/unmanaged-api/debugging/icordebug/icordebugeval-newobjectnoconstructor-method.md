---
description: "Learn more about: ICorDebugEval::NewObjectNoConstructor Method"
title: "ICorDebugEval::NewObjectNoConstructor Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugEval.NewObjectNoConstructor"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugEval::NewObjectNoConstructor"
helpviewer_keywords:
  - "NewObjectNoConstructor method [.NET debugging]"
  - "ICorDebugEval::NewObjectNoConstructor method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugEval::NewObjectNoConstructor Method

Allocates a new object instance of the specified type, without attempting to call a constructor method.

This method is obsolete. Use [ICorDebugEval2::NewParameterizedObjectNoConstructor](icordebugeval2-newparameterizedobjectnoconstructor-method.md) instead.

## Syntax

```cpp
HRESULT NewObjectNoConstructor (
    [in] ICorDebugClass     *pClass
);
```

## Parameters

 `pClass`
 [in] Pointer to an ICorDebugClass object that represents the type of object to be instantiated.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** 1.1, 1.0

## See also

- [NewParameterizedObjectNoConstructor Method](icordebugeval2-newparameterizedobjectnoconstructor-method.md)
