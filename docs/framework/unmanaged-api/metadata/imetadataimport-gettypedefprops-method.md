---
description: "Learn more about: IMetaDataImport::GetTypeDefProps Method"
title: "IMetaDataImport::GetTypeDefProps Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.GetTypeDefProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetTypeDefProps"
helpviewer_keywords: 
  - "GetTypeDefProps method [.NET Framework metadata]"
  - "IMetaDataImport::GetTypeDefProps method [.NET Framework metadata]"
ms.assetid: 00061a25-ba05-47a7-b984-fd916b06b149
topic_type: 
  - "apiref"
---
# IMetaDataImport::GetTypeDefProps Method

Returns metadata information for the <xref:System.Type> represented by the specified TypeDef token.  
  
## Syntax  
  
```cpp  
HRESULT GetTypeDefProps (  
   [in]  mdTypeDef   td,  
   [out] LPWSTR      szTypeDef,  
   [in]  ULONG       cchTypeDef,  
   [out] ULONG       *pchTypeDef,  
   [out] DWORD       *pdwTypeDefFlags,  
   [out] mdToken     *ptkExtends  
);  
```  
  
## Parameters  

 `td`  
 [in] The TypeDef token that represents the type to return metadata for.  
  
 `szTypeDef`  
 [out] A buffer containing the type name.  
  
 `cchTypeDef`  
 [in] The size in wide characters of `szTypeDef`.  
  
 `pchTypeDef`  
 [out] The number of wide characters returned in `szTypeDef`.  
  
 `pdwTypeDefFlags`  
 [out] A pointer to any flags that modify the type definition. This value is a bitmask from the [CorTypeAttr](cortypeattr-enumeration.md) enumeration.  
  
 `ptkExtends`  
 [out] A TypeDef or TypeRef metadata token that represents the base type of the requested type.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
