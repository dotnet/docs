---
description: "Learn more about: DacpThreadLocalModuleData Structure"
title: "DacpThreadLocalModuleData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpThreadLocalModuleData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpThreadLocalModuleData Structure"
helpviewer.keywords:
  - "DacpThreadLocalModuleData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpThreadLocalModuleData Structure

Defines a transport buffer for thread-local module information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpThreadLocalModuleData : ZeroInit<DacpThreadLocalModuleData>
{
    // These two parameters are used as input params when calling the
    // no-argument form of Request below.
    CLRDATA_ADDRESS threadAddr;
    ULONG64 ModuleIndex;
    
    CLRDATA_ADDRESS pClassData;   
    CLRDATA_ADDRESS pDynamicClassTable;   
    CLRDATA_ADDRESS pGCStaticDataStart;
    CLRDATA_ADDRESS pNonGCStaticDataStart;
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `threadAddr` | The address of the thread used as an input parameter for a request. |
| `ModuleIndex` | The module index used as an input parameter for a request. |
| `pClassData` | The address of the class data. |
| `pDynamicClassTable` | The address of the dynamic class table. |
| `pGCStaticDataStart` | The start address for garbage-collected static data. |
| `pNonGCStaticDataStart` | The start address for non-garbage-collected static data. |

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
