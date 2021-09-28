---
description: "Learn more about: ICorDebugFrame::GetFunctionToken Method"
title: "ICorDebugFrame::GetFunctionToken Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugFrame.GetFunctionToken"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFrame::GetFunctionToken"
helpviewer_keywords: 
  - "ICorDebugFrame::GetFunctionToken method [.NET Framework debugging]"
  - "GetFunctionToken method [.NET Framework debugging]"
ms.assetid: a46925b3-3bf8-404f-9f30-a86ae41032c1
topic_type: 
  - "apiref"
---
# ICorDebugFrame::GetFunctionToken Method

Gets the metadata token for the function that contains the code associated with this stack frame.  
  
## Syntax  
  
```cpp  
HRESULT GetFunctionToken (  
    [out] mdMethodDef        *pToken  
);  
```  
  
## Parameters  

 `pToken`  
 [out] A pointer to an `mdMethodDef` token that references the metadata for the function.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
