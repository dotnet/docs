---
description: "Learn more about: IHostTask Interface"
title: "IHostTask Interface"
ms.date: "03/30/2017"
api_name:
  - "IHostTask"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IHostTask"
helpviewer_keywords:
  - "IHostTask interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IHostTask Interface

Provides methods that allow the common language runtime (CLR) to communicate with the host to manage tasks.

## Methods

|Method|Description|
|------------|-----------------|
|[Alert Method](ihosttask-alert-method.md)|Requests that the host wake the task represented by the current `IHostTask` instance, so the task can be aborted.|
|[GetPriority Method](ihosttask-getpriority-method.md)|Gets the thread priority level of the task represented by the current `IHostTask` instance.|
|[Join Method](ihosttask-join-method.md)|Blocks the calling task until the task represented by the current `IHostTask` instance completes, the specified time interval elapses, or [IHostTask::Alert](ihosttask-alert-method.md) is called.|
|[SetCLRTask Method](ihosttask-setclrtask-method.md)|Associates an [ICLRTask Interface](iclrtask-interface.md) instance with the current `IHostTask` instance.|
|[SetPriority Method](ihosttask-setpriority-method.md)|Requests that the host adjust the thread priority level for the task represented by the current `IHostTask` instance.|
|[Start Method](ihosttask-start-method.md)|Requests that the host move the task represented by the current `IHostTask` instance from a suspended state to a live state, in which code can be executed.|

## Remarks

 The CLR calls methods defined by `IHostTask` to start a task, set its thread priority level, and so on.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRTask Interface](iclrtask-interface.md)
- [ICLRTaskManager Interface](iclrtaskmanager-interface.md)
- [IHostTaskManager Interface](ihosttaskmanager-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
