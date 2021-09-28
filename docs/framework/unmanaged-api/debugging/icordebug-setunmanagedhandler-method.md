---
description: "Learn more about: ICorDebug::SetUnmanagedHandler Method"
title: "ICorDebug::SetUnmanagedHandler Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebug.SetUnmanagedHandler"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebug::SetUnmanagerHandler"
helpviewer_keywords: 
  - "SetUnmanagedHandler method [.NET Framework debugging]"
  - "ICorDebug::SetUnmanagedHandler method [.NET Framework debugging]"
ms.assetid: 6b546be4-f86d-4536-8cfc-1d08e5066eb6
topic_type: 
  - "apiref"
---
# ICorDebug::SetUnmanagedHandler Method

Specifies the event handler object for unmanaged events.  
  
## Syntax  
  
```cpp  
HRESULT SetUnmanagedHandler (  
    [in] ICorDebugUnmanagedCallback  *pCallback  
);  
```  
  
## Parameters  

 `pCallback`  
 [in] A pointer to an [ICorDebugUnmanagedCallback](icordebugunmanagedcallback-interface.md) object that represents the event handler for unmanaged events.  
  
## Remarks  

 The event handler object for unmanaged events must be set after a call to [ICorDebug::Initialize](icordebug-initialize-method.md) and before any calls to [ICorDebug::CreateProcess](icordebug-createprocess-method.md) or [ICorDebug::DebugActiveProcess](icordebug-debugactiveprocess-method.md). However, for legacy purposes, you are not required to set the event handler object for unmanaged events until the first native debug event is raised. Specifically, if `ICorDebug::CreateProcess` has set the CREATE_SUSPENDED flag, native debug events cannot be dispatched until the main thread is resumed.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorDebug Interface](icordebug-interface.md)
