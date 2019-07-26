---
title: "ICorDebugManagedCallback::ExitAppDomain Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugManagedCallback.ExitAppDomain"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::ExitAppDomain"
helpviewer_keywords: 
  - "ICorDebugManagedCallback::ExitAppDomain method [.NET Framework debugging]"
  - "ExitAppDomain method [.NET Framework debugging]"
ms.assetid: d815486e-b3bd-4fe8-ba28-02abdb4d67ba
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugManagedCallback::ExitAppDomain Method
Notifies the debugger that an application domain has exited.  
  
## Syntax  
  
```cpp  
HRESULT ExitAppDomain (  
    [in] ICorDebugProcess   *pProcess,  
    [in] ICorDebugAppDomain *pAppDomain  
);  
```  
  
## Parameters  
 `pProcess`  
 [in] A pointer to an ICorDebugProcess object that represents the process that contains the given application domain.  
  
 `pAppDomain`  
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain that has exited.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorDebugManagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-interface.md)
