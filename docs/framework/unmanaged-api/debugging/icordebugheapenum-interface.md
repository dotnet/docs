---
description: "Learn more about: ICorDebugHeapEnum Interface"
title: "ICorDebugHeapEnum Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugHeapEnum"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugHeapEnum"
helpviewer_keywords: 
  - "ICorDebugHeapEnum interface [.NET Framework debugging]"
ms.assetid: 99cbc1eb-d539-4f76-a0d8-b93348112f14
topic_type: 
  - "apiref"
---
# ICorDebugHeapEnum Interface

Provides an enumerator for objects on the managed heap. This interface is a subclass of the ICorDebugEnum interface.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Next Method](icordebugheapenum-next-method.md)|Gets the specified number of [COR_HEAPOBJECT](cor-heapobject-structure.md) instances that contain information about objects on the managed heap.|  
  
## Remarks  

 The `ICorDebugHeapEnum` interface implements the ICorDebugEnum interface.  
  
 An `ICorDebugHeapEnum` instance is populated with [COR_HEAPOBJECT](cor-heapobject-structure.md) instances by calling the [ICorDebugProcess5::EnumerateHeap](icordebugprocess5-enumerateheap-method.md) method. Each [COR_HEAPOBJECT](cor-heapobject-structure.md) instance in the collection represents either a live object on the heap or an object that is not rooted by any object but has not yet been collected by the garbage collector. The [COR_HEAPOBJECT](cor-heapobject-structure.md) objects in the collection can be enumerated by calling the [ICorDebugHeapEnum::Next](icordebugheapenum-next-method.md) method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
