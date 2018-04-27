---
title: "ICLRSyncManager Interface"
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "ICLRSyncManager"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRSyncManager"
helpviewer_keywords: 
  - "ICLRSyncManager interface [.NET Framework hosting]"
ms.assetid: a49f9d80-1c76-4ddd-8c49-34f913a5c596
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRSyncManager Interface
Defines methods that allow the host to get information about requested tasks and to detect deadlocks in its synchronization implementation.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[CreateRWLockOwnerIterator Method](iclrsyncmanager-createrwlockowneriterator-method.md)|Requests that the common language runtime (CLR) create an iterator for the host to use to determine the set of tasks waiting on a reader-writer lock.|  
|[DeleteRWLockOwnerIterator Method](iclrsyncmanager-deleterwlockowneriterator-method.md)|Requests that the CLR destroy an iterator that was created by a call to `CreateRWLockOwnerIterator`.|  
|[GetMonitorOwner Method](iclrsyncmanager-getmonitorowner-method.md)|Gets the task that owns the specified monitor.|  
|[GetRWLockOwnerNext Method](iclrsyncmanager-getrwlockownernext-method.md)|Gets the next task that is waiting on the current reader-writer lock.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 <xref:System.Threading.Thread>  
 [IHostSyncManager Interface](ihostsyncmanager-interface.md)  
 [Managed and Unmanaged Threading](https://msdn.microsoft.com/library/db425c20-4b2f-4433-bf96-76071c7881e5(v=vs.100))  
 [Hosting Interfaces](hosting-interfaces.md)
