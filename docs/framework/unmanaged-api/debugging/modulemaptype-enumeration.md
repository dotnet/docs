---
description: "Learn more about: ModuleMapType Enumeration"
title: "ModuleMapType Enumeration"
ms.date: "07/30/2026"
api_name:
  - "ModuleMapType"
api_location:
  - "mscordacwks.dll"
api_type:
  - "COM"
f1_keywords:
  - "ModuleMapType"
helpviewer_keywords:
  - "ModuleMapType enumeration [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ModuleMapType Enumeration

Indicates the kind of module map to traverse.

## Syntax

```cpp
typedef enum ModuleMapType { TYPEDEFTOMETHODTABLE, TYPEREFTOMETHODTABLE };
```

## Members

|Member|Description|
|------------|-----------------|
|`TYPEDEFTOMETHODTABLE`|The module map maps TypeDef tokens to method table addresses.|
|`TYPEREFTOMETHODTABLE`|The module map maps TypeRef tokens to method table addresses.|

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
