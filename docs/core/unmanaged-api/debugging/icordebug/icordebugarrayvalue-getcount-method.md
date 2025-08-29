---
description: "Learn more about: ICorDebugArrayValue::GetCount Method"
title: "ICorDebugArrayValue::GetCount Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugArrayValue.GetCount"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugArrayValue::GetCount"
helpviewer_keywords:
  - "ICorDebugArrayValue::GetCount method [.NET debugging]"
  - "GetCount method, ICorDebugArrayValue interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugArrayValue::GetCount Method

Gets the total number of elements in the array.

## Syntax

```cpp
HRESULT GetCount (
    [out] ULONG32 *pnCount
);
```

## Parameters

 `pnCount`
 [out] A pointer to the total number of elements in the array.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
