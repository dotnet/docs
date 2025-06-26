---
description: "Learn more about: ICLRTask::ExitTask Method"
title: "ICLRTask::ExitTask Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRTask.ExitTask"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRTask::ExitTask"
helpviewer_keywords:
  - "ExitTask method [.NET Framework hosting]"
  - "ICLRTask::ExitTask method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRTask::ExitTask Method

Notifies the common language runtime (CLR) that the task represented by the current [ICLRTask](iclrtask-interface.md) instance is ending, and attempts to shut the task down gracefully.

## Syntax

```cpp
HRESULT ExitTask ();
```

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|`ExitTask` returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|

## Remarks

 `ExitTask` attempts a clean shutdown of a task, in a manner analogous to detaching a thread from an unmanaged type library.

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
