---
description: "Learn more about: ICorDebugEval::Abort Method"
title: "ICorDebugEval::Abort Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugEval.Abort"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugEval::Abort"
helpviewer_keywords:
  - "Abort method, ICorDebugEval interface [.NET debugging]"
  - "ICorDebugEval::Abort method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugEval::Abort Method

Aborts the computation this ICorDebugEval object is currently performing.

## Syntax

```cpp
HRESULT Abort ();
```

## Remarks

 If the evaluation is nested and it is not the most recent one, the `Abort` method may fail.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
