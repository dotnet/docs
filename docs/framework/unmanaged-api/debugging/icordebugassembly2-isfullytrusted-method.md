---
title: "ICorDebugAssembly2::IsFullyTrusted Method"
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
  - "ICorDebugAssembly2.IsFullyTrusted"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAssembly2::IsFullyTrusted"
helpviewer_keywords: 
  - "ICorDebugAssembly2::IsFullyTrusted method [.NET Framework debugging]"
  - "IsFullyTrusted method [.NET Framework debugging]"
ms.assetid: 26cbd27d-12bf-444a-8197-ccd14d37dda3
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugAssembly2::IsFullyTrusted Method
Gets a value that indicates whether the assembly has been granted full trust by the runtime security system.  
  
## Syntax  
  
```  
HRESULT IsFullyTrusted(  
    [out] BOOL *pbFullyTrusted  
);  
```  
  
#### Parameters  
 `pbFullyTrusted`  
 [out] `true` if the assembly has been granted full trust by the runtime security system; otherwise, `false`.  
  
## Remarks  
 This method returns an HRESULT of CORDBG_E_NOTREADY if the security policy for the assembly has not yet been resolved, that is, if no code in the assembly has been run yet.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
