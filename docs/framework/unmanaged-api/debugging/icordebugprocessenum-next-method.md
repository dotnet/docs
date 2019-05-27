---
title: "ICorDebugProcessEnum::Next Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugProcessEnum.Next"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcessEnum::Next"
helpviewer_keywords: 
  - "Next method, ICorDebugProcessEnum interface [.NET Framework debugging]"
  - "ICorDebugProcessEnum::Next method [.NET Framework debugging]"
ms.assetid: 4ac7077c-8d88-49c4-b360-b3af0c541c63
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugProcessEnum::Next Method
Gets the specified number of ICorDebugProcess instances from the enumeration, starting at the current position.  
  
## Syntax  
  
```  
HRESULT Next (  
    [in]  ULONG celt,  
    [out, size_is(celt), length_is(*pceltFetched)]  
        ICorDebugProcess *processes[],  
    [out] ULONG *pceltFetched  
);  
```  
  
## Parameters  
 `celt`  
 [in] The number of `ICorDebugProcess` instances to be retrieved.  
  
 `processess`  
 [out] An array of pointers, each of which points to an `ICorDebugProcess` object that represents a process.  
  
 `pceltFetched`  
 [out] Pointer to the number of `ICorDebugProcess` instances actually returned. This value may be null if `celt` is one.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
