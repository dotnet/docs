---
description: "Learn more about: ICorDebugThread::GetUserState Method"
title: "ICorDebugThread::GetUserState Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugThread.GetUserState"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugThread::GetUserState"
helpviewer_keywords:
  - "GetUserState method, ICorDebugThread interface [.NET debugging]"
  - "ICorDebugThread::GetUserState method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugThread::GetUserState Method

Gets the current user state of this ICorDebugThread.

## Syntax

```cpp
HRESULT GetUserState (
    [out] CorDebugUserState   *pState
);
```

## Parameters

 `pState`
 [out] A pointer to a bitwise combination of CorDebugUserState enumeration values that describe the current user state of this thread.

## Remarks

The user state of the thread is the state of the thread when it is examined by the program that is being debugged. A thread may have multiple state bits set.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
