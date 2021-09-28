---
description: "Learn more about: ICorDebugReferenceValue::GetValue Method"
title: "ICorDebugReferenceValue::GetValue Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugReferenceValue.GetValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugReferenceValue::GetValue"
helpviewer_keywords: 
  - "GetValue method, ICorDebugReferenceValue interface [.NET Framework debugging]"
  - "ICorDebugReferenceValue::GetValue method [.NET Framework debugging]"
ms.assetid: 5da07f99-6c70-46ec-b997-5ab6fb7106cd
topic_type: 
  - "apiref"
---
# ICorDebugReferenceValue::GetValue Method

Gets the current memory address of the referenced object.  
  
## Syntax  
  
```cpp  
HRESULT GetValue (  
    [out] CORDB_ADDRESS   *pValue  
);  
```  
  
## Parameters  

 `pValue`  
 [out] A pointer to a `CORDB_ADDRESS` value that specifies the address of the object to which this ICorDebugReferenceValue object points.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
