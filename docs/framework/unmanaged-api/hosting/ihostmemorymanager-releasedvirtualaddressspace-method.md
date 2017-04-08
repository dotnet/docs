---
title: "IHostMemoryManager::ReleasedVirtualAddressSpace Method | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
apiname: 
  - "IHostMemoryManager.ReleasedVirtualAddressSpace"
apilocation: 
  - "mscoree.dll"
apitype: "COM"
f1_keywords: 
  - "IHostMemoryManager::ReleasedVirtualAddressSpace"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ReleasedVirtualAddressSpace method [.NET Framework hosting]"
  - "IHostMemoryManager::ReleasedVirtualAddressSpace method [.NET Framework hosting]"
ms.assetid: d1876601-6ab9-48e1-8ebd-184af1d0cd76
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# IHostMemoryManager::ReleasedVirtualAddressSpace Method
Notifies the host that the common language runtime (CLR) has finished using the specified memory.  
  
## Syntax  
  
```  
HRESULT ReleasedVirtualAddressSpace(  
    [in] LPVOID startAddress  
);  
```  
  
#### Parameters  
 `startAddress`  
 [in] Pointer to the starting address of the memory to be released.  
  
## Remarks  
 The `ReleasedVirtualAddressSpace` method is a callback method and must be implemented by the writer of the hosting application. It is called by the CLR.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IHostMemoryManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostmemorymanager-interface.md)