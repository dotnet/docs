---
title: "IHostMemoryManager::VirtualFree Method"
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
  - "IHostMemoryManager.VirtualFree"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostMemoryManager::VirtualFree"
helpviewer_keywords: 
  - "IHostMemoryManager::VirtualFree method [.NET Framework hosting]"
  - "VirtualFree method [.NET Framework hosting]"
ms.assetid: 1a436e89-eb28-4d15-bcf1-a072f86dbd99
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostMemoryManager::VirtualFree Method
Serves as a logical wrapper for the corresponding Win32 function. The Win32 implementation of `VirtualFree` releases, decommits, or releases and decommits a region of pages within the virtual address space of the calling process.  
  
## Syntax  
  
```  
HRESULT VirtualFree (  
    [in] LPVOID  lpAddress,  
    [in] SIZE_T  dwSize,  
    [in] DWORD   dwFreeType  
);  
```  
  
#### Parameters  
 `lpAddress`  
 [in] A pointer to the base address of the virtual memory pages to be freed.  
  
 `dwSize`  
 [in] The size, in bytes, of the region to be freed.  
  
 `dwFreeType`  
 [in] The type of freeing operation.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`VirtualFree` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|HOST_E_INVALIDOPERATION|An attempt was made to free memory that was not allocated through the host.|  
  
## Remarks  
 `VirtualFree` frees virtual memory pages associated with the `lpAddress` parameter through an earlier call to the [IHostMemoryManager::VirtualAlloc](../../../../docs/framework/unmanaged-api/hosting/ihostmemorymanager-virtualalloc-method.md) function. Attempts to free memory that was not allocated through the host should return HOST_E_INVALIDOPERATION.  
  
 The semantics are identical to those of the Win32 implementation of `VirtualFree`. For more information, see the Windows Platform documentation.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IHostMemoryManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostmemorymanager-interface.md)  
 [IHostMalloc Interface](../../../../docs/framework/unmanaged-api/hosting/ihostmalloc-interface.md)
