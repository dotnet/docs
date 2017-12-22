---
title: "IMetaDataAssemblyImport::EnumExportedTypes Method"
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
  - "IMetaDataAssemblyImport.EnumExportedTypes"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataAssemblyImport::EnumExportedTypes"
helpviewer_keywords: 
  - "EnumExportedTypes method [.NET Framework metadata]"
  - "IMetaDataAssemblyImport::EnumExportedTypes method [.NET Framework metadata]"
ms.assetid: e5912ed8-e4ce-438b-8ea3-d9e4c288d109
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataAssemblyImport::EnumExportedTypes Method
Enumerates the exported types referenced in the assembly manifest in the current metadata scope.  
  
## Syntax  
  
```  
HRESULT EnumExportedTypes (  
    [in, out] HCORENUM     *phEnum,   
    [out] mdExportedType   rExportedTypes[],   
    [in]  ULONG            cMax,   
    [out] ULONG            *pcTokens  
);  
```  
  
#### Parameters  
 `phEnum`  
 [in, out] A pointer to the enumerator. This must be a null value when the `EnumExportedTypes` method is called for the first time.  
  
 `rExportedTypes`  
 [out] The enumeration of `mdExportedType` metadata tokens.  
  
 `cMax`  
 [in] The maximum number of `mdExportedType` tokens that can be placed in the `rExportedTypes` array.  
  
 `pcTokens`  
 [out] The number of `mdExportedType` tokens actually placed in `rExportedTypes`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|`EnumExportedTypes` returned successfully.|  
|`S_FALSE`|There are no tokens to enumerate. In this case, `pcTokens` is set to zero.|  
  
## Requirements  
 **Platform:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataAssemblyImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyimport-interface.md)
