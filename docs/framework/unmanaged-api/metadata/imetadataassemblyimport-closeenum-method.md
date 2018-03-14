---
title: "IMetaDataAssemblyImport::CloseEnum Method"
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
  - "IMetaDataAssemblyImport.CloseEnum"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataAssemblyImport::CloseEnum"
helpviewer_keywords: 
  - "CloseEnum method, IMetaDataAssemblyImport interface [.NET Framework metadata]"
  - "IMetaDataAssemblyImport::CloseEnum method [.NET Framework metadata]"
ms.assetid: c9df4087-12b3-46d9-b075-9067dd7805df
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataAssemblyImport::CloseEnum Method
Releases a reference to the specified enumeration instance.  
  
## Syntax  
  
```  
void CloseEnum (  
    [in] HCORENUM     hEnum  
);  
```  
  
#### Parameters  
 `hEnum`  
 [in] The enumeration instance to be closed.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataAssemblyImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyimport-interface.md)
