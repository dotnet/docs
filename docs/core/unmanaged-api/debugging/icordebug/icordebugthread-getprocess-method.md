---
description: "Learn more about: ICorDebugThread::GetProcess Method"
title: "ICorDebugThread::GetProcess Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugThread.GetProcess"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugThread::GetProcess"
helpviewer_keywords:
  - "ICorDebugThread::GetProcess method [.NET debugging]"
  - "GetProcess method, ICorDebugThread interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugThread::GetProcess Method

Gets an interface pointer to the process of which this ICorDebugThread forms a part.

## Syntax

```cpp
HRESULT GetProcess (
    [out] ICorDebugProcess   **ppProcess
);
```

## Parameters

 `ppProcess`
 [out] A pointer to the address of an ICorDebugProcess interface object that represents the process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
