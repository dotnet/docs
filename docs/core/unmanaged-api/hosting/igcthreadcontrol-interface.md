---
description: "Learn more about: IGCThreadControl Interface"
title: "IGCThreadControl Interface"
ms.date: "03/30/2017"
api_name: 
  - "IGCThreadControl"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IGCThreadControl"
helpviewer_keywords: 
  - "IGCThreadControl interface [.NET Framework hosting]"
ms.assetid: 3ff04d75-85ac-4df9-886d-dbaa037c0552
topic_type: 
  - "apiref"
---
# IGCThreadControl Interface

Provides methods for participating in the scheduling of threads that would otherwise be blocked for a garbage collection.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[SuspensionEnding Method](igcthreadcontrol-suspensionending-method.md)|Notifies the host that the runtime is resuming threads after a garbage collection or other suspension.|  
|[SuspensionStarting Method](igcthreadcontrol-suspensionstarting-method.md)|Notifies the host that the runtime is beginning a thread suspension for a garbage collection or other suspension.|  
|[ThreadIsBlockingForSuspension Method](igcthreadcontrol-threadisblockingforsuspension-method.md)|Notifies the host that the thread making the call is about to block, perhaps for a garbage collection or other suspension.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Hosting Interfaces](hosting-interfaces.md)
