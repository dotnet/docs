---
title: "IMetaDataAssemblyImport::EnumFiles Method"
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
  - "IMetaDataAssemblyImport.EnumFiles"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataAssemblyImport::EnumFiles"
helpviewer_keywords: 
  - "IMetaDataAssemblyImport::EnumFiles method [.NET Framework metadata]"
  - "EnumFiles method [.NET Framework metadata]"
ms.assetid: f0d721e2-b946-426d-8e20-9124bd04e4cb
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataAssemblyImport::EnumFiles Method
Enumerates the files referenced in the current assembly manifest.  
  
## Syntax  
  
```  
HRESULT EnumFiles (  
    [in, out] HCORENUM    *phEnum,   
    [out] mdFile          rFiles[],   
    [in]  ULONG           cMax,   
    [out] ULONG           *pcTokens  
);  
```  
  
#### Parameters  
 `phEnum`  
 [in, out] A pointer to the enumerator. This must be a null value for the first call of this method.  
  
 `rFiles`  
 [out] The array used to store the `mdFile` metadata tokens.  
  
 `cMax`  
 [in] The maximum number of `mdFile` tokens that can be placed in `rFiles`.  
  
 `pcTokens`  
 [out] The number of `mdFile` tokens actually placed in `rFiles`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|`EnumFiles` returned successfully.|  
|`S_FALSE`|There are no tokens to enumerate. In this case, `pcTokens` is set to zero.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataAssemblyImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyimport-interface.md)
