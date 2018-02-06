---
title: "IHostTask::SetPriority Method"
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
  - "IHostTask.SetPriority"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostTask::SetPriority"
helpviewer_keywords: 
  - "IHostTask::SetPriority method [.NET Framework hosting]"
  - "SetPriority method [.NET Framework hosting]"
ms.assetid: cd8c379b-c7a0-434f-8e23-899bd26be75d
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostTask::SetPriority Method
Requests that the host adjust the thread priority level for the task represented by the current [IHostTask](../../../../docs/framework/unmanaged-api/hosting/ihosttask-interface.md) instance.  
  
## Syntax  
  
```  
HRESULT SetPriority (  
    [in] int newPriority  
);  
```  
  
#### Parameters  
 `newPriority`  
 [in] An integer that represents the requested thread priority value for the task represented by the current `IHostTask` instance.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`SetPriority` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  
 Threads are granted processing time using a round-robin system that is partly based on a thread's priority level. `SetPriority` allows the CLR to set that thread priority level for the current task. The following `newPriority` values are supported.  
  
-   THREAD_PRIORITY_ABOVE_NORMAL  
  
-   THREAD_PRIORITY_BELOW_NORMAL  
  
-   THREAD_PRIORITY_HIGHEST  
  
-   THREAD_PRIORITY_IDLE  
  
-   THREAD_PRIORITY_LOWEST  
  
-   THREAD_PRIORITY_NORMAL  
  
-   THREAD_PRIORITY_TIME_CRITICAL  
  
 The CLR calls `SetPriority` when the value of the <xref:System.Threading.Thread.Priority%2A?displayProperty=nameWithType> is modified by user code. A host can define its own algorithms for thread priority assignment, and is free to ignore this request.  
  
> [!NOTE]
>  `SetPriority` does not report whether the thread priority level was changed. Call [IHostTask::GetPriority](../../../../docs/framework/unmanaged-api/hosting/ihosttask-getpriority-method.md) to determine the value of the task's thread priority level.  
  
 Thread priority level values are defined by the Win32 `SetThreadPriority` function. For more information about thread priority, see the Windows Platform documentation.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 <xref:System.Threading.Thread>  
 [ICLRTask Interface](../../../../docs/framework/unmanaged-api/hosting/iclrtask-interface.md)  
 [ICLRTaskManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrtaskmanager-interface.md)  
 [IHostTask Interface](../../../../docs/framework/unmanaged-api/hosting/ihosttask-interface.md)  
 [GetPriority Method](../../../../docs/framework/unmanaged-api/hosting/ihosttask-getpriority-method.md)  
 [IHostTaskManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihosttaskmanager-interface.md)
