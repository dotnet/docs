---
description: "Learn more about: ICorDebugThread::GetProcess Method"
title: "ICorDebugThread::GetProcess Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugThread.GetProcess"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread::GetProcess"
helpviewer_keywords: 
  - "ICorDebugThread::GetProcess method [.NET Framework debugging]"
  - "GetProcess method, ICorDebugThread interface [.NET Framework debugging]"
ms.assetid: 163816e7-0739-4566-b3df-cd256be8b8a4
topic_type: 
  - "apiref"
---
# ICorDebugThread::GetProcess Method

Gets an interface pointer to the process of which this ICorDebugThread forms a part.  
  
## Syntax  
  
```cpp  
HRESULT GetProcess (  
    [out] ICorDebugProcess   **ppProcess  
);  
```  
  
## Parameters  

 `ppProcess`  
 [out] A pointer to the address of an ICorDebugProcess interface object that represents the process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
