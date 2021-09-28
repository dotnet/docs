---
description: "Learn more about: ICorDebugManagedCallback2::ChangeConnection Method"
title: "ICorDebugManagedCallback2::ChangeConnection Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugManagedCallback2.ChangeConnection"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback2::ChangeConnection"
helpviewer_keywords: 
  - "ICorDebugManagedCallback2::ChangeConnection method [.NET Framework debugging]"
  - "ChangeConnection method [.NET Framework debugging]"
ms.assetid: 7263f9a9-4c0b-4d82-a181-288873fb2b18
topic_type: 
  - "apiref"
---
# ICorDebugManagedCallback2::ChangeConnection Method

Notifies the debugger that the set of tasks associated with the specified connection has changed.  
  
## Syntax  
  
```cpp  
HRESULT ChangeConnection (  
    [in] ICorDebugProcess     *pProcess,  
    [in] CONNID               dwConnectionId  
);  
```  
  
## Parameters  

 `pProcess`  
 [in] A pointer to an "ICorDebugProcess" object that represents the process containing the connection that changed.  
  
 `dwConnectionId`  
 [in] The ID of the connection that changed.  
  
## Remarks  

 A `ChangeConnection` callback will be fired in either of the following cases:  
  
- When a debugger attaches to a process that contains connections. In this case, the runtime will generate and dispatch a [ICorDebugManagedCallback2::CreateConnection](icordebugmanagedcallback2-createconnection-method.md) event and a `ChangeConnection` event for each connection in the process. A `ChangeConnection` event is generated for every existing connection, regardless of whether that connection’s set of tasks has been changed since its creation.  
  
- When a host calls [ICLRDebugManager::SetConnectionTasks](../hosting/iclrdebugmanager-setconnectiontasks-method.md) in the [Hosting API](../hosting/index.md).  
  
 The debugger should scan all threads in the process to pick up the new changes.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorDebugManagedCallback2 Interface](icordebugmanagedcallback2-interface.md)
- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
