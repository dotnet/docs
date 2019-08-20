---
title: "ICorDebugManagedCallback::LoadAssembly Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugManagedCallback.LoadAssembly"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::LoadAssembly"
helpviewer_keywords: 
  - "LoadAssembly method [.NET Framework debugging]"
  - "ICorDebugManagedCallback::LoadAssembly method [.NET Framework debugging]"
ms.assetid: 55cb673a-e240-43a6-a406-6912e7c0fe66
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugManagedCallback::LoadAssembly Method
Notifies the debugger that a common language runtime (CLR) assembly has been successfully loaded.  
  
## Syntax  
  
```cpp  
HRESULT LoadAssembly (  
    [in] ICorDebugAppDomain *pAppDomain,  
    [in] ICorDebugAssembly  *pAssembly  
);  
```  
  
## Parameters  
 `pAppDomain`  
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain into which the assembly has been loaded.  
  
 `pAssembly`  
 [in] A pointer to an ICorDebugAssembly object that represents the assembly.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [UnloadAssembly Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-unloadassembly-method.md)
- [ICorDebugManagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-interface.md)
