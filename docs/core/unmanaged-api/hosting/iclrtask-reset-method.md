---
description: "Learn more about: ICLRTask::Reset Method"
title: "ICLRTask::Reset Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRTask.Reset"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRTask::Reset"
helpviewer_keywords:
  - "ICLRTask::Reset method [.NET Framework hosting]"
  - "Reset method, ICLRTask interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRTask::Reset Method

Informs the common language runtime (CLR) that the host has completed a task, and enables the CLR to reuse the current [ICLRTask](iclrtask-interface.md) instance to represent another task.

## Syntax

```cpp
HRESULT Reset (
    [in] BOOL fFull
);
```

## Parameters

 `fFull`
 [in] `true`, if the runtime should reset all thread-related static values in addition to the security and locale information related to the current `ICLRTask` instance; otherwise, `false`.

 If the value is `true`, the runtime resets data that was stored using <xref:System.Threading.Thread.AllocateDataSlot%2A> or <xref:System.Threading.Thread.AllocateNamedDataSlot%2A>.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|`Reset` returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call. successfully|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|

## Remarks

 The CLR can recycle previously created `ICLRTask` instances to avoid the overhead of repeatedly creating new instances every time it needs a fresh task. The host enables this feature by calling `ICLRTask::Reset` instead of [ICLRTask::ExitTask](iclrtask-exittask-method.md) when it has completed a task. The following list summarizes the normal life cycle of an `ICLRTask` instance:

1. The runtime creates a new `ICLRTask` instance.

2. The runtime calls [IHostTaskManager::GetCurrentTask](ihosttaskmanager-getcurrenttask-method.md) to get a reference to the current host task.

3. The runtime calls [IHostTask::SetCLRTask](ihosttask-setclrtask-method.md) to associate the new instance with the host task.

4. The task executes and completes.

5. The host destroys the task by calling `ICLRTask::ExitTask`.

 `Reset` alters this scenario in two ways. In step 5 above, the host calls `Reset` to reset the task to a clean state, and then decouples the `ICLRTask` instance from its associated [IHostTask](ihosttask-interface.md) instance. If desired, the host can also cache the `IHostTask` instance for reuse. In step 1 above, the runtime pulls a recycled `ICLRTask` from the cache instead of creating a new instance.

 This approach works well when the host also has a pool of reusable worker tasks. When the host destroys one of its `IHostTask` instances, it destroys the corresponding `ICLRTask` by calling `ExitTask`.

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
