---
title: "IHostMAlloc::DebugAlloc Method"
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
  - "IHostMAlloc.DebugAlloc"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostMAlloc::DebugAlloc"
helpviewer_keywords: 
  - "DebugAlloc method [.NET Framework hosting]"
  - "IHostMAlloc::DebugAlloc method [.NET Framework hosting]"
ms.assetid: 0bfbc527-bea2-43ce-b041-69186f4440dd
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostMAlloc::DebugAlloc Method
Requests that the host allocate the specified amount of memory from the heap, and additionally track where the memory was allocated.  
  
## Syntax  
  
```  
HRESULT DebugAlloc (  
    [in]  SIZE_T  cbSize,   
    [in]  EMemoryCriticalLevel dwCriticalLevel,   
    [in]  char*   pszFileName,   
    [in]  int     iLineNo,   
    [out] void**  ppMem  
);  
```  
  
#### Parameters  
 `cbSize`  
 [in] The size, in bytes, of the current memory allocation request.  
  
 `dwCriticalLevel`  
 [in] One of the [EMemoryCriticalLevel](../../../../docs/framework/unmanaged-api/hosting/ememorycriticallevel-enumeration.md) values, indicating the impact of an allocation failure.  
  
 `pszFileName`  
 [in] The code file of the executable being debugged.  
  
 `iLineNo`  
 [in] The line number in `pszFileName` where the allocation was requested.  
  
 `ppMem`  
 [out] A pointer to the allocated memory, or null if the request could not be completed.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`DebugAlloc` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_OUTOFMEMORY|Not enough memory was available to complete the allocation request.|  
  
## Remarks  
 The CLR gets an interface pointer to an [IHostMalloc](../../../../docs/framework/unmanaged-api/hosting/ihostmalloc-interface.md) instance by calling the [IHostMemoryManager::CreateMalloc](../../../../docs/framework/unmanaged-api/hosting/ihostmemorymanager-createmalloc-method.md) method. `DebugAlloc` allows the runtime to get code file information for use during debugging.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IHostMemoryManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostmemorymanager-interface.md)  
 [IHostMalloc Interface](../../../../docs/framework/unmanaged-api/hosting/ihostmalloc-interface.md)
