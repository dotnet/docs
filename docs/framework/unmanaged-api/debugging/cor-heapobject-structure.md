---
description: "Learn more about: COR_HEAPOBJECT Structure"
title: "COR_HEAPOBJECT Structure"
ms.date: "03/30/2017"
api_name: 
  - "COR_HEAPOBJECT"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_HEAPOBJECT"
helpviewer_keywords: 
  - "COR_HEAPOBJECT structure [.NET Framework debugging]"
ms.assetid: a92fdf95-492b-49ae-a741-2186e5c1d7c5
topic_type: 
  - "apiref"
---
# COR_HEAPOBJECT Structure

Provides information about an object on the managed heap.  
  
## Syntax  
  
```cpp  
typedef struct _COR_HEAPOBJECT {  
    CORDB_ADDRESS address;
    ULONG64 size;
    COR_TYPEID type;
} COR_HEAPOBJECT;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`address`|The address of the object in memory.|  
|`size`|The total size of the object, in bytes.|  
|`type`|A [COR_TYPEID](cor-typeid-structure.md) token that represents the type of the object.|  
  
## Remarks  

 `COR_HEAPOBJECT` instances can be retrieved by enumerating an [ICorDebugHeapEnum](icordebugheapenum-interface.md) interface object that is populated by calling the [ICorDebugProcess5::EnumerateHeap](icordebugprocess5-enumerateheap-method.md) method.  
  
 A `COR_HEAPOBJECT` instance provides information either about a live object on the managed heap, or about an object that is not rooted by any object but has not yet been collected by the garbage collector.  
  
 For better performance, the `COR_HEAPOBJECT.address` field is a `CORDB_ADDRESS` value rather than the ICorDebugValue interface value used in much of the debugging API. To obtain an ICorDebugValue object for a given object address, you can pass the `CORDB_ADDRESS` value to the [ICorDebugProcess5::GetObject](icordebugprocess5-getobject-method.md) method.  
  
 For better performance, the `COR_HEAPOBJECT.type` field is a `COR_TYPEID` value rather than the ICorDebugType interface value used in much of the debugging API. To obtain an ICorDebugType object for a given type ID, you can pass the `COR_TYPEID` value to the [ICorDebugProcess5::GetTypeForTypeID](icordebugprocess5-gettypefortypeid-method.md) method.  
  
 The `COR_HEAPOBJECT` structure includes a reference-counted COM interface. If you retrieve a `COR_HEAPOBJECT` instance from the enumerator by calling the [ICorDebugHeapEnum::Next](icordebugheapenum-next-method.md) method, you must subsequently release the reference.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [Debugging Structures](debugging-structures.md)
- [Debugging](index.md)
