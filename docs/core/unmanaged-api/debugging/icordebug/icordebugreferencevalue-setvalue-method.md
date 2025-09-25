---
description: "Learn more about: ICorDebugReferenceValue::SetValue Method"
title: "ICorDebugReferenceValue::SetValue Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugReferenceValue.SetValue"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugReferenceValue::SetValue"
helpviewer_keywords:
  - "SetValue method, ICorDebugReferenceValue interface [.NET debugging]"
  - "ICorDebugReferenceValue::SetValue method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugReferenceValue::SetValue Method

Sets the specified memory address. That is, this method sets this ICorDebugReferenceValue to point to an object.

## Syntax

```cpp
HRESULT SetValue (
    [in] CORDB_ADDRESS    value
);
```

## Parameters

 `value`
 [in] A `CORDB_ADDRESS` value that specifies the address of the object to which this `ICorDebugReferenceValue` points.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
