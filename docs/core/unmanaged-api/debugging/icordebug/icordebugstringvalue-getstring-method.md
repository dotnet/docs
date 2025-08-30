---
description: "Learn more about: ICorDebugStringValue::GetString Method"
title: "ICorDebugStringValue::GetString Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugStringValue.GetString"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugStringValue::GetString"
helpviewer_keywords:
  - "ICorDebugStringValue::GetString method [.NET debugging]"
  - "GetString method, ICorDebugStringValue interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugStringValue::GetString Method

Gets the string referenced by this ICorDebugStringValue.

## Syntax

```cpp
HRESULT GetString (
    [in] ULONG32    cchString,
    [out] ULONG32   *pcchString,
    [out, size_is(cchString), length_is(*pcchString)]
        WCHAR       szString[]
);
```

## Parameters

 `cchString`
 [in] The size of the `szString` array.

 `pcchString`
 [out] A pointer to the number of characters returned in the `szString` array.

 `szString`
 [out] An array that stores the retrieved string.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
