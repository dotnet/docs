---
title: "COR_IL_MAP Structure"
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
  - "COR_IL_MAP"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_IL_MAP"
helpviewer_keywords: 
  - "COR_IL_MAP structure [.NET Framework debugging]"
ms.assetid: 534ebc17-963d-4b26-8375-8cd940281db3
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# COR_IL_MAP Structure
Specifies changes in the relative offset of a function.  
  
## Syntax  
  
```  
typedef struct _COR_IL_MAP {  
    ULONG32 oldOffset;   
    ULONG32 newOffset;   
    BOOL    fAccurate;  
} COR_IL_MAP;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`oldOffset`|The old Microsoft intermediate language (MSIL) offset relative to the beginning of the function.|  
|`newOffset`|The new MSIL offset relative to the beginning of the function.|  
|`fAccurate`|`true` if the mapping is known to be accurate; otherwise, `false`.|  
  
## Remarks  
 The format of the map is as follows: The debugger will assume that `oldOffset` refers to an MSIL offset within the original, unmodified MSIL code. The `newOffset` parameter refers to the corresponding MSIL offset within the new, instrumented code.  
  
 For stepping to work properly, the following requirements should be met:  
  
-   The map should be sorted in ascending order.  
  
-   Instrumented MSIL code should not be reordered.  
  
-   Original MSIL code should not be removed.  
  
-   The map should include entries to map all the sequence points from the program database (PDB) file.  
  
 The map does not interpolate missing entries. The following example shows a map and its results.  
  
 Map:  
  
-   0 old offset, 0 new offset  
  
-   5 old offset, 10 new offset  
  
-   9 old offset, 20 new offset  
  
 Results:  
  
-   An old offset of 0, 1, 2, 3, or 4 will be mapped to a new offset of 0.  
  
-   An old offset of 5, 6, 7, or 8 will be mapped to new offset 10.  
  
-   An old offset of 9 or higher will be mapped to new offset 20.  
  
-   A new offset of 0, 1, 2, 3, 4, 5, 6, 7, 8, or 9 will be mapped to old offset 0.  
  
-   A new offset of 10, 11, 12, 13, 14, 15, 16, 17, 18, or 19 will be mapped to old offset 5.  
  
-   A new offset of 20 or higher will be mapped to old offset 9.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorProf.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Debugging Structures](../../../../docs/framework/unmanaged-api/debugging/debugging-structures.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
