---
description: "Learn more about: IHostCrst Interface"
title: "IHostCrst Interface"
ms.date: "03/30/2017"
api_name: 
  - "IHostCrst"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostCrst"
helpviewer_keywords: 
  - "IHostCrst interface [.NET Framework hosting]"
ms.assetid: ac298ebd-0815-47e4-a823-30b31baab903
topic_type: 
  - "apiref"
---
# IHostCrst Interface

Serves as the host's representation of a critical section for threading.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Enter Method](ihostcrst-enter-method.md)|Enters the critical section.|  
|[Leave Method](ihostcrst-leave-method.md)|Leaves the critical section.|  
|[SetSpinCount Method](ihostcrst-setspincount-method.md)|Sets the spin count for the critical section.|  
|[TryEnter Method](ihostcrst-tryenter-method.md)|Attempts to enter the critical section, and reports success or failure immediately.|  
  
## Remarks  

 `IHostCrst` allows the common language runtime (CLR) to communicate directly with the host's representation of a critical section, rather than using Win32 functions such as `EnterCriticalSection` or `LeaveCriticalSection`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRSyncManager Interface](iclrsyncmanager-interface.md)
- [IHostSyncManager Interface](ihostsyncmanager-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
