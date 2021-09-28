---
description: "Learn more about: CorDebugExceptionCallbackType Enumeration"
title: "CorDebugExceptionCallbackType Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorDebugExceptionCallbackType"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorDebugExceptionCallbackType"
helpviewer_keywords: 
  - "CorDebugExceptionCallbackType enumeration [.NET Framework debugging]"
ms.assetid: 4d946ad4-3c19-42cb-bec9-8633325ba769
topic_type: 
  - "apiref"
---
# CorDebugExceptionCallbackType Enumeration

Indicates the type of callback that is made from an [ICorDebugManagedCallback2::Exception](icordebugmanagedcallback2-exception-method.md) event.  
  
## Syntax  
  
```cpp  
typedef enum CorDebugExceptionCallbackType {  
    DEBUG_EXCEPTION_FIRST_CHANCE         = 1,  
    DEBUG_EXCEPTION_USER_FIRST_CHANCE    = 2,  
    DEBUG_EXCEPTION_CATCH_HANDLER_FOUND  = 3,  
    DEBUG_EXCEPTION_UNHANDLED            = 4  
} CorDebugExceptionCallbackType;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`DEBUG_EXCEPTION_FIRST_CHANCE`|An exception was thrown.|  
|`DEBUG_EXCEPTION_USER_FIRST_CHANCE`|The exception windup process entered user code.|  
|`DEBUG_EXCEPTION_CATCH_HANDLER_FOUND`|The exception windup process found a `catch` block in user code.|  
|`DEBUG_EXCEPTION_UNHANDLED`|The exception was not handled.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Debugging Enumerations](debugging-enumerations.md)
