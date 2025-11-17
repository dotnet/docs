---
description: "Learn more about: ICorDebugHandleValue::GetHandleType Method"
title: "ICorDebugHandleValue::GetHandleType Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugHandleValue.GetHandleType"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugHandleValue::GetHandleType"
helpviewer_keywords:
  - "GetHandleType method [.NET debugging]"
  - "ICorDebugHandleValue::GetHandleType method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugHandleValue::GetHandleType Method

Gets a value that indicates the kind of handle referenced by this ICorDebugHandleValue object.

## Syntax

```cpp
HRESULT GetHandleType (
    [out] CorDebugHandleType  *pType
);
```

## Parameters

 `pType`
 [out] A pointer to a value of the CorDebugHandleType enumeration that indicates the type of this handle.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
