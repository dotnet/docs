---
title: "COR_PRF_GC_ROOT_FLAGS Enumeration"
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
  - "COR_PRF_GC_ROOT_FLAGS"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_PRF_GC_ROOT_FLAGS"
helpviewer_keywords: 
  - "COR_PRF_GC_ROOT_FLAGS enumeration [.NET Framework profiling]"
ms.assetid: 4611ee6f-0f05-4d84-91e1-e83d5e7dd7e4
topic_type: 
  - "apiref"
caps.latest.revision: 16
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# COR_PRF_GC_ROOT_FLAGS Enumeration
Indicates a property of a garbage collection root.  
  
## Syntax  
  
```  
typedef enum {  
    COR_PRF_GC_ROOT_PINNING = 0x1,  
    COR_PRF_GC_ROOT_WEAKREF = 0x2,  
    COR_PRF_GC_ROOT_INTERIOR = 0x4,  
    COR_PRF_GC_ROOT_REFCOUNTED = 0x8,  
} COR_PRF_GC_ROOT_FLAGS;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`COR_PRF_GC_ROOT_PINNING`|The root prevents a garbage collection from moving the object.|  
|`COR_PRF_GC_ROOT_WEAKREF`|The root does not prevent garbage collection.|  
|`COR_PRF_GC_ROOT_INTERIOR`|The root refers to a field of the object rather than the object itself.|  
|`COR_PRF_GC_ROOT_REFCOUNTED`|The root prevents garbage collection if the reference count of the object is a certain value.|  
  
## Remarks  
 `COR_PRF_GC_ROOT_FLAGS` is a bitmask that provides additional information about special roots. However, not all roots are special. For example, some roots are not weak references, interior pointers, pinned, or reference-counted. For such roots, there are no flags to convey. Therefore, methods that use this enumeration, such as the [ICorProfilerCallback2::RootReferences2](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-rootreferences2-method.md) method, send 0 for the flags bitmask, indicating that all flags are turned off.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Profiling Enumerations](../../../../docs/framework/unmanaged-api/profiling/profiling-enumerations.md)
