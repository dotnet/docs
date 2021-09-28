---
description: "Learn more about: ICorDebugController::EnumerateThreads Method"
title: "ICorDebugController::EnumerateThreads Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugController.EnumerateThreads"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugController::EnumerateThreads"
helpviewer_keywords: 
  - "ICorDebugController::EnumerateThreads method [.NET Framework debugging]"
  - "EnumerateThreads method [.NET Framework debugging]"
ms.assetid: 73f536f6-4668-4a4a-b3e4-ac7df862d5be
topic_type: 
  - "apiref"
---
# ICorDebugController::EnumerateThreads Method

Gets an enumerator for the active managed threads in the process.  
  
## Syntax  
  
```cpp  
HRESULT EnumerateThreads (  
    [out] ICorDebugThreadEnum **ppThreads  
);  
```  
  
## Parameters  

 `ppThreads`  
 [out] A pointer to the address of an "ICorDebugThreadEnum" object that represents an enumerator for all managed threads that are active in the process.  
  
## Remarks  

 A thread is considered active after the [ICorDebugManagedCallback::CreateThread](icordebugmanagedcallback-createthread-method.md) callback has been dispatched and before the [ICorDebugManagedCallback::ExitThread](icordebugmanagedcallback-exitthread-method.md) callback has been dispatched. A managed thread may not necessarily have any managed frames on its stack. Threads can be enumerated even before the [ICorDebugManagedCallback::CreateProcess](icordebugmanagedcallback-createprocess-method.md) callback. The enumeration will naturally be empty.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
