---
title: "IHostMemoryManager::VirtualAlloc Method"
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
  - "IHostMemoryManager.VirtualAlloc"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostMemoryManager::VirtualAlloc"
helpviewer_keywords: 
  - "VirtualAlloc method [.NET Framework hosting]"
  - "IHostMemoryManager::VirtualAlloc method [.NET Framework hosting]"
ms.assetid: 4dff3646-a050-4bd9-ac31-fe307e8637ec
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostMemoryManager::VirtualAlloc Method
Serves as a logical wrapper for the corresponding Win32 function. The Win32 implementation of `VirtualAlloc` reserves or commits a region of pages in the virtual address space of the calling process.  
  
## Syntax  
  
```  
HRESULT VirtualAlloc (  
    [in]  void*   pAddress,  
    [in]  SIZE_T  dwSize,  
    [in]  DWORD   flAllocationType,  
    [in]  DWORD   flProtect,  
    [in]  EMemoryCriticalLevel dwCriticalLevel,  
    [out] void**  ppMem  
);  
```  
  
#### Parameters  
 `pAddress`  
 [in] A pointer to the starting address of the region to allocate.  
  
 `dwSize`  
 [in] The size, in bytes, of the region.  
  
 `flAllocationType`  
 [in] The type of memory allocation.  
  
 `flProtect`  
 [in] Memory protection for the region of pages to be allocated.  
  
 `dwCriticalLevel`  
 [in] An [EMemoryCriticalLevel](../../../../docs/framework/unmanaged-api/hosting/ememorycriticallevel-enumeration.md) value that indicates the impact of an allocation failure.  
  
 `ppMem`  
 [out] Pointer to the starting address of the allocated memory, or null if the request could not be satisfied.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`VirtualAlloc` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_OUTOFMEMORY|Not enough memory was available to complete the allocation request|  
  
## Remarks  
 You reserve a region in the address space of your process by calling `VirtualAlloc`. The `pAddress` parameter contains the beginning address of the memory block you want. This parameter is typically set to null. The operating system keeps a record of free address ranges available to your process. A `pAddress` value of null instructs the system to reserve the region wherever it sees fit. Alternatively, you can provide a specific starting address for the memory block. In both cases, the output parameter `ppMem` is returned as a pointer to the allocated memory. The function itself returns an HRESULT value.  
  
 The Win32 `VirtualAlloc` function does not have a `ppMem` parameter, and returns the pointer to the allocated memory instead. For more information, see the Windows Platform documentation.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IHostMemoryManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostmemorymanager-interface.md)
