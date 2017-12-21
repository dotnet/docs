---
title: "ICorDebugStackWalk::GetContext Method"
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
  - "ICorDebugStackWalk.GetContext Method"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugStackWalk::GetContext"
helpviewer_keywords: 
  - "GetContext method, ICorDebugStackWalk interface [.NET Framework debugging]"
  - "ICorDebugStackWalk::GetContext method [.NET Framework debugging]"
ms.assetid: 081d1c95-152b-4797-8552-18453eb7b14b
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugStackWalk::GetContext Method
Returns the context for the current frame in the [ICorDebugStackWalk](../../../../docs/framework/unmanaged-api/debugging/icordebugstackwalk-interface.md) object.  
  
## Syntax  
  
```  
HRESULT GetContext([in]  ULONG32 contextFlags,  
                   [in]  ULONG32 contextBufSize,  
                   [out] ULONG32* contextSize,  
                   [out, size_is(contextBufSize)] BYTE contextBuf[]);  
```  
  
#### Parameters  
 `contextFlags`  
 [in] Flags that indicate the requested contents of the context buffer (defined in WinNT.h).  
  
 `contextBufSize`  
 [in] The allocated size of the context buffer.  
  
 `contextSize`  
 [out] The actual size of the context. This value must be less than or equal to the size of the context buffer.  
  
 `contextBuf`  
 [out] The context buffer.  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The context for the current frame was successfully returned.|  
|E_FAIL|The context could not be returned.|  
|HRESULT_FROM_WIN32(ERROR_INSUFFICIENT BUFFER)|The context buffer is too small.|  
|CORDBG_E_PAST_END_OF_STACK|The frame pointer is already at the end of the stack; therefore, no additional frames can be accessed.|  
  
## Exceptions  
  
## Remarks  
 Because unwinding restores only a subset of the registers, such as non-volatile registers, the context may not exactly match the register state at the time of the call.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
