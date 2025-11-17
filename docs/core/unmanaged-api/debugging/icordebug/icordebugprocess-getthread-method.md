---
description: "Learn more about: ICorDebugProcess::GetThread Method"
title: "ICorDebugProcess::GetThread Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugProcess.GetThread"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugProcess::GetThread"
helpviewer_keywords:
  - "ICorDebugProcess::GetThread method [.NET debugging]"
  - "GetThread method, ICorDebugProcess interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugProcess::GetThread Method

Gets this process's thread that has the specified operating system (OS) thread ID.

## Syntax

```cpp
HRESULT GetThread(
    [in] DWORD dwThreadId,
    [out] ICorDebugThread **ppThread);
```

## Parameters

 `dwThreadId`
 [in] The OS thread ID of the thread to be retrieved.

 `ppThread`
 [out] A pointer to the address of an ICorDebugThread object that represents the thread.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
