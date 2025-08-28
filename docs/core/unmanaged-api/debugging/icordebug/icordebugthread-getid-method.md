---
description: "Learn more about: ICorDebugThread::GetID Method"
title: "ICorDebugThread::GetID Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugThread.GetID"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugThread::GetID"
helpviewer_keywords:
  - "ICorDebugThread::GetID method [.NET debugging]"
  - "GetID method, ICorDebugThread interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugThread::GetID Method

Gets the current operating system identifier of the active part of this ICorDebugThread.

## Syntax

```cpp
HRESULT GetID (
    [out] DWORD *pdwThreadId
);
```

## Parameters

 `pdwThreadId`
 [out] The identifier of the thread.

## Remarks

 The operating system identifier can potentially change during execution of a process, and can be a different value for different parts of the thread.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
