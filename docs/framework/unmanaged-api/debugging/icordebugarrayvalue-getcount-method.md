---
description: "Learn more about: ICorDebugArrayValue::GetCount Method"
title: "ICorDebugArrayValue::GetCount Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugArrayValue.GetCount"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugArrayValue::GetCount"
helpviewer_keywords: 
  - "ICorDebugArrayValue::GetCount method [.NET Framework debugging]"
  - "GetCount method, ICorDebugArrayValue interface [.NET Framework debugging]"
ms.assetid: 44cd98cf-2127-4d46-8c6a-da4e857bb6b0
topic_type: 
  - "apiref"
---
# ICorDebugArrayValue::GetCount Method

Gets the total number of elements in the array.  
  
## Syntax  
  
```cpp  
HRESULT GetCount (  
    [out] ULONG32 *pnCount  
);  
```  
  
## Parameters  

 `pnCount`  
 [out] A pointer to the total number of elements in the array.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
