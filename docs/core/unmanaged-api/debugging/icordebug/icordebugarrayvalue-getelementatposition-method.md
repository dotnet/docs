---
description: "Learn more about: ICorDebugArrayValue::GetElementAtPosition Method"
title: "ICorDebugArrayValue::GetElementAtPosition Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugArrayValue.GetElementAtPosition"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugArrayValue::GetElementAtPosition"
helpviewer_keywords:
  - "GetElementAtPosition method [.NET debugging]"
  - "ICorDebugArrayValue::GetElementAtPosition method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugArrayValue::GetElementAtPosition Method

Gets the element at the given position, treating the array as a zero-based, single-dimensional array.

## Syntax

```cpp
HRESULT GetElementAtPosition (
    [in]  ULONG32          nPosition,
    [out] ICorDebugValue   **ppValue
);
```

## Parameters

 `nPosition`
 [in] The position of the element to be retrieved.

 `ppValue`
 [out] A pointer to the address of an ICorDebugValue object that represents the value of the element.

## Remarks

The layout of a multi-dimension array follows the C++ style of array layout.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
