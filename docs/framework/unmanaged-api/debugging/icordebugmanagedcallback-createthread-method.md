---
title: "ICorDebugManagedCallback::CreateThread Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugManagedCallback.CreateThread"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::CreateThread method"
helpviewer_keywords: 
  - "ICorDebugManagedCallback::CreateThread method [.NET Framework debugging]"
  - "CreateThread method [.NET Framework debugging]"
ms.assetid: 6b961728-21c4-4e8d-ae81-197458be62f4
topic_type: 
  - "apiref"
---
# ICorDebugManagedCallback::CreateThread Method
Notifies the debugger that a thread has started executing managed code.  
  
## Syntax  
  
```cpp  
HRESULT CreateThread (  
    [in] ICorDebugAppDomain *pAppDomain,  
    [in] ICorDebugThread    *thread  
);  
```  
  
## Parameters  
 `pAppDomain`  
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain that contains the thread.  
  
 `thread`  
 [in] A pointer to an ICorDebugThread object that represents the thread.  
  
## Remarks  
 The thread will be positioned at the first managed code instruction to be executed.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorDebugManagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-interface.md)
