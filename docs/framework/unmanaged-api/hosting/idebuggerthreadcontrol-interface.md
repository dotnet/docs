---
title: "IDebuggerThreadControl Interface"
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
  - "IDebuggerThreadControl"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IDebuggerThreadControl"
helpviewer_keywords: 
  - "IDebuggerThreadControl interface [.NET Framework hosting]"
ms.assetid: 0a270c42-a7d1-45f1-a64d-fa3e84d14532
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IDebuggerThreadControl Interface
Provides methods for notifying the host about the blocking and unblocking of threads by the debugging services.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[ThreadIsBlockingForDebugger Method](../../../../docs/framework/unmanaged-api/hosting/idebuggerthreadcontrol-threadisblockingfordebugger-method.md)|Notifies the host that the thread that is sending this callback is about to block within the debugging services.|  
|[ReleaseAllRuntimeThreads Method](../../../../docs/framework/unmanaged-api/hosting/idebuggerthreadcontrol-releaseallruntimethreads-method.md)|Notifies the host that the debugging services are about to release all threads that are blocked.|  
|[StartBlockingForDebugger Method](../../../../docs/framework/unmanaged-api/hosting/idebuggerthreadcontrol-startblockingfordebugger-method.md)|Notifies the host that the debugging services are about to start blocking all threads.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)
