---
description: "Learn more about: ICorDebugCode::GetFunction Method"
title: "ICorDebugCode::GetFunction Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugCode.GetFunction"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugCode::GetFunction"
helpviewer_keywords:
  - "GetFunction method, ICorDebugCode interface [.NET debugging]"
  - "ICorDebugCode::GetFunction method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugCode::GetFunction Method

Gets the "ICorDebugFunction" associated with this "ICorDebugCode".

## Syntax

```cpp
HRESULT GetFunction (
    [out] ICorDebugFunction **ppFunction
);
```

## Parameters

 `ppFunction`
 [out] A pointer to the address of the function.

## Remarks

 `ICorDebugCode` and `ICorDebugFunction` maintain a one-to-one relationship.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
