---
title: "ICorDebugCode::GetFunction Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugCode.GetFunction"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugCode::GetFunction"
helpviewer_keywords: 
  - "GetFunction method, ICorDebugCode interface [.NET Framework debugging]"
  - "ICorDebugCode::GetFunction method [.NET Framework debugging]"
ms.assetid: c568b737-fdb2-4816-accd-051f5ab760f1
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugCode::GetFunction Method
Gets the "ICorDebugFunction" associated with this "ICorDebugCode".  
  
## Syntax  
  
```  
HRESULT GetFunction (  
    [out] ICorDebugFunction **ppFunction  
);  
```  
  
#### Parameters  
 `ppFunction`  
 [out] A pointer to the address of the function.  
  
## Remarks  
 `ICorDebugCode` and `ICorDebugFunction` maintain a one-to-one relationship.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
 
