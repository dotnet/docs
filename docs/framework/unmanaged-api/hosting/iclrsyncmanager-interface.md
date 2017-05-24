---
title: "ICLRSyncManager Interface | Microsoft Docs"
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
  - "ICLRSyncManager"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRSyncManager"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ICLRSyncManager interface [.NET Framework hosting]"
ms.assetid: a49f9d80-1c76-4ddd-8c49-34f913a5c596
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICLRSyncManager Interface
Defines methods that allow the host to get information about requested tasks and to detect deadlocks in its synchronization implementation.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[CreateRWLockOwnerIterator Method](../../../../docs/framework/unmanaged-api/hosting/iclrsyncmanager-createrwlockowneriterator-method.md)|Requests that the common language runtime (CLR) create an iterator for the host to use to determine the set of tasks waiting on a reader-writer lock.|  
|[DeleteRWLockOwnerIterator Method](../../../../docs/framework/unmanaged-api/hosting/iclrsyncmanager-deleterwlockowneriterator-method.md)|Requests that the CLR destroy an iterator that was created by a call to `CreateRWLockOwnerIterator`.|  
|[GetMonitorOwner Method](../../../../docs/framework/unmanaged-api/hosting/iclrsyncmanager-getmonitorowner-method.md)|Gets the task that owns the specified monitor.|  
|[GetRWLockOwnerNext Method](../../../../docs/framework/unmanaged-api/hosting/iclrsyncmanager-getrwlockownernext-method.md)|Gets the next task that is waiting on the current reader-writer lock.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 <xref:System.Threading.Thread>   
 [IHostSyncManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostsyncmanager-interface.md)   
 [Managed and Unmanaged Threading](http://msdn.microsoft.com/en-us/db425c20-4b2f-4433-bf96-76071c7881e5)   
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)