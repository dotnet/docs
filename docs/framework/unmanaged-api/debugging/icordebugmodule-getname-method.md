---
title: "ICorDebugModule::GetName Method"
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
  - "ICorDebugModule.GetName"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugModule::GetName"
helpviewer_keywords: 
  - "ICorDebugModule::GetName method [.NET Framework debugging]"
  - "GetName method, ICorDebugModule interface [.NET Framework debugging]"
ms.assetid: db499637-7ba9-421e-b8b1-35856995e80b
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugModule::GetName Method
Gets the file name of the module.  
  
## Syntax  
  
```  
HRESULT GetName(  
    [in] ULONG32 cchName,  
    [out] ULONG32 *pcchName,  
    [out, size_is(cchName), length_is(*pcchName)] WCHAR szName[]  
);  
```  
  
#### Parameters  
 `cchname`  
 [in] The size of the `szName` array.  
  
 `pcchName`  
 [in] A pointer to the length of the returned name.  
  
 `szName`  
 [out] An array that stores the returned name.  
  
## Remarks  
 The `GetName` method returns an S_OK HRESULT if the module's file name matches the name on disk. `GetName` returns an S_FALSE HRESULT if the name is fabricated, such as for a dynamic or in-memory module.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
    
 
