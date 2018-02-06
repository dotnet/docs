---
title: "IHostMalloc Interface"
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
  - "IHostMAlloc"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostMAlloc"
helpviewer_keywords: 
  - "IHostMAlloc interface [.NET Framework hosting]"
ms.assetid: e3c6643b-6fc7-4a99-959d-4b7b4e63fdee
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostMalloc Interface
Provides methods that allow the common language runtime (CLR) to request fine-grained allocations from the heap through the host.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Alloc Method](../../../../docs/framework/unmanaged-api/hosting/ihostmalloc-alloc-method.md)|Requests that the host allocate the requested amount of memory from the heap.|  
|[DebugAlloc Method](../../../../docs/framework/unmanaged-api/hosting/ihostmalloc-debugalloc-method.md)|Requests that the host allocate the requested amount of memory from the heap, and additionally track where the memory was allocated.|  
|[Free Method](../../../../docs/framework/unmanaged-api/hosting/ihostmalloc-free-method.md)|Frees memory that was allocated by using the `Alloc` method.|  
  
## Remarks  
 The CLR gets an interface pointer to an `IHostMalloc` instance by calling the [IHostMemoryManager::CreateMalloc](../../../../docs/framework/unmanaged-api/hosting/ihostmemorymanager-createmalloc-method.md) method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IHostMemoryManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostmemorymanager-interface.md)  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)
