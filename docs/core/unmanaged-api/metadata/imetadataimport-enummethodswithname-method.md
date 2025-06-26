---
description: "Learn more about: IMetaDataImport::EnumMethodsWithName Method"
title: "IMetaDataImport::EnumMethodsWithName Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.EnumMethodsWithName"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::EnumMethodsWithName"
helpviewer_keywords: 
  - "IMetaDataImport::EnumMethodsWithName method [.NET Framework metadata]"
  - "EnumMethodsWithName method [.NET Framework metadata]"
ms.assetid: a8624913-2e23-46ad-a0c1-bb8eccbbf20f
topic_type: 
  - "apiref"
---
# IMetaDataImport::EnumMethodsWithName Method

Enumerates methods that have the specified name and that are defined by the type referenced by the specified TypeDef token.  
  
## Syntax  
  
```cpp  
HRESULT EnumMethodsWithName (  
   [in, out] HCORENUM    *phEnum,  
   [in]  mdTypeDef       cl,  
   [in]  LPCWSTR         szName,  
   [out] mdMethodDef     rMethods[],  
   [in]  ULONG           cMax,  
   [out] ULONG           *pcTokens  
);  
```  
  
## Parameters  

 `phEnum`  
 [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.  
  
 `cl`  
 [in] A TypeDef token representing the type whose methods to enumerate.  
  
 `szName`  
 [in] The name that limits the scope of the enumeration.  
  
 `rMethods`  
 [out] The array used to store the MethodDef tokens.  
  
 `cMax`  
 [in] The maximum size of the `rMethods` array.  
  
 `pcTokens`  
 [out] The number of MethodDef tokens returned in `rMethods`.  
  
## Remarks  

 This method enumerates fields and methods, but not properties or events. Unlike [IMetaDataImport::EnumMethods](imetadataimport-enummethods-method.md), `EnumMethodsWithName` discards all method tokens that do not have the specified name.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|`EnumMethodsWithName` returned successfully.|  
|`S_FALSE`|There are no tokens to enumerate. In that case, `pcTokens` is zero.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
