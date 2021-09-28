---
description: "Learn more about: IMetaDataEmit::SetCustomAttributeValue Method"
title: "IMetaDataEmit::SetCustomAttributeValue Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.SetCustomAttributeValue"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::SetCustomAttributeValue"
helpviewer_keywords: 
  - "SetCustomAttributeValue method [.NET Framework metadata]"
  - "IMetaDataEmit::SetCustomAttributeValue method [.NET Framework metadata]"
ms.assetid: f721c863-9642-4e64-917a-65f9e55c25b9
topic_type: 
  - "apiref"
---
# IMetaDataEmit::SetCustomAttributeValue Method

Sets or updates the value of a custom attribute defined by a prior call to [IMetaDataEmit::DefineCustomAttribute](imetadataemit-definecustomattribute-method.md).  
  
## Syntax  
  
```cpp  
HRESULT SetCustomAttributeValue (
    [in]  mdCustomAttribute       pcv,
    [in]  void const              *pCustomAttribute,
    [in]  ULONG                   cbCustomAttribute
);  
```  
  
## Parameters  

 `pcv`  
 [in] The token of the target custom attribute.  
  
 `pCustomAttribute`  
 [in] A pointer to the array that contains the custom attribute.  
  
 `cbCustomAttribute`  
 [in] The size, in bytes, of the custom attribute.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
