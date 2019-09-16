---
title: "ICorDebugFrame::GetCallee Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugFrame.GetCallee"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFrame::GetCallee"
helpviewer_keywords: 
  - "ICorDebugFrame::GetCallee method [.NET Framework debugging]"
  - "GetCallee method, ICorDebugFrame interface [.NET Framework debugging]"
ms.assetid: 92d8136d-0436-4c7e-a6b2-80765f892a0d
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugFrame::GetCallee Method
Gets a pointer to the ICorDebugFrame object in the current chain that this frame called.  
  
## Syntax  
  
```cpp  
HRESULT GetCallee (  
    [out] ICorDebugFrame     **ppFrame  
);  
```  
  
## Parameters  
 `ppFrame`  
 [out] A pointer to the address of an `ICorDebugFrame` object that represents the called frame. This value is null if the calling frame is the innermost frame in the current chain.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
