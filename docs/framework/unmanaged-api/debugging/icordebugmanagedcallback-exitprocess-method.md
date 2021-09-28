---
description: "Learn more about: ICorDebugManagedCallback::ExitProcess Method"
title: "ICorDebugManagedCallback::ExitProcess Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugManagedCallback.ExitProcess"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::ExitProcess"
helpviewer_keywords: 
  - "ExitProcess method, ICorDebugManagedCallback interface [.NET Framework debugging]"
  - "ICorDebugManagedCallback::ExitProcess method [.NET Framework debugging]"
ms.assetid: 63a7d47a-0d54-4e29-9767-9f09feaa38b7
topic_type: 
  - "apiref"
---
# ICorDebugManagedCallback::ExitProcess Method

Notifies the debugger that a process has exited.  
  
## Syntax  
  
```cpp  
HRESULT ExitProcess (  
    [in] ICorDebugProcess *pProcess  
);  
```  
  
## Parameters  

 `pProcess`  
 [in] A pointer to an ICorDebugProcess object that represents the process.  
  
## Remarks  

 You cannot continue from an `ExitProcess` event. This event may fire asynchronously to other events while the process appears to be stopped. This can occur if the process terminates while stopped, usually due to some external force.  
  
 If the common language runtime (CLR) is already dispatching a managed callback, this event will be delayed until after that callback has returned.  
  
 The `ExitProcess` event is the only exit/unload event that is guaranteed to get called on shutdown.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
