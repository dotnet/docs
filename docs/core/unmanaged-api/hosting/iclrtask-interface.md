---
description: "Learn more about: ICLRTask Interface"
title: "ICLRTask Interface"
ms.date: "03/30/2017"
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
---
# ICLRTask Interface

Provides methods that allow the host to make requests of the common language runtime (CLR), or to provide notification to the CLR about the associated task.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Abort Method](iclrtask-abort-method.md)|Requests that the CLR abort the task that the current `ICLRTask` instance represents.|  
|[ExitTask Method](iclrtask-exittask-method.md)|Notifies the CLR that the task associated with the current `ICLRTask` instance is ending, and attempts to shut the task down gracefully.|  
|[GetMemStats Method](iclrtask-getmemstats-method.md)|Gets statistical information on the use of memory resources by the task represented by the current `ICLRTask` instance.|  
|[LocksHeld Method](iclrtask-locksheld-method.md)|Gets the number of locks currently held on the task.|  
|[NeedsPriorityScheduling Method](iclrtask-needspriorityscheduling-method.md)|Gets a value indicating whether the host should assign a high priority to rescheduling the task represented by the current `ICLRTask` instance.|  
|[Reset Method](iclrtask-reset-method.md)|Informs the CLR that the host has completed a task, and enables the CLR to reuse the current `ICLRTask` instance to represent another task.|  
|[RudeAbort Method](iclrtask-rudeabort-method.md)|Causes the CLR to abort the task represented by the current `ICLRTask` instance immediately, without a guarantee that finalizers will be executed.|  
|[SetTaskIdentifier Method](iclrtask-settaskidentifier-method.md)|Sets a unique identifier for the task represented by the current `ICLRTask` instance, for use in debugging.|  
|[SwitchIn Method](iclrtask-switchin-method.md)|Notifies the CLR that the task represented by the current `ICLRTask` instance is in an operable state.|  
|[SwitchOut Method](iclrtask-switchout-method.md)|Notifies the CLR that the task represented by the current `ICLRTask` instance is no longer in an operable state.|  
|[YieldTask Method](iclrtask-yieldtask-method.md)|Requests that the CLR make processor time available to other tasks. The CLR makes no guarantee that the task will be put in a state where it can yield processing time.|  
  
## Remarks  

 An `ICLRTask` is the representation of a task for the CLR. At any point during code execution, a task can be described either as running or waiting to run. The host calls the `ICLRTask::SwitchIn` method to notify the CLR that the task that the current `ICLRTask` instance represents is now in an operable state. After a call to `ICLRTask::SwitchIn`, the host can schedule the task on any operating system thread, except in cases where the runtime requires thread-affinity, as specified by calls to the [IHostTaskManager::BeginThreadAffinity](ihosttaskmanager-beginthreadaffinity-method.md) and [IHostTaskManager::EndThreadAffinity](ihosttaskmanager-endthreadaffinity-method.md) methods. Some time later, the operating system might decide to remove the task from the thread and place it in a non-running state. For example, this might happen whenever the task blocks on synchronization primitives, or waits for I/O operations to complete. The host calls [SwitchOut](iclrtask-switchout-method.md) to notify the CLR that the task represented by the current `ICLRTask` instance is no longer in an operable state.  
  
 A task typically terminates at the end of code execution. At that time, the host calls `ICLRTask::ExitTask` to destroy the associated `ICLRTask`. However, tasks can also be recycled by using a call to `ICLRTask::Reset`, which allows the `ICLRTask` instance to be used again. This approach prevents the overhead of repeatedly creating and destroying instances.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRTaskManager Interface](iclrtaskmanager-interface.md)
- [IHostTask Interface](ihosttask-interface.md)
- [IHostTaskManager Interface](ihosttaskmanager-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
- [ICLRTask2 Interface](iclrtask2-interface.md)
