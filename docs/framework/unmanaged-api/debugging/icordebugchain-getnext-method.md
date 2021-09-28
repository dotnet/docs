---
description: "Learn more about: ICorDebugChain::GetNext Method"
title: "ICorDebugChain::GetNext Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugChain.GetNext"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugChain::GetNext"
helpviewer_keywords: 
  - "GetNext method [.NET Framework debugging]"
  - "ICorDebugChain::GetNext method [.NET Framework debugging]"
ms.assetid: 8d9744a5-e08b-4ab2-9855-5c22711cc1e6
topic_type: 
  - "apiref"
---
# ICorDebugChain::GetNext Method

Gets the next chain of frames for the thread.  
  
## Syntax  
  
```cpp  
HRESULT GetNext (  
    [out] ICorDebugChain     **ppChain  
);  
```  
  
## Parameters  

 `ppChain`  
 [out] A pointer to the address of an ICorDebugChain object that represents the next chain of frames for the thread. If this chain is the last chain, `ppChain` is null.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
