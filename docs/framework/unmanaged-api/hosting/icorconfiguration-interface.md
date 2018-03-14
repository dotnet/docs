---
title: "ICorConfiguration Interface"
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
  - "ICorConfiguration"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorConfiguration"
helpviewer_keywords: 
  - "ICorConfiguration interface [.NET Framework hosting]"
ms.assetid: aaf96116-372b-4538-afb1-9e0fcdac1f98
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorConfiguration Interface
Provides methods for configuring the common language runtime (CLR).  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[AddDebuggerSpecialThread Method](../../../../docs/framework/unmanaged-api/hosting/icorconfiguration-adddebuggerspecialthread-method.md)|Indicates to the debugging services that a particular thread should be allowed to continue executing while the debugger has an application stopped during managed or unmanaged debugging scenarios.|  
|[SetDebuggerThreadControl Method](../../../../docs/framework/unmanaged-api/hosting/icorconfiguration-setdebuggerthreadcontrol-method.md)|Sets the callback interface that the debugging services will call as CLR threads are blocked and unblocked for debugging.|  
|[SetGCHostControl Method](../../../../docs/framework/unmanaged-api/hosting/icorconfiguration-setgchostcontrol-method.md)|Sets the callback interface to be used by the garbage collector to request the host to change the limits of virtual memory.|  
|[SetGCThreadControl Method](../../../../docs/framework/unmanaged-api/hosting/icorconfiguration-setgcthreadcontrol-method.md)|Sets the callback interface for scheduling threads for non-runtime tasks that would otherwise be blocked for a garbage collection.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)  
 [CorRuntimeHost Coclass](../../../../docs/framework/unmanaged-api/hosting/corruntimehost-coclass.md)
