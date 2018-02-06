---
title: "IHostIoCompletionManager::CloseIoCompletionPort Method"
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
  - "IHostIoCompletionManager.CloseIoCompletionPort"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostIoCompletionManager::CloseIoCompletionPort"
helpviewer_keywords: 
  - "IHostIoCompletionManager::CloseIoCompletionPort method [.NET Framework hosting]"
  - "CloseIoCompletionPort method [.NET Framework hosting]"
ms.assetid: e86ad7be-3758-498a-a972-5522d69dfbb3
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostIoCompletionManager::CloseIoCompletionPort Method
Requests that the host close a port that was opened through an earlier call to [CreateIoCompletionPort](../../../../docs/framework/unmanaged-api/hosting/ihostiocompletionmanager-createiocompletionport-method.md).  
  
## Syntax  
  
```  
HRESULT CloseIoCompletionPort (  
    [in] HANDLE hPort  
);  
```  
  
#### Parameters  
 `hPort`  
 [in] The handle of the port to close.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`CloseIoCompletionPort` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_INVALIDARG|An invalid port handle was passed.|  
  
## Remarks  
 `hPort` must be a handle to a port that was created by an earlier call to `CreateIoCompletionPort`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRIoCompletionManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclriocompletionmanager-interface.md)  
 [IHostIoCompletionManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostiocompletionmanager-interface.md)
