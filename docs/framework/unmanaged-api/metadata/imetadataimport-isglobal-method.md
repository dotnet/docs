---
title: "IMetaDataImport::IsGlobal Method"
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
  - "IMetaDataImport.IsGlobal"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::IsGlobal"
helpviewer_keywords: 
  - "IsGlobal method [.NET Framework metadata]"
  - "IMetaDataImport::IsGlobal method [.NET Framework metadata]"
ms.assetid: 44cf6908-f555-4ae8-b2cf-24bd974bf2fe
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::IsGlobal Method
Gets a value indicating whether the field, method, or type represented by the specified metadata token has global scope.  
  
## Syntax  
  
```  
HRESULT IsGlobal (  
   [in]  mdToken     pd,  
   [out] int         *pbGlobal  
);  
```  
  
#### Parameters  
 `pd`  
 [in] A metadata token that represents a type, field, or method.  
  
 `pbGlobal`  
 [out] 1 if the object has global scope; otherwise, 0 (zero).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
