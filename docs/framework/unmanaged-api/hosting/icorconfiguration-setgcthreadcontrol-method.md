---
title: "ICorConfiguration::SetGCThreadControl Method"
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
  - "ICorConfiguration.SetGCThreadControl"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "SetGCThreadControl"
helpviewer_keywords: 
  - "ICorConfiguration::SetGCThreadControl method [.NET Framework hosting]"
  - "SetGCThreadControl method [.NET Framework hosting]"
ms.assetid: 72e38e61-3d56-4ae3-b8f6-0ab7922aaf11
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorConfiguration::SetGCThreadControl Method
Sets the callback interface for scheduling threads for non-runtime tasks that would otherwise be blocked for a garbage collection.  
  
## Syntax  
  
```  
HRESULT SetGCThreadControl (  
    [in] IGCThreadControl* pGCThreadControl  
);  
```  
  
#### Parameters  
 `pGCThreadControl`  
 [in] A pointer to an [IGCThreadControl](../../../../docs/framework/unmanaged-api/hosting/igcthreadcontrol-interface.md) object that notifies the host about the suspension of threads for non-runtime tasks.  
  
## Remarks  
 The host may choose within the [IGCThreadControl::ThreadIsBlockingForSuspension](../../../../docs/framework/unmanaged-api/hosting/igcthreadcontrol-threadisblockingforsuspension-method.md) callback whether to reschedule a thread.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorConfiguration Interface](../../../../docs/framework/unmanaged-api/hosting/icorconfiguration-interface.md)
