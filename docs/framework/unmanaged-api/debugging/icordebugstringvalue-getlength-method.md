---
title: "ICorDebugStringValue::GetLength Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugStringValue.GetLength"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugStringValue::GetLength"
helpviewer_keywords: 
  - "ICorDebugStringValue::GetLength method [.NET Framework debugging]"
  - "GetLength method [.NET Framework debugging]"
ms.assetid: a1ebfc69-46a6-4225-8788-b7cfb2f15e1d
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugStringValue::GetLength Method
Gets the number of characters in the string referenced by this ICorDebugStringValue.  
  
## Syntax  
  
```  
HRESULT GetLength (  
    [out] ULONG32   *pcchString  
);  
```  
  
## Parameters  
 `pcchString`  
 [out] A pointer to a value that specifies the length of the string referenced by this `ICorDebugStringValue` object.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
