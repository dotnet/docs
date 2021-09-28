---
description: "Learn more about: ICorDebugManagedCallback::EditAndContinueRemap Method"
title: "ICorDebugManagedCallback::EditAndContinueRemap Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugManagedCallback.EditAndContinueRemap"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::EditAndContinueRemap"
helpviewer_keywords: 
  - "EditAndContinueRemap method [.NET Framework debugging]"
  - "ICorDebugManagedCallback::EditAndContinueRemap method [.NET Framework debugging]"
ms.assetid: 24a8fcce-317e-48ff-aefc-d86123ada935
topic_type: 
  - "apiref"
---
# ICorDebugManagedCallback::EditAndContinueRemap Method

This method has been deprecated. It notifies the debugger that a remap event has been sent to the integrated development environment (IDE).  
  
## Syntax  
  
```cpp  
HRESULT EditAndContinueRemap (  
    [in] ICorDebugAppDomain *pAppDomain,  
    [in] ICorDebugThread *pThread,  
    [in] ICorDebugFunction *pFunction,  
    [in] BOOL fAccurate  
);  
```  
  
## Remarks  

 The `EditAndContinueRemap` method is called when the execution of the code in an old version of an updated function has been attempted. The common language runtime calls the `EditAndContinueRemap` method to send a remap event to the IDE.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
