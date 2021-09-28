---
description: "Learn more about: IMethodMalloc Interface"
title: "IMethodMalloc Interface"
ms.date: "03/30/2017"
api_name: 
  - "IMethodMalloc"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMethodMalloc"
helpviewer_keywords: 
  - "IMethodMalloc interface [.NET Framework profiling]"
ms.assetid: 8c8ab5dc-557c-473a-82f2-6e403eca7dac
topic_type: 
  - "apiref"
---
# IMethodMalloc Interface

Provides a method to allocate memory for a new Microsoft intermediate language (MSIL) function body.  
  
> [!NOTE]
> The `IMethodMalloc` interface is a simple memory allocator. It allows you to allocate memory, but not to free it.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Alloc Method](imethodmalloc-alloc-method.md)|Attempts to allocate a specified amount of memory for a new MSIL function body.|  
  
## Remarks  

 Each allocator is module-specific and ensures that the function body will be at a positive offset from the base of the module. Memory above the base of a module can be precious, so the allocator should be used to allocate memory only for a function body.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Profiling Interfaces](profiling-interfaces.md)
