---
title: "IMetaDataEmit::DefineNestedType Method"
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
  - "IMetaDataEmit.DefineNestedType"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::DefineNestedType"
helpviewer_keywords: 
  - "IMetaDataEmit::DefineNestedType method [.NET Framework metadata]"
  - "DefineNestedType method [.NET Framework metadata]"
ms.assetid: 1e994de6-4628-459c-b967-b34be1e9fe4f
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataEmit::DefineNestedType Method
Creates the metadata signature of a type definition, returns an `mdTypeDef` token for that type, and specifies that the defined type is a member of the type referenced by the `tdEncloser` parameter.  
  
## Syntax  
  
```  
HRESULT DefineNestedType (   
    [in]  LPCWSTR     szTypeDef,  
    [in]  DWORD       dwTypeDefFlags,   
    [in]  mdToken     tkExtends,   
    [in]  mdToken     rtkImplements[],   
    [in]  mdTypeDef   tdEncloser,   
    [out] mdTypeDef   *ptd  
);  
```  
  
#### Parameters  
 `szTypeDef`  
 [in] The name of the type in Unicode.  
  
 `dwTypeDefFlags`  
 [in] `TypeDef` attributes. This is a bitmask of `CorTypeAttr` values.  
  
 `tkExtends`  
 [in] The token of the base class. This is either a `mdTypeDef` or a `mdTypeRef` token.  
  
 `rtkImplements`[]  
 [in] An array of tokens that specify the interfaces that this class or interface implements.  
  
 `tdEncloser`  
 [in] The token of the enclosing type. The last element of the array must be `mdTokenNil`.  
  
 `ptd`  
 [out] The `mdTypeDef` token assigned.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)  
 [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
