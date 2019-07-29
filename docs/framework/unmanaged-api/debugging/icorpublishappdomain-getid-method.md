---
title: "ICorPublishAppDomain::GetID Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorPublishAppDomain.GetID"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorPublishAppDomain::GetID"
helpviewer_keywords: 
  - "GetID method, ICorPublishAppDomain interface [.NET Framework debugging]"
  - "ICorPublishAppDomain::GetID method [.NET Framework debugging]"
ms.assetid: 229437e3-1465-4bd8-8846-9804b2488133
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorPublishAppDomain::GetID Method
Gets the unique identifier for this [ICorPublishAppDomain](../../../../docs/framework/unmanaged-api/debugging/icorpublishappdomain-interface.md).  
  
## Syntax  
  
```cpp  
HRESULT GetID (  
    [out] ULONG32   *puId  
);  
```  
  
## Parameters  
 `puId`  
 [out] A pointer to the identifier of the application domain.  
  
## Remarks  
 The identifier is unique only in the scope of the containing process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorPub.idl, CorPub.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorPublishAppDomain Interface](../../../../docs/framework/unmanaged-api/debugging/icorpublishappdomain-interface.md)
