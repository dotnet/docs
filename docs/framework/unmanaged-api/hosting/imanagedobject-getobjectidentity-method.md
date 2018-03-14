---
title: "IManagedObject::GetObjectIdentity Method"
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
  - "IManagedObject.GetObjectIdentity"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GetObjectIdentity"
helpviewer_keywords: 
  - "GetObjectIdentity method [.NET Framework hosting]"
  - "IManagedObject::GetObjectIdentity method [.NET Framework hosting]"
ms.assetid: b862ff3e-e480-4cdf-84e2-e1013334a467
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IManagedObject::GetObjectIdentity Method
Gets the identity of this managed object.  
  
## Syntax  
  
```  
HRESULT GetObjectIdentity (  
    [out] BSTR*   pBSTRGUID,  
    [out] int*    AppDomainID,  
    [out] CCW_PTR pCCW  
);  
```  
  
#### Parameters  
 `pBSTRGUID`  
 [out] A pointer to the GUID of the process in which the object resides.  
  
 `AppDomainID`  
 [out] A pointer to the ID of the object's application domain.  
  
 `pCCW`  
 [out] A pointer to object's index in the COM classic v-table.  
  
## Remarks  
 The identity of a managed object includes process GUID, application domain ID, and the object's index in the COM classic v-table.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IManagedObject Interface](../../../../docs/framework/unmanaged-api/hosting/imanagedobject-interface.md)
