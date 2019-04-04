---
title: "ICorDebugAppDomain::GetProcess Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugAppDomain.GetProcess"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAppDomain::GetProcess"
helpviewer_keywords: 
  - "GetProcess method, ICorDebugAppDomain interface [.NET Framework debugging]"
  - "ICorDebugAppDomain::GetProcess method [.NET Framework debugging]"
ms.assetid: 9d0b9628-a91c-40d0-b9bc-00b34a396b8f
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugAppDomain::GetProcess Method
Gets the process containing the application domain.  
  
## Syntax  
  
```  
HRESULT GetProcess (  
    [out] ICorDebugProcess   **ppProcess  
);  
```  
  
## Parameters  
 `ppProcess`  
 [out] A pointer to the address of an ICorDebugProcess object that represents the process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
