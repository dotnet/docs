---
title: "ICorDebugThread::GetActiveChain Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugThread.GetActiveChain"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread::GetActiveChain"
helpviewer_keywords: 
  - "ICorDebugThread::GetActiveChain method [.NET Framework debugging]"
  - "GetActiveChain method [.NET Framework debugging]"
ms.assetid: f50de1f7-40ef-4949-b542-1d9a61f7bfef
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugThread::GetActiveChain Method
Gets an interface pointer to the active (most recent) stack chain on this ICorDebugThread object.  
  
## Syntax  
  
```  
HRESULT GetActiveChain (  
    [out] ICorDebugChain **ppChain  
);  
```  
  
## Parameters  
 `ppChain`  
 [out] A pointer to the address of an ICorDebugChain object that represents the stack chain.  
  
## Remarks  
 The `ppChain` parameter is null if no stack chain is currently active.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
