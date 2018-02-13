---
title: "ICorDebugProcess::GetThreadContext Method"
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
  - "ICorDebugProcess.GetThreadContext"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess::GetThreadContext"
helpviewer_keywords: 
  - "ICorDebugProcess::GetThreadContext method [.NET Framework debugging]"
  - "GetThreadContext method, ICorDebugProcess interface [.NET Framework debugging]"
ms.assetid: 5b132ef1-8d4b-4525-89b3-54123596c194
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugProcess::GetThreadContext Method
Gets the context for the given thread in this process.  
  
## Syntax  
  
```  
HRESULT GetThreadContext(  
    [in] DWORD threadID,  
    [in] ULONG32 contextSize,  
    [in, out, length_is(contextSize), size_is(contextSize)]  
    BYTE context[]);  
```  
  
#### Parameters  
 `threadID`  
 [in] The ID of the thread for which to retrieve the context.  
  
 `contextSize`  
 [in] The size of the `context` array.  
  
 `context`  
 [in, out] An array of bytes that describe the thread's context.  
  
 The context specifies the architecture of the processor on which the thread is executing.  
  
## Remarks  
 The debugger should call this method rather than the Win32 `GetThreadContext` method, because the thread may actually be in a "hijacked" state, in which its context has been temporarily changed. This method should be used only when a thread is in native code. Use [ICorDebugRegisterSet](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset-interface.md) for threads in managed code.  
  
 The data returned is a context structure for the current platform. Just as with the Win32 `GetThreadContext` method, the caller should initialize the `context` parameter before calling this method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
