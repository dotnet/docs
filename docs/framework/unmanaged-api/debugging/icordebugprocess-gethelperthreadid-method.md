---
title: "ICorDebugProcess::GetHelperThreadID Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ICorDebugProcess.GetHelperThreadID"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess::GetHelperThreadID"
helpviewer_keywords: 
  - "GetHelperThreadID method [.NET Framework debugging]"
  - "ICorDebugProcess::GetHelperThreadID method [.NET Framework debugging]"
ms.assetid: 84e1e605-37c1-49a5-8e12-35db85654622
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugProcess::GetHelperThreadID Method
Gets the operating system (OS) thread ID of the debugger's internal helper thread.  
  
## Syntax  
  
```  
HRESULT GetHelperThreadID (  
    [out] DWORD *pThreadID  
);  
```  
  
#### Parameters  
 `pThreadID`  
 [out] A pointer to the OS thread ID of the debugger's internal helper thread.  
  
## Remarks  
 During managed and unmanaged debugging, it is the debugger's responsibility to ensure that the thread with the specified ID remains running if it hits a breakpoint placed by the debugger. A debugger may also wish to hide this thread from the user. If no helper thread exists in the process yet, the `GetHelperThreadID` method returns zero in *`pThreadID`.  
  
 You cannot cache the thread ID of the helper thread, because it may change over time. You must re-query the thread ID at every stopping event.  
  
 The thread ID of the debugger's helper thread will be correct on every unmanaged [ICorDebugManagedCallback::CreateThread](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-createthread-method.md) event, thus allowing a debugger to determine the thread ID of its helper thread and hide it from the user. A thread that is identified as a helper thread during an unmanaged `ICorDebugManagedCallback::CreateThread` event will never run managed user code.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl. CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
