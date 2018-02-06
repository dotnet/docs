---
title: "IHostSyncManager::CreateCrst Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
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
ms.assetid: ac278cc8-2540-4a6c-b5c6-b90c3970b4f4
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostSyncManager::CreateCrst Method
Creates a critical section object for synchronization.  
  
## Syntax  
  
```  
HRESULT CreateCrst (  
    [out] IHostCrst** ppCrst  
);  
```  
  
#### Parameters  
 `ppCrst`  
 [out] A pointer to the address of an [IHostCrst](../../../../docs/framework/unmanaged-api/hosting/ihostcrst-interface.md) instance implemented by the host, or null if the critical section could not be created.  
  
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
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRSyncManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrsyncmanager-interface.md)  
 [IHostCrst Interface](../../../../docs/framework/unmanaged-api/hosting/ihostcrst-interface.md)  
 [IHostSyncManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostsyncmanager-interface.md)  
 [IHostSemaphore Interface](../../../../docs/framework/unmanaged-api/hosting/ihostsemaphore-interface.md)  
 [Mutexes](../../../../docs/standard/threading/mutexes.md)  
 [Semaphore and SemaphoreSlim](../../../../docs/standard/threading/semaphore-and-semaphoreslim.md)
