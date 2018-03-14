---
title: "ICorDebugThread::GetCurrentException Method"
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
  - "ICorDebugThread.GetCurrentException"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread::GetCurrentException"
helpviewer_keywords: 
  - "ICorDebugThread::GetCurrentException method [.NET Framework debugging]"
  - "GetCurrentException method [.NET Framework debugging]"
ms.assetid: 331ed465-a195-4359-8584-b82c6098b29b
topic_type: 
  - "apiref"
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugThread::GetCurrentException Method
Gets an interface pointer to an ICorDebugValue object that represents an exception that is currently being thrown by managed code.  
  
## Syntax  
  
```  
HRESULT GetCurrentException (  
    [out] ICorDebugValue **ppExceptionObject  
);  
```  
  
#### Parameters  
 `ppExceptionObject`  
 [out] A pointer to the address of an `ICorDebugValue` object that represents the exception that is currently being thrown by managed code.  
  
## Remarks  
 The exception object will exist from the time the exception is thrown until the end of the `catch` block. A function evaluation, which is performed by the ICorDebugEval methods, will clear out the exception object on setup and restore it on completion.  
  
 Exceptions can be nested (for example, if an exception is thrown in a filter or in a function evaluation), so there may be multiple outstanding exceptions on a single thread. `GetCurrentException` returns the most current exception.  
  
 The exception object and type may change throughout the life of the exception. For example, after an exception of type x is thrown, the common language runtime (CLR) may run out of memory and promote it to an out-of-memory exception.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
