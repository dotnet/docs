---
description: "Learn more about: IMetaDataImport::EnumProperties Method"
title: "IMetaDataImport::EnumProperties Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.EnumProperties"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::EnumProperties"
helpviewer_keywords: 
  - "IMetaDataImport::EnumProperties method [.NET Framework metadata]"
  - "EnumProperties method [.NET Framework metadata]"
ms.assetid: 60573ad7-8821-4721-a068-3f7a6d25926a
topic_type: 
  - "apiref"
---
# IMetaDataImport::EnumProperties Method

Enumerates PropertyDef tokens representing the properties of the type referenced by the specified TypeDef token.  
  
## Syntax  
  
```cpp  
HRESULT EnumProperties (  
   [in, out] HCORENUM    *phEnum,  
   [in]      mdTypeDef   td,  
   [out]     mdProperty  rProperties[],  
   [in]      ULONG       cMax,  
   [out]     ULONG       *pcProperties  
);  
```  
  
## Parameters  

 `phEnum`  
 [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.  
  
 `td`  
 [in] A TypeDef token representing the type with properties to enumerate.  
  
 `rProperties`  
 [out] The array used to store the PropertyDef tokens.  
  
 `cMax`  
 [in] The maximum size of the `rProperties` array.  
  
 `pcProperties`  
 [out] The number of PropertyDef tokens returned in `rProperties`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|`EnumProperties` returned successfully.|  
|`S_FALSE`|There are no tokens to enumerate. In that case, `pcProperties` is zero.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
