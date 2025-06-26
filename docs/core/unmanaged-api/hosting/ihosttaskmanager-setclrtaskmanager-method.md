---
description: "Learn more about: IHostTaskManager::SetCLRTaskManager Method"
title: "IHostTaskManager::SetCLRTaskManager Method"
ms.date: "03/30/2017"
api_name:
  - "IHostTaskManager.SetCLRTaskManager"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IHostTaskManager::SetCLRTaskManager"
helpviewer_keywords:
  - "IHostTaskManager::SetCLRTaskManager method [.NET Framework hosting]"
  - "SetCLRTaskManager method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IHostTaskManager::SetCLRTaskManager Method

Provides the host with an interface pointer to an [ICLRTaskManager](iclrtaskmanager-interface.md) instance implemented by the common language runtime (CLR).

## Syntax

```cpp
HRESULT SetCLRTaskManager (
    [in] ICLRTaskManager *pManager
);
```

## Parameters

 `pManager`
 [in] A pointer to an `ICLRTaskManager` instance implemented by the common language runtime.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|`SetCLRTaskManager` returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|

## Remarks

 The runtime calls `SetCLRTaskManager` to provide the host with an interface pointer to an `ICLRTaskManager` instance.

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
