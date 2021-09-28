---
description: "Learn more about: ICorDebugManagedCallback::EvalComplete Method"
title: "ICorDebugManagedCallback::EvalComplete Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugManagedCallback.EvalComplete"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::EvalComplete"
helpviewer_keywords: 
  - "ICorDebugManagedCallback::EvalComplete method [.NET Framework debugging]"
  - "EvalComplete method [.NET Framework debugging]"
ms.assetid: f74ab4eb-cd1b-407c-a66d-8ec0d85647f3
topic_type: 
  - "apiref"
---
# ICorDebugManagedCallback::EvalComplete Method

Notifies the debugger that an evaluation has been completed.  
  
## Syntax  
  
```cpp  
HRESULT EvalComplete (  
    [in] ICorDebugAppDomain *pAppDomain,  
    [in] ICorDebugThread    *pThread,  
    [in] ICorDebugEval      *pEval  
);  
```  
  
## Parameters  

 `pAppDomain`  
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain in which the evaluation was performed.  
  
 `pThread`  
 [in] A pointer to an ICorDebugThread object that represents the thread in which the evaluation was performed.  
  
 `pEval`  
 [in] A pointer to an ICorDebugEval object that represents the code that performed the evaluation.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
