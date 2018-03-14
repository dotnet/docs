---
title: "IMethodMalloc Interface"
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
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMethodMalloc Interface
Provides a method to allocate memory for a new Microsoft intermediate language (MSIL) function body.  
  
> [!NOTE]
>  The `IMethodMalloc` interface is a simple memory allocator. It allows you to allocate memory, but not to free it.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Alloc Method](../../../../docs/framework/unmanaged-api/profiling/imethodmalloc-alloc-method.md)|Attempts to allocate a specified amount of memory for a new MSIL function body.|  
  
## Remarks  
 Each allocator is module-specific and ensures that the function body will be at a positive offset from the base of the module. Memory above the base of a module can be precious, so the allocator should be used to allocate memory only for a function body.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)
