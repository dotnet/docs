---
title: "CorDebugIntercept Enumeration"
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
  - "CorDebugIntercept"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorDebugIntercept"
helpviewer_keywords: 
  - "CorDebugIntercept enumeration [.NET Framework debugging]"
ms.assetid: 3d5b642e-7ef2-428b-a5ae-509c35ed461a
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorDebugIntercept Enumeration
Indicates the types of code that can be intercepted (that is, stepped into).  
  
## Syntax  
  
```  
typedef enum CorDebugIntercept {  
    INTERCEPT_NONE                = 0x0,  
    INTERCEPT_CLASS_INIT          = 0x01,  
    INTERCEPT_EXCEPTION_FILTER    = 0x02,  
    INTERCEPT_SECURITY            = 0x04,  
    INTERCEPT_CONTEXT_POLICY      = 0x08,  
    INTERCEPT_INTERCEPTION        = 0x10,  
    INTERCEPT_ALL                 = 0xffff  
} CorDebugIntercept;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`INTERCEPT_NONE`|No code can be intercepted.|  
|`INTERCEPT_CLASS_INIT`|A constructor can be intercepted.|  
|`INTERCEPT_EXCEPTION_FILTER`|An exception filter can be intercepted.|  
|`INTERCEPT_SECURITY`|Code that enforces security can be intercepted.|  
|`INTERCEPT_CONTEXT_POLICY`|A context policy can be intercepted.|  
|`INTERCEPT_INTERCEPTION`|Not used.|  
|`INTERCEPT_ALL`|All code can be intercepted.|  
  
## Remarks  
 Use the [ICorDebugStepper::SetInterceptMask](../../../../docs/framework/unmanaged-api/debugging/icordebugstepper-setinterceptmask-method.md) method to establish the types of code that can be intercepted.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)
