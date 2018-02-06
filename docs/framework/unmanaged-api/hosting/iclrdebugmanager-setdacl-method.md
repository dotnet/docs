---
title: "ICLRDebugManager::SetDacl Method"
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
  - "ICLRDebugManager.SetDacl"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDebugManager::SetDacl"
helpviewer_keywords: 
  - "SetDacl method [.NET Framework hosting]"
  - "ICLRDebugManager::SetDacl method [.NET Framework hosting]"
ms.assetid: 52f4af3f-e02b-4c20-9fd9-e8e4f4d6fc31
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRDebugManager::SetDacl Method
This method is not implemented.  
  
## Syntax  
  
```  
HRESULT SetDacl (  
    [in] PACL pacl  
);  
```  
  
#### Parameters  
 `pacl`  
 [in] A pointer to the Access Control List (ACL).  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|E_NOTIMPL|The method is not implemented.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRControl Interface](../../../../docs/framework/unmanaged-api/hosting/iclrcontrol-interface.md)  
 [ICLRDebugManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrdebugmanager-interface.md)  
 [GetDacl Method](../../../../docs/framework/unmanaged-api/hosting/iclrdebugmanager-getdacl-method.md)  
 [IHostControl Interface](../../../../docs/framework/unmanaged-api/hosting/ihostcontrol-interface.md)
