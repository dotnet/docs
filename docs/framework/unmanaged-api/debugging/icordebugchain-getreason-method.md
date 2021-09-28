---
description: "Learn more about: ICorDebugChain::GetReason Method"
title: "ICorDebugChain::GetReason Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugChain.GetReason"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GetReason"
helpviewer_keywords: 
  - "GetReason method [.NET Framework debugging]"
  - "ICorDebugChain::GetReason method [.NET Framework debugging]"
ms.assetid: 9f9f62b9-113a-4a98-8f9b-b593cef27b03
topic_type: 
  - "apiref"
---
# ICorDebugChain::GetReason Method

Gets the reason for the genesis of this calling chain.  
  
## Syntax  
  
```cpp  
HRESULT GetReason (  
    [out] CorDebugChainReason *pReason  
);  
```  
  
## Parameters  

 `pReason`  
 [out] A pointer to a value (a bitwise combination) of the CorDebugChainReason enumeration that indicates the reason for the genesis of this calling chain.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
