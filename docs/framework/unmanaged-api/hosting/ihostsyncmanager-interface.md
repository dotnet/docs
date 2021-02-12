---
description: "Learn more about: IHostSyncManager Interface"
title: "IHostSyncManager Interface"
ms.date: "03/30/2017"
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
---
# IHostSyncManager Interface

Provides methods that allow the common language runtime (CLR) to create synchronization primitives by calling the host instead of using the Win32 synchronization functions.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[CreateAutoEvent Method](ihostsyncmanager-createautoevent-method.md)|Creates an auto-reset event object.|  
|[CreateCrst Method](ihostsyncmanager-createcrst-method.md)|Creates a critical section object for synchronization.|  
|[CreateCrstWithSpinCount Method](ihostsyncmanager-createcrstwithspincount-method.md)|Creates a critical section object with spin count for synchronization.|  
|[CreateManualEvent Method](ihostsyncmanager-createmanualevent-method.md)|Creates a manual-reset event object.|  
|[CreateMonitorEvent Method](ihostsyncmanager-createmonitorevent-method.md)|Creates a monitored auto-reset event object.|  
|[CreateRWLockReaderEvent Method](ihostsyncmanager-createrwlockreaderevent-method.md)|Creates a manual-reset event object for the implementation of a reader lock.|  
|[CreateRWLockWriterEvent Method](ihostsyncmanager-createrwlockwriterevent-method.md)|Creates an auto-reset event object for the implementation of a writer lock.|  
|[CreateSemaphore Method](ihostsyncmanager-createsemaphore-method.md)|Creates an [IHostSemaphore](ihostsemaphore-interface.md) object for the CLR to use as a semaphore for wait events.|  
|[SetCLRSyncManager Method](ihostsyncmanager-setclrsyncmanager-method.md)|Sets the [ICLRSyncManager](iclrsyncmanager-interface.md) instance to associate with the current `IHostSyncManager` instance.|  
  
## Remarks  

 The CLR discovers the host's implementation of `IHostSyncManager` by calling the [IHostControl::GetHostManager](ihostcontrol-gethostmanager-method.md) method with an `IID` of IID_IHostSyncManager.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRSyncManager Interface](iclrsyncmanager-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
