---
title: "IGCThreadControl Interface"
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
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IGCThreadControl Interface
Provides methods for participating in the scheduling of threads that would otherwise be blocked for a garbage collection.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[SuspensionEnding Method](../../../../docs/framework/unmanaged-api/hosting/igcthreadcontrol-suspensionending-method.md)|Notifies the host that the runtime is resuming threads after a garbage collection or other suspension.|  
|[SuspensionStarting Method](../../../../docs/framework/unmanaged-api/hosting/igcthreadcontrol-suspensionstarting-method.md)|Notifies the host that the runtime is beginning a thread suspension for a garbage collection or other suspension.|  
|[ThreadIsBlockingForSuspension Method](../../../../docs/framework/unmanaged-api/hosting/igcthreadcontrol-threadisblockingforsuspension-method.md)|Notifies the host that the thread making the call is about to block, perhaps for a garbage collection or other suspension.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)
