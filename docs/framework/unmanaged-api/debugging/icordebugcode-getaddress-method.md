---
title: "ICorDebugCode::GetAddress Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugCode.GetAddress"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugCode::GetAddress"
helpviewer_keywords: 
  - "GetAddress method, ICorDebugCode interface [.NET Framework debugging]"
  - "ICorDebugCode::GetAddress method [.NET Framework debugging]"
ms.assetid: cc507cb0-df2e-49c2-b32e-0c3271a8df9a
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugCode::GetAddress Method
Gets the relative virtual address (RVA) of the code segment that this "ICorDebugCode" interface represents.  
  
## Syntax  
  
```  
HRESULT GetAddress (  
    [out] CORDB_ADDRESS *pStart  
);  
```  
  
#### Parameters  
 `pStart`  
 [out] A pointer to the RVA of the code segment.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
 
