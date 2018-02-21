---
title: "ICorDebugFunction::GetLocalVarSigToken Method"
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
  - "ICorDebugFunction.GetLocalVarSigToken"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFunction::GetLocalVarSigToken"
helpviewer_keywords: 
  - "ICorDebugFunction::GetLocalVarSigToken method [.NET Framework debugging]"
  - "GetLocalVarSigToken method [.NET Framework debugging]"
ms.assetid: 31e53494-bcc9-4981-91a4-f7e0f02cad48
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugFunction::GetLocalVarSigToken Method
Gets the metadata token for the local variable signature of the function that is represented by this ICorDebugFunction instance.  
  
## Syntax  
  
```  
HRESULT GetLocalVarSigToken (  
    [out] mdSignature *pmdSig  
);  
```  
  
#### Parameters  
 `pmdSig`  
 [out] A pointer to the `mdSignature` token for the local variable signature of this function, or `mdSignatureNil`, if this function has no local variables.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
