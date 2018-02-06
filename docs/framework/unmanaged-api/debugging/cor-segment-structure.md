---
title: "COR_SEGMENT Structure"
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
  - "COR_SEGMENT"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_SEGMENT"
helpviewer_keywords: 
  - "COR_SEGMENT structure [.NET Framework debugging]"
ms.assetid: 93aeecb9-7fef-4545-8daf-f566dfc47084
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# COR_SEGMENT Structure
Contains information about a region of memory in the managed heap.  
  
## Syntax  
  
```  
typedef struct _COR_SEGMENT {  
    CORDB_ADDRESS start;            
    CORDB_ADDRESS end;              
    CorDebugGenerationTypes gen;    
    ULONG heap;                     
} COR_SEGMENT;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`start`|The starting address of the memory region.|  
|`end`|The ending address of the memory region.|  
|`gen`|A [CorDebugGenerationTypes](../../../../docs/framework/unmanaged-api/debugging/cordebuggenerationtypes-enumeration.md) enumeration member that indicates the generation of the memory region.|  
|`heap`|The heap number in which the memory region resides. See the Remarks section for more information.|  
  
## Remarks  
 The `COR_SEGMENTS` structure represents a region of memory in the managed heap.  `COR_SEGMENTS` objects are members of the [ICorDebugHeapRegionEnum](../../../../docs/framework/unmanaged-api/debugging/icordebugheapsegmentenum-interface.md) collection object, which is populated by calling the[ICorDebugProcess5::EnumerateHeapRegions](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess5-enumerateheapregions-method.md) method.  
  
 The `heap` field is the processor number, which corresponds to the heap being reported. For workstation garbage collectors, its value is always zero, because workstations have only one garbage collection heap. For server garbage collectors, its value corresponds to the processor the heap is attached to. Note that there may be more or fewer garbage collection heaps than there are actual processors due to the implementation details of the garbage collector.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [Debugging Structures](../../../../docs/framework/unmanaged-api/debugging/debugging-structures.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
