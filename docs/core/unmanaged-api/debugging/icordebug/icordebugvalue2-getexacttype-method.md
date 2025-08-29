---
description: "Learn more about: ICorDebugValue2::GetExactType Method"
title: "ICorDebugValue2::GetExactType Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugValue2.GetExactType"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugValue2::GetExactType"
helpviewer_keywords:
  - "ICorDebugValue2::GetExactType method [.NET debugging]"
  - "GetExactType method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugValue2::GetExactType Method

Gets an interface pointer to an "ICorDebugType" object that represents the <xref:System.Type> of this value.

## Syntax

```cpp
HRESULT GetExactType (
    [out] ICorDebugType   **ppType
);
```

## Parameters

 `ppType`
 [out] A pointer to the address of an `ICorDebugType` object that represents the <xref:System.Type> of the value represented by this "ICorDebugValue2" object.

## Remarks

The generics-aware `GetExactType` method supersedes both the [ICorDebugObjectValue::GetClass](icordebugobjectvalue-getclass-method.md) and the [ICorDebugValue::GetType](icordebugvalue-gettype-method.md) methods, each of which return information about the type of a value.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also
