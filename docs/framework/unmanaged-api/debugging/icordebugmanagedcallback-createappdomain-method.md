---
title: "ICorDebugManagedCallback::CreateAppDomain Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugManagedCallback.CreateAppDomain"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::CreateAppDomain"
helpviewer_keywords: 
  - "CreateAppDomain method [.NET Framework debugging]"
  - "ICorDebugManagedCallback::CreateAppDomain method [.NET Framework debugging]"
ms.assetid: 48d410d7-6749-4125-a8fd-f9562c7088e9
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugManagedCallback::CreateAppDomain Method
Notifies the debugger that an application domain has been created.  
  
## Syntax  
  
```cpp  
HRESULT CreateAppDomain (  
    [in] ICorDebugProcess   *pProcess,  
    [in] ICorDebugAppDomain *pAppDomain  
);  
```  
  
## Parameters  
 `pProcess`  
 [in] A pointer to an ICorDebugProcess object that represents the process in which the application domain was created.  
  
 `pAppDomain`  
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain that has been created.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorDebugManagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-interface.md)
