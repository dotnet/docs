---
description: "Learn more about: ICorDebugEval::IsActive Method"
title: "ICorDebugEval::IsActive Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugEval.IsActive"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugEval::IsActive"
helpviewer_keywords:
  - "IsActive method, ICorDebugEval interface [.NET debugging]"
  - "ICorDebugEval::IsActive method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugEval::IsActive Method

Gets a value that indicates whether this ICorDebugEval object is currently executing.

## Syntax

```cpp
HRESULT IsActive (
    [out] BOOL              *pbActive
);
```

## Parameters

 `pbActive`
 [out] Pointer to a value that indicates whether this evaluation is active.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
