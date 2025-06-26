---
description: "Learn more about: ICLRDebugManager Interface"
title: "ICLRDebugManager Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICLRDebugManager"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDebugManager"
helpviewer_keywords: 
  - "ICLRDebugManager interface [.NET Framework hosting]"
ms.assetid: e835062c-c7d6-4945-8a44-2de7ebf3928e
topic_type: 
  - "apiref"
---
# ICLRDebugManager Interface

Provides methods that allow a host to associate a set of tasks with an identifier and a friendly name.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[BeginConnection Method](iclrdebugmanager-beginconnection-method.md)|Establishes a new connection between the host and the debugger to associate tasks with an identifier and a friendly name.|  
|[EndConnection Method](iclrdebugmanager-endconnection-method.md)|Removes the association between a list of tasks and an identifier and a friendly name.|  
|[GetDacl Method](iclrdebugmanager-getdacl-method.md)|This method is not implemented.|  
|[IsDebuggerAttached Method](iclrdebugmanager-isdebuggerattached-method.md)|Gets a value that indicates whether a debugger is attached to the process.|  
|[SetConnectionTasks Method](iclrdebugmanager-setconnectiontasks-method.md)|Associates a list of [ICLRTask](iclrtask-interface.md) instances with an identifier and a friendly name.|  
|[SetDacl Method](iclrdebugmanager-setdacl-method.md)|This method is not implemented.|  
|[SetSymbolReadingPolicy Method](iclrdebugmanager-setsymbolreadingpolicy-method.md)|Sets the policy for reading program database (PDB) files. The policy determines whether information about line numbers and files is included in call stacks.|  
  
## Remarks  

 In debugging scenarios, a host might want to group tasks according to its own programming logic. For example, a grouping would allow a developer to see only the tasks required by the developer's APIs, instead of seeing every task running in the process. `ICLRDebugManager` allows the host to implement this kind of grouping.  
  
> [!IMPORTANT]
> Three `ICLRDebugManager` methods, `BeginConnection`, `SetConnectionTasks` and `EndConnection`, are dependent upon each other. They must be called in the given order to work as expected.  
  
 The grouping, and the identifiers and friendly names that the host assigns to the grouping, have no meaning for the common language runtime (CLR). The CLR merely passes the information along to the debugger.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Hosting Interfaces](hosting-interfaces.md)
