---
title: "COR_ARRAY_LAYOUT Structure"
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
  - "COR_ARRAY_LAYOUT"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_ARRAY_LAYOUT"
helpviewer_keywords: 
  - "COR_DEBUG_IL_TO_NATIVE_MAP structure [.NET Framework debugging]"
ms.assetid: aa20ac3d-6f60-4aa2-91c5-f3a86f82eba8
topic_type: 
  - "apiref"
caps.latest.revision: 5
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# COR_ARRAY_LAYOUT Structure
Provides information about the layout of an array object in memory.  
  
## Syntax  
  
```  
typedef struct COR_ARRAY_LAYOUT {  
    COR_TYPEID componentID;  
    CorElementType componentType;  
    ULONG32 firstElementOffset;  
    ULONG32 elementSize;  
    ULONG32 countOffset;   
    ULONG32 rankSize;   
    ULONG32 numRanks;   
    ULONG32 rankOffset;   
} COR_ARRAY_LAYOUT;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`componentID`|The identifier of the type of objects that the array contains.|  
|`componentType`|A CorElementType enumeration value that indicates whether the component is a garbage collection reference, a value class, or a primitive.|  
|`firstElementOffset`|The offset to the first element in the array.|  
|`elementSize`|The size of each element.|  
|`countOffset`|The offset to the number of elements in the array.|  
|`rankSize`|The size of the rank, in bytes.|  
|`numRanks`|The number of ranks in the array.|  
|`rankOffset`|The offset at which the ranks start.|  
  
## Remarks  
 The `rankSize` field specifies the size of a rank in a multi-dimensional array. It is accurate for single-dimensional arrays as well.  
  
 The value of `numRanks` is 1 for a single-dimensional array and `N` for a multi-dimensional array of `N` dimensions.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [Debugging Structures](../../../../docs/framework/unmanaged-api/debugging/debugging-structures.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
