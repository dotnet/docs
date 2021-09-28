---
description: "Learn more about: CorDebugDebugEventKind Enumeration"
title: "CorDebugDebugEventKind Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorDebugDebugEventKind"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: 6075a6cd-97e6-4472-a090-0dd14860d1f3
topic_type: 
  - "apiref"
---
# CorDebugDebugEventKind Enumeration

Indicates the type of event whose information is decoded by the [DecodeEvent](icordebugprocess6-decodeevent-method.md) method.  
  
## Syntax  
  
```cpp  
typedef enum CorDebugDebugEventKind {  
    DEBUG_EVENT_KIND_MODULE_LOADED                          = 1,  
    DEBUG_EVENT_KIND_MODULE_UNLOADED                        = 2,  
    DEBUG_EVENT_KIND_MANAGED_EXCEPTION_FIRST_CHANCE         = 3,  
    DEBUG_EVENT_KIND_MANAGED_EXCEPTION_USER_FIRST_CHANCE    = 4,  
    DEBUG_EVENT_KIND_MANAGED_EXCEPTION_CATCH_HANDLER_FOUND  = 5,  
    DEBUG_EVENT_KIND_MANAGED_EXCEPTION_UNHANDLED            = 6  
} CorDebugRecordFormat;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`DEBUG_EVENT_KIND_MODULE_LOADED`|A module load event.|  
|`DEBUG_EVENT_KIND_MODULE_UNLOADED`|A module unload event.|  
|`DEBUG_EVENT_KIND_MANAGED_EXCEPTION_FIRST_CHANCE`|A first-chance exception.|  
|`DEBUG_EVENT_KIND_MANAGED_EXCEPTION_USER_FIRST_CHANCE`|A first-chance user exception.|  
|`DEBUG_EVENT_KIND_MANAGED_EXCEPTION_CATCH_HANDLER_FOUND`|An exception for which a `catch` handler exists.|  
|`DEBUG_EVENT_KIND_MANAGED_EXCEPTION_UNHANDLED`|An unhandled exception.|  
  
## Remarks  

 A member of the `CorDebugDebugEventKind` enumeration is returned by calling the [ICorDebugDebugEvent::GetEventKind](icordebugdebugevent-geteventkind-method.md) method.  
  
> [!NOTE]
> This enumeration is intended for use in .NET Native debugging scenarios only.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [Debugging Enumerations](debugging-enumerations.md)
