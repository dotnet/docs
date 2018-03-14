---
title: "ICorDebugValueEnum::Next Method"
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
  - "ICorDebugValueEnum.Next"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugValueEnum::Next"
helpviewer_keywords: 
  - "ICorDebugValueEnum::Next method [.NET Framework debugging]"
  - "Next method, ICorDebugValueEnum interface [.NET Framework debugging]"
ms.assetid: f5ef94dd-dfee-49d3-a398-b110f8906dd8
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugValueEnum::Next Method
Gets the specified number of "ICorDebugValue" instances from the enumeration, starting at the current position.  
  
## Syntax  
  
```  
HRESULT Next (  
    [in]  ULONG  celt,  
    [out, size_is(celt), length_is(*pceltFetched)]  
        ICorDebugValue *values[],  
    [out] ULONG *pceltFetched  
);  
```  
  
#### Parameters  
 `celt`  
 [in] The number of `ICorDebugValue` instances to be retrieved.  
  
 `values`  
 [out] An array of pointers, each of which points to an `ICorDebugValue` object.  
  
 `pceltFetched`  
 [out] Pointer to the number of `ICorDebugValue` instances actually returned. This value may be null if `celt` is one.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
    
 
