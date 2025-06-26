---
description: "Learn more about: ICLRTaskManager::CreateTask Method"
title: "ICLRTaskManager::CreateTask Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRTaskManager.CreateTask"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRTaskManager::CreateTask"
helpviewer_keywords:
  - "ICLRTaskManager::CreateTask method [.NET Framework hosting]"
  - "CreateTask method, ICLRTaskManager interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRTaskManager::CreateTask Method

Requests explicitly that the common language runtime (CLR) create a new task.

## Syntax

```cpp
HRESULT CreateTask (
    [out] ICLRTask **pTask
);
```

## Parameters

 `pTask`
 [out] A pointer to the address of a newly created [ICLRTask](iclrtask-interface.md), or null, if the task could not be created.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|The method returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|
|E_OUTOFMEMORY|Not enough memory is available to allocate the requested resource.|

## Remarks

 The CLR creates a new task automatically upon initialization, when user code creates a thread by using types in the <xref:System.Threading> namespace, or when the size of the thread pool is increased. It also creates tasks when unmanaged code makes a call to a managed function.

 `CreateTask` allows the host to make an explicit request that the CLR create a new task. For example, the host can invoke this method to preinitialize data structures.

> [!IMPORTANT]
> The new task is returned in a suspended state and remains suspended until the host explicitly calls [IHostTask::Start](ihosttask-start-method.md).

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRTask Interface](iclrtask-interface.md)
- [ICLRTaskManager Interface](iclrtaskmanager-interface.md)
- [IHostTask Interface](ihosttask-interface.md)
- [IHostTaskManager Interface](ihosttaskmanager-interface.md)
