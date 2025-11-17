---
description: "Learn more about: ICorDebugBoxValue::GetObject Method"
title: "ICorDebugBoxValue::GetObject Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugBoxValue.GetObject"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugBoxValue::GetObject"
helpviewer_keywords:
  - "ICorDebugBoxValue::GetObject method [.NET debugging]"
  - "GetObject method, ICorDebugBoxValue interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugBoxValue::GetObject Method

Gets the boxed value.

## Syntax

```cpp
HRESULT GetObject (
    [out] ICorDebugObjectValue **ppObject
);
```

## Parameters

 `ppObject`
 [out] A pointer to the address of an ICorDebugObjectValue object that represents the boxed value.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
