---
description: "Learn more about: IMetaDataImport::EnumParams Method"
title: "IMetaDataImport::EnumParams Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.EnumParams"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::EnumParams"
helpviewer_keywords: 
  - "IMetaDataImport::EnumParams method [.NET Framework metadata]"
  - "EnumParams method [.NET Framework metadata]"
ms.assetid: 52118dc9-fe6e-4b39-aa48-c3cc3ea4214d
topic_type: 
  - "apiref"
---
# IMetaDataImport::EnumParams Method

Enumerates ParamDef tokens representing the parameters of the method referenced by the specified MethodDef token.  
  
## Syntax  
  
```cpp  
HRESULT EnumParams (  
   [in, out] HCORENUM    *phEnum,  
   [in]  mdMethodDef     mb,  
   [out] mdParamDef      rParams[],  
   [in]  ULONG           cMax,  
   [out] ULONG          *pcTokens  
);  
```  
  
## Parameters  

 `phEnum`  
 [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.  
  
 `mb`  
 [in] A MethodDef token representing the method with the parameters to enumerate.  
  
 `rParams`  
 [out] The array used to store the ParamDef tokens.  
  
 `cMax`  
 [in] The maximum size of the `rParams` array.  
  
 `pcTokens`  
 [out] The number of ParamDef tokens returned in `rParams`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|`EnumParams` returned successfully.|  
|`S_FALSE`|There are no tokens to enumerate. In that case, `pcTokens` is zero.|  
  
## Requirements  

 **Platform:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
