---
description: "Learn more about: IHostIoCompletionManager::SetMinThreads Method"
title: "IHostIoCompletionManager::SetMinThreads Method"
ms.date: "03/30/2017"
api_name:
  - "IHostIoCompletionManager.SetMinThreads"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IHostIoCompletionManager::SetMinThreads"
helpviewer_keywords:
  - "SetMinThreads method, IHostIoCompletionManager interface [.NET Framework hosting]"
  - "IHostIoCompletionManager::SetMinThreads method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IHostIoCompletionManager::SetMinThreads Method

Sets the minimum number of threads that the host should allot to I/O completion.

## Syntax

```cpp
HRESULT SetMinThreads (
    [in] DWORD dwMinIoCompletionThreads
);
```

## Parameters

 `dwMinIoCompletionThreads`
 [in] The minimum number of I/O completion threads that the host should create.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|`SetMinThreads` returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|
|E_NOTIMPL|The host does not provide an implementation of `SetMinThreads`.|

## Remarks

 A host might want exclusive control over the number of threads that can be allotted to process I/O requests, for reasons such as implementation, performance, or scalability. For this reason, the host is not required to implement `SetMinThreads`. In this case, the host should return E_NOTIMPL from this method.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRIoCompletionManager Interface](iclriocompletionmanager-interface.md)
- [SetMaxThreads Method](ihostiocompletionmanager-setmaxthreads-method.md)
- [IHostIoCompletionManager Interface](ihostiocompletionmanager-interface.md)
