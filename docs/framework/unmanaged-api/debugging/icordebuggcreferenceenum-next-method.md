---
description: "Learn more about: ICorDebugGCReferenceEnum::Next Method"
title: "ICorDebugGCReferenceEnum::Next Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugGCReferenceEnum.Next"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugGCReferenceEnum::Next"
helpviewer_keywords: 
  - "Next method, ICorDebugGCReferenceEnum interface [.NET Framework debugging]"
  - "ICorDebugGCReferenceEnum::Next method [.NET Framework debugging]"
ms.assetid: 91b1345c-a94f-4ef8-9696-3823d06c6d05
topic_type: 
  - "apiref"
---
# ICorDebugGCReferenceEnum::Next Method

Gets the specified number of [COR_GC_REFERENCE](cor-gc-reference-structure.md) instances that contain information about objects that will be garbage-collected.  
  
## Syntax  
  
```cpp  
HRESULT Next(  
    [in] ULONG celt,    [out, size_is(celt), length_is(*pceltFetched)] COR_GC_REFERENCE roots[],
    [out] ULONG *pceltFetched  
);  
```  
  
## Parameters  

 celt  
 [in] The number of roots to be retrieved.  
  
 roots  
 [out] An array of pointers, each of which points to a [COR_GC_REFERENCE](cor-gc-reference-structure.md) object that represents the root of an object to be garbage-collected.  
  
 pceltFetched  
 [out] A pointer to the number of [COR_GC_REFERENCE](cor-gc-reference-structure.md) objects actually returned in `roots`. This value may be `null` if `celt` is 1.  
  
## Remarks  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorDebugGCReferenceEnum Interface](icordebuggcreferenceenum-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
