---
description: "Learn more about: ICorDebugThread::GetDebugState Method"
title: "ICorDebugThread::GetDebugState Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugThread.GetDebugState"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread::GetDebugState"
helpviewer_keywords: 
  - "GetDebugState method [.NET Framework debugging]"
  - "ICorDebugThread::GetDebugState method [.NET Framework debugging]"
ms.assetid: 9be27b0c-1d99-4722-b0d4-40cf6753ce5c
topic_type: 
  - "apiref"
---
# ICorDebugThread::GetDebugState Method

Gets the current debug state of this ICorDebugThread object.  
  
## Syntax  
  
```cpp  
HRESULT GetDebugState (  
    [out] CorDebugThreadState   *pState  
);  
```  
  
## Parameters  

 `pState`  
 [out] A pointer to a bitwise combination of CorDebugThreadState enumeration values that describes the current debug state of this thread.  
  
## Remarks  

 If the process is currently stopped, `pState` represents the debug state that would exist for this thread if the process were to be continued, not the actual current state of this thread.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
