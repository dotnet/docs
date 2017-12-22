---
title: "COR_PRF_GC_GENERATION Enumeration"
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
  - "COR_PRF_GC_GENERATION"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_PRF_GC_GENERATION"
helpviewer_keywords: 
  - "COR_GC_GENERATION_FLAGS enumeration [.NET Framework profiling]"
ms.assetid: d6ece160-26ad-4d39-abd7-05acd6f78c48
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# COR_PRF_GC_GENERATION Enumeration
Identifies a garbage-collection generation.  
  
## Syntax  
  
```  
typedef enum {  
    COR_PRF_GC_GEN_0 = 0,  
    COR_PRF_GC_GEN_1 = 1,  
    COR_PRF_GC_GEN_2 = 2,  
    COR_PRF_GC_LARGE_OBJECT_HEAP = 3  
} COR_PRF_GC_GENERATION;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`COR_PRF_GC_GEN_0`|The object is stored as generation 0.|  
|`COR_PRF_GC_GEN_1`|The object is stored as generation 1.|  
|`COR_PRF_GC_GEN_2`|The object is stored as generation 2.|  
|`COR_PRF_GC_LARGE_OBJECT_HEAP`|The object is stored in the large-object heap.|  
  
## Remarks  
 The garbage collector improves memory management performance by dividing objects into generations based on age. The garbage collector currently uses three generations, numbered 0, 1, and 2, plus a special heap segment that is used for large objects. Objects whose size is larger than a particular value are stored in the large-object heap. Other allocated objects start out belonging to generation 0. All objects that exist after garbage collection occurs in generation 0 are promoted to generation 1. Objects that exist after garbage collection occurs in generation 1 move into generation 2.  
  
 The use of generations means that the garbage collector has to work with only a subset of the allocated objects at any one time.  
  
 The `COR_PRF_GC_GENERATION` enumeration is used by the [COR_PRF_GC_GENERATION_RANGE](../../../../docs/framework/unmanaged-api/profiling/cor-prf-gc-generation-range-structure.md) structure.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Profiling Enumerations](../../../../docs/framework/unmanaged-api/profiling/profiling-enumerations.md)
