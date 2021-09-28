---
description: "Learn more about: ICorDebugArrayValue::GetRank Method"
title: "ICorDebugArrayValue::GetRank Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugArrayValue.GetRank"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugArrayValue::GetRank"
helpviewer_keywords: 
  - "ICorDebugArrayValue::GetRank method [.NET Framework debugging]"
  - "GetRank method, ICorDebugArrayValue interface [.NET Framework debugging]"
ms.assetid: 5e83c82c-593d-4691-90b0-383d218b415e
topic_type: 
  - "apiref"
---
# ICorDebugArrayValue::GetRank Method

Gets the number of dimensions in the array.  
  
## Syntax  
  
```cpp  
HRESULT GetRank (  
    [out] ULONG32   *pnRank  
);  
```  
  
## Parameters  

 `pnRank`  
 [out] A pointer to the number of dimensions in this `ICorDebugArrayValue` object.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
