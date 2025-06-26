---
description: "Learn more about: IHostSyncManager::CreateCrst Method"
title: "IHostSyncManager::CreateCrst Method"
ms.date: "03/30/2017"
api_name:
  - "IHostSyncManager.CreateCrst"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IHostSyncManager::CreateCrst"
helpviewer_keywords:
  - "CreateCrst method [.NET Framework hosting]"
  - "IHostSyncManager::CreateCrst method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IHostSyncManager::CreateCrst Method

Creates a critical section object for synchronization.

## Syntax

```cpp
HRESULT CreateCrst (
    [out] IHostCrst** ppCrst
);
```

## Parameters

 `ppCrst`
 [out] A pointer to the address of an [IHostCrst](ihostcrst-interface.md) instance implemented by the host, or null if the critical section could not be created.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|`CreateCrst` returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|
|E_OUTOFMEMORY|Not enough memory was available to create the requested critical section.|

## Remarks

 Critical section objects provide synchronization similar to that provided by a mutex object, except that critical sections can be used only by the threads of a single process. `CreateCrst` mirrors the Win32 `InitializeCriticalSection` function.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRSyncManager Interface](iclrsyncmanager-interface.md)
- [IHostCrst Interface](ihostcrst-interface.md)
- [IHostSyncManager Interface](ihostsyncmanager-interface.md)
- [IHostSemaphore Interface](ihostsemaphore-interface.md)
- [Mutexes](../../../standard/threading/mutexes.md)
- [Semaphore and SemaphoreSlim](../../../standard/threading/semaphore-and-semaphoreslim.md)
