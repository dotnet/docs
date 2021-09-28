---
description: "Learn more about: ICorDebugThread2::InterceptCurrentException Method"
title: "ICorDebugThread2::InterceptCurrentException Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugThread2.InterceptCurrentException"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread2::InterceptCurrentException"
helpviewer_keywords: 
  - "InterceptCurrentException method [.NET Framework debugging]"
  - "ICorDebugThread2::InterceptCurrentException method [.NET Framework debugging]"
ms.assetid: 536d2357-1b97-49e0-a10c-c860aed74e6e
topic_type: 
  - "apiref"
---
# ICorDebugThread2::InterceptCurrentException Method

Allows a debugger to intercept the current exception on this thread.  
  
## Syntax  
  
```cpp  
HRESULT InterceptCurrentException (  
    [in] ICorDebugFrame  *pFrame  
);  
```  
  
## Parameters  

 `pFrame`  
 [in] A pointer to an ICorDebugFrame that represents the active stack frame.  
  
## Remarks  

 The `InterceptCurrentException` method can be called between an exception callback ([ICorDebugManagedCallback::Exception](icordebugmanagedcallback-exception-method.md) or [ICorDebugManagedCallback2::Exception](icordebugmanagedcallback2-exception-method.md)) and the associated call to [ICorDebugController::Continue](icordebugcontroller-continue-method.md).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
