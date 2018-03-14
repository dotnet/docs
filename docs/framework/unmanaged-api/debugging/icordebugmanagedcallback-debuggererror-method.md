---
title: "ICorDebugManagedCallback::DebuggerError Method"
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
  - "ICorDebugManagedCallback.DebuggerError"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::DebuggerError"
helpviewer_keywords: 
  - "DebuggerError method [.NET Framework debugging]"
  - "ICorDebugManagedCallback::DebuggerError method [.NET Framework debugging]"
ms.assetid: 9e983d11-eaf3-4741-b936-29ec456384a3
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugManagedCallback::DebuggerError Method
Notifies the debugger that an error has occurred while attempting to handle an event from the common language runtime (CLR).  
  
## Syntax  
  
```  
HRESULT DebuggerError (  
    [in] ICorDebugProcess *pProcess,  
    [in] HRESULT           errorHR,  
    [in] DWORD             errorCode  
);  
```  
  
#### Parameters  
 `pProcess`  
 [in] A pointer to an "ICorDebugProcess" object that represents the process in which the event occurred.  
  
 `errorHR`  
 [in] The HRESULT value that was returned from the event handler.  
  
 `errorCode`  
 [in] An integer that specifies the CLR error.  
  
## Remarks  
 The process may be placed into pass-through mode, depending on the nature of the error.  
  
 The `DebugError` callback indicates that debugging services have been disabled due to an error, so debuggers should make the error message available to the user. [ICorDebugProcess::GetID](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-getid-method.md) will be safe to call, but all other methods, including [ICorDebug::Terminate](../../../../docs/framework/unmanaged-api/debugging/icordebug-terminate-method.md), should not be called. The debugger should use operating-system facilities for terminating processes.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorDebugManagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-interface.md)
