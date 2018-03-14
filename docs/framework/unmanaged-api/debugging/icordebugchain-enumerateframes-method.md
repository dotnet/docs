---
title: "ICorDebugChain::EnumerateFrames Method"
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
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugChain::EnumerateFrames Method
Gets an enumerator that contains all the managed stack frames in the chain, starting with the most recent frame.  
  
## Syntax  
  
```  
HRESULT EnumerateFrames (  
    [out] ICorDebugFrameEnum **ppFrames  
);  
```  
  
#### Parameters  
 `ppFrames`  
 [out] A pointer to the address of an ICorDebugFrameEnum object that is the enumerator for the stack frames.  
  
## Remarks  
 The chain represents the physical call stack for the thread.  
  
 The `EnumerateFrames` method should be called only for managed chains. The debugging API does not provide methods for obtaining frames contained in unmanaged chains. The debugger must use other means to obtain this information.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
