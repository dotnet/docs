---
description: "Learn more about: IHostThreadPoolManager::SetMaxThreads Method"
title: "IHostThreadPoolManager::SetMaxThreads Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostThreadPoolManager.SetMaxThreads"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostThreadPoolManager::SetMaxThreads"
helpviewer_keywords: 
  - "IHostThreadPoolManager::SetMaxThreads method [.NET Framework hosting]"
  - "SetMaxThreads method, IHostThreadPoolManager interface [.NET Framework hosting]"
ms.assetid: 77cfd347-95c2-4425-b807-4ecc2a8d4578
topic_type: 
  - "apiref"
---
# IHostThreadPoolManager::SetMaxThreads Method

Sets the maximum number of threads that the host can maintain in the thread pool.  
  
## Syntax  
  
```cpp  
HRESULT SetMaxThreads (  
    [in] DWORD MaxThreads  
);  
```  
  
## Parameters  

 `MaxThreads`  
 The maximum number of worker threads in the thread pool.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`SetMaxThreads` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown, catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_NOTIMPL|The host does not provide an implementation of `SetMaxThreads`.|  
  
## Remarks  

 A host is not required to allow the CLR to configure the size of the thread pool. Some hosts might want exclusive control over the thread pool, for reasons such as implementation, performance, or scalability. In this case, a host should return an HRESULT value of E_NOTIMPL.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- <xref:System.Threading.ThreadPool.SetMaxThreads%2A>
- <xref:System.Threading.ThreadPool>
- [GetMaxThreads Method](ihostthreadpoolmanager-getmaxthreads-method.md)
- [SetMinThreads Method](ihostthreadpoolmanager-setminthreads-method.md)
- [IHostThreadPoolManager Interface](ihostthreadpoolmanager-interface.md)
