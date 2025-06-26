---
description: "Learn more about: IMetaDataImport::EnumMethods Method"
title: "IMetaDataImport::EnumMethods Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.EnumMethods"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::EnumMethods"
helpviewer_keywords: 
  - "IMetaDataImport::EnumMethods method [.NET Framework metadata]"
  - "EnumMethods method [.NET Framework metadata]"
ms.assetid: 8cc3b0c3-d97d-4f71-9e7d-ef2a92b4959a
topic_type: 
  - "apiref"
---
# IMetaDataImport::EnumMethods Method

Enumerates MethodDef tokens representing methods of the specified type.  
  
## Syntax  
  
```cpp  
HRESULT EnumMethods (  
   [in, out] HCORENUM   *phEnum,
   [in]  mdTypeDef      cl,
   [out] mdMethodDef    rMethods[],
   [in]  ULONG          cMax,
   [out] ULONG          *pcTokens  
);  
```  
  
## Parameters  

 `phEnum`  
 [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.  
  
 `cl`  
 [in] A TypeDef token representing the type with the methods to enumerate.  
  
 `rMethods`  
 [out] The array to store the MethodDef tokens.  
  
 `cMax`  
 [in] The maximum size of the MethodDef `rMethods` array.  
  
 `pcTokens`  
 [out] The number of MethodDef tokens returned in `rMethods`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|`EnumMethods` returned successfully.|  
|`S_FALSE`|There are no MethodDef tokens to enumerate. In that case, `pcTokens` is zero.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
