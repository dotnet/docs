---
description: "Learn more about: ICorDebugThread::GetAppDomain Method"
title: "ICorDebugThread::GetAppDomain Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugThread.GetAppDomain"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugThread::GetAppDomain"
helpviewer_keywords:
  - "GetAppDomain method, ICorDebugThread interface [.NET debugging]"
  - "ICorDebugThread::GetAppDomain method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugThread::GetAppDomain Method

Gets an interface pointer to the application domain in which this ICorDebugThread is currently executing.

## Syntax

```cpp
HRESULT GetAppDomain (
    [out] ICorDebugAppDomain  **ppAppDomain
);
```

## Parameters

 `ppAppDomain`
 [out] A pointer to an ICorDebugAppDomain object that represents the application domain in which this thread is currently executing.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
