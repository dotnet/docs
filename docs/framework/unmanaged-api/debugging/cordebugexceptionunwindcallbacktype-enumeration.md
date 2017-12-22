---
title: "CorDebugExceptionUnwindCallbackType Enumeration"
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
  - "CorDebugExceptionUnwindCallbackType"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorDebugExceptionUnwindCallbackType"
helpviewer_keywords: 
  - "CorDebugExceptionUnwindCallbackType enumeration [.NET Framework debugging]"
ms.assetid: 783dce92-8a98-43db-8f78-888d943dd5b2
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorDebugExceptionUnwindCallbackType Enumeration
Indicates the event that is being signaled by the callback during the unwind phase.  
  
## Syntax  
  
```  
typedef enum CorDebugExceptionUnwindCallbackType {  
    DEBUG_EXCEPTION_UNWIND_BEGIN = 1,  
    DEBUG_EXCEPTION_INTERCEPTED  = 2  
} CorDebugExceptionUnwindCallbackType;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`DEBUG_EXCEPTION_UNWIND_BEGIN`|The beginning of the unwind process.|  
|`DEBUG_EXCEPTION_INTERCEPTED`|The exception was intercepted.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)
