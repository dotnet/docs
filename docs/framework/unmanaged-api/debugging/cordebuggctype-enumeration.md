---
title: "CorDebugGCType Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorDebugGCType"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorDebugGCType"
helpviewer_keywords: 
  - "CorDebugGCType enumeration [.NET Framework debugging]"
ms.assetid: 880ca92a-42d4-42a5-9b9c-c2848eb39c6a
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# CorDebugGCType Enumeration
Indicates whether the garbage collector is running on a workstation or a server.  
  
## Syntax  
  
```cpp  
typedef enum CorDebugGCType {  
    CorDebugWorkstationGC  = 0,  
    CorDebugServerGC       = ( CorDebugWorkstationGC + 1 )  
} CorDebugGCType;  
```  
  
## Parameters  
  
## Members  
  
|Member name|Description|  
|-----------------|-----------------|  
|`CorDebugWorkstationGC`|The garbage collector is running on a workstation.|  
|`CorDebugServerGC`|The garbage collector is running on a server.|  
  
## Remarks  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)
