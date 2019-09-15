---
title: "ICorDebugChain::GetCaller Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugChain.GetCaller"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugChain::GetCaller"
helpviewer_keywords: 
  - "ICorDebugChain::GetCaller method [.NET Framework debugging]"
  - "GetCaller method, ICorDebugChain interface [.NET Framework debugging]"
ms.assetid: d0b8ab4b-d7d2-4fa0-945f-3d2b87e7e991
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugChain::GetCaller Method
Gets the chain that called this chain.  
  
## Syntax  
  
```cpp  
HRESULT GetCaller (  
    [out] ICorDebugChain      **ppChain  
);  
```  
  
## Parameters  
 `ppChain`  
 [out] A pointer to the address of an ICorDebugChain object that represents the calling chain.  
  
 If this chain was spontaneously called (as would be the case if this chain or the debugger initialized the call stack), `ppChain` will be null.  
  
## Remarks  
 The calling chain may be on a different thread, if the call was marshaled across threads.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
