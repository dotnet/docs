---
title: "IMetaDataImport2::GetGenericParamConstraintProps Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport2.GetGenericParamConstraintProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport2::GetGenericParamConstraintProps"
helpviewer_keywords: 
  - "IMetaDataImport2::GetGenericParamConstraintProps method [.NET Framework metadata]"
  - "GetGenericParamConstraintProps method [.NET Framework metadata]"
ms.assetid: c5fee4a0-b132-4e5e-8730-e586ce314b9a
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataImport2::GetGenericParamConstraintProps Method
Gets the metadata associated with the generic parameter constraint represented by the specified constraint token.  
  
## Syntax  
  
```  
HRESULT GetGenericParamConstraintProps (  
   [in]  mdGenericParamConstraint  gpc,  
   [out] mdGenericParam            *ptGenericParam,  
   [out] mdToken                   *ptkConstraintType  
);  
```  
  
## Parameters  
 `gpc`  
 [in] The token to the generic parameter constraint for which to return the metadata.  
  
 `ptGenericParam`  
 [out] A pointer to the token that represents the generic parameter that is constrained.  
  
 `ptkConstraintType`  
 [out] A pointer to a TypeDef, TypeRef, or TypeSpec token that represents a constraint on `ptGenericParam`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
- [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)
