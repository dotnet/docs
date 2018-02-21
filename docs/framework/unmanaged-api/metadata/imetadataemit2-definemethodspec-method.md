---
title: "IMetaDataEmit2::DefineMethodSpec Method"
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
  - "IMetaDataEmit2.DefineMethodSpec"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit2::DefineMethodSpec"
helpviewer_keywords: 
  - "DefineMethodSpec method [.NET Framework metadata]"
  - "IMetaDataEmit2::DefineMethodSpec method [.NET Framework metadata]"
ms.assetid: 3c24e552-fc69-4971-b65a-a3e4b5f7f1e8
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataEmit2::DefineMethodSpec Method
Creates a generic instance of a method, and gets a token to the definition.  
  
## Syntax  
  
```  
HRESULT DefineMethodSpec (  
    [in]  mdToken           tkParent,   
    [in]  PCCOR_SIGNATURE   pvSigBlob,   
    [in]  ULONG             cbSigBlob,   
    [out] mdMethodSpec      *pmi  
);  
```  
  
#### Parameters  
 `tkParent`  
 [in] A token for the method of which to create the generic instance. The token must be of type `mdMethodDef` or `mdMemberRef`.  
  
 `pvSigBlob`  
 [in] A pointer to the binary COM+ signature of the method.  
  
 `cbSibBlob`  
 [in] The size, in bytes, of `pvSigBlob`.  
  
 `pmi`  
 [out] A token to the metadata signature definition of the method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)  
 [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)
