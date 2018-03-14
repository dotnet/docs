---
title: "ICorDebugStackWalk::GetFrame Method"
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
  - "ICorDebugStackWalk.GetFrame Method"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugStackWalk::GetFrame"
helpviewer_keywords: 
  - "GetFrame method [.NET Framework debugging]"
  - "ICorDebugStackWalk::GetFrame method [.NET Framework debugging]"
ms.assetid: 4083b505-5b59-44fb-8c5d-129db6a96c10
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugStackWalk::GetFrame Method
Gets the current frame in the [ICorDebugStackWalk](../../../../docs/framework/unmanaged-api/debugging/icordebugstackwalk-interface.md) object.  
  
## Syntax  
  
```  
HRESULT GetFrame([out] ICorDebugFrame ** pFrame);  
```  
  
#### Parameters  
 `pFrame`  
 [in] A pointer to the address of the created frame object that represents the current frame in the stack.  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The runtime successfully returned the current frame.|  
|E_FAIL|The current frame was not returned.|  
|S_FALSE|The current frame is a native stack frame.|  
|E_INVALIDARG|`pFrame` is null.|  
|CORDBG_E_PAST_END_OF_STACK|The frame pointer is already at the end of the stack; therefore, no additional frames can be accessed.|  
  
## Exceptions  
  
## Remarks  
 `ICorDebugStackWalk` returns only actual stack frames. Use the [ICorDebugThread3::GetActiveInternalFrames](../../../../docs/framework/unmanaged-api/debugging/icordebugthread3-getactiveinternalframes-method.md) method to return internal frames. (Internal frames are data structures pushed onto the stack by the runtime to store temporary data.)  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICorDebugStackWalk Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugstackwalk-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
