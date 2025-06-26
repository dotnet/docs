---
description: "Learn more about: IHostTaskManager::SwitchToTask Method"
title: "IHostTaskManager::SwitchToTask Method"
ms.date: "03/30/2017"
api_name:
  - "IHostTaskManager.SwitchToTask"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IHostTaskManager::SwitchToTask"
helpviewer_keywords:
  - "IHostTaskManager::SwitchToTask method [.NET Framework hosting]"
  - "SwitchToTask method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IHostTaskManager::SwitchToTask Method

Notifies the host that it should switch out the current task.

## Syntax

```cpp
HRESULT SwitchToTask (
    [in] DWORD option
);
```

## Parameters

 `option`
 [in] One of the [WAIT_OPTION](wait-option-enumeration.md) enumeration values, indicating the action the host should take if the requested operation blocks.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|`SwitchToTask` returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|

## Remarks

 The host can switch in another task as desired or needed.

> [!NOTE]
> `SwitchToTask` does not specify which task the host should switch to; it specifies only the task that it should switch from.

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
