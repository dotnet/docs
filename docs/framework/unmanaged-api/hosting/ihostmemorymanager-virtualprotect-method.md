---
title: "IHostMemoryManager::VirtualProtect Method"
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
  - "IHostMemoryManager.VirtualProtect"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostMemoryManager::VirtualProtect"
helpviewer_keywords: 
  - "IHostMemoryManager::VirtualProtect method [.NET Framework hosting]"
  - "VirtualProtect method [.NET Framework hosting]"
ms.assetid: 13be0299-df0d-4951-aabf-0676a30b385f
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostMemoryManager::VirtualProtect Method
Serves as a logical wrapper for the corresponding Win32 function. The Win32 implementation of `VirtualProtect` changes the protection on a region of committed pages in the virtual address space of the calling process.  
  
## Syntax  
  
```  
HRESULT VirtualProtect (  
    [in]  void*   lpAddress,  
    [in]  SIZE_T  dwSize,  
    [in]  DWORD   flNewProtect,  
    [out] DWORD*  pflOldProtect  
);  
```  
  
#### Parameters  
 `lpAddress`  
 [in] A pointer to the base address of the virtual memory whose protection attributes are to be changed.  
  
 `dwSize`  
 [in] The size, in bytes, of the region of memory pages to be changed.  
  
 `flNewProtect`  
 [in] The type of memory protection to apply.  
  
 `pflOldProtect`  
 [out] A pointer to the previous memory protection value.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`VirtualProtect` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  
 This implementation of `VirtualProtect` returns an HRESULT value, while the Win32 implementation returns a non-zero value to indicate success, and a zero value to indicate failure. For more information, see the Windows Platform documentation.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IHostMemoryManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostmemorymanager-interface.md)
