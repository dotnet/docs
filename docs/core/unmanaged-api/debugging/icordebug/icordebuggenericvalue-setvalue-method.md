---
description: "Learn more about: ICorDebugGenericValue::SetValue Method"
title: "ICorDebugGenericValue::SetValue Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugGenericValue.SetValue"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugGenericValue::SetValue"
helpviewer_keywords:
  - "ICorDebugGenericValue::SetValue method [.NET debugging]"
  - "SetValue method, ICorDebugGenericValue interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugGenericValue::SetValue Method

Copies a new value from the specified buffer.

## Syntax

```cpp
HRESULT SetValue (
    [in] void      *pFrom
);
```

## Parameters

 `pFrom`
 [in] A pointer to the buffer from which to copy the value.

## Remarks

 For reference types, the value is the reference, not the content.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
