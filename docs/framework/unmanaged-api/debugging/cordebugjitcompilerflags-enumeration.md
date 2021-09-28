---
description: "Learn more about: CorDebugJITCompilerFlags Enumeration"
title: "CorDebugJITCompilerFlags Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorDebugJITCompilerFlags"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorDebugJITCompilerFlags"
helpviewer_keywords: 
  - "CorDebugJITCompilerFlags enumeration [.NET Framework debugging]"
ms.assetid: c0774f70-5bed-45e8-9922-fdad778c4c33
topic_type: 
  - "apiref"
---
# CorDebugJITCompilerFlags Enumeration

Contains values that influence the behavior of the managed just-in-time (JIT) compiler.  
  
## Syntax  
  
```cpp  
typedef enum CorDebugJITCompilerFlags {  
  
    CORDEBUG_JIT_DEFAULT = 0x1,  
    CORDEBUG_JIT_DISABLE_OPTIMIZATION = 0x3,  
    CORDEBUG_JIT_ENABLE_ENC = 0x7  
  
} CorDebugJITCompilerFlags;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`CORDEBUG_JIT_DEFAULT`|Specifies that the compiler should track compilation data, and allows optimizations.|  
|`CORDEBUG_JIT_DISABLE_OPTIMIZATION`|Specifies that the compiler should track compilation data, but disables optimizations.|  
|`CORDEBUG_JIT_ENABLE_ENC`|Specifies that the compiler should track compilation data, disables optimizations, and enables Edit and Continue technologies.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Debugging Enumerations](debugging-enumerations.md)
