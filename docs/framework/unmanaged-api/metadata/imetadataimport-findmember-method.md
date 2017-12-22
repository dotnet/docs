---
title: "IMetaDataImport::FindMember Method"
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
  - "IMetaDataImport.FindMember"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::FindMember"
helpviewer_keywords: 
  - "IMetaDataImport::FindMember method [.NET Framework metadata]"
  - "FindMember method [.NET Framework metadata]"
ms.assetid: ad32fb84-c2b6-41cd-888d-787ff3a90449
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::FindMember Method
Gets a pointer to the MemberDef token for field or method that is enclosed by the specified <xref:System.Type> and that has the specified name and metadata signature.  
  
## Syntax  
  
```  
HRESULT FindMember (  
   [in]  mdTypeDef         td,  
   [in]  LPCWSTR           szName,   
   [in]  PCCOR_SIGNATURE   pvSigBlob,   
   [in]  ULONG             cbSigBlob,   
   [out] mdToken           *pmb  
);  
```  
  
#### Parameters  
 `td`  
 [in] The TypeDef token for the class or interface that encloses the member to search for. If this value is `mdTokenNil`, the lookup is done for a global-variable or global-function.  
  
 `szName`  
 [in] The name of the member to search for.  
  
 `pvSigBlob`  
 [in] A pointer to the binary metadata signature of the member.  
  
 `cbSigBlob`  
 [in] The size in bytes of `pvSigBlob`.  
  
 `pmb`  
 [out] A pointer to the matching MemberDef token.  
  
## Remarks  
 You specify the member using its enclosing class or interface (`td`), its name (`szName`), and optionally its signature (`pvSigBlob`). There might be multiple members with the same name in a class or interface. In that case, pass the member's signature to find the unique match.  
  
 The signature passed to `FindMember` must have been generated in the current scope, because signatures are bound to a particular scope. A signature can embed a token that identifies the enclosing class or value type. The token is an index into the local TypeDef table. You cannot build a run-time signature outside the context of the current scope and use that signature as input to input to `FindMember`.  
  
 `FindMember` finds only members that were defined directly in the class or interface; it does not find inherited members.  
  
> [!NOTE]
>  `FindMember` is a helper method. It calls [IMetaDataImport::FindMethod](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-findmethod-method.md); if that call does not find a match, `FindMember` then calls [IMetaDataImport::FindField](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-findfield-method.md).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
