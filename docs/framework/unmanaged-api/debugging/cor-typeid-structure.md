---
description: "Learn more about: COR_TYPEID Structure"
title: "COR_TYPEID Structure"
ms.date: "03/30/2017"
api_name: 
  - "COR_TYPEID"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_TYPEID"
helpviewer_keywords: 
  - "COR_TYPEID structure [.NET Framework debugging]"
ms.assetid: 1e172b14-ee22-4943-b3b8-3740e7bdcd2e
topic_type: 
  - "apiref"
---
# COR_TYPEID Structure

Contains a type identifier.  
  
## Syntax  
  
```cpp  
typedef struct COR_TYPEID{  
    UINT64 token1;  
    UINT64 token2;  
} COR_TYPEID;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`token1`|The first token.|  
|`token2`|The second token.|  
  
## Remarks  

 The `COR_TYPEID` structure is returned by a number of debugging methods that provide information about objects to be garbage-collected. It can then be passed as an argument to other debugging methods that provide additional information about that item. For example, by enumerating an [ICorDebugHeapEnum](icordebugheapenum-interface.md) object, you can retrieve individual [COR_HEAPOBJECT](cor-heapobject-structure.md) objects that represent individual objects on the managed heap. You can then pass the `COR_TYPEID` value from the `COR_HEAPOBJECT.type` field to the [ICorDebugProcess5::GetTypeForTypeID](icordebugprocess5-gettypefortypeid-method.md) method to retrieve an ICorDebugType object that provides type information about the object.  
  
 A `COR_TYPEID` object is intended to be opaque. Its individual fields should not be accessed or manipulated. Its sole use is as an identifier that is provided as an `out` parameter in a method call and that can, in turn, be passed to other methods to provide additional information.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [Debugging Structures](debugging-structures.md)
- [Debugging](index.md)
