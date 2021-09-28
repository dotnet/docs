---
description: "Learn more about: ICorDebugArrayValue::GetElementType Method"
title: "ICorDebugArrayValue::GetElementType Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugArrayValue.GetElementType"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugArrayValue::GetElementType"
helpviewer_keywords: 
  - "ICorDebugArrayValue::GetElementType method [.NET Framework debugging]"
  - "GetElementType method [.NET Framework debugging]"
ms.assetid: ed71961e-ae9b-4dfc-9554-06637696d697
topic_type: 
  - "apiref"
---
# ICorDebugArrayValue::GetElementType Method

Gets a value that indicates the simple type of the elements in the array.  
  
## Syntax  
  
```cpp  
HRESULT GetElementType (  
    [out] CorElementType  *pType  
);  
```  
  
## Parameters  

 `pType`  
 [out] A pointer to a value of the CorElementType enumeration that indicates the type.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
