---
description: "Learn more about: ICorDebugThread::CreateStepper Method"
title: "ICorDebugThread::CreateStepper Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugThread.CreateStepper"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread::CreateStepper"
helpviewer_keywords: 
  - "ICorDebugThread::CreateStepper method [.NET Framework debugging]"
  - "CreateStepper method, ICorDebugThread interface [.NET Framework debugging]"
ms.assetid: 4657443f-dd12-431b-a648-175c23f13c83
topic_type: 
  - "apiref"
---
# ICorDebugThread::CreateStepper Method

Creates an ICorDebugStepper object that allows stepping through the active frame of this ICorDebugThread.  
  
## Syntax  
  
```cpp  
HRESULT CreateStepper (  
    [out] ICorDebugStepper **ppStepper  
);  
```  
  
## Parameters  

 `ppStepper`  
 [out] A pointer to the address of an `ICorDebugStepper` object that allows stepping through the active frame of this thread.  
  
## Remarks  

 The active frame may be unmanaged code.  
  
 The `ICorDebugStepper` interface must be used to perform the actual stepping.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
