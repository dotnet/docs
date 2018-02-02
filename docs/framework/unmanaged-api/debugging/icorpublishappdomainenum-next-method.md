---
title: "ICorPublishAppDomainEnum::Next Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ICorPublishAppDomainEnum.Next"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorPublishAppDomainEnum::Next"
helpviewer_keywords: 
  - "Next method, ICorPublishAppDomainEnum interface [.NET Framework debugging]"
  - "ICorPublishAppDomainEnum::Next method [.NET Framework debugging]"
ms.assetid: ad37cd10-0339-4d08-9b0e-4b3428bb4dc3
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorPublishAppDomainEnum::Next Method
Gets the specified number of application domains that currently exist in the process, starting at the current position.  
  
## Syntax  
  
```  
HRESULT Next (  
    [in] ULONG  celt,  
    [out, size_is(celt), length_is(*pceltFetched)]   
        ICorPublishAppDomain **objects,  
    [out] ULONG *pceltFetched  
);  
```  
  
#### Parameters  
 `celt`  
 [in] The number of elements to be retrieved.  
  
 `objects`  
 [out] A pointer to the array of retrieved [ICorPublishAppDomain](../../../../docs/framework/unmanaged-api/debugging/icorpublishappdomain-interface.md) objects, each of which represents an application domain.  
  
 `pceltFetched`  
 [out] Pointer to the number of application domains actually returned. This value may be null if `celt` is one.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorPub.idl, CorPub.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorPublishAppDomainEnum Interface](../../../../docs/framework/unmanaged-api/debugging/icorpublishappdomainenum-interface.md)
