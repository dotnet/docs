---
description: "Learn more about: ICorDebugChain::EnumerateFrames Method"
title: "ICorDebugChain::EnumerateFrames Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugChain.EnumerateFrames"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugChain::EnumerateFrames method"
helpviewer_keywords: 
  - "EnumerateFrames method [.NET Framework debugging]"
  - "ICorDebugChain::EnumerateFrames method [.NET Framework debugging]"
ms.assetid: 9fcefa98-750d-4168-8915-8173a43accf2
topic_type: 
  - "apiref"
---
# ICorDebugChain::EnumerateFrames Method

Gets an enumerator that contains all the managed stack frames in the chain, starting with the most recent frame.  
  
## Syntax  
  
```cpp  
HRESULT EnumerateFrames (  
    [out] ICorDebugFrameEnum **ppFrames  
);  
```  
  
## Parameters  

 `ppFrames`  
 [out] A pointer to the address of an ICorDebugFrameEnum object that is the enumerator for the stack frames.  
  
## Remarks  

 The chain represents the physical call stack for the thread.  
  
 The `EnumerateFrames` method should be called only for managed chains. The debugging API does not provide methods for obtaining frames contained in unmanaged chains. The debugger must use other means to obtain this information.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
