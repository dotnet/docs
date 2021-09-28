---
description: "Learn more about: IHostGCManager Interface"
title: "IHostGCManager Interface"
ms.date: "03/30/2017"
api_name: 
  - "IHostGCManager"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostGCManager"
helpviewer_keywords: 
  - "IHostGCManager interface [.NET Framework hosting]"
ms.assetid: 820330a4-244c-4f67-ab5e-f24b0b3c2080
topic_type: 
  - "apiref"
---
# IHostGCManager Interface

Provides methods that notify the host of events in the garbage collection mechanism implemented by the common language runtime (CLR).  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|[SuspensionEnding Method](ihostgcmanager-suspensionending-method.md)|Notifies the host that the CLR is resuming execution of tasks on threads that had been suspended for a garbage collection.|  
|[SuspensionStarting Method](ihostgcmanager-suspensionstarting-method.md)|Notifies the host that the CLR is suspending execution of tasks, to perform a garbage collection.|  
|[ThreadIsBlockingForSuspension Method](ihostgcmanager-threadisblockingforsuspension-method.md)|Notifies the host that the thread from which the method call was made is about to block for a garbage collection.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRTask Interface](iclrtask-interface.md)
- [ICLRTaskManager Interface](iclrtaskmanager-interface.md)
- [IHostTask Interface](ihosttask-interface.md)
- [IHostTaskManager Interface](ihosttaskmanager-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
