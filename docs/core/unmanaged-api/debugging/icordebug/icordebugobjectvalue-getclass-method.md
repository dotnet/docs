---
description: "Learn more about: ICorDebugObjectValue::GetClass Method"
title: "ICorDebugObjectValue::GetClass Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugObjectValue.GetClass"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugObjectValue::GetClass"
helpviewer_keywords:
  - "ICorDebugObjectValue::GetClass method [.NET debugging]"
  - "GetClass method, ICorDebugObjectValue interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugObjectValue::GetClass Method

Gets the class of this object value.

## Syntax

```cpp
HRESULT GetClass (
    [out] ICorDebugClass     **ppClass
);
```

## Parameters

 `ppClass`
 [out] A pointer to the address of an "ICorDebugClass" object that represents the class of the object value represented by this "ICorDebugObjectValue" object.

## Remarks

The `GetClass` and [ICorDebugValue::GetType](icordebugvalue-gettype-method.md) methods each return information about the type of a value; they are both superseded by the generics-aware [ICorDebugValue2::GetExactType](icordebugvalue2-getexacttype-method.md).

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also
