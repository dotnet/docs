---
description: "Learn more about: IMetaDataEmit::GetTokenFromTypeSpec Method"
title: "IMetaDataEmit::GetTokenFromTypeSpec Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.GetTokenFromTypeSpec"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::GetTokenFromTypeSpec"
helpviewer_keywords: 
  - "GetTokenFromTypeSpec method [.NET Framework metadata]"
  - "IMetaDataEmit::GetTokenFromTypeSpec method [.NET Framework metadata]"
ms.assetid: 7de6447a-a751-49d8-87e2-951cee77b536
topic_type: 
  - "apiref"
---
# IMetaDataEmit::GetTokenFromTypeSpec Method

Gets a metadata token for the type with the specified metadata signature.  
  
## Syntax  
  
```cpp  
HRESULT GetTokenFromTypeSpec (
    [in]  PCCOR_SIGNATURE       pvSig,
    [in]  ULONG                 cbSig,
    [out] mdTypeSpec            *ptypespec
);  
```  
  
## Parameters  

 `pvSig`  
 [in] The signature being defined.  
  
 `cbSig`  
 [in] The count of bytes in `pvSig`.  
  
 `ptypespec`  
 [out] The `mdTypeSpec` token assigned.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
