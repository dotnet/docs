---
description: "Learn more about: CorDebugCreateProcessFlags Enumeration"
title: "CorDebugCreateProcessFlags Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorDebugCreateProcessFlags"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorDebugCreateProcessFlags"
helpviewer_keywords: 
  - "CorDebugCreateProcessFlags enumeration [.NET Framework debugging]"
ms.assetid: e709acce-6a17-4346-b38a-467dba567358
topic_type: 
  - "apiref"
---
# CorDebugCreateProcessFlags Enumeration

Provides additional debugging options that can be used in a call to the [ICorDebug::CreateProcess](icordebug-createprocess-method.md) method.  
  
## Syntax  
  
```cpp  
typedef enum CorDebugCreateProcessFlags {  
    DEBUG_NO_SPECIAL_OPTIONS    = 0x0000  
} CorDebugCreateProcessFlags;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`DEBUG_NO_SPECIAL_OPTIONS`|No special options are set.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Debugging Enumerations](debugging-enumerations.md)
