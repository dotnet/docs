---
title: "IMetaDataAssemblyImport::EnumManifestResources Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
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
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataAssemblyImport::EnumManifestResources Method
Gets a pointer to an enumerator for the resources referenced in the current assembly manifest.  
  
## Syntax  
  
```  
HRESULT EnumManifestResources (  
    [in, out] HCORENUM         *phEnum,   
    [out] mdManifestResource   rManifestResources[],   
    [in]  ULONG                cMax,   
    [out] ULONG                *pcTokens  
);   
```  
  
#### Parameters  
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
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataAssemblyImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyimport-interface.md)
