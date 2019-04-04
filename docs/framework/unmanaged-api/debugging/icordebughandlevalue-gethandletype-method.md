---
title: "ICorDebugHandleValue::GetHandleType Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugHandleValue.GetHandleType"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugHandleValue::GetHandleType"
helpviewer_keywords: 
  - "GetHandleType method [.NET Framework debugging]"
  - "ICorDebugHandleValue::GetHandleType method [.NET Framework debugging]"
ms.assetid: d5e7b12d-835a-4e86-ae2f-d658d4f1c67c
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugHandleValue::GetHandleType Method
Gets a value that indicates the kind of handle referenced by this ICorDebugHandleValue object.  
  
## Syntax  
  
```  
HRESULT GetHandleType (  
    [out] CorDebugHandleType  *pType  
);  
```  
  
## Parameters  
 `pType`  
 [out] A pointer to a value of the CorDebugHandleType enumeration that indicates the type of this handle.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
