---
title: "ICorDebugFrameEnum::Next Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugFrameEnum.Next"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFrameEnum::Next"
helpviewer_keywords: 
  - "ICorDebugFrameEnum::Next method [.NET Framework debugging]"
  - "Next method, ICorDebugFrameEnum interface [.NET Framework debugging]"
ms.assetid: 0bc96acb-6179-4328-a447-cda562ce9e98
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugFrameEnum::Next Method
Gets the specified number of ICorDebugFrame instances, starting at the current position.  
  
## Syntax  
  
```cpp  
HRESULT Next (  
    [in] ULONG  celt,  
    [out, size_is(celt), length_is(*pceltFetched)]  
        ICorDebugFrame *frames[],  
    [out] ULONG *pceltFetched  
);  
```  
  
## Parameters  
 `celt`  
 [in] The number of `ICorDebugFrame` instances to be retrieved.  
  
 `frames`  
 [out] An array of pointers, each of which points to an `ICorDebugFrame` object.  
  
 `pceltFetched`  
 [out] A pointer to the number of `ICorDebugFrame` instances actually returned. This value may be null if `celt` is one.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
