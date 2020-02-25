---
title: "ICorDebugAppDomain::GetId Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugAppDomain.GetId"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAppDomain::GetId"
helpviewer_keywords: 
  - "GetId method, ICorDebugAppDomain interface [.NET Framework debugging]"
  - "ICorDebugAppDomain::GetId method [.NET Framework debugging]"
ms.assetid: 32c27576-71fa-42ee-8230-67b92913ea08
topic_type: 
  - "apiref"
---
# ICorDebugAppDomain::GetId Method
Gets the unique identifier of the application domain.  
  
## Syntax  
  
```cpp  
HRESULT GetID (  
    [out] ULONG32   *pId  
);  
```  
  
## Parameters  
 `pId`  
 [out] The unique identifier of the application domain.  
  
## Remarks  
 The identifier for the application domain is unique within the containing process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
