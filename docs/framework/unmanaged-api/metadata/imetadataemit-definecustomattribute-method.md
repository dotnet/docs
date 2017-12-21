---
title: "IMetaDataEmit::DefineCustomAttribute Method"
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
  - "IMetaDataEmit.DefineCustomAttribute"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::DefineCustomAttribute"
helpviewer_keywords: 
  - "DefineCustomAttribute method [.NET Framework metadata]"
  - "IMetaDataEmit::DefineCustomAttribute method [.NET Framework metadata]"
ms.assetid: 7dd14854-b756-4401-b167-88ca576dc8f0
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataEmit::DefineCustomAttribute Method
Creates a definition for a custom attribute with the specified metadata signature, to be attached to the specified object, and gets a token to that custom attribute definition.  
  
## Syntax  
  
```  
HRESULT DefineCustomAttribute (   
    [in]  mdToken     tkObj,   
    [in]  mdToken     tkType,   
    [in]  void const  *pCustomAttribute,   
    [in]  ULONG       cbCustomAttribute,   
    [out] mdCustomAttribute *pcv   
);  
```  
  
#### Parameters  
 `tkObj`  
 [in] The token for the owner item.  
  
 `tkType`  
 [in] The token that identifies the custom attribute.  
  
 `pCustomAttribute`  
 [in] A pointer to the custom attribute.  
  
 `cbCustomAttribute`  
 [in] The count of bytes in `pCustomAttribute`.  
  
 `pcv`  
 [out] The `mdCustomAttribute` token assigned.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)  
 [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
