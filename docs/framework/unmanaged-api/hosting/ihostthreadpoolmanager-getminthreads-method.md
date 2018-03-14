---
title: "IHostThreadPoolManager::GetMinThreads Method"
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
  - "IHostThreadPoolManager.GetMinThreads"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostThreadPoolManager::GetMinThreads"
helpviewer_keywords: 
  - "IHostThreadPoolManager::GetMinThreads method [.NET Framework hosting]"
  - "GetMinThreads method, IHostThreadPoolManager interface [.NET Framework hosting]"
ms.assetid: dc07232b-b2e4-4dab-87e2-3c955974ab48
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostThreadPoolManager::GetMinThreads Method
Gets the minimum number of idle threads that the host maintains in the thread pool in anticipation of requests.  
  
## Syntax  
  
```  
HRESULT GetMinThreads (  
    [out] DWORD *MinThreads  
);  
```  
  
#### Parameters  
 `MinThreads`  
 [out] A pointer to the minimum number of idle worker threads that the host currently maintains.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`GetMinThreads` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_NOTIMPL|The host does not provide an implementation of `GetMinThreads`.|  
  
## Remarks  
 The host is not required to provide an implementation of `GetMinThreads`. In this case, it should return an HRESULT value of E_NOTIMPL.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 <xref:System.Threading.ThreadPool.GetMinThreads%2A>  
 <xref:System.Threading.ThreadPool>  
 [GetMaxThreads Method](../../../../docs/framework/unmanaged-api/hosting/ihostthreadpoolmanager-getmaxthreads-method.md)  
 [SetMinThreads Method](../../../../docs/framework/unmanaged-api/hosting/ihostthreadpoolmanager-setminthreads-method.md)  
 [IHostThreadPoolManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostthreadpoolmanager-interface.md)
