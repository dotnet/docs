---
description: "Learn more about: IMetaDataImport::EnumTypeRefs Method"
title: "IMetaDataImport::EnumTypeRefs Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.EnumTypeRefs"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::EnumTypeRefs"
helpviewer_keywords: 
  - "EnumTypeRefs method [.NET Framework metadata]"
  - "IMetaDataImport::EnumTypeRefs method [.NET Framework metadata]"
ms.assetid: b4896b8f-8e97-469c-8089-e72a025661b5
topic_type: 
  - "apiref"
---
# IMetaDataImport::EnumTypeRefs Method

Enumerates TypeRef tokens defined in the current metadata scope.  
  
## Syntax  
  
```cpp  
HRESULT EnumTypeRefs (  
   [in, out] HCORENUM    *phEnum,
   [out] mdTypeRef       rTypeRefs[],  
   [in]  ULONG           cMax,
   [out] ULONG           *pcTypeRefs  
);  
```  
  
## Parameters  

 `phEnum`  
 [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.  
  
 `rTypeRefs`  
 [out] The array used to store the TypeRef tokens.  
  
 `cMax`  
 [in] The maximum size of the `rTypeRefs` array.  
  
 `pcTypeRefs`  
 [out] A pointer to the number of TypeRef tokens returned in `rTypeRefs`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|`EnumTypeRefs` returned successfully.|  
|`S_FALSE`|There are no tokens to enumerate. In that case, `pcTypeRefs` is zero.|  
  
## Remarks  

 A TypeRef token represents a reference to a type.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
