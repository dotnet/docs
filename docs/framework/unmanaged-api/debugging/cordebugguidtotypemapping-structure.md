---
title: "CorDebugGuidToTypeMapping Structure"
ms.date: "03/30/2017"
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
---
# CorDebugGuidToTypeMapping Structure
Maps a Windows Runtime GUID to its corresponding ICorDebugType object.  
  
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
|`iid`|The GUID of the cached Windows Runtime type.|  
|`pType`|A pointer to an ICorDebugType object that provides information about the cached type.|  
  
## Requirements  
 **Platforms:** Windows Runtime.  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [Debugging Structures](../../../../docs/framework/unmanaged-api/debugging/debugging-structures.md)
- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
