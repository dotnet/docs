---
description: "Learn more about: DacpObjectType Enumeration"
title: "DacpObjectType Enumeration"
ms.date: "07/30/2026"
api_name:
  - "DacpObjectType"
api_location:
  - "mscordacwks.dll"
api_type:
  - "COM"
f1_keywords:
  - "DacpObjectType"
helpviewer_keywords:
  - "DacpObjectType enumeration [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpObjectType Enumeration

Indicates the type of runtime object.

## Syntax

```cpp
enum DacpObjectType { OBJ_STRING=0,OBJ_FREE,OBJ_OBJECT,OBJ_ARRAY,OBJ_OTHER };
```

## Members

| Member | Description |
| ------ | ----------- |
| `OBJ_STRING` | The object is a string. |
| `OBJ_FREE` | The object is free space on the managed heap. |
| `OBJ_OBJECT` | The object is a non-array object. |
| `OBJ_ARRAY` | The object is an array. |
| `OBJ_OTHER` | The object is another object type. |

## Remarks

This enumeration lives inside the runtime and is not exposed through any headers or library files. To use it, define the enumeration as specified above.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging Enumerations](debugging-enumerations.md)
- [Debugging](index.md)
- [DacpObjectData Structure](dacpobjectdata-structure.md)
