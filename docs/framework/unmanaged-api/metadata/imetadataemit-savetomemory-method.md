---
title: "IMetaDataEmit::SaveToMemory Method | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
apiname: 
  - "IMetaDataEmit.SaveToMemory"
apilocation: 
  - "mscoree.dll"
apitype: "COM"
f1_keywords: 
  - "IMetaDataEmit::SaveToMemory"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "IMetaDataEmit::SaveToMemory method [.NET Framework metadata]"
  - "SaveToMemory method [.NET Framework metadata]"
ms.assetid: d5237628-2675-45ed-a39e-65c0731b6a56
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# IMetaDataEmit::SaveToMemory Method
Saves all metadata in the current scope to the specified area of memory.  
  
## Syntax  
  
```  
HRESULT SaveToMemory (   
    [out]  void        *pbData,   
    [in]   ULONG       cbData   
);  
```  
  
#### Parameters  
 `pbData`  
 [out] The address at which to begin writing metadata.  
  
 `cbData`  
 [in] The size, in bytes, of the allocated memory.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)   
 [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)