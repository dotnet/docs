---
title: "ICorDebugEval::IsActive Method"
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
  - "ICorDebugEval.IsActive"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugEval::IsActive"
helpviewer_keywords: 
  - "IsActive method, ICorDebugEval interface [.NET Framework debugging]"
  - "ICorDebugEval::IsActive method [.NET Framework debugging]"
ms.assetid: bf2bba24-d278-43bd-b1c5-35680e748d3e
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugEval::IsActive Method
Gets a value that indicates whether this ICorDebugEval object is currently executing.  
  
## Syntax  
  
```  
HRESULT IsActive (  
    [out] BOOL              *pbActive  
);  
```  
  
#### Parameters  
 `pbActive`  
 [out] Pointer to a value that indicates whether this evaluation is active.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
