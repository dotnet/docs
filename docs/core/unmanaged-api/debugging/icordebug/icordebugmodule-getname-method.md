---
description: "Learn more about: ICorDebugModule::GetName Method"
title: "ICorDebugModule::GetName Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugModule.GetName"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugModule::GetName"
helpviewer_keywords:
  - "ICorDebugModule::GetName method [.NET debugging]"
  - "GetName method, ICorDebugModule interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugModule::GetName Method

Gets the file name of the module.

## Syntax

```cpp
HRESULT GetName(
    [in] ULONG32 cchName,
    [out] ULONG32 *pcchName,
    [out, size_is(cchName), length_is(*pcchName)] WCHAR szName[]
);
```

## Parameters

 `cchname`
 [in] The size of the `szName` array.

 `pcchName`
 [in] A pointer to the length of the returned name.

 `szName`
 [out] An array that stores the returned name.

## Remarks

The `GetName` method returns an S_OK HRESULT if the module's file name matches the name on disk. `GetName` returns an S_FALSE HRESULT if the name is fabricated, such as for a dynamic or in-memory module.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also
