---
description: "Learn more about: ICLRTaskManager Interface"
title: "ICLRTaskManager Interface"
ms.date: "03/30/2017"
api_name:
  - "ICLRTaskManager"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRTaskManager"
helpviewer_keywords:
  - "ICLRTaskManager interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRTaskManager Interface

Provides methods that allow the host to request explicitly that the common language runtime (CLR) create a new task, get the currently executing task, and set the geographic language and culture for the task.

## Methods

|Method|Description|
|------------|-----------------|
|[CreateTask Method](iclrtaskmanager-createtask-method.md)|Requests explicitly that the CLR create a new [ICLRTask](iclrtask-interface.md) instance.|
|[GetCurrentTask Method](iclrtaskmanager-getcurrenttask-method.md)|Gets the `ICLRTask` instance that represents the task that is currently executing.|
|[GetCurrentTaskType Method](iclrtaskmanager-getcurrenttasktype-method.md)|Gets the type of the task that is currently executing.|
|[SetLocale Method](iclrtaskmanager-setlocale-method.md)|Notifies the CLR that the host has modified the locale identifier on the currently executing task.|
|[SetUILocale Method](iclrtaskmanager-setuilocale-method.md)|Notifies the common language runtime that the host has modified the user interface locale identifier on the currently executing task.|

## Remarks

 Each task that is running in a hosted environment has representations both on the host side (an instance of [IHostTask](ihosttask-interface.md)) and on the CLR side (an instance of [ICLRTask](iclrtask-interface.md)). Either the host or the CLR can initiate the creation of a task, but the host-side representation must be associated with a corresponding CLR-side representation to ensure successful communication between the host and the CLR regarding the task. The two objects must be created and instantiated before managed code can execute on an operating system thread.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRTask Interface](iclrtask-interface.md)
- [IHostTask Interface](ihosttask-interface.md)
- [IHostTaskManager Interface](ihosttaskmanager-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
