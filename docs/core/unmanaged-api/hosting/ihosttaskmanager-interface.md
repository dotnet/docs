---
description: "Learn more about: IHostTaskManager Interface"
title: "IHostTaskManager Interface"
ms.date: "03/30/2017"
api_name: 
  - "IHostTaskManager"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostTaskManager"
helpviewer_keywords: 
  - "IHostTaskManager interface [.NET Framework hosting]"
ms.assetid: 4a0b05b9-3ef1-4607-b7c8-bd4dd43647a0
topic_type: 
  - "apiref"
---
# IHostTaskManager Interface

Provides methods that allow the common language runtime (CLR) to work with tasks through the host instead of using the standard operating system threading or fiber functions.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[BeginDelayAbort Method](ihosttaskmanager-begindelayabort-method.md)|Notifies the host that managed code is entering a period in which the current task must not be aborted.|  
|[BeginThreadAffinity Method](ihosttaskmanager-beginthreadaffinity-method.md)|Notifies the host that managed code is entering a period in which the current task must not be moved to another operating system thread.|  
|[CallNeedsHostHook Method](ihosttaskmanager-callneedshosthook-method.md)|Enables the host to specify whether the common language runtime can inline the specified call to an unmanaged function.|  
|[CreateTask Method](ihosttaskmanager-createtask-method.md)|Requests that the host create a new task.|  
|[EndDelayAbort Method](ihosttaskmanager-enddelayabort-method.md)|Notifies the host that managed code is exiting the period in which the current task must not be aborted, following an earlier call to `BeginDelayAbort`.|  
|[EndThreadAffinity Method](ihosttaskmanager-endthreadaffinity-method.md)|Notifies the host that managed code is exiting the period in which the current task must not be moved to another operating system thread, following an earlier call to `BeginThreadAffinity`.|  
|[EnterRuntime Method](ihosttaskmanager-enterruntime-method.md)|Notifies the host that a call to an unmanaged method, such as a platform invoke method, is returning execution control to the CLR.|  
|[GetCurrentTask Method](ihosttaskmanager-getcurrenttask-method.md)|Gets an interface pointer to the task that is currently executing on the operating system thread from which this call is made.|  
|[GetStackGuarantee Method](ihosttaskmanager-getstackguarantee-method.md)|Gets the amount of stack space that is guaranteed to be available after a stack operation completes, but before the closing of a process.|  
|[LeaveRuntime Method](ihosttaskmanager-leaveruntime-method.md)|Notifies the host that managed code is about to make a call to an unmanaged function.|  
|[ReverseEnterRuntime Method](ihosttaskmanager-reverseenterruntime-method.md)|Notifies the host that a call is being made into the common language runtime (CLR) from unmanaged code.|  
|[ReverseLeaveRuntime Method](ihosttaskmanager-reverseleaveruntime-method.md)|Notifies the host that control is leaving the CLR and entering an unmanaged function that was, in turn, called from managed code.|  
|[SetCLRTaskManager Method](ihosttaskmanager-setclrtaskmanager-method.md)|Provides the host with an interface pointer to an [ICLRTaskManager](iclrtaskmanager-interface.md) instance implemented by the CLR.|  
|[SetLocale Method](ihosttaskmanager-setlocale-method.md)|Notifies the host that the CLR has changed the locale on the current task.|  
|[SetStackGuarantee Method](ihosttaskmanager-setstackguarantee-method.md)|Reserved for internal use only.|  
|[SetUILocale Method](ihosttaskmanager-setuilocale-method.md)|Notifies the host that the user interface locale has been changed on the current task.|  
|[Sleep Method](ihosttaskmanager-sleep-method.md)|Notifies the host that the current task is going to sleep.|  
|[SwitchToTask Method](ihosttaskmanager-switchtotask-method.md)|Notifies the host that it should switch out the current task.|  
  
## Remarks  

 `IHostTaskManager` allows the CLR to create and manage tasks, to provide hooks for the host to take action when control transfers from managed to unmanaged code and vice versa, and to specify certain actions the host can and cannot take during code execution.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRTask Interface](iclrtask-interface.md)
- [ICLRTaskManager Interface](iclrtaskmanager-interface.md)
- [IHostTask Interface](ihosttask-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
