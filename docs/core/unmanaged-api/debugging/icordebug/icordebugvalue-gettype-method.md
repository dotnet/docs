---
description: "Learn more about: ICorDebugValue::GetType Method"
title: "ICorDebugValue::GetType Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugValue.GetType"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugValue::GetType"
helpviewer_keywords:
  - "ICorDebugValue::GetType method [.NET debugging]"
  - "GetType method, ICorDebugValue interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugValue::GetType Method

Gets the primitive type of this "ICorDebugValue" object.

## Syntax

```cpp
HRESULT GetType (
    [out] CorElementType   *pType
);
```

## Parameters

 `pType`
 [out] A pointer to a value of the "CorElementType" enumeration that indicates the value's type.

## Remarks

If the object is a complex run-time type, that type may be examined through the appropriate subclasses of the `ICorDebugValue` interface. For example, "ICorDebugObjectValue", which inherits from `ICorDebugValue`, represents a complex type.

The `GetType` and [ICorDebugObjectValue::GetClass](icordebugobjectvalue-getclass-method.md) methods each return information about the type of a value. They are both superseded by the generics-aware [ICorDebugValue2::GetExactType](icordebugvalue2-getexacttype-method.md) method.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also
