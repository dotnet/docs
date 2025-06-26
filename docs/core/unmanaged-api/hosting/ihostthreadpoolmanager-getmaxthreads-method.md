---
description: "Learn more about: IHostThreadPoolManager::GetMaxThreads Method"
title: "IHostThreadPoolManager::GetMaxThreads Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostThreadPoolManager.GetMaxThreads"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostThreadPoolManager::GetMaxThreads"
helpviewer_keywords: 
  - "IHostThreadPoolManager::GetMaxThreads method [.NET Framework hosting]"
  - "GetMaxThreads method, IHostThreadPoolManager interface [.NET Framework hosting]"
ms.assetid: db268876-6178-4a81-aca3-318ee7f96001
topic_type: 
  - "apiref"
---
# IHostThreadPoolManager::GetMaxThreads Method

Gets the maximum number of threads that the host maintains concurrently in the thread pool.  
  
## Syntax  
  
```cpp  
HRESULT GetMaxThreads (  
    [out] DWORD *pdwMaxWorkerThreads  
);  
```  
  
## Parameters  

 `pdwMaxWorkerThreads`  
 [out] A pointer to the maximum number of threads that the host maintains in the thread pool.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`GetMaxThreads` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR( has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_NOTIMPL|The host does not provide an implementation of `GetMaxThreads`.|  
  
## Remarks  

 The CLR calls `GetMaxThreads` to determine the total number of threads in the thread pool. The [GetAvailableThreads](ihostthreadpoolmanager-getavailablethreads-method.md) method gets the number of threads that are not currently processing work items. All requests above the returned value of the `pdwMaxWorkerThreads` parameter remain queued until threads become available.  
  
 If the host does not provide an implementation of `GetMaxThreads`, it should return an HRESULT value of E_NOTIMPL.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- <xref:System.Threading.ThreadPool.GetMaxThreads%2A>
- <xref:System.Threading.ThreadPool>
- [GetMinThreads Method](ihostthreadpoolmanager-getminthreads-method.md)
- [SetMaxThreads Method](ihostthreadpoolmanager-setmaxthreads-method.md)
- [IHostThreadPoolManager Interface](ihostthreadpoolmanager-interface.md)
