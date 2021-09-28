---
description: "Learn more about: ICorDebugHeapSegmentEnum::Next Method"
title: "ICorDebugHeapSegmentEnum::Next Method"
ms.date: "03/30/2017"
api_name: 
  - "Next"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugHeapSegmentEnum::Next"
helpviewer_keywords: 
  - "ICorDebugHeapSegmentEnum::Next method [.NET Framework debugging]"
  - "Next method, ICorDebugHeapSegmentEnum interface [.NET Framework debugging]"
ms.assetid: 51625fd0-7399-49c7-b22b-5dfb05451fe6
topic_type: 
  - "apiref"
---
# ICorDebugHeapSegmentEnum::Next Method

Gets the specified number of [COR_SEGMENT](cor-segment-structure.md) instances that contain information about memory regions of the managed heap.  
  
## Syntax  
  
```cpp  
HRESULT Next(  
    [in] ULONG celt,    [out, size_is(celt), length_is(*pceltFetched)] COR_SEGMENT segments[],
    [out] ULONG *pceltFetched  
);  
```  
  
## Parameters  

 celt  
 [in] The number of segments to be retrieved.  
  
 segments  
 [out] An array of pointers, each of which points to a [COR_SEGMENT](cor-segment-structure.md) object that provides information about a region of memory in the managed heap.  
  
 pceltFetched  
 [out] A pointer to the number of [COR_SEGMENT](cor-segment-structure.md) objects actually returned in `segments`. This value may be `null` if `celt` is 1.  
  
## Remarks  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorDebugHeapSegmentEnum Interface](icordebugheapsegmentenum-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
