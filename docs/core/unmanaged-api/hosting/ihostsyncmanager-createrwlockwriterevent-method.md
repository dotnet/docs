---
description: "Learn more about: IHostSyncManager::CreateRWLockWriterEvent Method"
title: "IHostSyncManager::CreateRWLockWriterEvent Method"
ms.date: "03/30/2017"
api_name:
  - "IHostSyncManager.CreateRWLockWriterEvent"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IHostSyncManager::CreateRWLockWriterEvent"
helpviewer_keywords:
  - "CreateRWLockWriterEvent method [.NET Framework hosting]"
  - "IHostSyncManager::CreateRWLockWriterEvent method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IHostSyncManager::CreateRWLockWriterEvent Method

Creates an auto-reset event object for the implementation of a writer lock.

## Syntax

```cpp
HRESULT CreateRWLockWriterEvent (
    [in]  SIZE_T cookie,
    [out] IHostAutoEvent **ppEvent
);
```

## Parameters

 `cookie`
 [in] A cookie to associate with the auto-reset event.

 `ppEvent`
 [out] A pointer to the address of an [IHostAutoEvent](ihostautoevent-interface.md) instance, or null if the event object could not be created.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|`CreateRWLockWriterEvent` returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|
|E_OUTOFMEMORY|Not enough memory was available to create the requested event object.|

## Remarks

 The CLR calls the `CreateRWLockWriterEvent` method to get a reference to an `IHostAutoEvent` instance to use in its implementation of a writer lock. The host can use the specified cookie to determine which tasks are waiting on the lock by calling the iteration methods of the [ICLRSyncManager](iclrsyncmanager-interface.md) interface.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRSyncManager Interface](iclrsyncmanager-interface.md)
- [IHostAutoEvent Interface](ihostautoevent-interface.md)
- [IHostManualEvent Interface](ihostmanualevent-interface.md)
- [IHostSyncManager Interface](ihostsyncmanager-interface.md)
