---
title: "ICorDebugManagedCallback::NameChange Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugManagedCallback.NameChange"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::NameChange"
helpviewer_keywords: 
  - "ICorDebugManagedCallback::NameChange method [.NET Framework debugging]"
  - "NameChange method [.NET Framework debugging]"
ms.assetid: a7018a0e-880e-4b68-b52a-1cd22c7aad62
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugManagedCallback::NameChange Method
Notifies the debugger that the name of either an application domain or a thread has changed.  
  
## Syntax  
  
```cpp  
HRESULT NameChange (  
    [in] ICorDebugAppDomain *pAppDomain,  
    [in] ICorDebugThread    *pThread  
);  
```  
  
## Parameters  
 `pAppDomain`  
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain that either had a name change or that contains the thread that had a name change.  
  
 `pThread`  
 [in] A pointer to an ICorDebugThread object that represents the thread that had a name change.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorDebugManagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-interface.md)
