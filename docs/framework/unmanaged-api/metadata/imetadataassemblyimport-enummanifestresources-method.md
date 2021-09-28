---
description: "Learn more about: IMetaDataAssemblyImport::EnumManifestResources Method"
title: "IMetaDataAssemblyImport::EnumManifestResources Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataAssemblyImport.EnumManifestResources"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataAssemblyImport::EnumManifestResources"
helpviewer_keywords: 
  - "IMetaDataAssemblyImport::EnumManifestResources method [.NET Framework metadata]"
  - "EnumManifestResources method [.NET Framework metadata]"
ms.assetid: 9543b111-5705-40c9-935c-a3ffc7a581aa
topic_type: 
  - "apiref"
---
# IMetaDataAssemblyImport::EnumManifestResources Method

Gets a pointer to an enumerator for the resources referenced in the current assembly manifest.  
  
## Syntax  
  
```cpp  
HRESULT EnumManifestResources (  
    [in, out] HCORENUM         *phEnum,
    [out] mdManifestResource   rManifestResources[],
    [in]  ULONG                cMax,
    [out] ULONG                *pcTokens  
);
```  
  
## Parameters  

 `phEnum`  
 [in, out] A pointer to the enumerator. This must be a null value when the `EnumManifestResources` method is called for the first time.  
  
 `rManifestResources`  
 [out] The array used to store the `mdManifestResource` metadata tokens.  
  
 `cMax`  
 [in] The maximum number of `mdManifestResource` tokens that can be placed in `rManifestResources`.  
  
 `pcTokens`  
 [out] The number of `mdManifestResource` tokens actually placed in `rManifestResources`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|`EnumManifestResources` returned successfully.|  
|`S_FALSE`|There are no tokens to enumerate. In this case, `pcTokens` is set to zero.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataAssemblyImport Interface](imetadataassemblyimport-interface.md)
