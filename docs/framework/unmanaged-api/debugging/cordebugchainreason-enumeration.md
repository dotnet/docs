---
title: "CorDebugChainReason Enumeration"
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
  - "CorDebugChainReason"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorDebugChainReason"
helpviewer_keywords: 
  - "CorDebugChainReason enumeration [.NET Framework debugging]"
ms.assetid: c915da51-50b2-41df-841a-2b971f4d0975
topic_type: 
  - "apiref"
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorDebugChainReason Enumeration
Indicates the reason or reasons for the initiation of a call chain.  
  
## Syntax  
  
```  
typedef enum CorDebugChainReason {  
    CHAIN_NONE              = 0x000,  
    CHAIN_CLASS_INIT        = 0x001,  
    CHAIN_EXCEPTION_FILTER  = 0x002,  
    CHAIN_SECURITY          = 0x004,  
    CHAIN_CONTEXT_POLICY    = 0x008,  
    CHAIN_INTERCEPTION      = 0x010,  
    CHAIN_PROCESS_START     = 0x020,  
    CHAIN_THREAD_START      = 0x040,  
    CHAIN_ENTER_MANAGED     = 0x080,  
    CHAIN_ENTER_UNMANAGED   = 0x100,  
    CHAIN_DEBUGGER_EVAL     = 0x200,  
    CHAIN_CONTEXT_SWITCH    = 0x400,  
    CHAIN_FUNC_EVAL         = 0x800  
} CorDebugChainReason;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`CHAIN_NONE`|No call chain has been initiated.|  
|`CHAIN_CLASS_INIT`|The chain was initiated by a constructor.|  
|`CHAIN_EXCEPTION_FILTER`|The chain was initiated by an exception filter.|  
|`CHAIN_SECURITY`|The chain was initiated by code that enforces security.|  
|`CHAIN_CONTEXT_POLICY`|The chain was initiated by a context policy.|  
|`CHAIN_INTERCEPTION`|Not used.|  
|`CHAIN_PROCESS_START`|Not used.|  
|`CHAIN_THREAD_START`|The chain was initiated by the start of a thread execution.|  
|`CHAIN_ENTER_MANAGED`|The chain was initiated by entry into managed code.|  
|`CHAIN_ENTER_UNMANAGED`|The chain was initiated by entry into unmanaged code.|  
|`CHAIN_DEBUGGER_EVAL`|Not used.|  
|`CHAIN_CONTEXT_SWITCH`|Not used.|  
|`CHAIN_FUNC_EVAL`|The chain was initiated by a function evaluation.|  
  
## Remarks  
 Use the [ICorDebugChain::GetReason](../../../../docs/framework/unmanaged-api/debugging/icordebugchain-getreason-method.md) method to ascertain the reasons for the initiation of a call chain.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)
