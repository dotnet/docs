---
title: "IMetaDataImport::FindField Method"
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
  - "IMetaDataImport.FindField"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::FindField"
helpviewer_keywords: 
  - "IMetaDataImport::FindField method [.NET Framework metadata]"
  - "FindField method [.NET Framework metadata]"
ms.assetid: 38cd4e16-fbb2-471c-aa73-ac51a1931ad2
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::FindField Method
Gets a pointer to the FieldDef token for the field that is enclosed by the specified <xref:System.Type> and that has the specified name and metadata signature.  
  
## Syntax  
  
```  
HRESULT FindField (  
   [in]  mdTypeDef         td,  
   [in]  LPCWSTR           szName,  
   [in]  PCCOR_SIGNATURE   pvSigBlob,  
   [in]  ULONG             cbSigBlob,  
   [out] mdFieldDef        *pmb  
);  
```  
  
#### Parameters  
 `td`  
 [in] The TypeDef token for the class or interface that encloses the field to search for. If this value is `mdTokenNil`, the lookup is done for a global variable.  
  
 `szName`  
 [in] The name of the field to search for.  
  
 `pvSigBlob`  
 [in] A pointer to the binary metadata signature of the field.  
  
 `cbSigBlob`  
 [in] The size in bytes of `pvSigBlob`.  
  
 `pmb`  
 [out] A pointer to the matching FieldDef token.  
  
## Remarks  
 You specify the field using its enclosing class or interface (`td`), its name (`szName`), and optionally its signature (`pvSigBlob`).  
  
 The signature passed to `FindField` must have been generated in the current scope, because signatures are bound to a particular scope. A signature can embed a token that identifies the enclosing class or value type. (The token is an index into the local TypeDef table). You cannot build a run-time signature outside the context of the current scope and use that signature as input to `FindField`.  
  
 `FindField` finds only fields that were defined directly in the class or interface; it does not find inherited fields.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
