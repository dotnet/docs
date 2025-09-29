---
description: "Learn more about: ICorDebugEval2::NewParameterizedArray Method"
title: "ICorDebugEval2::NewParameterizedArray Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugEval2.NewParameterizedArray"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugEval2::NewParameterizedArray"
helpviewer_keywords:
  - "ICorDebugEval2::NewParameterizedArray method [.NET debugging]"
  - "NewParameterizedArray method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugEval2::NewParameterizedArray Method

Allocates a new array of the specified element type and dimensions.

## Syntax

```cpp
HRESULT NewParameterizedArray(
    [in] ICorDebugType          *pElementType,
    [in] ULONG32                rank,
    [in, size_is(rank)] ULONG32 dims[],
    [in, size_is(rank)] ULONG32 lowBounds[]
);
```

## Parameters

 `pElementType`
 [in] A pointer to an ICorDebugType object that represents the type of element stored in the array.

 `rank`
 [in] The number of dimensions of the array.

 `dims`
 [in] The size, in bytes, of each dimension of the array.

 `lowBounds`
 [in] Optional. The lower bound of each dimension of the array. If this value is omitted, a lower bound of zero is assumed for each dimension.

## Remarks

The elements of the array may be instances of a generic type. The array is always created in the application domain in which the thread is currently running.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
