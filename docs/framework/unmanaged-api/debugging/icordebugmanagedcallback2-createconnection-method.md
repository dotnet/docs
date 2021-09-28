---
description: "Learn more about: ICorDebugManagedCallback2::CreateConnection Method"
title: "ICorDebugManagedCallback2::CreateConnection Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugManagedCallback2.CreateConnection"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback2::CreateConnection"
helpviewer_keywords: 
  - "CreateConnection method [.NET Framework debugging]"
  - "ICorDebugManagedCallback2::CreateConnection method [.NET Framework debugging]"
ms.assetid: 49e647be-9d63-4250-9d11-704e2a400d1b
topic_type: 
  - "apiref"
---
# ICorDebugManagedCallback2::CreateConnection Method

Notifies the debugger that a new connection has been created.  
  
## Syntax  
  
```cpp  
HRESULT CreateConnection (  
    [in] ICorDebugProcess     *pProcess,  
    [in] CONNID               dwConnectionId,  
    [in] WCHAR                *pConnName  
);  
```  
  
## Parameters  

 `pProcess`  
 [in] A pointer to an "ICorDebugProcess" object that represents the process in which the connection was created  
  
 `dwConnectionId`  
 [in] The ID of the new connection.  
  
 `pConnName`  
 [in] A pointer to the name of the new connection.  
  
## Remarks  

 A `CreateConnection` callback will be fired in either of the following cases:  
  
- When a debugger attaches to a process that contains connections. In this case, the runtime will generate and dispatch a `CreateConnection` event and a [ICorDebugManagedCallback2::ChangeConnection](icordebugmanagedcallback2-changeconnection-method.md) event for each connection in the process.  
  
- When a host calls [ICLRDebugManager::BeginConnection](../hosting/iclrdebugmanager-beginconnection-method.md) in the [Hosting API](../hosting/index.md).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorDebugManagedCallback2 Interface](icordebugmanagedcallback2-interface.md)
- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
