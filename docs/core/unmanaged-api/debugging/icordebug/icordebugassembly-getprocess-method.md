---
description: "Learn more about: ICorDebugAssembly::GetProcess Method"
title: "ICorDebugAssembly::GetProcess Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAssembly.GetProcess"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAssembly::GetProcess"
helpviewer_keywords:
  - "ICorDebugAssembly::GetProcess method [.NET debugging]"
  - "GetProcess method, ICorDebugAssembly interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugAssembly::GetProcess Method

Gets an interface pointer to the process in which this ICorDebugAssembly instance is running.

## Syntax

```cpp
HRESULT GetProcess (
    [out] ICorDebugProcess **ppProcess
);
```

## Parameters

 `ppProcess`
 [out] A pointer to an ICorDebugProcess interface that represents the process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
