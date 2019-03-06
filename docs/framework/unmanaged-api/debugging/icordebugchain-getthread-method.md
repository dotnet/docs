---
title: "ICorDebugChain::GetThread Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugChain.GetThread"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugChain::GetThread"
helpviewer_keywords: 
  - "GetThread method, ICorDebugChain interface [.NET Framework debugging]"
  - "ICorDebugChain::GetThread method [.NET Framework debugging]"
ms.assetid: b3390319-6366-418c-ba80-b552ac4dfc1e
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugChain::GetThread Method
Gets the physical thread this call chain is part of.  
  
## Syntax  
  
```  
HRESULT GetThread (  
    [out] ICorDebugThread    **ppThread  
);  
```  
  
## Parameters  
 `ppThread`  
 [out] A pointer to an ICorDebugThread object that represents the physical thread this call chain is part of.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
