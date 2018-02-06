---
title: "IHostSyncManager Interface"
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
  - "IHostSyncManager"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostSyncManager"
helpviewer_keywords: 
  - "IHostSyncManager interface [.NET Framework hosting]"
ms.assetid: 2e081a37-6a28-4c93-b7ab-1c96a464637c
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostSyncManager Interface
Provides methods that allow the common language runtime (CLR) to create synchronization primitives by calling the host instead of using the Win32 synchronization functions.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[CreateAutoEvent Method](../../../../docs/framework/unmanaged-api/hosting/ihostsyncmanager-createautoevent-method.md)|Creates an auto-reset event object.|  
|[CreateCrst Method](../../../../docs/framework/unmanaged-api/hosting/ihostsyncmanager-createcrst-method.md)|Creates a critical section object for synchronization.|  
|[CreateCrstWithSpinCount Method](../../../../docs/framework/unmanaged-api/hosting/ihostsyncmanager-createcrstwithspincount-method.md)|Creates a critical section object with spin count for synchronization.|  
|[CreateManualEvent Method](../../../../docs/framework/unmanaged-api/hosting/ihostsyncmanager-createmanualevent-method.md)|Creates a manual-reset event object.|  
|[CreateMonitorEvent Method](../../../../docs/framework/unmanaged-api/hosting/ihostsyncmanager-createmonitorevent-method.md)|Creates a monitored auto-reset event object.|  
|[CreateRWLockReaderEvent Method](../../../../docs/framework/unmanaged-api/hosting/ihostsyncmanager-createrwlockreaderevent-method.md)|Creates a manual-reset event object for the implementation of a reader lock.|  
|[CreateRWLockWriterEvent Method](../../../../docs/framework/unmanaged-api/hosting/ihostsyncmanager-createrwlockwriterevent-method.md)|Creates an auto-reset event object for the implementation of a writer lock.|  
|[CreateSemaphore Method](../../../../docs/framework/unmanaged-api/hosting/ihostsyncmanager-createsemaphore-method.md)|Creates an [IHostSemaphore](../../../../docs/framework/unmanaged-api/hosting/ihostsemaphore-interface.md) object for the CLR to use as a semaphore for wait events.|  
|[SetCLRSyncManager Method](../../../../docs/framework/unmanaged-api/hosting/ihostsyncmanager-setclrsyncmanager-method.md)|Sets the [ICLRSyncManager](../../../../docs/framework/unmanaged-api/hosting/iclrsyncmanager-interface.md) instance to associate with the current `IHostSyncManager` instance.|  
  
## Remarks  
 The CLR discovers the host's implementation of `IHostSyncManager` by calling the [IHostControl::GetHostManager](../../../../docs/framework/unmanaged-api/hosting/ihostcontrol-gethostmanager-method.md) method with an `IID` of IID_IHostSyncManager.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRSyncManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrsyncmanager-interface.md)  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)
