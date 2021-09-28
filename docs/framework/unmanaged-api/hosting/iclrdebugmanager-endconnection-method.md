---
description: "Learn more about: ICLRDebugManager::EndConnection Method"
title: "ICLRDebugManager::EndConnection Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRDebugManager.EndConnection"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDebugManager::EndConnection"
helpviewer_keywords: 
  - "ICLRDebugManager::EndConnection method [.NET Framework hosting]"
  - "EndConnection method [.NET Framework hosting]"
ms.assetid: 89dc7363-2f29-4eb2-8f23-fccdda6a76a6
topic_type: 
  - "apiref"
---
# ICLRDebugManager::EndConnection Method

Removes the association between a list of tasks and an identifier and a friendly name.  
  
## Syntax  
  
```cpp  
HRESULT EndConnection (  
    [in] CONNID dwConnectionId  
);  
```  
  
## Parameters  

 `dwConnectionId`  
 [in] The host-specific identifier for the connection and the associated list of common language runtime (CLR) tasks.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`EndConnection` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_INVALIDARG|[BeginConnection](iclrdebugmanager-beginconnection-method.md) was never called using `dwConnectionId`, or `dwConnectionId` was zero.|  
  
## Remarks  

 [ICLRDebugManager](iclrdebugmanager-interface.md) provides three methods, `BeginConnection`, [SetConnectionTasks](iclrdebugmanager-setconnectiontasks-method.md), and `EndConnection`, for associating task lists with identifiers and friendly names.  
  
> [!IMPORTANT]
> These three methods must be called in a specific order for each set of tasks. `BeginConnection` is called first to establish a new connection. `SetConnectionTasks` is called next to provide the set of tasks to be associated with that connection. `EndConnection` is called last to remove the association between the task list and the identifier and friendly name.However, calls for different connections can be nested.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRControl Interface](iclrcontrol-interface.md)
- [ICLRDebugManager Interface](iclrdebugmanager-interface.md)
- [BeginConnection Method](iclrdebugmanager-beginconnection-method.md)
- [SetConnectionTasks Method](iclrdebugmanager-setconnectiontasks-method.md)
- [IHostControl Interface](ihostcontrol-interface.md)
