---
title: "ICorDebugFrame::GetChain Method"
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
  - "ICorDebugFrame.GetChain"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFrame::GetChain"
helpviewer_keywords: 
  - "ICorDebugFrame::GetChain method [.NET Framework debugging]"
  - "GetChain method [.NET Framework debugging]"
ms.assetid: e28e51d3-8f73-494f-bcd4-48bac239fbe1
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugFrame::GetChain Method
Gets a pointer to the chain this frame is a part of.  
  
## Syntax  
  
```  
HRESULT GetChain (  
    [out] ICorDebugChain     **ppChain  
);  
```  
  
#### Parameters  
 `ppChain`  
 [out] A pointer to the address of an ICorDebugChain object that represents the chain containing this frame.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
