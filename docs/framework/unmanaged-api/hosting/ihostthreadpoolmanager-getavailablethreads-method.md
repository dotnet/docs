---
description: "Learn more about: IHostThreadPoolManager::GetAvailableThreads Method"
title: "IHostThreadPoolManager::GetAvailableThreads Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostThreadPoolManager.GetAvailableThreads"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostThreadPoolManager::GetAvailableThreads"
helpviewer_keywords: 
  - "GetAvailableThreads method, IHostThreadPoolManager interface [.NET Framework hosting]"
  - "IHostThreadPoolManager::GetAvailableThreads method [.NET Framework hosting]"
ms.assetid: 61d26dfd-7f24-4e7d-a63e-b30a463f08e1
topic_type: 
  - "apiref"
---
# IHostThreadPoolManager::GetAvailableThreads Method

Gets the number of threads in the thread pool that are not currently processing work items.  
  
## Syntax  
  
```cpp  
HRESULT GetAvailableThreads (  
    [out] DWORD *pdwAvailableWorkerThreads  
);  
```  
  
## Parameters  

 `pdwAvailableWorkerThreads`  
 [out] Pointer to the number of threads in the thread pool that are not currently processing work items.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`GetAvailableThreads` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_NOTIMPL|The host does not provide an implementation of `GetAvailableThreads`.|  
  
## Remarks  

 If the host does not provide an implementation of `GetAvailableThreads`, it should return an HRESULT value of E_NOTIMPL.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- <xref:System.Threading.ThreadPool.GetAvailableThreads%2A>
- <xref:System.Threading.ThreadPool>
- [IHostThreadPoolManager Interface](ihostthreadpoolmanager-interface.md)
