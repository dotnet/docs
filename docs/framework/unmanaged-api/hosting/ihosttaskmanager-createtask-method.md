---
title: "IHostTaskManager::CreateTask Method"
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
  - "IHostTaskManager.CreateTask"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostTaskManager::CreateTask"
helpviewer_keywords: 
  - "CreateTask method, IHostTaskManager interface [.NET Framework hosting]"
  - "IHostTaskManager::CreateTask method [.NET Framework hosting]"
ms.assetid: a6f8ad36-61e1-42b0-9db2-add575646d18
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostTaskManager::CreateTask Method
Requests that the host create a new task.  
  
## Syntax  
  
```  
HRESULT CreateTask (  
    [in]  DWORD stacksize,   
    [in]  LPTHREAD_START_ROUTINE pStartAddress,  
    [in]  PVOID pParameter,  
    [out] IHostTask **ppTask  
);  
```  
  
#### Parameters  
 `stacksize`  
 [in] The requested size, in bytes, of the requested stack, or 0 (zero) for the default size.  
  
 `pStartAddress`  
 [in] A pointer to the function the task is to execute.  
  
 `pParameter`  
 [in] A pointer to the user data to be passed to the function, or null if the function takes no parameters.  
  
 `ppTask`  
 [out] A pointer to the address of an [IHostTask](../../../../docs/framework/unmanaged-api/hosting/ihosttask-interface.md) instance created by the host, or null if the task cannot be created. The task remains in a suspended state until it is explicitly started by a call to [IHostTask::Start](../../../../docs/framework/unmanaged-api/hosting/ihosttask-start-method.md).  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`CreateTask` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_OUTOFMEMORY|Not enough memory was available to create the requested task.|  
  
## Remarks  
 The CLR calls `CreateTask` to request that the host create a new task. The host returns an interface pointer to an `IHostTask` instance. The returned task must remain suspended until it is explicitly started by a call to `IHostTask::Start`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRTask Interface](../../../../docs/framework/unmanaged-api/hosting/iclrtask-interface.md)  
 [ICLRTaskManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrtaskmanager-interface.md)  
 [IHostTask Interface](../../../../docs/framework/unmanaged-api/hosting/ihosttask-interface.md)  
 [IHostTaskManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihosttaskmanager-interface.md)
