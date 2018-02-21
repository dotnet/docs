---
title: "ICorDebugCodeEnum::Next Method"
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
  - "ICorDebugCodeEnum.Next"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugCodeEnum::Next"
helpviewer_keywords: 
  - "ICorDebugCodeEnum::Next method [.NET Framework debugging]"
  - "Next method, ICorDebugEnum interface [.NET Framework debugging]"
ms.assetid: 644ece86-384d-4c63-9fba-52c789616ff7
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugCodeEnum::Next Method
Gets the specified number of "ICorDebugCode" instances from the enumeration, starting at the current position.  
  
## Syntax  
  
```  
HRESULT Next (  
    [in] ULONG  celt,  
    [out, size_is(celt), length_is(*pceltFetched)]  
        ICorDebugCode *values[],  
    [out] ULONG *pceltFetched  
);  
```  
  
#### Parameters  
 `celt`  
 [in] The number of `ICorDebugCode` instances to be retrieved.  
  
 `values`  
 [out] An array of pointers, each of which points to an `ICorDebugCode` object.  
  
 `pceltFetched`  
 [out] A pointer to the number of `ICorDebugCode` instances actually returned. This value may be null if `celt` is one.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
    
 
