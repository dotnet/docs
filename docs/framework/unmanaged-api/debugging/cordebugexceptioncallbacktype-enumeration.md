---
title: "CorDebugExceptionCallbackType Enumeration"
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
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorDebugExceptionCallbackType Enumeration
Indicates the type of callback that is made from an [ICorDebugManagedCallback2::Exception](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback2-exception-method.md) event.  
  
## Syntax  
  
```  
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
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)
