---
title: "IMetaDataEmit::DefineField Method"
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
  - "IMetaDataEmit.DefineField"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::DefineField"
helpviewer_keywords: 
  - "IMetaDataEmit::DefineField method [.NET Framework metadata]"
  - "DefineField method, IMetaDataEmit interface [.NET Framework metadata"
ms.assetid: 6b5be4fc-2e86-499c-8b09-833160bca767
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataEmit::DefineField Method
Creates a definition for a field with the specified metadata signature, and gets a token to that field definition.  
  
## Syntax  
  
```  
HRESULT DefineField (   
    [in]  mdTypeDef   td,   
    [in]  LPCWSTR     szName,   
    [in]  DWORD       dwFieldFlags,   
    [in]  PCCOR_SIGNATURE pvSigBlob,   
    [in]  ULONG       cbSigBlob,   
    [in]  DWORD       dwCPlusTypeFlag,   
    [in]  void const  *pValue,   
    [in]  ULONG       cchValue,   
    [out] mdFieldDef  *pmd   
);  
```  
  
#### Parameters  
 `td`  
 [in] The `mdTypeDef` token for the enclosing class or interface.  
  
 `szName`  
 [in] The field name in Unicode.  
  
 `dwFieldFlags`  
 [in] The field attributes. This is a bitmask of `CorFieldAttr` values.  
  
 `pvSigBlob`  
 [in] The field signature as a BLOB.  
  
 `cbSigBlob`  
 [in] The count of bytes in `pvSigBlob`.  
  
 `dwCPlusTypeFlage`  
 [in] The `ELEMENT_TYPE_`*\** for the constant value. This is a `CorElementType` value. If not defining a constant value for the field, use `ELEMENT_TYPE_END`.  
  
 `pValue`  
 [in] The constant value for the field.  
  
 `cchValue`  
 [in] The size in (Unicode) characters of `pValue`.  
  
 `pmd`  
 [out] The `mdFieldDef` token assigned.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)  
 [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
