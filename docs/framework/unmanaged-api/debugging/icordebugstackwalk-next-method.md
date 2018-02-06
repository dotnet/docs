---
title: "ICorDebugStackWalk::Next Method"
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
  - "ICorDebugStackWalk.Next Method"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugStackWalk::Next"
helpviewer_keywords: 
  - "ICorDebugStackWalk::Next method [.NET Framework debugging]"
  - "Next method, ICorDebugStackWalk interface [.NET Framework debugging]"
ms.assetid: 189c36be-028c-4fba-a002-5edfb8fcd07f
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugStackWalk::Next Method
Moves the [ICorDebugStackWalk](../../../../docs/framework/unmanaged-api/debugging/icordebugstackwalk-interface.md) object to the next frame.  
  
## Syntax  
  
```  
HRESULT Next();  
```  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The runtime successfully unwound to the next frame (see Remarks).|  
|E_FAIL|The `ICorDebugStackWalk` object could not be advanced.|  
|CORDBG_S_AT_END_OF_STACK|The end of the stack was reached as a result of this unwind.|  
|CORDBG_E_PAST_END_OF_STACK|The frame pointer is already at the end of the stack; therefore, no additional frames can be accessed.|  
  
## Exceptions  
  
## Remarks  
 The `Next` method advances the `ICorDebugStackWalk` object to the calling frame only if the runtime can unwind the current frame. Otherwise, the object advances to the next frame that the runtime is able to unwind.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICorDebugStackWalk Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugstackwalk-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
