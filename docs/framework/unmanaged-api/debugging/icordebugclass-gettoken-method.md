---
title: "ICorDebugClass::GetToken Method"
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
  - "ICorDebugClass.GetToken"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugClass::GetToken"
helpviewer_keywords: 
  - "GetToken method, ICorDebugClass interface [.NET Framework debugging]"
  - "ICorDebugClass::GetToken method [.NET Framework debugging]"
ms.assetid: ee5c848a-eac4-4462-b07a-07ccd76a75df
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugClass::GetToken Method
Gets the `TypeDef` metadata token that references the definition of this class.  
  
## Syntax  
  
```  
HRESULT GetToken (  
    [out] mdTypeDef          *pTypeDef  
);  
```  
  
#### Parameters  
 `pTypeDef`  
 [out] A pointer to an `mdTypeDef` token that references the definition of this class.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Interfaces](../../../../docs/framework/unmanaged-api/metadata/metadata-interfaces.md)
