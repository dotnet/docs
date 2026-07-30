---
description: "Learn more about: DacpGcHeapDetails Structure"
title: "DacpGcHeapDetails Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpGcHeapDetails Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpGcHeapDetails Structure"
helpviewer.keywords:
  - "DacpGcHeapDetails Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpGcHeapDetails Structure

Defines a transport buffer for detailed garbage collection heap information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
#define DAC_NUMBERGENERATIONS 4

struct DacpGcHeapDetails : ZeroInit<DacpGcHeapDetails>
{
    CLRDATA_ADDRESS heapAddr; // Only filled in in server mode, otherwise NULL
    CLRDATA_ADDRESS alloc_allocated;

    CLRDATA_ADDRESS mark_array;
    CLRDATA_ADDRESS current_c_gc_state;
    CLRDATA_ADDRESS next_sweep_obj;
    CLRDATA_ADDRESS saved_sweep_ephemeral_seg;
    CLRDATA_ADDRESS saved_sweep_ephemeral_start;
    CLRDATA_ADDRESS background_saved_lowest_address;
    CLRDATA_ADDRESS background_saved_highest_address;

    DacpGenerationData generation_table [DAC_NUMBERGENERATIONS]; 
    CLRDATA_ADDRESS ephemeral_heap_segment;        
    CLRDATA_ADDRESS finalization_fill_pointers [DAC_NUMBERGENERATIONS + 3];
    CLRDATA_ADDRESS lowest_address;
    CLRDATA_ADDRESS highest_address;
    CLRDATA_ADDRESS card_table;

    // Use this for workstation mode (DacpGcHeapDat.bServerMode==FALSE).
    HRESULT Request(ISOSDacInterface *sos)
    {
        return sos->GetGCHeapStaticData(this);
    }

    // Use this for Server mode, as there are multiple heaps,
    // and you need to pass a heap address in addr.
    HRESULT Request(ISOSDacInterface *sos, CLRDATA_ADDRESS addr)
    {
        return sos->GetGCHeapDetails(addr, this);
    }
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `heapAddr` | The address of the GC heap. This member is filled only in server mode; otherwise, it is `NULL`. |
| `alloc_allocated` | The current allocation pointer for the heap. |
| `mark_array` | The address of the mark array. |
| `current_c_gc_state` | The address of the current compacting GC state. |
| `next_sweep_obj` | The address of the next object to sweep. |
| `saved_sweep_ephemeral_seg` | The address of the saved ephemeral segment for a sweep. |
| `saved_sweep_ephemeral_start` | The address of the saved ephemeral sweep start. |
| `background_saved_lowest_address` | The lowest address saved for background GC state. |
| `background_saved_highest_address` | The highest address saved for background GC state. |
| `generation_table` | An array of [DacpGenerationData structures](dacpgenerationdata-structure.md) with data for each GC generation. |
| `ephemeral_heap_segment` | The address of the ephemeral heap segment. |
| `finalization_fill_pointers` | An array of finalization fill pointers. |
| `lowest_address` | The lowest address in the heap. |
| `highest_address` | The highest address in the heap. |
| `card_table` | The address of the GC card table. |
| `Request` | Populates the structure by calling `ISOSDacInterface::GetGCHeapStaticData` for workstation GC or `ISOSDacInterface::GetGCHeapDetails` for server GC. |

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
- [DacpGenerationData Structure](dacpgenerationdata-structure.md)
