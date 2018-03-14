---
title: "COR_PRF_GC_ROOT_KIND Enumeration"
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
  - "COR_PRF_GC_ROOT_KIND"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_PRF_GC_ROOT_KIND"
helpviewer_keywords: 
  - "COR_PRF_GC_ROOT_KIND enumeration [.NET Framework profiling]"
ms.assetid: b9fb1c03-417f-41d4-aed4-02cb4ade8def
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# COR_PRF_GC_ROOT_KIND Enumeration
Indicates the kind of garbage collection root that is exposed by the [ICorProfilerCallback2::RootReferences2](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-rootreferences2-method.md) callback.  
  
## Syntax  
  
```  
typedef enum {  
    COR_PRF_GC_ROOT_STACK = 1,  
    COR_PRF_GC_ROOT_FINALIZER = 2,  
    COR_PRF_GC_ROOT_HANDLE = 3,  
    COR_PRF_GC_ROOT_OTHER = 0  
} COR_PRF_GC_ROOT_KIND;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`COR_PRF_GC_ROOT_STACK`|The root is a variable on the stack.|  
|`COR_PRF_GC_ROOT_FINALIZER`|The root is an entry in the finalizer queue.|  
|`COR_PRF_GC_ROOT_HANDLE`|The root is a garbage collection handle.|  
|`COR_PRF_GC_ROOT_OTHER`|The kind of root is unspecified.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Profiling Enumerations](../../../../docs/framework/unmanaged-api/profiling/profiling-enumerations.md)
