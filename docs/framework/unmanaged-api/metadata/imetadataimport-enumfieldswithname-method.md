---
description: "Learn more about: IMetaDataImport::EnumFieldsWithName Method"
title: "IMetaDataImport::EnumFieldsWithName Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.EnumFieldsWithName"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::EnumFieldsWithName"
helpviewer_keywords: 
  - "IMetaDataImport::EnumFieldsWithName method [.NET Framework metadata]"
  - "EnumFieldsWithName method [.NET Framework metadata]"
ms.assetid: 42145e8d-000f-4d0b-ae43-c08201190fa2
topic_type: 
  - "apiref"
---
# IMetaDataImport::EnumFieldsWithName Method

Enumerates FieldDef tokens of the specified type with the specified name.  
  
## Syntax  
  
```cpp  
HRESULT EnumFieldsWithName (  
   [in, out] HCORENUM    *phEnum,
   [in]  mdTypeDef       cl,
   [in]  LPCWSTR         szName,
   [out] mdFieldDef      rFields[],
   [in]  ULONG           cMax,
   [out] ULONG           *pcTokens
);  
```  
  
## Parameters  

 `phEnum`  
 [in, out] A pointer to the enumerator.  
  
 `cl`  
 [in] The token of the type whose fields are to be enumerated.  
  
 `szName`  
 [in] The field name that limits the scope of the enumeration.  
  
 `rFields`  
 [out] Array used to store the FieldDef tokens.  
  
 `cMax`  
 [in] The maximum size of the `rFields` array.  
  
 `pcTokens`  
 [out] The actual number of FieldDef tokens returned in `rFields`.  
  
## Remarks  

 Unlike [IMetaDataImport::EnumFields](imetadataimport-enumfields-method.md), `EnumFieldsWithName` discards all field tokens that do not have the specified name.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|`EnumFieldsWithName` returned successfully.|  
|`S_FALSE`|There are no fields to enumerate. In that case, `pcTokens` is zero.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
