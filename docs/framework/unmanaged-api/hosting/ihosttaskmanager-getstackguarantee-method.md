---
title: "IHostTaskManager::GetStackGuarantee Method"
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
  - "IHostTaskManager.GetStackGuarantee"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostTaskManager::GetStackGuarantee"
helpviewer_keywords: 
  - "GetStackGuarantee method [.NET Framework hosting]"
  - "IHostTaskManager::GetStackGuarantee method [.NET Framework hosting]"
ms.assetid: 8176d732-c25c-4520-811d-e3310f339947
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostTaskManager::GetStackGuarantee Method
Gets the amount of stack space that is guaranteed to be available after a stack operation completes, but before the closing of a process.  
  
## Syntax  
  
```  
HRESULT GetStackGuarantee(  
    [out] ULONG *pGuarantee  
);  
```  
  
#### Parameters  
 `pGuarantee`  
 [out] A pointer to the number of bytes that are available.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IHostTaskManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihosttaskmanager-interface.md)
