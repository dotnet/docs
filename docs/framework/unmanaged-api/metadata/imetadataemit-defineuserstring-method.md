---
title: "IMetaDataEmit::DefineUserString Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.DefineUserString"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::DefineUserString"
helpviewer_keywords: 
  - "DefineUserString method [.NET Framework metadata]"
  - "IMetaDataEmit::DefineUserString method [.NET Framework metadata]"
ms.assetid: 88fb7ef3-bbdf-429c-b678-c9c153456461
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataEmit::DefineUserString Method
Gets a metadata token for the specified literal string.  
  
## Syntax  
  
```  
HRESULT DefineUserString (   
    [in]  LPCWSTR     szString,   
    [in]  ULONG       cchString,   
    [out] mdString    *pstk   
);  
```  
  
## Parameters  
 `szString`  
 [in] The user string to store.  
  
 `cchString`  
 [in] The count of wide characters in `szString`.  
  
 `pstk`  
 [out] The string token assigned.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
