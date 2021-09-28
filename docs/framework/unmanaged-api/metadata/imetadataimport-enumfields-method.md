---
description: "Learn more about: IMetaDataImport::EnumFields Method"
title: "IMetaDataImport::EnumFields Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.EnumFields"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::EnumFields"
helpviewer_keywords: 
  - "EnumFields method [.NET Framework metadata]"
  - "IMetaDataImport::EnumFields method [.NET Framework metadata]"
ms.assetid: 1d23247e-c58c-45db-afd8-83aa89cde18e
topic_type: 
  - "apiref"
---
# IMetaDataImport::EnumFields Method

Enumerates FieldDef tokens for the type referenced by the specified TypeDef token.  
  
## Syntax  
  
```cpp  
HRESULT EnumFields (
   [in, out] HCORENUM    *phEnum,
   [in]      mdTypeDef   cl,
   [out]     mdFieldDef  rFields[],
   [in]      ULONG       cMax,
   [out]     ULONG       *pcTokens  
);  
```  
  
## Parameters  

 `phEnum`  
 [in, out] A pointer to the enumerator.  
  
 `cl`  
 [in] The TypeDef token of the class whose fields are to be enumerated.  
  
 `rFields`  
 [out] The list of FieldDef tokens.  
  
 `cMax`  
 [in] The maximum size of the `rFields` array.  
  
 `pcTokens`  
 [out] The actual number of FieldDef tokens returned in `rFields`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|`EnumFields` returned successfully.|  
|`S_FALSE`|There are no fields to enumerate. In that case, `pcTokens` is zero.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
