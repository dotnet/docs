---
description: "Learn more about: CorDebugNGenPolicy Enumeration"
title: "CorDebugNGenPolicy Enumeration"
ms.date: "03/30/2017"
dev_langs: 
  - "cpp"
api_name: 
  - "CorDebugNGenPolicy"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorDebugNGenPolicy"
helpviewer_keywords: 
  - "CorDebugNgenPolicy enumeration [.NET Framework debugging]"
ms.assetid: edb4e4d2-3166-44d4-8b17-bf302f7ea093
topic_type: 
  - "apiref"
---
# CorDebugNGenPolicy Enumeration

Provides a value that determines whether a debugger loads native (NGen) images from the native image cache.  
  
## Syntax  
  
```cpp
enum CorDebugNGENPolicy {  
    DISABLE_LOCAL_NIC = 1  
} CorDebugNGENPolicy;  
```  
  
## Members  
  
|Member name|Description|  
|-----------------|-----------------|  
|`DISABLE_LOCAL_NIC`|In a Windows 8.x Store app, the use of images from the local native image cache is disabled. In a desktop app, this setting has no effect.|  
  
## Remarks  

 The `CorDebugNGENPolicy` enumeration is used by the [ICorDebugProcess5::EnableNGENPolicy](icordebugprocess5-enablengenpolicy-method.md) method. Disabling the use of images from the local native image cache provides for a consistent debugging experience by ensuring that the debugger loads debuggable JIT-compiled images instead of optimized native images.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [Debugging Enumerations](debugging-enumerations.md)
