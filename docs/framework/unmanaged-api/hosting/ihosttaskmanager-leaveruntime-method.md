---
title: "IHostTaskManager::LeaveRuntime Method"
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
  - "IHostTaskManager.LeaveRuntime"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostTaskManager::LeaveRuntime"
helpviewer_keywords: 
  - "IHostTaskManager::LeaveRuntime method [.NET Framework hosting]"
  - "LeaveRuntime method [.NET Framework hosting]"
ms.assetid: 43689cc4-e48e-46e5-a22d-bafd768b8759
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostTaskManager::LeaveRuntime Method
Notifies the host that the currently executing task is about to leave the common language runtime (CLR) and enter unmanaged code.  
  
> [!IMPORTANT]
>  A corresponding call to [IHostTaskManager::EnterRuntime](../../../../docs/framework/unmanaged-api/hosting/ihosttaskmanager-enterruntime-method.md) notifies the host that the currently executing task is reentering managed code.  
  
## Syntax  
  
```  
HRESULT LeaveRuntime (  
    [in] SIZE_T target  
);  
```  
  
#### Parameters  
 `target`  
 [in] The address within the mapped portable executable file of the unmanaged function to be called.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`LeaveRuntime` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_OUTOFMEMORY|Not enough memory is available to complete the requested allocation.|  
  
## Remarks  
 Call sequences to and from unmanaged code can be nested. For example, the list below describes a hypothetical situation in which the sequence of calls to `LeaveRuntime`, [IHostTaskManager::ReverseEnterRuntime](../../../../docs/framework/unmanaged-api/hosting/ihosttaskmanager-reverseenterruntime-method.md), [IHostTaskManager::ReverseLeaveRuntime](../../../../docs/framework/unmanaged-api/hosting/ihosttaskmanager-reverseleaveruntime-method.md), and `IHostTaskManager::EnterRuntime` allows the host to identify the nested layers.  
  
|Action|Corresponding Method Call|  
|------------|-------------------------------|  
|A managed Visual Basic executable calls an unmanaged function written in C by using platform invoke.|`IHostTaskManager::LeaveRuntime`|  
|The unmanaged C function calls a method in a managed DLL written in C#.|`IHostTaskManager::ReverseEnterRuntime`|  
|The managed C# function calls another unmanaged function written in C, also using platform invoke.|`IHostTaskManager::LeaveRuntime`|  
|The second unmanaged function returns execution to the C# function.|`IHostTaskManager::EnterRuntime`|  
|The C# function returns execution to the first unmanaged function.|`IHostTaskManager::ReverseLeaveRuntime`|  
|The first unmanaged function returns execution to the Visual Basic program.|`IHostTaskManager::EnterRuntime`|  
  
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
