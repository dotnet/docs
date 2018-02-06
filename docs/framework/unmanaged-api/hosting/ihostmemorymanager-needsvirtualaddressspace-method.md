---
title: "IHostMemoryManager::NeedsVirtualAddressSpace Method"
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
  - "IHostMemoryManager.NeedsVirtualAddressSpace"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostMemoryManager::NeedsVirtualAddressSpace"
helpviewer_keywords: 
  - "IHostMemoryManager::NeedsVirtualAddressSpace method [.NET Framework hosting]"
  - "NeedsVirtualAddressSpace method [.NET Framework hosting]"
ms.assetid: 71f0eab5-0170-46f8-9f88-1df5abdeb34a
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostMemoryManager::NeedsVirtualAddressSpace Method
Notifies the host that the common language runtime (CLR) is going to attempt to use the specified memory.  
  
## Syntax  
  
```  
HRESULT NeedsVirtualAddressSpace (  
    [in] LPVOID  startAddress,  
    [in] SIZE_T  size  
);  
```  
  
#### Parameters  
 `startAddress`  
 [in] The starting address of the memory.  
  
 `size`  
 [in] The size, in bytes, of the memory.  
  
## Remarks  
 The `NeedsVirtualAddressSpace` method is a callback method and must be implemented by the writer of the hosting application. It is called by the CLR.  
  
 If the host does not want the CLR to use the specified memory, it may return an E_OUTOFMEMORY HRESULT.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IHostMemoryManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostmemorymanager-interface.md)
