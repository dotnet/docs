---
title: "IMetaDataImport::FindMemberRef Method"
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
  - "IMetaDataImport.FindMemberRef"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::FindMemberRef"
helpviewer_keywords: 
  - "IMetaDataImport::FindMemberRef method [.NET Framework metadata]"
  - "FindMemberRef method [.NET Framework metadata]"
ms.assetid: 1ccda329-d752-4d89-abe8-511af3c3f4c9
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::FindMemberRef Method
Gets a pointer to the MemberRef token for the member reference that is enclosed by the specified <xref:System.Type> and that has the specified name and metadata signature.  
  
## Syntax  
  
```  
HRESULT FindMemberRef (  
   [in]  mdTypeRef          td,  
   [in]  LPCWSTR            szName,   
   [in]  PCCOR_SIGNATURE    pvSigBlob,   
   [in]  ULONG              cbSigBlob,   
   [out] mdMemberRef        *pmr  
);  
```  
  
#### Parameters  
 `td`  
 [in] The TypeRef token for the class or interface that encloses the member reference to search for. If this value is `mdTokenNil`, the lookup is done for a global variable or a global-function reference.  
  
 `szName`  
 [in] The name of the member reference to search for.  
  
 `pvSigBlob`  
 [in] A pointer to the binary metadata signature of the member reference.  
  
 `cbSigBlob`  
 [in] The size in bytes of `pvSigBlob`.  
  
 `pmr`  
 [out] A pointer to the matching MemberRef token.  
  
## Remarks  
 You specify the member using its enclosing class or interface (`td`), its name (`szName`), and optionally its signature (`pvSigBlob`).  
  
 The signature passed to `FindMemberRef` must have been generated in the current scope, because signatures are bound to a particular scope. A signature can embed a token that identifies the enclosing class or value type. The token is an index into the local TypeDef table. You cannot build a run-time signature outside the context of the current scope and use that signature as input to `FindMemberRef`.  
  
 `FindMemberRef` finds only member references that were defined directly in the class or interface; it does not find inherited member references.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
