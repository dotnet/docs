---
description: "Learn more about: COR_FIELD Structure"
title: "COR_FIELD Structure"
ms.date: "03/30/2017"
api_name: 
  - "COR_FIELD"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_FIELD"
helpviewer_keywords: 
  - "COR_FIELD structure [.NET Framework debugging]"
ms.assetid: c0822423-a9df-4961-950d-50dcc152f863
topic_type: 
  - "apiref"
---
# COR_FIELD Structure

Provides information about a field in an object.  
  
## Syntax  
  
```cpp  
typedef struct COR_FIELD{  
    mdFieldDef token;  
    ULONG32 offset;  
    COR_TYPEID id;  
    CorElementType fieldType;  
} COR_FIELD;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`token`|An `mdFieldDef` token that can be used to get field information.|  
|`offset`|The offset, in bytes, to the field data in the object.|  
|`id`|A [COR_TYPEID](cor-typeid-structure.md) value that identifies the type of this field.|  
|`fieldType`|A CorElementType enumeration value that indicates the type of the field.|  
  
## Remarks  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [Debugging Structures](debugging-structures.md)
- [Debugging](index.md)
