---
description: "Learn more about: IMetaDataEmit::DefineMethodImpl Method"
title: "IMetaDataEmit::DefineMethodImpl Method"
ms.date: "03/30/2017"
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
---
# IMetaDataEmit::DefineMethodImpl Method

Creates a definition for implementation of a method inherited from an interface, and returns a token to that method-implementation definition.  
  
## Syntax  
  
```cpp  
HRESULT DefineMethodImpl (
    [in]  mdTypeDef         td,
    [in]  mdToken           tkBody,
    [in]  mdToken           tkDecl  
);  
```  
  
## Parameters  

 `td`  
 [in] The `mdTypedef` token of the implementing class.  
  
 `tkBody`  
 [in] The `mdMethodDef` or `mdMemberRef` token of the code body.  
  
 `tkDecl`  
 [in] The `mdMethodDef` or `mdMemberRef` token of the interface method being implemented.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
