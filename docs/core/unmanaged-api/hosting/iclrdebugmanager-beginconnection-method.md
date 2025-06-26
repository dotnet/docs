---
description: "Learn more about: ICLRDebugManager::BeginConnection Method"
title: "ICLRDebugManager::BeginConnection Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRDebugManager.BeginConnection"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDebugManager::BeginConnection"
helpviewer_keywords: 
  - "ICLRDebugManager::BeginConnection method [.NET Framework hosting]"
  - "BeginConnection method [.NET Framework hosting]"
ms.assetid: bdd98146-ff4d-4150-a264-a4c1a32d31f3
topic_type: 
  - "apiref"
---
# ICLRDebugManager::BeginConnection Method

Establishes a new connection between the host and the debugger to associate a list of tasks with an identifier and a friendly name.  
  
## Syntax  
  
```cpp  
HRESULT BeginConnection (  
    [in] CONNID dwConnectionId,  
    [in, string] wchar_t* szConnectionName  
);  
```  
  
## Parameters  

 `dwConnectionId`  
 [in] An identifier to associate with the list of common language runtime (CLR) tasks.  
  
 `szConnectionName`  
 [in] A friendly name to associate with the list of CLR tasks.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`BeginConnection` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_INVALIDARG|`dwConnectionId` was zero, or `BeginConnection` was already called using this `dwConnectionId` value, or `szConnectionName` was null.|  
|E_OUTOFMEMORY|Not enough memory could be allocated to hold the list of tasks associated with this connection.|  
  
## Remarks  

 [ICLRDebugManager](iclrdebugmanager-interface.md) provides three methods, `BeginConnection`, [SetConnectionTasks](iclrdebugmanager-setconnectiontasks-method.md), and [EndConnection](iclrdebugmanager-endconnection-method.md), for associating task lists with identifiers and friendly names.  
  
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
- [EndConnection Method](iclrdebugmanager-endconnection-method.md)
- [SetConnectionTasks Method](iclrdebugmanager-setconnectiontasks-method.md)
- [IHostControl Interface](ihostcontrol-interface.md)
