---
title: "ICorDebugClass::GetModule Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugClass.GetModule"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugClass::GetModule"
helpviewer_keywords: 
  - "GetModule method, ICorDebugClass interface [.NET Framework debugging]"
  - "ICorDebugClass::GetModule method [.NET Framework debugging]"
ms.assetid: 87029cc4-e5e1-42d5-8b98-655bb7ece520
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugClass::GetModule Method
Gets the module that defines this class.  
  
## Syntax  
  
```cpp  
HRESULT GetModule (  
    [out] ICorDebugModule    **pModule  
);  
```  
  
## Parameters  
 `pModule`  
 [out] A pointer to the address of an ICorDebugModule object that represents the module in which this class is defined.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
