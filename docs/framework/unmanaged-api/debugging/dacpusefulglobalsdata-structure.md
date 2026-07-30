---
description: "Learn more about: DacpUsefulGlobalsData Structure"
title: "DacpUsefulGlobalsData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpUsefulGlobalsData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpUsefulGlobalsData Structure"
helpviewer.keywords:
  - "DacpUsefulGlobalsData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpUsefulGlobalsData Structure

Defines a transport buffer for global runtime method table addresses.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpUsefulGlobalsData : ZeroInit<DacpUsefulGlobalsData>
{
    CLRDATA_ADDRESS ArrayMethodTable;
    CLRDATA_ADDRESS StringMethodTable;
    CLRDATA_ADDRESS ObjectMethodTable;
    CLRDATA_ADDRESS ExceptionMethodTable;
    CLRDATA_ADDRESS FreeMethodTable;
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `ArrayMethodTable` | The address of the array method table. |
| `StringMethodTable` | The address of the string method table. |
| `ObjectMethodTable` | The address of the object method table. |
| `ExceptionMethodTable` | The address of the exception method table. |
| `FreeMethodTable` | The address of the free object method table. |

## Remarks

This structure lives inside the runtime and is not exposed through any headers or library files. To use it, define the structure as specified above.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  


## See also

- [Debugging](index.md)
- [Debugging Structures](debugging-structures.md)
