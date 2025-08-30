---
description: "Learn more about: ICorDebugAssembly::GetName Method"
title: "ICorDebugAssembly::GetName Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAssembly.GetName"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAssembly::GetName"
helpviewer_keywords:
  - "ICorDebugAssembly::GetName method [.NET debugging]"
  - "GetName method, ICorDebugAssembly interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugAssembly::GetName Method

Gets the name of the assembly that this `ICorDebugAssembly` instance represents.

## Syntax

```cpp
HRESULT GetName (
    [in] ULONG32  cchName,
    [out] ULONG32 *pcchName,
    [out, size_is(cchName), length_is(*pcchName)] WCHAR szName[]
);
```

## Parameters

 `cchName`
 [in] The size of the `szName` array.

 `pcchName`
 [out] A pointer to an integer that specifies the actual length of the name.

 `szName`
 [out] An array that stores the name.

## Remarks

The `GetName` method returns the full path and file name of the assembly.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
