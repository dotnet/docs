---
title: "IMetaDataEmit::SetParamProps Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.SetParamProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::SetParamProps"
helpviewer_keywords: 
  - "IMetaDataEmit::SetParamProps method [.NET Framework metadata]"
  - "SetParamProps method [.NET Framework metadata]"
ms.assetid: a95a3908-9f87-4084-937e-8e01ef03ad63
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataEmit::SetParamProps Method
Sets or changes features of a method parameter that was defined by a prior call to [IMetaDataEmit::DefineParam](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-defineparam-method.md).  
  
## Syntax  
  
```  
HRESULT SetParamProps (   
    [in]  mdParamDef  pd,   
    [in]  LPCWSTR     szName,   
    [in]  DWORD       dwParamFlags,   
    [in]  DWORD       dwCPlusTypeFlag,   
    [in]  void const  *pValue,   
    [in]  ULONG       cchValue   
);  
```  
  
#### Parameters  
 `pd`  
 [in] The token for the target parameter.  
  
 `szName`  
 [in] The name of the parameter in Unicode.  
  
 `dwParamFlags`  
 [in] The flags for the parameter.  
  
 `dwCPlusTypeFlag`  
 [in] The ELEMENT_TYPE_* for the constant value.  
  
 `pValue`  
 [in] The constant value for the parameter.  
  
 `cchValue`  
 [in] The size in (Unicode) characters of `pValue`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
- [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
