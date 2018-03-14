---
title: "ICorDebugProcess::SetThreadContext Method"
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
  - "ICorDebugProcess.SetThreadContext"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess::SetThreadContext"
helpviewer_keywords: 
  - "ICorDebugProcess::SetThreadContext method [.NET Framework debugging]"
  - "SetThreadContext method, ICorDebugProcess interface [.NET Framework debugging]"
ms.assetid: a7b50175-2bf1-40be-8f65-64aec7aa1247
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugProcess::SetThreadContext Method
Sets the context for the given thread in this process.  
  
## Syntax  
  
```  
HRESULT SetThreadContext(  
    [in] DWORD threadID,  
    [in] ULONG32 contextSize,  
    [in, length_is(contextSize), size_is(contextSize)]  
    BYTE context[]);  
```  
  
#### Parameters  
 `threadID`  
 [in] The ID of the thread for which to set the context.  
  
 `contextSize`  
 [in] The size of the `context` array.  
  
 `context`  
 [in] An array of bytes that describe the thread's context.  
  
 The context specifies the architecture of the processor on which the thread is executing.  
  
## Remarks  
 The debugger should call this method rather than the Win32 `SetThreadContext` function, because the thread may actually be in a "hijacked" state, in which its context has been temporarily changed. This method should be used only when a thread is in native code. Use [ICorDebugRegisterSet](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset-interface.md) for threads in managed code. You should never need to modify the context of a thread during an out-of-band (OOB) debug event.  
  
 The data passed must be a context structure for the current platform.  
  
 This method can corrupt the runtime if used improperly.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
