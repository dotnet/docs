---
description: "Learn more about: IHostIoCompletionManager::CloseIoCompletionPort Method"
title: "IHostIoCompletionManager::CloseIoCompletionPort Method"
ms.date: "03/30/2017"
api_name:
  - "IHostIoCompletionManager.CloseIoCompletionPort"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IHostIoCompletionManager::CloseIoCompletionPort"
helpviewer_keywords:
  - "IHostIoCompletionManager::CloseIoCompletionPort method [.NET Framework hosting]"
  - "CloseIoCompletionPort method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IHostIoCompletionManager::CloseIoCompletionPort Method

Requests that the host close a port that was opened through an earlier call to [CreateIoCompletionPort](ihostiocompletionmanager-createiocompletionport-method.md).

## Syntax

```cpp
HRESULT CloseIoCompletionPort (
    [in] HANDLE hPort
);
```

## Parameters

 `hPort`
 [in] The handle of the port to close.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|`CloseIoCompletionPort` returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|
|E_INVALIDARG|An invalid port handle was passed.|

## Remarks

 `hPort` must be a handle to a port that was created by an earlier call to `CreateIoCompletionPort`.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRIoCompletionManager Interface](iclriocompletionmanager-interface.md)
- [IHostIoCompletionManager Interface](ihostiocompletionmanager-interface.md)
