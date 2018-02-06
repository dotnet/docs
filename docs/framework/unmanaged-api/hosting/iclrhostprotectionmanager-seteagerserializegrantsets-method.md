---
title: "ICLRHostProtectionManager::SetEagerSerializeGrantSets Method"
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
  - "ICLRHostProtectionManager.SetEagerSerializeGrantSets"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRHostProtectionManager::SetEagerSerializeGrantSets"
helpviewer_keywords: 
  - "SetEagerSerializeGrantSets method [.NET Framework hosting]"
  - "ICLRHostProtectionManager::SetEagerSerializeGrantSets method [.NET Framework hosting]"
ms.assetid: d6158360-22b1-4ace-ad85-d830b9964783
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRHostProtectionManager::SetEagerSerializeGrantSets Method
This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.  
  
## Syntax  
  
```  
HRESULT SetEagerSerializeGrantSets ();  
```  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`SetEagerSerializeGrantSets` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRControl Interface](../../../../docs/framework/unmanaged-api/hosting/iclrcontrol-interface.md)  
 [ICLRHostProtectionManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrhostprotectionmanager-interface.md)
