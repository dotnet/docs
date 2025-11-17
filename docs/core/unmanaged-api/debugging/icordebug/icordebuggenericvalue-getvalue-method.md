---
description: "Learn more about: ICorDebugGenericValue::GetValue Method"
title: "ICorDebugGenericValue::GetValue Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugGenericValue.GetValue"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugGenericValue::GetValue"
helpviewer_keywords:
  - "ICorDebugGenericValue::GetValue method [.NET debugging]"
  - "GetValue method, ICorDebugGenericValue interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugGenericValue::GetValue Method

Copies the value of this generic into the specified buffer.

## Syntax

```cpp
HRESULT GetValue (
    [out] void     *pTo
);
```

## Parameters

 `pTo`
 [out] A pointer to the value that is represented by this ICorDebugGenericValue object. The value may be a simple type or a reference type (that is, a pointer).

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
