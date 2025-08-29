---
description: "Learn more about: ICorDebugFunction::GetToken Method"
title: "ICorDebugFunction::GetToken Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugFunction.GetToken"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugFunction::GetToken"
helpviewer_keywords:
  - "ICorDebugFunction::GetToken method [.NET debugging]"
  - "GetToken method, ICorDebugFunction interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugFunction::GetToken Method

Gets the metadata token for this function.

## Syntax

```cpp
HRESULT GetToken (
    [out] mdMethodDef *pMethodDef
);
```

## Parameters

 `pMethodDef`
 [out] A pointer to an `mdMethodDef` token that references the metadata for this function.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
