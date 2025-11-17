---
description: "Learn more about: ICorDebugType::GetRank Method"
title: "ICorDebugType::GetRank Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugType.GetRank"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugType::GetRank"
helpviewer_keywords:
  - "GetRank method, ICorDebugType interface [.NET debugging]"
  - "ICorDebugType::GetRank method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugType::GetRank Method

Gets the number of dimensions in an array type.

## Syntax

```cpp
HRESULT GetRank (
    [out] ULONG32   *pnRank
);
```

## Parameters

 `pnRank`
 [out] A pointer to the number of dimensions.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
