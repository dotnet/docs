---
description: "Learn more about: ICorDebugFunction::GetModule Method"
title: "ICorDebugFunction::GetModule Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugFunction.GetModule"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugFunction::GetModule"
helpviewer_keywords:
  - "ICorDebugFunction::GetModule method [.NET debugging]"
  - "GetModule method, ICorDebugFunction interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugFunction::GetModule Method

Gets the module in which this function is defined.

## Syntax

```cpp
HRESULT GetModule (
    [out] ICorDebugModule **ppModule
);
```

## Parameters

 `ppModule`
 [out] A pointer to the address of an ICorDebugModule object that represents the module in which this function is defined.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
