---
description: "Learn more about: IMetaDataImport2::EnumGenericParams Method"
title: "IMetaDataImport2::EnumGenericParams Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport2.EnumGenericParams"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport2::EnumGenericParams"
helpviewer_keywords: 
  - "EnumGenericParams method [.NET Framework metadata]"
  - "IMetaDataImport2::EnumGenericParams method [.NET Framework metadata]"
ms.assetid: b50488a5-3cf0-483c-82dc-2892a3ec61ac
topic_type: 
  - "apiref"
---
# IMetaDataImport2::EnumGenericParams Method

Gets an enumerator for an array of generic parameter tokens associated with the specified TypeDef or MethodDef token.  
  
## Syntax  
  
```cpp
HRESULT EnumGenericParams (  
   [in, out] HCORENUM     *phEnum,
   [in]  mdToken          tk,  
   [out] mdGenericParam   rGenericParams[],
   [in]  ULONG            cMax,
   [out] ULONG            *pcGenericParams  
);  
```  
  
## Parameters  

 `phEnum`  
 [in, out] A pointer to the enumerator.  
  
 `tk`  
 [in] The TypeDef or MethodDef token whose generic parameters are to be enumerated.  
  
 `rGenericParams`  
 [out] The array of generic parameters to enumerate.  
  
 `cMax`  
 [in] The requested maximum number of tokens to place in `rGenericParams`.  
  
 `pcGenericParams`  
 [out] The returned number of tokens placed in `rGenericParams`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|`EnumGenericParams` returned successfully.|  
|`S_FALSE`|`phEnum` has no member elements. In this case, `pcGenericParams` is set to 0 (zero).|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
- [IMetaDataImport Interface](imetadataimport-interface.md)
