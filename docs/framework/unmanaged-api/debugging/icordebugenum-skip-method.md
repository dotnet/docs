---
title: "ICorDebugEnum::Skip Method"
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
  - "ICorDebugEnum.Skip"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugEnum::Skip"
helpviewer_keywords: 
  - "ICorDebugEnum::Skip method [.NET Framework debugging]"
  - "Skip method, ICorDebugEnum interface [.NET Framework debugging]"
ms.assetid: e925d88a-67a5-4f76-88b8-09cedeed0232
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugEnum::Skip Method
Moves the cursor forward in the enumeration by the specified number of items.  
  
## Syntax  
  
```  
HRESULT Skip (  
    [in] ULONG celt  
);  
```  
  
#### Parameters  
 `celt`  
 [in] The number of items by which to move the cursor forward.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorDebugEnum Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugenum-interface1.md)
