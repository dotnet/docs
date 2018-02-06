---
title: "ICorDebugChain::IsManaged Method"
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
  - "ICorDebugChain.IsManaged"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugChain::IsManaged"
helpviewer_keywords: 
  - "ICorDebugChain::IsManaged method [.NET Framework debugging]"
  - "IsManaged method, ICorDebugChain interface [.NET Framework debugging]"
ms.assetid: 17b389a0-1a4d-4e8a-8613-9bc1769930f9
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugChain::IsManaged Method
Gets a value that indicates whether this chain is running managed code.  
  
## Syntax  
  
```  
HRESULT IsManaged (  
    [out] BOOL               *pManaged  
);  
```  
  
#### Parameters  
 `pManaged`  
 [out] `true` if this chain is running managed code; otherwise, `false`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
