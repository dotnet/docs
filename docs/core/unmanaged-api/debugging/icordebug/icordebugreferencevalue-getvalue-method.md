---
description: "Learn more about: ICorDebugReferenceValue::GetValue Method"
title: "ICorDebugReferenceValue::GetValue Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugReferenceValue.GetValue"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugReferenceValue::GetValue"
helpviewer_keywords:
  - "GetValue method, ICorDebugReferenceValue interface [.NET debugging]"
  - "ICorDebugReferenceValue::GetValue method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugReferenceValue::GetValue Method

Gets the current memory address of the referenced object.

## Syntax

```cpp
HRESULT GetValue (
    [out] CORDB_ADDRESS   *pValue
);
```

## Parameters

 `pValue`
 [out] A pointer to a `CORDB_ADDRESS` value that specifies the address of the object to which this ICorDebugReferenceValue object points.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
