---
title: "ICorDebugFrame::GetFunction Method"
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
  - "ICorDebugFrame.GetFunction"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFrame::GetFunction"
helpviewer_keywords: 
  - "GetFunction method, ICorDebugFrame interface [.NET Framework debugging]"
  - "ICorDebugFrame::GetFunction method [.NET Framework debugging]"
ms.assetid: 879d2311-0ff1-4616-a8b3-959ea5868b2e
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugFrame::GetFunction Method
Gets the function that contains the code associated with this stack frame.  
  
## Syntax  
  
```  
HRESULT GetFunction (  
    [out] ICorDebugFunction  **ppFunction  
);  
```  
  
#### Parameters  
 `ppFunction`  
 [out] A pointer to the address of an ICorDebugFunction object that represents the function containing the code associated with this stack frame.  
  
## Remarks  
 The `GetFunction` method may fail if the frame is not associated with any particular function.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
