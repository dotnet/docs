---
title: "ICorDebugThread::GetUserState Method"
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
  - "ICorDebugThread.GetUserState"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread::GetUserState"
helpviewer_keywords: 
  - "GetUserState method, ICorDebugThread interface [.NET Framework debugging]"
  - "ICorDebugThread::GetUserState method [.NET Framework debugging]"
ms.assetid: ae0cfd73-8ead-4d36-9310-dccaac9db0bd
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugThread::GetUserState Method
Gets the current user state of this ICorDebugThread.  
  
## Syntax  
  
```  
HRESULT GetUserState (  
    [out] CorDebugUserState   *pState  
);  
```  
  
#### Parameters  
 `pState`  
 [out] A pointer to a bitwise combination of CorDebugUserState enumeration values that describe the current user state of this thread.  
  
## Remarks  
 The user state of the thread is the state of the thread when it is examined by the program that is being debugged. A thread may have multiple state bits set.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
