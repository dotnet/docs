---
description: "Learn more about: ICorDebugObjectEnum::Next Method"
title: "ICorDebugObjectEnum::Next Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugObjectEnum.Next"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugObjectEnum::Next"
helpviewer_keywords: 
  - "Next method, ICorDebugObjectEnum interface [.NET Framework debugging]"
  - "ICorDebugObjectEnum::Next method [.NET Framework debugging]"
ms.assetid: 10093e3d-26b6-4ad7-8ef3-bbf66243fc02
topic_type: 
  - "apiref"
---
# ICorDebugObjectEnum::Next Method

Gets the relative virtual addresses (RVAs) of the specified number of objects from the enumeration, starting at the current position.  
  
## Syntax  
  
```cpp  
HRESULT Next (  
    [in] ULONG celt,  
    [out, size_is(celt), length_is(*pceltFetched)]
        CORDB_ADDRESS objects[],  
    [out] ULONG *pceltFetched  
);  
```  
  
## Parameters  

 `celt`  
 [in] The number of objects to be retrieved.  
  
 `objects`  
 [out] An array of pointers, each of which points to a CORDB_ADDRESS object.  
  
 `pceltFetched`  
 [out] Pointer to the number of objects actually returned. This value may be null if `celt` is one.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
