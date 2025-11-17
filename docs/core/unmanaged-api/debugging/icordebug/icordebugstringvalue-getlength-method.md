---
description: "Learn more about: ICorDebugStringValue::GetLength Method"
title: "ICorDebugStringValue::GetLength Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugStringValue.GetLength"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugStringValue::GetLength"
helpviewer_keywords:
  - "ICorDebugStringValue::GetLength method [.NET debugging]"
  - "GetLength method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugStringValue::GetLength Method

Gets the number of characters in the string referenced by this ICorDebugStringValue.

## Syntax

```cpp
HRESULT GetLength (
    [out] ULONG32   *pcchString
);
```

## Parameters

 `pcchString`
 [out] A pointer to a value that specifies the length of the string referenced by this `ICorDebugStringValue` object.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
