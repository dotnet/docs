---
description: "Learn more about: COR_HEAPINFO Structure"
title: "COR_HEAPINFO Structure"
ms.date: "03/30/2017"
api_name: 
  - "COR_HEAPINFO"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_HEAPINFO"
helpviewer_keywords: 
  - "COR_HEAPINFO structure [.NET Framework debugging]"
ms.assetid: bfb2cd39-3e0b-4d51-ba0c-f009755c1456
topic_type: 
  - "apiref"
---
# COR_HEAPINFO Structure

Provides general information about the garbage collection heap, including whether it is enumerable.  
  
## Syntax  
  
```cpp  
typedef struct _COR_HEAPINFO {  
    BOOL areGCStructuresValid;
    DWORD pointerSize;
    DWORD numHeaps;  
    BOOL concurrent;
    CorDebugGCType gcType;
} COR_HEAPINFO;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`areGCStructuresValid`|`true` if garbage collection structures are valid and the heap can be enumerated; otherwise, `false`.|  
|`pointerSize`|The size, in bytes, of pointers on the target architecture.|  
|`numHeaps`|The number of logical garbage collection heaps in the process.|  
|`concurrent`|`TRUE` if concurrent (background) garbage collection is enabled; otherwise, `FALSE`.|  
|`gcType`|A member of the [CorDebugGCType](cordebuggctype-enumeration.md) enumeration that indicates whether the garbage collector is running on a workstation or a server.|  
  
## Remarks  

 An instance of the `COR_HEAPINFO` structure is returned by calling the [ICorDebugProcess5::GetGCHeapInformation](icordebugprocess5-getgcheapinformation-method.md) method.  
  
 Before enumerating objects on the garbage collection heap, you must always check the `areGCStructuresValid` field to ensure that the heap is in an enumerable state. For more information, see the [ICorDebugProcess5::GetGCHeapInformation](icordebugprocess5-getgcheapinformation-method.md) method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [Debugging Structures](debugging-structures.md)
- [Debugging](index.md)
