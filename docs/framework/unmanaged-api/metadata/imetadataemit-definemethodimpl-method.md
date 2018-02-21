---
title: "IMetaDataEmit::DefineMethodImpl Method"
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
  - "IMetaDataEmit.DefineMethodImpl"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::DefineMethodImpl"
helpviewer_keywords: 
  - "DefineMethodImpl method [.NET Framework metadata]"
  - "IMetaDataEmit::DefineMethodImpl method [.NET Framework metadata]"
ms.assetid: 9dcc8b3d-33ee-4c7c-8d6f-322c57b94a0f
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataEmit::DefineMethodImpl Method
Creates a definition for implementation of a method inherited from an interface, and returns a token to that method-implementation definition.  
  
## Syntax  
  
```  
HRESULT DefineMethodImpl (   
    [in]  mdTypeDef         td,   
    [in]  mdToken           tkBody,   
    [in]  mdToken           tkDecl  
);  
```  
  
#### Parameters  
 `td`  
 [in] The `mdTypedef` token of the implementing class.  
  
 `tkBody`  
 [in] The `mdMethodDef` or `mdMethodRef` token of the code body.  
  
 `tkDecl`  
 [in] The `mdMethodDef` or `mdMethodRef` token of the interface method being implemented.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)  
 [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
