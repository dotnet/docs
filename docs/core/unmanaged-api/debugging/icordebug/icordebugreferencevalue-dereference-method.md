---
description: "Learn more about: ICorDebugReferenceValue::Dereference Method"
title: "ICorDebugReferenceValue::Dereference Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugReferenceValue.Dereference"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugReferenceValue::Dereference"
helpviewer_keywords:
  - "ICorDebugReferenceValue::Dereference method [.NET debugging]"
  - "Dereference method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugReferenceValue::Dereference Method

Gets the object that is referenced.

## Syntax

```cpp
HRESULT Dereference (
    [out] ICorDebugValue  **ppValue
);
```

## Parameters

 `ppValue`
 [out] A pointer to the address of an ICorDebugValue that represents the object to which this ICorDebugReferenceValue object points.

## Remarks

 The `ICorDebugValue` object is valid only while its reference has not yet been disabled.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
