---
description: "Learn more about: ICorDebugChain::GetStackRange Method"
title: "ICorDebugChain::GetStackRange Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugChain.GetStackRange"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugChain::GetStackRange"
helpviewer_keywords: 
  - "ICorDebugChain::GetStackRange method [.NET Framework debugging]"
  - "GetStackRange method, ICorDebugChain interface [.NET Framework debugging]"
ms.assetid: 554284e7-3f6c-4d40-8da5-1c9317fbd484
topic_type: 
  - "apiref"
---
# ICorDebugChain::GetStackRange Method

Gets the address range of the stack segment for this chain.  
  
## Syntax  
  
```cpp  
HRESULT GetStackRange (  
    [out] CORDB_ADDRESS      *pStart,
    [out] CORDB_ADDRESS      *pEnd  
);  
```  
  
## Parameters  

 `pStart`  
 [out] A pointer to a `CORDB_ADDRESS` value that is the starting address of the stack segment.  
  
 `pEnd`  
 [out] A pointer to a `CORDB_ADDRESS` value that is the ending address of the stack segment.  
  
## Remarks  

 The numeric range is meaningful only for comparison of stack frame locations. You cannot make any assumptions about what is actually stored on the stack.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
