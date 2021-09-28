---
description: "Learn more about: IMetaDataEmit::SetFieldMarshal Method"
title: "IMetaDataEmit::SetFieldMarshal Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.SetFieldMarshal"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::SetFieldMarshal"
helpviewer_keywords: 
  - "SetFieldMarshal method [.NET Framework metadata]"
  - "IMetaDataEmit::SetFieldMarshal method [.NET Framework metadata]"
ms.assetid: be232314-7f69-4855-bfab-63361bd22307
topic_type: 
  - "apiref"
---
# IMetaDataEmit::SetFieldMarshal Method

Sets the PInvoke marshaling information for the field, method return, or method parameter referenced by the specified token.  
  
## Syntax  
  
```cpp  
HRESULT SetFieldMarshal (  
    [in]  mdToken          tk,
    [in]  PCCOR_SIGNATURE  pvNativeType,
    [in]  ULONG            cbNativeType
);  
```  
  
## Parameters  

 `tk`  
 [in] The token for target data item. This is either a `mdFieldDef` or a `mdParamDef` token.  
  
 `pvNativeType`  
 [in] The signature for unmanaged type.  
  
 `cbNativeType`  
 [in] The count of bytes in `pvNativeType`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
