---
title: "ICorDebugManagedCallback::Breakpoint Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugManagedCallback.Breakpoint"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::Breakpoint"
helpviewer_keywords: 
  - "ICorDebugManagedCallback::Breakpoint method [.NET Framework debugging]"
  - "Breakpoint method [.NET Framework debugging]"
ms.assetid: 60b279b0-a726-46d2-8c53-76986a007ebb
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugManagedCallback::Breakpoint Method
Notifies the debugger when a breakpoint is encountered.  
  
## Syntax  
  
```  
HRESULT Breakpoint (  
    [in] ICorDebugAppDomain  *pAppDomain,  
    [in] ICorDebugThread     *pThread,  
    [in] ICorDebugBreakpoint *pBreakpoint  
);  
```  
  
## Parameters  
 `pAppDomain`  
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain that contains the breakpoint.  
  
 `pThread`  
 [in] A pointer to an ICorDebugThread object that represents the thread that contains the breakpoint.  
  
 `pBreakpoint`  
 [in] A pointer to an ICorDebugBreakpoint object that represents the breakpoint.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorDebugManagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-interface.md)
