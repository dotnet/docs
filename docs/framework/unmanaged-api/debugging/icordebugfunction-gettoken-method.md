---
description: "Learn more about: ICorDebugFunction::GetToken Method"
title: "ICorDebugFunction::GetToken Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugFunction.GetToken"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFunction::GetToken"
helpviewer_keywords: 
  - "ICorDebugFunction::GetToken method [.NET Framework debugging]"
  - "GetToken method, ICorDebugFunction interface [.NET Framework debugging]"
ms.assetid: c6bbf479-062e-48e9-9c70-0f92e293e36a
topic_type: 
  - "apiref"
---
# ICorDebugFunction::GetToken Method

Gets the metadata token for this function.  
  
## Syntax  
  
```cpp  
HRESULT GetToken (  
    [out] mdMethodDef *pMethodDef  
);  
```  
  
## Parameters  

 `pMethodDef`  
 [out] A pointer to an `mdMethodDef` token that references the metadata for this function.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
