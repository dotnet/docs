---
description: "Learn more about: COR_TYPE_LAYOUT Structure"
title: "COR_TYPE_LAYOUT Structure"
ms.date: "03/30/2017"
api_name: 
  - "COR_TYPE_LAYOUT"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_TYPE_LAYOUT"
helpviewer_keywords: 
  - "COR_TYPE_LAYOUT structure [.NET Framework debugging]"
ms.assetid: 43a7addd-f25a-4049-9907-abec3eb17af2
topic_type: 
  - "apiref"
---
# COR_TYPE_LAYOUT Structure

Provides information about the layout of an object in memory.  
  
## Syntax  
  
```cpp  
typedef struct COR_TYPE_LAYOUT {  
    COR_TYPEID parentID;  
    ULONG32 objectSize;  
    ULONG32 numFields;  
    ULONG32 boxOffset;  
    CorElementType type;  
} COR_TYPE_LAYOUT;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`parentID`|The identifier of the parent type to this type. This will be the NULL type id (token1= 0, token2 = 0) if the type id corresponds to <xref:System.Object?displayProperty=nameWithType>.|  
|`objectSize`|The base size of an object of this type. This is the total size for non-variable sized objects.|  
|`numFields`|The number of fields included in objects of this type.|  
|`boxOffset`|If this type is boxed, the beginning offset of an object's fields. This field is valid only for value types such as primitives and structures.|  
|`type`|The CorElementType to which this type belongs.|  
  
## Remarks  

 If `numFields` is greater than zero, you can call the [ICorDebugProcess5::GetTypeFields](icordebugprocess5-gettypefields-method.md) method to obtain information about the fields in this type. If `type` is `ELEMENT_TYPE_STRING`, `ELEMENT_TYPE_ARRAY`, or `ELEMENT_TYPE_SZARRAY`, the size of objects of this type is variable, and you can pass the [COR_TYPEID](cor-typeid-structure.md) structure to the [ICorDebugProcess5::GetArrayLayout](icordebugprocess5-getarraylayout-method.md) method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [Debugging Structures](debugging-structures.md)
- [Debugging](index.md)
