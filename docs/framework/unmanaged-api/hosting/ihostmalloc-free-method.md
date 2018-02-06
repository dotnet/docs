---
title: "IHostMAlloc::Free Method"
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
  - "IHostMAlloc.Free"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostMAlloc::Free"
helpviewer_keywords: 
  - "IHostMAlloc::Free method [.NET Framework hosting]"
  - "Free method, IHostMAlloc interface [.NET Framework hosting]"
ms.assetid: c89abf5b-1120-4437-8b57-4a99fb3ae7f9
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostMAlloc::Free Method
Frees memory that was allocated by using the [Alloc](../../../../docs/framework/unmanaged-api/hosting/ihostmalloc-alloc-method.md) function.  
  
## Syntax  
  
```  
HRESULT Free (  
    [in] void* pMem  
);  
```  
  
#### Parameters  
 `pMem`  
 [in] A pointer to the memory to be freed.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`Free` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|HOST_E_INVALIDOPERATION|An attempt was made to free memory that was not allocated through the host.|  
  
## Remarks  
 If the `pMem` parameter refers to a region of memory that was not allocated by using a call to `Alloc`, the host should return HOST_E_INVALIDOPERATION.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IHostMemoryManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostmemorymanager-interface.md)  
 [IHostMalloc Interface](../../../../docs/framework/unmanaged-api/hosting/ihostmalloc-interface.md)
