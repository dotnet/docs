---
description: "Learn more about: ICorDebugManagedCallback::UnloadClass Method"
title: "ICorDebugManagedCallback::UnloadClass Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugManagedCallback.UnloadClass"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::UnloadClass"
helpviewer_keywords: 
  - "ICorDebugManagedCallback::UnloadClass method [.NET Framework debugging]"
  - "UnloadClass method [.NET Framework debugging]"
ms.assetid: 66a59b18-ce9a-41f4-b23b-4dd6753d6d36
topic_type: 
  - "apiref"
---
# ICorDebugManagedCallback::UnloadClass Method

Notifies the debugger that a class is being unloaded.  
  
## Syntax  
  
```cpp  
HRESULT UnloadClass (  
    [in] ICorDebugAppDomain  *pAppDomain,  
    [in] ICorDebugClass      *c  
);  
```  
  
## Parameters  

 `pAppDomain`  
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain containing the class.  
  
 `c`  
 [in] A pointer to an ICorDebugClass object that represents the class.  
  
## Remarks  

 The class should not be referenced after this call.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [LoadClass Method](icordebugmanagedcallback-loadclass-method.md)
- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
