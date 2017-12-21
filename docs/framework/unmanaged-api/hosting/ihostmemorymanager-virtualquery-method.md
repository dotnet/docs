---
title: "IHostMemoryManager::VirtualQuery Method"
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
  - "IHostMemoryManager.VirtualQuery"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostMemoryManager::VirtualQuery"
helpviewer_keywords: 
  - "IHostMemoryManager::VirtualQuery method [.NET Framework hosting]"
  - "VirtualQuery method [.NET Framework hosting]"
ms.assetid: 757af1e6-b9e8-49e7-b5db-342be3aa205f
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostMemoryManager::VirtualQuery Method
Serves as a logical wrapper for the corresponding Win32 function. The Win32 implementation of `VirtualQuery` retrieves information about a range of pages in the virtual address space of the calling process.  
  
## Syntax  
  
```  
HRESULT VirtualQuery (  
    [in]  void*    lpAddress,  
    [out] void*    lpBuffer,  
    [in]  SIZE_T   dwLength,  
    [out] SIZE_T*  pResult  
);  
```  
  
#### Parameters  
 `lpAddress`  
 [in] A pointer to the address in virtual memory to be queried.  
  
 `lpBuffer`  
 [out] A pointer to a structure that contains information about the specified memory region.  
  
 `dwLength`  
 [in] The size, in bytes, of the buffer that `lpBuffer` points to.  
  
 `pResult`  
 [out] A pointer to the number of bytes returned by the information buffer.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`VirtualQuery` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  
 `VirtualQuery` provides information about a range of pages in the virtual address space of the calling process. This implementation sets the value of the `pResult` parameter to the number of bytes returned in the information buffer, and returns an HRESULT value. In the Win32 `VirtualQuery` function, the return value is the buffer size. For more information, see the Windows Platform documentation.  
  
> [!IMPORTANT]
>  The operating system's implementation of `VirtualQuery` does not incur deadlock and can run to completion with random threads suspended in user code. Use great caution when implementing a hosted version of this method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IHostMemoryManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostmemorymanager-interface.md)
