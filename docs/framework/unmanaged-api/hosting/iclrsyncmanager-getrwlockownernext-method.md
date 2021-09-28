---
description: "Learn more about: ICLRSyncManager::GetRWLockOwnerNext Method"
title: "ICLRSyncManager::GetRWLockOwnerNext Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRSyncManager.GetRWLockOwnerNext"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRSyncManager::GetRWLockOwnerNext"
helpviewer_keywords: 
  - "ICLRSyncManager::GetRWLockOwnerNext method [.NET Framework hosting]"
  - "GetRWLockOwnerNext method [.NET Framework hosting]"
ms.assetid: 0e025b6a-280e-40a2-a2d0-b15f58777b81
topic_type: 
  - "apiref"
---
# ICLRSyncManager::GetRWLockOwnerNext Method

Gets the next [IHostTask](ihosttask-interface.md) instance that is blocked on the current reader-writer lock.  
  
## Syntax  
  
```cpp
HRESULT GetRWLockOwnerNext (  
    [in] SIZE_T       Iterator,  
    [out] IHostTask  *ppOwnerHostTask  
);  
```  
  
## Parameters  

 `Iterator`  
 [in] The iterator that was created by using a call to [CreateRWLockOwnerIterator](iclrsyncmanager-createrwlockowneriterator-method.md).  
  
 `ppOwnerHostTask`  
 [out] A pointer to the next `IHostTask` that is waiting on the lock, or null if no task is waiting.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`GetRWLockOwnerNext` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 If `ppOwnerHostTask` is set to null, the iteration has terminated, and the host should call the [DeleteRWLockOwnerIterator](iclrsyncmanager-deleterwlockowneriterator-method.md) method.  
  
> [!NOTE]
> The CLR calls `AddRef` on the `IHostTask` to which `ppOwnerHostTask` points to prevent this task from exiting while the host holds the pointer. The host must call `Release` to decrement the reference count when it is finished.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRSyncManager Interface](iclrsyncmanager-interface.md)
- [IHostSyncManager Interface](ihostsyncmanager-interface.md)
