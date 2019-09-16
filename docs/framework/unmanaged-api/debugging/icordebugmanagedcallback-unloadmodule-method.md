---
title: "ICorDebugManagedCallback::UnloadModule Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugManagedCallback.UnloadModule"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::UnloadModule"
helpviewer_keywords: 
  - "ICorDebugManagedCallback::UnloadModule method [.NET Framework debugging]"
  - "UnloadModule method [.NET Framework debugging]"
ms.assetid: b12bfcd9-1e29-48bf-9a3d-44bfae5df5e8
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugManagedCallback::UnloadModule Method
Notifies the debugger that a common language runtime module (DLL) has been unloaded.  
  
## Syntax  
  
```cpp  
HRESULT UnloadModule (  
    [in] ICorDebugAppDomain  *pAppDomain,  
    [in] ICorDebugModule     *pModule  
);  
```  
  
## Parameters  
 `pAppDomain`  
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain that contained the module.  
  
 `pModule`  
 [in] A pointer to an ICorDebugModule object that represents the module.  
  
## Remarks  
 The module should not be used after this call.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [LoadModule Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-loadmodule-method.md)
- [ICorDebugManagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-interface.md)
