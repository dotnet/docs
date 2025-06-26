---
description: "Learn more about: IMetaDataImport2::EnumMethodSpecs Method"
title: "IMetaDataImport2::EnumMethodSpecs Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport2.EnumMethodSpecs"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport2::EnumMethodSpecs"
helpviewer_keywords: 
  - "IMetaDataImport2::EnumMethodSpecs method [.NET Framework metadata]"
  - "EnumMethodSpecs method [.NET Framework metadata]"
ms.assetid: b3fc1e6c-bcb6-4915-baf8-7dc0a31b8724
topic_type: 
  - "apiref"
---
# IMetaDataImport2::EnumMethodSpecs Method

Gets an enumerator for an array of MethodSpec tokens associated with the specified MethodDef or MemberRef token.  
  
## Syntax  
  
```cpp  
HRESULT EnumMethodSpecs (  
    [in, out] HCORENUM      *phEnum,
    [in]      mdToken       tk,  
    [out]     mdMethodSpec  rMethodSpecs[],  
    [in]      ULONG         cMax,  
    [out]     ULONG         *pcMethodSpecs  
);
```  
  
## Parameters  

 `phEnum`  
 [in, out] A pointer to the enumerator for `rMethodSpecs`.  
  
 `tk`  
 [in] The MemberRef or MethodDef token that represents the method whose MethodSpec tokens are to be enumerated. If the value of `tk` is 0 (zero), all MethodSpec tokens in the scope will be enumerated.  
  
 `rMethodSpecs`  
 [out] The array of MethodSpec tokens to enumerate.  
  
 `cMax`  
 [in] The requested maximum number of tokens to place in `rMethodSpecs`.  
  
 `pcMethodSpecs`  
 [out] The returned number of tokens placed in `rMethodSpecs`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|`EnumMethodSpecs` returned successfully.|  
|`S_FALSE`|`phEnum` has no member elements. In this case, `pcMethodSpecs` is set to 0 (zero).|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
- [IMetaDataImport Interface](imetadataimport-interface.md)
