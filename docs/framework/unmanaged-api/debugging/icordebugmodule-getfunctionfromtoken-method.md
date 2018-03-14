---
title: "ICorDebugModule::GetFunctionFromToken Method"
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
  - "ICorDebugModule.GetFunctionFromToken"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugModule::GetFunctionFromToken"
helpviewer_keywords: 
  - "GetFunctionFromToken method, ICorDebugModule interface [.NET Framework debugging]"
  - "ICorDebugModule::GetFunctionFromToken method [.NET Framework debugging]"
ms.assetid: 6fe12194-4ef7-43c1-9570-ade35ccf127a
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugModule::GetFunctionFromToken Method
Gets the function that is specified by the metadata token.  
  
## Syntax  
  
```  
HRESULT GetFunctionFromToken(  
    [in] mdMethodDef methodDef,  
    [out] ICorDebugFunction **ppFunction  
);  
```  
  
#### Parameters  
 `methodDef`  
 [in] A `mdMethodDef` metadata token that references the function's metadata.  
  
 `ppFunction`  
 [out] A pointer to the address of a ICorDebugFunction interface object that represents the function.  
  
## Remarks  
 The `GetFunctionFromToken` method returns a CORDBG_E_FUNCTION_NOT_IL HRESULT if the value passed in `methodDef` does not refer to a Microsoft intermediate language (MSIL) method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
