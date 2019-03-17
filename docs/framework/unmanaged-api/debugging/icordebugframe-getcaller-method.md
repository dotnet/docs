---
title: "ICorDebugFrame::GetCaller Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugFrame.GetCaller"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFrame::GetCaller"
helpviewer_keywords: 
  - "GetCaller method, ICorDebugFrame interface [.NET Framework debugging]"
  - "ICorDebugFrame::GetCaller method [.NET Framework debugging]"
ms.assetid: bfdc946b-8238-4eb9-8a85-884049fb0fd4
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugFrame::GetCaller Method
Gets a pointer to the ICorDebugFrame object in the current chain that called this frame.  
  
## Syntax  
  
```  
HRESULT GetCaller (  
    [out] ICorDebugFrame     **ppFrame  
);  
```  
  
## Parameters  
 `ppFrame`  
 [out] A pointer to the address of an `ICorDebugFrame` object that represents the calling frame. This value is null if the called frame is the outermost frame in the current chain.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
