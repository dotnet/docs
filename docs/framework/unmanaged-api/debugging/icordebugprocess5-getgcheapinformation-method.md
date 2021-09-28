---
description: "Learn more about: ICorDebugProcess5::GetGCHeapInformation Method"
title: "ICorDebugProcess5::GetGCHeapInformation Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugProcess5.GetGCHeapInformation"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess5::GetGCHeapInformation"
helpviewer_keywords: 
  - "ICorDebugProcess5::GetGCHeapInformation method [.NET Framework debugging]"
  - "GetGCHeapInformation method, ICorDebugProcess5 interface [.NET Framework debugging]"
ms.assetid: b9538ceb-230a-4079-9cb2-903dbf5c1848
topic_type: 
  - "apiref"
---
# ICorDebugProcess5::GetGCHeapInformation Method

Provides general information about the garbage collection heap, including whether it is currently enumerable.  
  
## Syntax  
  
```cpp  
HRESULT GetGCHeapInformation(  
    [out] COR_HEAPINFO *pHeapInfo  
);  
```  
  
## Parameters  

 `pHeapInfo`  
 [out] A pointer to a [COR_HEAPINFO](cor-heapinfo-structure.md) value that provides general information about the garbage collection heap.  
  
## Remarks  

 The `ICorDebugProcess5::GetGCHeapInformation` method must be called before enumerating the heap or individual heap regions to ensure that the garbage collection structures in the process are currently valid. The garbage collection heap cannot be walked while a collection is in progress. Otherwise, the enumeration may capture garbage collection structures that are invalid.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorDebugProcess5 Interface](icordebugprocess5-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
