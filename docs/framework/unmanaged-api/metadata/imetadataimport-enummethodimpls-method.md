---
title: "IMetaDataImport::EnumMethodImpls Method"
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
  - "IMetaDataImport.EnumMethodImpls"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::EnumMethodImpls"
helpviewer_keywords: 
  - "EnumMethodImpls method [.NET Framework metadata]"
  - "IMetaDataImport::EnumMethodImpls method [.NET Framework metadata]"
ms.assetid: 4e0f865d-88b5-44bd-be35-492622e5e08e
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::EnumMethodImpls Method
Enumerates MethodBody and MethodDeclaration tokens representing methods of the specified type.  
  
## Syntax  
  
```  
HRESULT EnumMethodImpls (  
   [in, out] HCORENUM    *phEnum,   
   [in]      mdTypeDef   td,   
   [out]     mdToken     rMethodBody[],   
   [out]     mdToken     rMethodDecl[],   
   [in]      ULONG       cMax,   
   [in]      ULONG       *pcTokens  
);  
```  
  
#### Parameters  
 `phEnum`  
 [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.  
  
 `td`  
 [in] A TypeDef token for the type whose method implementations to enumerate.  
  
 `rMethodBody`  
 [out] The array to store the MethodBody tokens.  
  
 `rMethodDecl`  
 [out] The array to store the MethodDeclaration tokens.  
  
 `cMax`  
 [in] The maximum size of the `rMethodBody` and `rMethodDecl` arrays.  
  
 `pcTokens`  
 [in] The actual number of methods returned in `rMethodBody` and `rMethodDecl`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|`EnumMethodImpls` returned successfully.|  
|`S_FALSE`|There are no method tokens to enumerate. In that case, `pcTokens` is zero.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
