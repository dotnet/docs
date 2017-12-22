---
title: "ICorDebugThread::GetActiveFrame Method"
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
  - "ICorDebugThread.GetActiveFrame"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread::GetActiveFrame"
helpviewer_keywords: 
  - "ICorDebugThread::GetActiveFrame method [.NET Framework debugging]"
  - "GetActiveFrame method, ICorDebugThread interface [.NET Framework debugging]"
ms.assetid: 8d6d3a1a-fef6-4f2f-a22c-3bdd30d70e07
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugThread::GetActiveFrame Method
Gets an interface pointer to the active (most recent) frame on this ICorDebugThread object.  
  
## Syntax  
  
```  
HRESULT GetActiveFrame (  
    [out] ICorDebugFrame   **ppFrame  
);  
```  
  
#### Parameters  
 `ppFrame`  
 [out] A pointer to the address of an ICorDebugFrame interface object that represents a frame.  
  
## Remarks  
 The `ppFrame` parameter is null if no frame is currently active.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
