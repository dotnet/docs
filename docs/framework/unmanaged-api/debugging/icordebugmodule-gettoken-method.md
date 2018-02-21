---
title: "ICorDebugModule::GetToken Method"
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
  - "ICorDebugModule.GetToken"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugModule::GetToken"
helpviewer_keywords: 
  - "ICorDebugModule::GetToken method [.NET Framework debugging]"
  - "GetToken method, ICorDebugModule interface [.NET Framework debugging]"
ms.assetid: f759f87a-18ae-4c1a-8300-29b803432d0a
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugModule::GetToken Method
Gets the token for the table entry for this module.  
  
## Syntax  
  
```  
HRESULT GetToken(  
    [out] mdModule *pToken  
);  
```  
  
#### Parameters  
 `pToken`  
 [out] A pointer to the `mdModule` token that references the module's metadata.  
  
## Remarks  
 The token can be passed to the [IMetaDataImport](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md), [IMetaDataImport2](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md), and [IMetaDataAssemblyImport](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyimport-interface.md) metadata import interfaces.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata](../../../../docs/framework/unmanaged-api/metadata/index.md)
