---
title: "ICorConfiguration::SetGCHostControl Method"
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
  - "ICorConfiguration.SetGCHostControl"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "SetGCHostControl"
helpviewer_keywords: 
  - "ICorConfiguration::SetGCHostControl method [.NET Framework hosting]"
  - "SetGCHostControl method [.NET Framework hosting]"
ms.assetid: bca6bd79-e288-475a-aa46-6bf81541d966
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorConfiguration::SetGCHostControl Method
Sets the callback interface to be used by the garbage collector to request the host to change the limits of virtual memory.  
  
## Syntax  
  
```  
HRESULT SetGCHostControl (  
    [in] IGCHostControl* pGCHostControl  
);  
```  
  
#### Parameters  
 `pGCHostControl`  
 [in] A pointer to an [IGCHostControl](../../../../docs/framework/unmanaged-api/hosting/igchostcontrol-interface.md) object that allows the garbage collector to request the host to change the limits of virtual memory.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorConfiguration Interface](../../../../docs/framework/unmanaged-api/hosting/icorconfiguration-interface.md)
