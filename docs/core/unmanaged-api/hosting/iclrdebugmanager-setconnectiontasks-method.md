---
description: "Learn more about: ICLRDebugManager::SetConnectionTasks Method"
title: "ICLRDebugManager::SetConnectionTasks Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRDebugManager.SetConnectionTasks"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRDebugManager::SetConnectionTasks"
helpviewer_keywords:
  - "SetConnectionTasks method [.NET Framework hosting]"
  - "ICLRDebugManager::SetConnectionTasks method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRDebugManager::SetConnectionTasks Method

Associates a list of [ICLRTask](iclrtask-interface.md) instances with an identifier and a friendly name.

## Syntax

```cpp
HRESULT SetConnectionTasks (
    [in] CONNID id,
    [in] DWORD dwCount,
    [in, size_is(dwCount)] ICLRTask **ppCLRTask
);
```

## Parameters

 `id`
 [in] The host-specific identifier for the connection with which to associate the `ppCLRTask` array.

 `dwCount`
 [in] The number of members of `ppCLRTask`. This number must be greater than zero.

 `ppCLRTask`
 [in] An array of `ICLRTask` pointers to associate with the connection identified by `id`. This array must contain at least one member.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|`SetConnectionTasks` returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|
|E_INVALIDARG|[BeginConnection](iclrdebugmanager-beginconnection-method.md) has not been called using this value of `id`, or `dwCount` or `id` is zero, or one of the elements of `ppCLRTask` is null.|

## Remarks

 [ICLRDebugManager](iclrdebugmanager-interface.md) provides three methods, `BeginConnection`, `SetConnectionTasks`, and [EndConnection](iclrdebugmanager-endconnection-method.md), for associating task lists with identifiers and friendly names.

> [!IMPORTANT]
> These three methods must be called in a specific order for each set of tasks. `BeginConnection` is called first to establish a new connection. `SetConnectionTasks` is called next to provide the set of tasks to be associated with that connection. `EndConnection` is called last to remove the association between the task list and the identifier and friendly name.However, calls for different connections can be nested.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRControl Interface](iclrcontrol-interface.md)
- [ICLRDebugManager Interface](iclrdebugmanager-interface.md)
- [BeginConnection Method](iclrdebugmanager-beginconnection-method.md)
- [EndConnection Method](iclrdebugmanager-endconnection-method.md)
- [IHostControl Interface](ihostcontrol-interface.md)
