---
title: "IHostIoCompletionManager::GetMaxThreads Method"
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
  - "IHostIoCompletionManager.GetMaxThreads"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostIoCompletionManager::GetMaxThreads"
helpviewer_keywords: 
  - "IHostIoCompletionManager::GetMaxThreads method [.NET Framework hosting]"
  - "GetMaxThreads method, IHostIoCompletionManager interface [.NET Framework hosting]"
ms.assetid: e7a6cadc-2433-4472-a701-58891abcde45
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostIoCompletionManager::GetMaxThreads Method
Gets the maximum number of threads that the host can allot to service I/O requests.  
  
## Syntax  
  
```  
HRESULT GetMaxThreads (  
    [out] DWORD *pdwMaxIoCompletionThreads  
);  
```  
  
#### Parameters  
 `pdwMaxIoCompletionThreads`  
 [out] A pointer to the maximum number of threads in the thread pool that the host can allot to service I/O requests.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`GetMaxThreads` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_NOTIMPL|The host does not provide an implementation of `GetMaxThreads`.|  
  
## Remarks  
 A host might want exclusive control over the number of threads that can be allotted to process I/O requests, for reasons such as implementation, performance, or scalability. For this reason, the host is not required to implement `GetMaxThreads`. In this case, the host should return E_NOTIMPL from this method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRIoCompletionManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclriocompletionmanager-interface.md)  
 [IHostIoCompletionManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostiocompletionmanager-interface.md)
