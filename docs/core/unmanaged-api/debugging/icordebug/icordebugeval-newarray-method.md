---
description: "Learn more about: ICorDebugEval::NewArray Method"
title: "ICorDebugEval::NewArray Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugEval.NewArray"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugEval::NewArray"
helpviewer_keywords:
  - "NewArray method [.NET debugging]"
  - "ICorDebugEval::NewArray method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugEval::NewArray Method

Allocates a new array of the specified element type and dimensions.

This method is obsolete. Use [ICorDebugEval2::NewParameterizedArray](icordebugeval2-newparameterizedarray-method.md) instead.

## Syntax

```cpp
HRESULT NewArray (
    [in] CorElementType     elementType,
    [in] ICorDebugClass     *pElementClass,
    [in] ULONG32            rank,
    [in, size_is(rank)] ULONG32 dims[],
    [in, size_is(rank)] ULONG32 lowBounds[]
);
```

## Parameters

 `elementType`
 [in] A value of the CorElementType enumeration that specifies the element type of the array.

 `pElementClass`
 [in] A pointer to a ICorDebugClass object that specifies the class of the element. This value may be null if the element type is a primitive type.

 `rank`
 [in] The number of dimensions of the array. This value must be 1.

 `dims`
 [in] The size, in bytes, of each dimension of the array.

 `lowBounds`
 [in] Optional. The lower bound of each dimension of the array. If this value is omitted, a lower bound of zero is assumed for each dimension.

## Remarks

The array is always created in the application domain in which the thread is currently executing.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** 1.1, 1.0
