---
title: "ICLRTask Interface"
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
  - "ICLRTask"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRTask"
helpviewer_keywords: 
  - "ICLRTask interface [.NET Framework hosting]"
ms.assetid: b3a44df3-578a-4451-b55e-70c8e7695f5e
topic_type: 
  - "apiref"
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRTask Interface
Provides methods that allow the host to make requests of the common language runtime (CLR), or to provide notification to the CLR about the associated task.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Abort Method](../../../../docs/framework/unmanaged-api/hosting/iclrtask-abort-method.md)|Requests that the CLR abort the task that the current `ICLRTask` instance represents.|  
|[ExitTask Method](../../../../docs/framework/unmanaged-api/hosting/iclrtask-exittask-method.md)|Notifies the CLR that the task associated with the current `ICLRTask` instance is ending, and attempts to shut the task down gracefully.|  
|[GetMemStats Method](../../../../docs/framework/unmanaged-api/hosting/iclrtask-getmemstats-method.md)|Gets statistical information on the use of memory resources by the task represented by the current `ICLRTask` instance.|  
|[LocksHeld Method](../../../../docs/framework/unmanaged-api/hosting/iclrtask-locksheld-method.md)|Gets the number of locks currently held on the task.|  
|[NeedsPriorityScheduling Method](../../../../docs/framework/unmanaged-api/hosting/iclrtask-needspriorityscheduling-method.md)|Gets a value indicating whether the host should assign a high priority to rescheduling the task represented by the current `ICLRTask` instance.|  
|[Reset Method](../../../../docs/framework/unmanaged-api/hosting/iclrtask-reset-method.md)|Informs the CLR that the host has completed a task, and enables the CLR to reuse the current `ICLRTask` instance to represent another task.|  
|[RudeAbort Method](../../../../docs/framework/unmanaged-api/hosting/iclrtask-rudeabort-method.md)|Causes the CLR to abort the task represented by the current `ICLRTask` instance immediately, without a guarantee that finalizers will be executed.|  
|[SetTaskIdentifier Method](../../../../docs/framework/unmanaged-api/hosting/iclrtask-settaskidentifier-method.md)|Sets a unique identifier for the task represented by the current `ICLRTask` instance, for use in debugging.|  
|[SwitchIn Method](../../../../docs/framework/unmanaged-api/hosting/iclrtask-switchin-method.md)|Notifies the CLR that the task represented by the current `ICLRTask` instance is in an operable state.|  
|[SwitchOut Method](../../../../docs/framework/unmanaged-api/hosting/iclrtask-switchout-method.md)|Notifies the CLR that the task represented by the current `ICLRTask` instance is no longer in an operable state.|  
|[YieldTask Method](../../../../docs/framework/unmanaged-api/hosting/iclrtask-yieldtask-method.md)|Requests that the CLR make processor time available to other tasks. The CLR makes no guarantee that the task will be put in a state where it can yield processing time.|  
  
## Remarks  
 An `ICLRTask` is the representation of a task for the CLR. At any point during code execution, a task can be described either as running or waiting to run. The host calls the `ICLRTask::SwitchIn` method to notify the CLR that the task that the current `ICLRTask` instance represents is now in an operable state. After a call to `ICLRTask::SwitchIn`, the host can schedule the task on any operating system thread, except in cases where the runtime requires thread-affinity, as specified by calls to the [IHostTaskManager::BeginThreadAffinity](../../../../docs/framework/unmanaged-api/hosting/ihosttaskmanager-beginthreadaffinity-method.md) and [IHostTaskManager::EndThreadAffinity](../../../../docs/framework/unmanaged-api/hosting/ihosttaskmanager-endthreadaffinity-method.md) methods. Some time later, the operating system might decide to remove the task from the thread and place it in a non-running state. For example, this might happen whenever the task blocks on synchronization primitives, or waits for I/O operations to complete. The host calls [SwitchOut](../../../../docs/framework/unmanaged-api/hosting/iclrtask-switchout-method.md) to notify the CLR that the task represented by the current `ICLRTask` instance is no longer in an operable state.  
  
 A task typically terminates at the end of code execution. At that time, the host calls `ICLRTask::ExitTask` to destroy the associated `ICLRTask`. However, tasks can also be recycled by using a call to `ICLRTask::Reset`, which allows the `ICLRTask` instance to be used again. This approach prevents the overhead of repeatedly creating and destroying instances.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRTaskManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrtaskmanager-interface.md)  
 [IHostTask Interface](../../../../docs/framework/unmanaged-api/hosting/ihosttask-interface.md)  
 [IHostTaskManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihosttaskmanager-interface.md)  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)  
 [ICLRTask2 Interface](../../../../docs/framework/unmanaged-api/hosting/iclrtask2-interface.md)
