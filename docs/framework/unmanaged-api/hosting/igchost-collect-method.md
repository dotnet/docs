---
title: "IGCHost::Collect Method"
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
  - "IGCHost.Collect"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "Collect"
helpviewer_keywords: 
  - "Collect method, IGCHost interface [.NET Framework hosting]"
  - "IGCHost::Collect method [.NET Framework hosting]"
ms.assetid: fc7d9448-3186-494d-9f0d-ea39717e9a82
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IGCHost::Collect Method
Forces a collection to occur for the given generation, regardless of the state of the current garbage collection.  
  
## Syntax  
  
```  
HRESULT Collect (  
    [in] LONG Generation  
);  
```  
  
#### Parameters  
 `Generation`  
 [in] The generation on which to perform the garbage collection. A value of -1 indicates that all generations will undergo a garbage collection.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** GCHost.idl, GCHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IGCHost Interface](../../../../docs/framework/unmanaged-api/hosting/igchost-interface.md)
