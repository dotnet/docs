---
title: "IHostMemoryManager::GetMemoryLoad Method"
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
  - "IHostMemoryManager.GetMemoryLoad"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostMemoryManager::GetMemoryLoad"
helpviewer_keywords: 
  - "IHostMemoryManager::GetMemoryLoad method [.NET Framework hosting]"
  - "GetMemoryLoad method [.NET Framework hosting]"
ms.assetid: e8138f6e-a0a4-48d4-8dae-9466b4dc6180
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostMemoryManager::GetMemoryLoad Method
Gets the amount of physical memory that is currently in use, and therefore unavailable, as reported by the host.  
  
## Syntax  
  
```  
HRESULT GetMemoryLoad (  
    [out] DWORD*  pMemoryLoad,   
    [out] SIZE_T  *pAvailableBytes  
);  
```  
  
#### Parameters  
 `pMemoryLoad`  
 [out] A pointer to the approximate percentage of total physical memory that is currently in use.  
  
 `pAvailableBytes`  
 [out] A pointer to the number of bytes available to the common language runtime (CLR).  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`GetMemoryLoad` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  
 `GetMemoryLoad` wraps the Win32 `GlobalMemoryStatus` function. The value of `pMemoryLoad` is the equivalent of the `dwMemoryLoad` field in the `MEMORYSTATUS` structure returned from `GlobalMemoryStatus`.  
  
 The runtime uses the return value as a heuristic for the garbage collector. For example, if the host reports that the majority of memory is in use, the garbage collector may elect to collect from multiple generations to increase the amount of memory that can potentially become available.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 <xref:System.GC?displayProperty=nameWithType>  
 [IHostMemoryManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostmemorymanager-interface.md)
