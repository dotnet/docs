---
description: "Learn more about: ICorDebugEval::GetThread Method"
title: "ICorDebugEval::GetThread Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugEval.GetThread"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugEval::GetThread"
helpviewer_keywords:
  - "GetThread method, ICorDebugEval interface [.NET debugging]"
  - "ICorDebugEval::GetThread method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugEval::GetThread Method

Gets the thread in which this evaluation is executing or will execute.

## Syntax

```cpp
HRESULT GetThread (
    [out] ICorDebugThread   **ppThread
);
```

## Parameters

 `ppThread`
 [out] A pointer to the address of an ICorDebugThread object that represents the thread.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
