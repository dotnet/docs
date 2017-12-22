---
title: "ICLRGCManager::Collect Method"
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
  - "ICLRGCManager.Collect"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRGCManager::Collect"
helpviewer_keywords: 
  - "ICLRGCManager::Collect method [.NET Framework hosting]"
  - "Collect method, ICLRGCManager interface [.NET Framework hosting]"
ms.assetid: 0c6cbbea-c27c-4695-bda3-17c1910d8ddb
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRGCManager::Collect Method
Forces a garbage collection for the specified generation.  
  
## Syntax  
  
```  
HRESULT Collect (  
    [in] LONG Generation  
);  
```  
  
#### Parameters  
 `Generation`  
 [in] The generation to collect. A value of -1 forces a collection of all generations.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`Collect` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  
 The `Collect` method forces the CLR's garbage collector to perform a collection regardless of its current state.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Automatic Memory Management](../../../../docs/standard/automatic-memory-management.md)  
 [Garbage Collection](../../../../docs/standard/garbage-collection/index.md)  
 [ICLRControl Interface](../../../../docs/framework/unmanaged-api/hosting/iclrcontrol-interface.md)  
 [ICLRGCManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrgcmanager-interface.md)  
 [CLR Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/clr-hosting-interfaces.md)  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)  
 [Hosting](../../../../docs/framework/unmanaged-api/hosting/index.md)
