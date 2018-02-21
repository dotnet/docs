---
title: "ICorDebugFrame::GetCaller Method"
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
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugFrame::GetCaller Method
Gets a pointer to the ICorDebugFrame object in the current chain that called this frame.  
  
## Syntax  
  
```  
HRESULT GetCaller (  
    [out] ICorDebugFrame     **ppFrame  
);  
```  
  
#### Parameters  
 `ppFrame`  
 [out] A pointer to the address of an `ICorDebugFrame` object that represents the calling frame. This value is null if the called frame is the outermost frame in the current chain.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
