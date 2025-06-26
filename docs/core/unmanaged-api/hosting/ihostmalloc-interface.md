---
description: "Learn more about: IHostMalloc Interface"
title: "IHostMalloc Interface"
ms.date: "03/30/2017"
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
---
# IHostMalloc Interface

Provides methods that allow the common language runtime (CLR) to request fine-grained allocations from the heap through the host.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Alloc Method](ihostmalloc-alloc-method.md)|Requests that the host allocate the requested amount of memory from the heap.|  
|[DebugAlloc Method](ihostmalloc-debugalloc-method.md)|Requests that the host allocate the requested amount of memory from the heap, and additionally track where the memory was allocated.|  
|[Free Method](ihostmalloc-free-method.md)|Frees memory that was allocated by using the `Alloc` method.|  
  
## Remarks  

 The CLR gets an interface pointer to an `IHostMalloc` instance by calling the [IHostMemoryManager::CreateMalloc](ihostmemorymanager-createmalloc-method.md) method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IHostMemoryManager Interface](ihostmemorymanager-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
