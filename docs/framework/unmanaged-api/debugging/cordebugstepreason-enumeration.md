---
title: "CorDebugStepReason Enumeration"
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
  - "CorDebugStepReason"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorDebugStepReason"
helpviewer_keywords: 
  - "CorDebugStepReason enumeration [.NET Framework debugging]"
ms.assetid: fe248069-b33c-48e1-a777-06ac9b239c54
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorDebugStepReason Enumeration
Indicates the outcome of an individual step.  
  
## Syntax  
  
```  
typedef enum CorDebugStepReason {  
    STEP_NORMAL,  
    STEP_RETURN,  
    STEP_CALL,  
    STEP_EXCEPTION_FILTER,  
    STEP_EXCEPTION_HANDLER,  
    STEP_INTERCEPT,  
    STEP_EXIT  
} CorDebugStepReason;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`STEP_NORMAL`|Stepping completed normally, within the same function.|  
|`STEP_RETURN`|Stepping continued normally, after the function returned.|  
|`STEP_CALL`|Stepping continued normally, at the beginning of a newly called function.|  
|`STEP_EXCEPTION_FILTER`|An exception was generated and control was passed to an exception filter.|  
|`STEP_EXCEPTION_HANDLER`|An exception was generated and control was passed to an exception handler.|  
|`STEP_INTERCEPT`|Control was passed to an interceptor.|  
|`STEP_EXIT`|The thread exited before the step was completed.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [StepComplete Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-stepcomplete-method.md)  
 [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)
