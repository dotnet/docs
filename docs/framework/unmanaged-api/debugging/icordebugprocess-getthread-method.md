---
description: "Learn more about: ICorDebugProcess::GetThread Method"
title: "ICorDebugProcess::GetThread Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugProcess.GetThread"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess::GetThread"
helpviewer_keywords: 
  - "ICorDebugProcess::GetThread method [.NET Framework debugging]"
  - "GetThread method, ICorDebugProcess interface [.NET Framework debugging]"
ms.assetid: a48261ed-700b-41c9-8cb4-18c526546603
topic_type: 
  - "apiref"
---
# ICorDebugProcess::GetThread Method

Gets this process's thread that has the specified operating system (OS) thread ID.  
  
## Syntax  
  
```cpp  
HRESULT GetThread(  
    [in] DWORD dwThreadId,  
    [out] ICorDebugThread **ppThread);  
```  
  
## Parameters  

 `dwThreadId`  
 [in] The OS thread ID of the thread to be retrieved.  
  
 `ppThread`  
 [out] A pointer to the address of an ICorDebugThread object that represents the thread.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
