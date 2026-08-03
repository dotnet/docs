---
description: "Learn more about: DacpGenerationData Structure"
title: "DacpGenerationData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpGenerationData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpGenerationData Structure"
helpviewer.keywords:
  - "DacpGenerationData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpGenerationData Structure

Defines a transport buffer for garbage collection generation information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpGenerationData : ZeroInit<DacpGenerationData>
{    
    CLRDATA_ADDRESS start_segment;
    CLRDATA_ADDRESS allocation_start;

    // These are examined only for generation 0, otherwise NULL
    CLRDATA_ADDRESS allocContextPtr;
    CLRDATA_ADDRESS allocContextLimit;
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `start_segment` | The address of the first heap segment for the generation. |
| `allocation_start` | The address where allocation starts for the generation. |
| `allocContextPtr` | The current allocation context pointer for generation 0; otherwise `NULL`. |
| `allocContextLimit` | The allocation context limit for generation 0; otherwise `NULL`. |

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
