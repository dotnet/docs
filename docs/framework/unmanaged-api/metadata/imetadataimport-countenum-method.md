---
title: "IMetaDataImport::CountEnum Method"
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
  - "IMetaDataImport.CountEnum"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::CountEnum"
helpviewer_keywords: 
  - "CountEnum method [.NET Framework metadata]"
  - "IMetaDataImport::CountEnum method [.NET Framework metadata]"
ms.assetid: d1de53ad-9435-4b5f-9df7-07f21210e5b5
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::CountEnum Method
Gets the number of elements in the enumeration that was retrieved by the specified enumerator.  
  
## Syntax  
  
```  
HRESULT CountEnum (  
   [in]  HCORENUM    hEnum,   
   [out] ULONG       *pulCount  
);  
```  
  
#### Parameters  
 `hEnum`  
 [in] The handle for the enumerator.  
  
 `pulCount`  
 [out] The number of elements enumerated.  
  
## Remarks  
 The handle specified by `hEnum` is obtained from a previous `Enum`*Name* call (for example, [IMetaDataImport::EnumTypeDefs](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-enumtypedefs-method.md)).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
