---
title: "IGCHost::SetVirtualMemLimit Method"
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
  - "IGCHost.SetVirtualMemLimit"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "SetVirtualMemLimit"
helpviewer_keywords: 
  - "IGCHost::SetVirtualMemLimit method [.NET Framework hosting]"
  - "SetVirtualMemLimit method [.NET Framework hosting]"
ms.assetid: c7e7c2d0-e58c-4650-b40c-47b2be2cda45
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IGCHost::SetVirtualMemLimit Method
Sets the maximum size of the runtime's virtual memory.  
  
## Syntax  
  
```  
HRESULT SetVirtualMemLimit (  
    [in] SIZE_T sztMaxVirtualMemMB  
);  
```  
  
#### Parameters  
 `sztMaxVirtualMemMB`  
 [in] The maximum size, in megabytes, of the runtime's virtual memory.  
  
## Remarks  
 The maximum size of the runtime's virtual memory can be changed dynamically.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** GCHost.idl, GCHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IGCHost Interface](../../../../docs/framework/unmanaged-api/hosting/igchost-interface.md)
