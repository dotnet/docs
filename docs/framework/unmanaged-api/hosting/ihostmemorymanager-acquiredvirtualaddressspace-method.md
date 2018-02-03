---
title: "IHostMemoryManager::AcquiredVirtualAddressSpace Method"
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
  - "IHostMemoryManager.AcquiredVirtualAddressSpace"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostMemoryManager::AcquiredVirtualAddressSpace"
helpviewer_keywords: 
  - "IHostMemoryManager::AcquiredVirtualAddressSpace method [.NET Framework hosting]"
  - "AcquiredVirtualAddressSpace method [.NET Framework hosting]"
ms.assetid: ef2f83c2-127e-4c38-8385-306c03cd2167
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostMemoryManager::AcquiredVirtualAddressSpace Method
Notifies the host that the common language runtime (CLR) has acquired the specified memory from the operating system.  
  
## Syntax  
  
```  
HRESULT AcquiredVirtualAddressSpace(  
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
 The `AcquiredVirtualAddressSpace` method is a callback method and must be implemented by the writer of the hosting application. It is called by the CLR.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IHostMemoryManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostmemorymanager-interface.md)
