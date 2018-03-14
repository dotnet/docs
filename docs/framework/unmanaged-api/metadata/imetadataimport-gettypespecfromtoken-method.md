---
title: "IMetaDataImport::GetTypeSpecFromToken Method"
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
  - "IMetaDataImport.GetTypeSpecFromToken"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetTypeSpecFromToken"
helpviewer_keywords: 
  - "GetTypeSpecFromToken method [.NET Framework metadata]"
  - "IMetaDataImport::GetTypeSpecFromToken method [.NET Framework metadata]"
ms.assetid: ee518bda-3296-482e-a7b7-e9d51dd1a181
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::GetTypeSpecFromToken Method
Gets the binary metadata signature of the type specification represented by the specified token.  
  
## Syntax  
  
```  
HRESULT GetTypeSpecFromToken (   
   [in]  mdTypeSpec            typespec,   
   [out] PCCOR_SIGNATURE       *ppvSig,   
   [out] ULONG                 *pcbSig  
);  
```  
  
#### Parameters  
 `typespec`  
 [in] The TypeSpec token associated with the requested metadata signature.  
  
 `ppvSig`  
 [out] A pointer to the binary metadata signature.  
  
 `pcbSig`  
 [out] The size, in bytes, of the metadata signature.  
  
## Return Value  
 An HRESULT that indicates success or failure. Failures can be tested with the FAILED macro.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
