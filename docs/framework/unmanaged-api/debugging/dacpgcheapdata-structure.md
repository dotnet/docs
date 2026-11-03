---
description: "Learn more about: DacpGcHeapData Structure"
title: "DacpGcHeapData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpGcHeapData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpGcHeapData Structure"
helpviewer.keywords:
  - "DacpGcHeapData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpGcHeapData Structure

Defines a transport buffer for general garbage collection heap information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpGcHeapData
    : ZeroInit<DacpGcHeapData>
{
    BOOL bServerMode;
    BOOL bGcStructuresValid;
    UINT HeapCount;
    UINT g_max_generation;
    
    HRESULT Request(ISOSDacInterface *sos)
    {
        return sos->GetGCHeapData(this);
    }
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `bServerMode` | A value that indicates whether the runtime uses server GC. |
| `bGcStructuresValid` | A value that indicates whether the GC structures are valid. |
| `HeapCount` | The number of GC heaps. |
| `g_max_generation` | The maximum GC generation number. |
| `Request` | Populates the structure by calling `ISOSDacInterface::GetGCHeapData`. |

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
