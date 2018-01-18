---
title: "ICorDebugManagedCallback::BreakpointSetError Method"
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
  - "ICorDebugManagedCallback.BreakpointSetError"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::BreakpointSetError"
helpviewer_keywords: 
  - "BreakpointSetError method [.NET Framework debugging]"
  - "ICorDebugManagedCallback::BreakpointSetError method [.NET Framework debugging]"
ms.assetid: f2b773a4-c4d0-429c-9717-51d6e2ed86af
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugManagedCallback::BreakpointSetError Method
Notifies the debugger that the common language runtime was unable to accurately bind a breakpoint that was set before a function was just-in-time (JIT) compiled.  
  
## Syntax  
  
```  
HRESULT BreakpointSetError (  
    [in] ICorDebugAppDomain  *pAppDomain,  
    [in] ICorDebugThread     *pThread,  
    [in] ICorDebugBreakpoint *pBreakpoint,  
    [in] DWORD                dwError  
);  
```  
  
#### Parameters  
 `pAppDomain`  
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain that contains the unbound breakpoint.  
  
 `pThread`  
 [in] A pointer to an ICorDebugThread object that represents the thread that contains the unbound breakpoint.  
  
 `pBreakpoint`  
 [in] A pointer to an ICorDebugBreakpoint object that represents the unbound breakpoint.  
  
 `dwError`  
 [in] An integer that indicates the error.  
  
## Remarks  
 The given breakpoint will never be hit. The debugger should deactivate and rebind it.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorDebugManagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-interface.md)
