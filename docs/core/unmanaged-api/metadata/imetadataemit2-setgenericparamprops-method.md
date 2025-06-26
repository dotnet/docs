---
description: "Learn more about: IMetaDataEmit2::SetGenericParamProps Method"
title: "IMetaDataEmit2::SetGenericParamProps Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit2.SetGenericParamProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit2::SetGenericParamProps"
helpviewer_keywords: 
  - "IMetaDataEmit2::SetGenericParamProps method [.NET Framework metadata]"
  - "SetGenericParamProps method [.NET Framework metadata]"
ms.assetid: cd93a48d-1fed-4706-bec6-a05dc3b64fbd
topic_type: 
  - "apiref"
---
# IMetaDataEmit2::SetGenericParamProps Method

Sets property values for the generic parameter definition referenced by the specified token.  
  
## Syntax  
  
```cpp  
HRESULT SetGenericParamProps (  
    [in] mdGenericParam   gp,
    [in] DWORD            dwParamFlags,
    [in] LPCWSTR          szName,
    [in] DWORD            reserved,
    [in] mdToken          rtkConstraints[]  
);  
```  
  
## Parameters  

 `gp`  
 [in] The token for the generic parameter definition for which to set values.  
  
 `dwParamFlags`  
 [in] A value of the [CorGenericParamAttr](corgenericparamattr-enumeration.md) enumeration that describes the type for the generic parameter.  
  
 `szName`  
 [in] Optional. The name of the parameter for which to set values.  
  
 `reserved`  
 [in] Reserved for future extensibility.  
  
 `rtkConstraints`  
 [in] Optional. A zero-terminated array of type constraints. Array members must be an `mdTypeDef`, `mdTypeRef`, or `mdTypeSpec` metadata token.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
- [IMetaDataEmit Interface](imetadataemit-interface.md)
