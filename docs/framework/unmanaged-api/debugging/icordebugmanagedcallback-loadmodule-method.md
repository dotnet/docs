---
description: "Learn more about: ICorDebugManagedCallback::LoadModule Method"
title: "ICorDebugManagedCallback::LoadModule Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugManagedCallback.LoadModule"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::LoadModule"
helpviewer_keywords: 
  - "ICorDebugManagedCallback::LoadModule method [.NET Framework debugging]"
  - "LoadModule method [.NET Framework debugging]"
ms.assetid: 66ec04e9-87cb-42ce-9720-81522abb5d5a
topic_type: 
  - "apiref"
---
# ICorDebugManagedCallback::LoadModule Method

Notifies the debugger that a common language runtime (CLR) module has been successfully loaded.  
  
## Syntax  
  
```cpp  
HRESULT LoadModule (  
    [in] ICorDebugAppDomain *pAppDomain,  
    [in] ICorDebugModule    *pModule  
);  
```  
  
## Parameters  

 `pAppDomain`  
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain into which the module has been loaded.  
  
 `pModule`  
 [in] A pointer to an ICorDebugModule object that represents the CLR module.  
  
## Remarks  

 The `LoadModule` callback provides an appropriate time to examine metadata for the module, set just-in-time (JIT) compiler flags, or enable or disable class loading callbacks for the module.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [UnloadModule Method](icordebugmanagedcallback-unloadmodule-method.md)
- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
