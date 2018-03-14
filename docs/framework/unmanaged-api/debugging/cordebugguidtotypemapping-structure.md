---
title: "CorDebugGuidToTypeMapping Structure"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
dev_langs: 
  - "cpp"
api_name: 
  - "CorDebugGuidToTypeMapping"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorDebugGuidToTypeMapping"
helpviewer_keywords: 
  - "CorDebugGuidToTypeMapping structure [.NET Framework debugging]"
ms.assetid: 57dbccd9-b16d-4da3-ae25-7a2cf9adf679
topic_type: 
  - "apiref"
caps.latest.revision: 3
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorDebugGuidToTypeMapping Structure
Maps a [!INCLUDE[wrt](../../../../includes/wrt-md.md)] GUID to its corresponding ICorDebugType object.  
  
## Syntax  
  
```cpp
typedef struct CorDebugGuidToTypeMapping {  
    GUID iid;  
    ICorDebugType *pType;  
} CorDebugGuidToTypeMapping;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`iid`|The GUID of the cached [!INCLUDE[wrt](../../../../includes/wrt-md.md)] type.|  
|`pType`|A pointer to an ICorDebugType object that provides information about the cached type.|  
  
## Requirements  
 **Platforms:** [!INCLUDE[wrt](../../../../includes/wrt-md.md)].  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [Debugging Structures](../../../../docs/framework/unmanaged-api/debugging/debugging-structures.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
