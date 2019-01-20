---
title: "ICorDebugCode::GetSize Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugCode.GetSize"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugCode::GetSize"
helpviewer_keywords: 
  - "GetSize method, ICorDebugCode interface [.NET Framework debugging]"
  - "ICorDebugCode::GetSize method [.NET Framework debugging]"
ms.assetid: 115bc6de-f5e2-4e8e-bb38-c7cf54045434
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugCode::GetSize Method
Gets the size, in bytes, of the binary code represented by this "ICorDebugCode".  
  
## Syntax  
  
```  
HRESULT GetSize (  
    [out] ULONG32    *pcBytes  
);  
```  
  
#### Parameters  
 `pcBytes`  
 [out] A pointer to the size, in bytes, of the binary code that this `ICorDebugCode` object represents.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
 
