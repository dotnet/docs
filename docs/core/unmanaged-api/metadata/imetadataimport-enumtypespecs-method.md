---
description: "Learn more about: IMetaDataImport::EnumTypeSpecs Method"
title: "IMetaDataImport::EnumTypeSpecs Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.EnumTypeSpecs"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::EnumTypeSpecs"
helpviewer_keywords: 
  - "EnumTypeSpecs method [.NET Framework metadata]"
  - "IMetaDataImport::EnumTypeSpecs method [.NET Framework metadata]"
ms.assetid: 75331c7b-988b-436c-9eb9-a270d37b4f06
topic_type: 
  - "apiref"
---
# IMetaDataImport::EnumTypeSpecs Method

Enumerates TypeSpec tokens defined in the current metadata scope.  
  
## Syntax  
  
```cpp  
HRESULT EnumTypeSpecs (  
   [in, out] HCORENUM    *phEnum,  
   [out] mdTypeSpec      rTypeSpecs[],  
   [in]  ULONG           cMax,  
   [out] ULONG           *pcTypeSpecs  
);  
```  
  
## Parameters  

 `phEnum`  
 [in, out] A pointer to the enumerator. This value must be NULL for the first call of this method.  
  
 `rTypeSpecs`  
 [out] The array used to store the TypeSpec tokens.  
  
 `cMax`  
 [in] The maximum size of the `rTypeSpecs` array.  
  
 `pcTypeSpecs`  
 [out] The number of TypeSpec tokens returned in `rTypeSpecs`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|`EnumTypeSpecs` returned successfully.|  
|`S_FALSE`|There are no tokens to enumerate. In that case, `pcTypeSpecs` is zero.|  
  
## Remarks  

 The TypeSpec tokens are created by the [IMetaDataEmit::GetTokenFromTypeSpec](imetadataemit-gettokenfromtypespec-method.md) method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
