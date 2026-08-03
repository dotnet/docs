---
description: "Learn more about: DacpOomData Structure"
title: "DacpOomData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpOomData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpOomData Structure"
helpviewer.keywords:
  - "DacpOomData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpOomData Structure

Defines a transport buffer for garbage collector out-of-memory information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpOomData : ZeroInit<DacpOomData>
{
    int reason;
    ULONG64 alloc_size;
    ULONG64 available_pagefile_mb;
    ULONG64 gc_index;
    int fgm;
    ULONG64 size;
    BOOL loh_p;

    HRESULT Request(ISOSDacInterface *sos)
    {
        return sos->GetOOMStaticData(this);
    }

    // Use this for Server mode, as there are multiple heaps,
    // and you need to pass a heap address in addr.
    HRESULT Request(ISOSDacInterface *sos, CLRDATA_ADDRESS addr)
    {
        return sos->GetOOMData(addr, this);
    }
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `reason` | The out-of-memory reason code. |
| `alloc_size` | The allocation size that contributed to the out-of-memory condition. |
| `available_pagefile_mb` | The amount of available page file space, in megabytes. |
| `gc_index` | The GC index associated with the out-of-memory condition. |
| `fgm` | A value associated with full GC mechanisms for the out-of-memory condition. |
| `size` | The size value associated with the out-of-memory condition. |
| `loh_p` | A value that indicates whether the allocation was for the large object heap. |
| `Request` | Populates the structure by calling `ISOSDacInterface::GetOOMStaticData` or `ISOSDacInterface::GetOOMData`. |

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
