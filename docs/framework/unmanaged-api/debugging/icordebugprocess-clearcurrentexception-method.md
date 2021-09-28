---
description: "Learn more about: ICorDebugProcess::ClearCurrentException Method"
title: "ICorDebugProcess::ClearCurrentException Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugProcess.ClearCurrentException"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess::ClearCurrentException"
helpviewer_keywords: 
  - "ClearCurrentException method, ICorDebugProcess interface [.NET Framework debugging]"
  - "ICorDebugProcess::ClearCurrentException method [.NET Framework debugging]"
ms.assetid: 9e02ee1a-e495-4578-bfb5-b946274bede7
topic_type: 
  - "apiref"
---
# ICorDebugProcess::ClearCurrentException Method

Clears the current unmanaged exception on the given thread.  
  
## Syntax  
  
```cpp  
HRESULT ClearCurrentException([in] DWORD threadID);  
```  
  
## Parameters  

 `threadID`  
 [in] The ID of the thread on which the current unmanaged exception will be cleared.  
  
## Remarks  

 Call this method before calling [ICorDebugController::Continue](icordebugcontroller-continue-method.md) when a thread has reported an unmanaged exception that should be ignored by the debuggee. This will clear both the outstanding in-band (IB) and out-of-band (OOB) events on the given thread. All OOB breakpoints and single-step exceptions are automatically cleared.  
  
 Use [ICorDebugThread2::InterceptCurrentException](icordebugthread2-interceptcurrentexception-method.md) to intercept the current managed exception on a thread.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
