---
description: "Learn more about: IMetaDataEmit::DefineCustomAttribute Method"
title: "IMetaDataEmit::DefineCustomAttribute Method"
ms.date: "03/30/2017"
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
---
# IMetaDataEmit::DefineCustomAttribute Method

Creates a definition for a custom attribute with the specified metadata signature, to be attached to the specified object, and gets a token to that custom attribute definition.  
  
## Syntax  
  
```cpp  
HRESULT DefineCustomAttribute (
    [in]  mdToken     tkObj,
    [in]  mdToken     tkType,
    [in]  void const  *pCustomAttribute,
    [in]  ULONG       cbCustomAttribute,
    [out] mdCustomAttribute *pcv
);  
```  
  
## Parameters  

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

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
