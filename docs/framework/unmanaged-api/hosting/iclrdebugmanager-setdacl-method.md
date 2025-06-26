---
description: "Learn more about: ICLRDebugManager::SetDacl Method"
title: "ICLRDebugManager::SetDacl Method"
ms.date: "03/30/2017"
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
---
# ICLRDebugManager::SetDacl Method

This method is not implemented.  
  
## Syntax  
  
```cpp  
HRESULT SetDacl (  
    [in] PACL pacl  
);  
```  
  
## Parameters  

 `pacl`  
 [in] A pointer to the Access Control List (ACL).  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|E_NOTIMPL|The method is not implemented.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRControl Interface](iclrcontrol-interface.md)
- [ICLRDebugManager Interface](iclrdebugmanager-interface.md)
- [GetDacl Method](iclrdebugmanager-getdacl-method.md)
- [IHostControl Interface](ihostcontrol-interface.md)
