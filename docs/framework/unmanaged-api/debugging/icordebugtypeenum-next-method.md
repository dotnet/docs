---
description: "Learn more about: ICorDebugTypeEnum::Next Method"
title: "ICorDebugTypeEnum::Next Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugTypeEnum.Next"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugTypeEnum::Next"
helpviewer_keywords: 
  - "ICorDebugTypeEnum::Next method [.NET Framework debugging]"
  - "Next method, ICorDebugTypeEnum interface [.NET Framework debugging]"
ms.assetid: d0fdeba3-c195-4ece-8caf-79b1f40025d2
topic_type: 
  - "apiref"
---
# ICorDebugTypeEnum::Next Method

Gets the number of "ICorDebugType" instances specified by `celt` from the enumeration, starting at the current position.  
  
## Syntax  
  
```cpp  
HRESULT Next (  
    [in]  ULONG  celt,  
    [out, size_is(celt), length_is(*pceltFetched)]  
        ICorDebugType *values[],  
    [out] ULONG *pceltFetched  
);  
```  
  
## Parameters  

 `celt`  
 [in] The number of `ICorDebugType` instances to be retrieved.  
  
 `values`  
 [out] An array of pointers, each of which points to an `ICorDebugType` object.  
  
 `pceltFetched`  
 [out] Pointer to the number of `ICorDebugType` instances actually returned. This value may be null if `celt` is one.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
