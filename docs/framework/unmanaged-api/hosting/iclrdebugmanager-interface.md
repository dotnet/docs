---
title: "ICLRDebugManager Interface"
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
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRDebugManager Interface
Provides methods that allow a host to associate a set of tasks with an identifier and a friendly name.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[BeginConnection Method](../../../../docs/framework/unmanaged-api/hosting/iclrdebugmanager-beginconnection-method.md)|Establishes a new connection between the host and the debugger to associate tasks with an identifier and a friendly name.|  
|[EndConnection Method](../../../../docs/framework/unmanaged-api/hosting/iclrdebugmanager-endconnection-method.md)|Removes the association between a list of tasks and an identifier and a friendly name.|  
|[GetDacl Method](../../../../docs/framework/unmanaged-api/hosting/iclrdebugmanager-getdacl-method.md)|This method is not implemented.|  
|[IsDebuggerAttached Method](../../../../docs/framework/unmanaged-api/hosting/iclrdebugmanager-isdebuggerattached-method.md)|Gets a value that indicates whether a debugger is attached to the process.|  
|[SetConnectionTasks Method](../../../../docs/framework/unmanaged-api/hosting/iclrdebugmanager-setconnectiontasks-method.md)|Associates a list of [ICLRTask](../../../../docs/framework/unmanaged-api/hosting/iclrtask-interface.md) instances with an identifier and a friendly name.|  
|[SetDacl Method](../../../../docs/framework/unmanaged-api/hosting/iclrdebugmanager-setdacl-method.md)|This method is not implemented.|  
|[SetSymbolReadingPolicy Method](../../../../docs/framework/unmanaged-api/hosting/iclrdebugmanager-setsymbolreadingpolicy-method.md)|Sets the policy for reading program database (PDB) files. The policy determines whether information about line numbers and files is included in call stacks.|  
  
## Remarks  
 In debugging scenarios, a host might want to group tasks according to its own programming logic. For example, a grouping would allow a developer to see only the tasks required by the developer's APIs, instead of seeing every task running in the process. `ICLRDebugManager` allows the host to implement this kind of grouping.  
  
> [!IMPORTANT]
>  Three `ICLRDebugManager` methods, `BeginConnection`, `SetConnectionTasks` and `EndConnection`, are dependent upon each other. They must be called in the given order to work as expected.  
  
 The grouping, and the identifiers and friendly names that the host assigns to the grouping, have no meaning for the common language runtime (CLR). The CLR merely passes the information along to the debugger.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)
