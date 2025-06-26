---
description: "Learn more about: ICLRSyncManager::DeleteRWLockOwnerIterator Method"
title: "ICLRSyncManager::DeleteRWLockOwnerIterator Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRSyncManager.DeleteRWLockOwnerIterator"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRSyncManager::DeleteRWLockOwnerIterator"
helpviewer_keywords: 
  - "ICLRSyncManager::DeleteRWLockOwnerIterator method [.NET Framework hosting]"
  - "DeleteRWLockOwnerIterator method [.NET Framework hosting]"
ms.assetid: fcfd340a-b7d6-44e4-8167-2c05b789d483
topic_type: 
  - "apiref"
---
# ICLRSyncManager::DeleteRWLockOwnerIterator Method

Requests that the common language runtime (CLR) destroy an iterator that was created by a call to [ICLRSyncManager::CreateRWLockOwnerIterator](iclrsyncmanager-createrwlockowneriterator-method.md).  
  
## Syntax  
  
```cpp  
HRESULT DeleteRWLockOwnerIterator (  
    [in] SIZE_T  Iterator  
);  
```  
  
## Parameters  

 `Iterator`  
 [in] The iterator that was created by using a call to `CreateRWLockOwnerIterator`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`DeleteRWLockOwnerIterator` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or is in a state in which it cannot run managed code or successfully process the call.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 The host can call this method and `CreateRWLockOwnerIterator` to ensure that its threading implementation remains synchronized.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRSyncManager Interface](iclrsyncmanager-interface.md)
- [IHostSyncManager Interface](ihostsyncmanager-interface.md)
