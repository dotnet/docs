---
description: "Learn more about: IHostTaskManager::EndDelayAbort Method"
title: "IHostTaskManager::EndDelayAbort Method"
ms.date: "03/30/2017"
api_name:
  - "IHostTaskManager.EndDelayAbort"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IHostTaskManager::EndDelayAbort"
helpviewer_keywords:
  - "EndDelayAbort method [.NET Framework hosting]"
  - "IHostTaskManager::EndDelayAbort method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IHostTaskManager::EndDelayAbort Method

Notifies the host that managed code is exiting the period in which the current task must not be aborted, following an earlier call to [IHostTaskManager::BeginDelayAbort](ihosttaskmanager-begindelayabort-method.md).

## Syntax

```cpp
HRESULT EndDelayAbort ();
```

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|`EndDelayAbort` returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|
|E_UNEXPECTED|`EndDelayAbort` was called without a corresponding call to `BeginDelayAbort`.|

## Remarks

 The CLR makes a corresponding call to `BeginDelayAbort` on the current task before calling `EndDelayAbort`. In the absence of such a corresponding call, the host's implementation of [IHostTaskManager](ihosttaskmanager-interface.md) should return E_UNEXPECTED from `EndDelayAbort`, and should take no action.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- <xref:System.Threading>
- [ICLRTask Interface](iclrtask-interface.md)
- [ICLRTaskManager Interface](iclrtaskmanager-interface.md)
- [IHostTask Interface](ihosttask-interface.md)
- [IHostTaskManager Interface](ihosttaskmanager-interface.md)
