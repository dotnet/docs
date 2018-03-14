---
title: "IHostTask Interface"
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
  - "IHostTask"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostTask"
helpviewer_keywords: 
  - "IHostTask interface [.NET Framework hosting]"
ms.assetid: a71dbbd5-64b8-47eb-9f03-8e8c85fbe2bc
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostTask Interface
Provides methods that allow the common language runtime (CLR) to communicate with the host to manage tasks.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Alert Method](../../../../docs/framework/unmanaged-api/hosting/ihosttask-alert-method.md)|Requests that the host wake the task represented by the current `IHostTask` instance, so the task can be aborted.|  
|[GetPriority Method](../../../../docs/framework/unmanaged-api/hosting/ihosttask-getpriority-method.md)|Gets the thread priority level of the task represented by the current `IHostTask` instance.|  
|[Join Method](../../../../docs/framework/unmanaged-api/hosting/ihosttask-join-method.md)|Blocks the calling task until the task represented by the current `IHostTask` instance completes, the specified time interval elapses, or [IHostTask::Alert](../../../../docs/framework/unmanaged-api/hosting/ihosttask-alert-method.md) is called.|  
|[SetCLRTask Method](../../../../docs/framework/unmanaged-api/hosting/ihosttask-setclrtask-method.md)|Associates an [ICLRTask Interface](../../../../docs/framework/unmanaged-api/hosting/iclrtask-interface.md) instance with the current `IHostTask` instance.|  
|[SetPriority Method](../../../../docs/framework/unmanaged-api/hosting/ihosttask-setpriority-method.md)|Requests that the host adjust the thread priority level for the task represented by the current `IHostTask` instance.|  
|[Start Method](../../../../docs/framework/unmanaged-api/hosting/ihosttask-start-method.md)|Requests that the host move the task represented by the current `IHostTask` instance from a suspended state to a live state, in which code can be executed.|  
  
## Remarks  
 The CLR calls methods defined by `IHostTask` to start a task, set its thread priority level, and so on.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRTask Interface](../../../../docs/framework/unmanaged-api/hosting/iclrtask-interface.md)  
 [ICLRTaskManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrtaskmanager-interface.md)  
 [IHostTaskManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihosttaskmanager-interface.md)  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)
