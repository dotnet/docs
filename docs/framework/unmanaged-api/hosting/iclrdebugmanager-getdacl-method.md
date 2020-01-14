---
title: "ICLRDebugManager::GetDacl Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRDebugManager.GetDacl"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDebugManager::GetDacl"
helpviewer_keywords: 
  - "GetDacl method [.NET Framework hosting]"
  - "ICLRDebugManager::GetDacl method [.NET Framework hosting]"
ms.assetid: 7115e920-aaff-440a-824e-39497139c6f6
topic_type: 
  - "apiref"
---
# ICLRDebugManager::GetDacl Method
This method is not implemented.  
  
## Syntax  
  
```cpp  
HRESULT GetDacl (  
    [out] PACL* ppacl  
);  
```  
  
## Parameters  
 `ppacl`  
 [out] An interface pointer to the Access Control List (ACL).  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|E_NOTIMPL|The method is not implemented.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRControl Interface](../../../../docs/framework/unmanaged-api/hosting/iclrcontrol-interface.md)
- [ICLRDebugManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrdebugmanager-interface.md)
- [SetDacl Method](../../../../docs/framework/unmanaged-api/hosting/iclrdebugmanager-setdacl-method.md)
- [IHostControl Interface](../../../../docs/framework/unmanaged-api/hosting/ihostcontrol-interface.md)
