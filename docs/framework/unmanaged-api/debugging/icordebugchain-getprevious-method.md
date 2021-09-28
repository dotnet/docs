---
description: "Learn more about: ICorDebugChain::GetPrevious Method"
title: "ICorDebugChain::GetPrevious Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugChain.GetPrevious"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugChain::GetPrevious"
helpviewer_keywords: 
  - "ICorDebugChain::GetPrevious method [.NET Framework debugging]"
  - "GetPrevious method [.NET Framework debugging]"
ms.assetid: 58eed4c8-d80c-4c6a-a875-967a90dd926c
topic_type: 
  - "apiref"
---
# ICorDebugChain::GetPrevious Method

Gets the previous chain of frames for the thread.  
  
## Syntax  
  
```cpp  
HRESULT GetPrevious (  
    [out] ICorDebugChain     **ppChain  
);  
```  
  
## Parameters  

 `ppChain`  
 [out] A pointer to the address of an ICorDebugChain object that represents the previous chain of frames for this thread. If this chain is the first chain, `ppChain` is null.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
