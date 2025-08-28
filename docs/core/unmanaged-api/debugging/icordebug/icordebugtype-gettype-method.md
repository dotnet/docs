---
description: "Learn more about: ICorDebugType::GetType Method"
title: "ICorDebugType::GetType Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugType.GetType"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugType::GetType"
helpviewer_keywords:
  - "ICorDebugType::GetType method [.NET debugging]"
  - "GetType method, ICorDebugType interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugType::GetType Method

Gets a CorElementType value that describes the native type of the common language runtime (CLR) <xref:System.Type> represented by this ICorDebugType.

## Syntax

```cpp
HRESULT GetType (
    [out] CorElementType   *ty
);
```

## Parameters

 `ty`
 [out] A pointer to a value of the `CorElementType` enumeration that indicates the CLR <xref:System.Type> that this `ICorDebugType` represents.

## Remarks

 If the value of `ty` is either ELEMENT_TYPE_CLASS or ELEMENT_TYPE_VALUETYPE, the [ICorDebugType::GetClass](icordebugtype-getclass-method.md) method may be called to get the uninstantiated type for a generic type; otherwise, do not call `ICorDebugType::GetClass`.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
