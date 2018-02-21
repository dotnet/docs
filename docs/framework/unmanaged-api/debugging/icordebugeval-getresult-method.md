---
title: "ICorDebugEval::GetResult Method"
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
  - "ICorDebugEval.GetResult"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugEval::GetResult"
helpviewer_keywords: 
  - "ICorDebugEval::GetResult method [.NET Framework debugging]"
  - "GetResult method [.NET Framework debugging]"
ms.assetid: 50dbb9af-58a1-41f4-b56d-3da20011884f
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugEval::GetResult Method
Gets the results of this evaluation.  
  
## Syntax  
  
```  
HRESULT GetResult (  
    [out] ICorDebugValue    **ppResult  
);  
```  
  
#### Parameters  
 `ppResult`  
 [out] Pointer to the address of an ICorDebugValue object that represents the results of this evaluation, if the evaluation completes normally.  
  
## Remarks  
 The `GetResult` method is valid only after the evaluation is completed.  
  
 If the evaluation completes normally, `ppResult` specifies the results. If it terminates with an exception, the result is the exception thrown. If the evaluation was for a new object, the result is the reference to the new object.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
