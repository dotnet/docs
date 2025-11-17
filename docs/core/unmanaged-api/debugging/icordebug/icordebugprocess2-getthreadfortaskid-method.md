---
description: "Learn more about: ICorDebugProcess2::GetThreadForTaskID Method"
title: "ICorDebugProcess2::GetThreadForTaskID Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugProcess2.GetThreadForTaskID"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugProcess2::GetThreadForTaskID"
helpviewer_keywords:
  - "ICorDebugProcess2::GetThreadForTaskId method [.NET debugging]"
  - "GetThreadForTaskID method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugProcess2::GetThreadForTaskID Method

Gets the thread on which the task with the specified identifier is executing.

## Syntax

```cpp
HRESULT GetThreadForTaskID (
    [in]  TASKID            taskid,
    [out] ICorDebugThread2  **ppThread
);
```

## Parameters

 `taskid`
 [in] The identifier of the task.

 `ppThread`
 [out] A pointer to the address of an ICorDebugThread2 object that represents the thread to be retrieved.

## Remarks

The host can set the task identifier by using the [ICLRTask::SetTaskIdentifier](../../../../framework/unmanaged-api/hosting/iclrtask-settaskidentifier-method.md) method.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
