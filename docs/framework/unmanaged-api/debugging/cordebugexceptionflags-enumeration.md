---
title: "CorDebugExceptionFlags Enumeration"
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
  - "CorDebugExceptionFlags"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorDebugExceptionFlags"
helpviewer_keywords: 
  - "CorDebugExceptionFlags enumeration [.NET Framework debugging]"
ms.assetid: b22687a8-e9cf-4e65-a1b0-f92a81bc524e
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorDebugExceptionFlags Enumeration
Provides additional information about an exception.  
  
## Syntax  
  
```  
typedef enum CorDebugExceptionFlags {  
    DEBUG_EXCEPTION_NONE = 0,  
    DEBUG_EXCEPTION_CAN_BE_INTERCEPTED = 0x0001  
} CorDebugExceptionFlags;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`DEBUG_EXCEPTION_NONE`|There is no exception.|  
|`DEBUG_EXCEPTION_CAN_BE_INTERCEPTED`|The exception is interceptable.<br /><br /> The timing of the exception may still be such that the debugger cannot intercept it. For example, if there is no managed code below the current callback or the exception event resulted from a just-in-time (JIT) attachment, the exception cannot be intercepted.|  
  
## Remarks  
 New values may be added to this enumeration in later versions, so you should prepare code that uses `CorDebugExceptionFlags` for unexpected values.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)
