---
title: "IGCHostControl::RequestVirtualMemLimit Method"
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
  - "IGCHostControl.RequestVirtualMemLimit"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "RequestVirtualMemLimit"
helpviewer_keywords: 
  - "IGCHostControl::RequestVirtualMemLimit method [.NET Framework hosting]"
  - "RequestVirtualMemLimit method [.NET Framework hosting]"
ms.assetid: f4984a8c-4c0e-4460-9aa1-d022b3621228
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IGCHostControl::RequestVirtualMemLimit Method
Requests the host to change the limits of virtual memory.  
  
## Syntax  
  
```  
HRESULT RequestVirtualMemLimit (  
    [in] SIZE_T       sztMaxVirtualMemMB,  
    [in, out] SIZE_T* psztNewMaxVirtualMemMB  
);  
```  
  
#### Parameters  
 `sztMaxVirtualMemMB`  
 [in] The requested size of memory to be allocated.  
  
 `psztNewMaxVirtualMemMB`  
 [in, out] A pointer to the actual size of memory allocated.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IGCHostControl Interface](../../../../docs/framework/unmanaged-api/hosting/igchostcontrol-interface.md)
