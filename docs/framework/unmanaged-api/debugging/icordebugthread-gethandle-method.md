---
title: "ICorDebugThread::GetHandle Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugThread.GetHandle"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread::GetHandle"
helpviewer_keywords: 
  - "GetHandle method, ICorDebugThread interface [.NET Framework debugging]"
  - "ICorDebugThread::GetHandle method [.NET Framework debugging]"
ms.assetid: 172ef8c4-2ead-4cfc-bd2e-dee4fb7191cd
topic_type: 
  - "apiref"
---
# ICorDebugThread::GetHandle Method
Gets the current handle for the active part of this ICorDebugThread.  
  
## Syntax  
  
```cpp  
HRESULT GetHandle (  
    [out] HTHREAD *phThreadHandle  
);  
```  
  
## Parameters  
 `phThreadHandle`  
 [out] A pointer to an HTHREAD that is the handle of the active part of this thread.  
  
## Remarks  
 The handle may change as the process executes, and may be different for different parts of the thread.  
  
 This handle is owned by the debugging API. The debugger should duplicate it before using it.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
