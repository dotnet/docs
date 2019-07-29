---
title: "IMetaDataEmit2::DefineGenericParam Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit2.DefineGenericParam"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit2::DefineGenericParam"
helpviewer_keywords: 
  - "IMetaDataEmit2::DefineGenericParam method [.NET Framework metadata]"
  - "DefineGenericParam method [.NET Framework metadata]"
ms.assetid: 47b2a3b6-907d-43dc-858d-1ae7dca1316a
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataEmit2::DefineGenericParam Method
Creates a definition for a generic type parameter, and gets a token to that generic type parameter.  
  
## Syntax  
  
```cpp  
HRESULT DefineGenericParam (   
    [in]  mdToken         tk,   
    [in]  ULONG           ulParamSeq,   
    [in]  DWORD           dwParamFlags,   
    [in]  LPCWSTR         szname,   
    [in]  DWORD           reserved,   
    [in]  mdToken         rtkConstraints[],   
    [out] mdGenericParam  *pgp  
);  
```  
  
## Parameters  
 `tk`  
 [in] An `mdTypeDef` or `mdMethodDef` token that represents the method or constructor for which to define a generic parameter.  
  
 `ulParamSeq`  
 [in] The index of the generic parameter.  
  
 `dwParamFlags`  
 [in] A value of the [CorGenericParamAttr](../../../../docs/framework/unmanaged-api/metadata/corgenericparamattr-enumeration.md) enumeration that describes the type for the generic parameter.  
  
 `szname`  
 [in] The name of the parameter.  
  
 `reserved`  
 [in] This parameter is reserved for future extensibility.  
  
 `rtkConstraints`  
 [in] A zero-terminated array of type constraints. Array members must be an `mdTypeDef`, `mdTypeRef`, or `mdTypeSpec` metadata token.  
  
 `pgp`  
 [out] A token that represents the generic parameter.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
- [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)
