---
description: "Learn more about: ICorDebugThread2::GetTaskID Method"
title: "ICorDebugThread2::GetTaskID Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugThread2.GetTaskID"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugThread2::GetTaskID"
helpviewer_keywords:
  - "ICorDebugThread2::GetTaskID method [.NET debugging]"
  - "GetTaskID method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugThread2::GetTaskID Method

Gets the identifier of the task running on this thread.

## Syntax

```cpp
HRESULT GetTaskID (
    [out] TASKID  *pTaskId
);
```

## Parameters

 `pTaskId`
 [out] A pointer to the identifier of the task running on the thread represented by this ICorDebugThread2 object.

## Remarks

 A task can only be running on the thread if the thread is associated with a connection. `GetTaskID` returns zero in `pTaskId` if the thread is not associated with a connection.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
