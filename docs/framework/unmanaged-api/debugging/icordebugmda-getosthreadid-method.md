---
title: "ICorDebugMDA::GetOSThreadId Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugMDA.GetOSThreadId"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugMDA::GetOSThreadId"
helpviewer_keywords: 
  - "ICorDebugMDA::GetOSThreadId method [.NET Framework debugging]"
  - "GetOSThreadId method [.NET Framework debugging]"
ms.assetid: 7ca7c364-ade4-4219-b434-9f6ae2359be6
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugMDA::GetOSThreadId Method
Gets the operating system (OS) thread identifier upon which the managed debugging assistant (MDA) represented by [ICorDebugMDA](../../../../docs/framework/unmanaged-api/debugging/icordebugmda-interface.md) is executing.  
  
## Syntax  
  
```cpp  
HRESULT GetOSThreadId (  
    [out] DWORD    *pOsTid  
);  
```  
  
## Parameters  
 `pOsTid`  
 [out] A pointer to the OS thread identifier.  
  
## Remarks  
 The OS thread is used instead of an ICorDebugThread to allow for situations in which an MDA is fired either on a native thread or on a managed thread that has not yet entered managed code.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorDebugMDA Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmda-interface.md)
- [Diagnosing Errors with Managed Debugging Assistants](../../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
