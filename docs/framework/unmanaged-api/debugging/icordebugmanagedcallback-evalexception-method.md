---
title: "ICorDebugManagedCallback::EvalException Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugManagedCallback.EvalException"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::EvalException"
helpviewer_keywords: 
  - "EvalException method [.NET Framework debugging]"
  - "ICorDebugManagedCallback::EvalException method [.NET Framework debugging]"
ms.assetid: d6036345-18a3-45c1-a302-b1c6f2dced9b
topic_type: 
  - "apiref"
---
# ICorDebugManagedCallback::EvalException Method
Notifies the debugger that an evaluation has terminated with an unhandled exception.  
  
## Syntax  
  
```cpp  
HRESULT EvalException (  
    [in] ICorDebugAppDomain *pAppDomain,  
    [in] ICorDebugThread    *pThread,  
    [in] ICorDebugEval      *pEval  
);  
```  
  
## Parameters  
 `pAppDomain`  
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain in which the evaluation terminated.  
  
 `pThread`  
 [in] A pointer to an ICorDebugThread object that represents the thread in which the evaluation terminated.  
  
 `pEval`  
 [in] A pointer to an ICorDebugEval object that represents the code that performed the evaluation.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorDebugManagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-interface.md)
