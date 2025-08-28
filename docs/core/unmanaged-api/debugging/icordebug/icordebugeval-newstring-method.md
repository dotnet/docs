---
description: "Learn more about: ICorDebugEval::NewString Method"
title: "ICorDebugEval::NewString Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugEval.NewString"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugEval::NewString"
helpviewer_keywords:
  - "NewString method [.NET debugging]"
  - "ICorDebugEval::NewString method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugEval::NewString Method

Allocates a new string instance with the specified contents.

## Syntax

```cpp
HRESULT NewString (
    [in] LPCWSTR   string
);
```

## Parameters

 `string`
 [in] Pointer to the contents for the string.

## Remarks

 The string is always created in the application domain in which the thread is currently executing.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
