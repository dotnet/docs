---
description: "Learn more about: DacpHeapSegmentData Structure"
title: "DacpHeapSegmentData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpHeapSegmentData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpHeapSegmentData Structure"
helpviewer.keywords:
  - "DacpHeapSegmentData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpHeapSegmentData Structure

Defines a transport buffer for garbage collection heap segment information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpHeapSegmentData
    : ZeroInit<DacpHeapSegmentData>
{
    CLRDATA_ADDRESS segmentAddr;
    CLRDATA_ADDRESS allocated;
    CLRDATA_ADDRESS committed;
    CLRDATA_ADDRESS reserved;
    CLRDATA_ADDRESS used;
    CLRDATA_ADDRESS mem;
    // pass this to request if non-null to get the next segments.
    CLRDATA_ADDRESS next;
    CLRDATA_ADDRESS gc_heap; // only filled in in server mode, otherwise NULL
    // computed field: if this is the ephemeral segment highMark includes the ephemeral generation
    CLRDATA_ADDRESS highAllocMark;

    size_t flags;
    CLRDATA_ADDRESS background_allocated;

    HRESULT Request(ISOSDacInterface *sos, CLRDATA_ADDRESS addr, const DacpGcHeapDetails& heap)
    {
        HRESULT hr = sos->GetHeapSegmentData(addr, this);

        // if this is the start segment, set highAllocMark too.
        if (SUCCEEDED(hr))
        {
            // TODO:  This needs to be put on the Dac side.
            if (this->segmentAddr == heap.generation_table[0].start_segment)
                highAllocMark = heap.alloc_allocated;
            else
                highAllocMark = allocated;
        }    
        return hr;
    }
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `segmentAddr` | The address of the heap segment. |
| `allocated` | The address of the allocated portion of the segment. |
| `committed` | The address up to which memory is committed for the segment. |
| `reserved` | The address up to which memory is reserved for the segment. |
| `used` | The address up to which memory is used for the segment. |
| `mem` | The start address of the segment memory. |
| `next` | The address of the next segment. Pass this value to `Request` if it is non-null to retrieve the next segment. |
| `gc_heap` | The address of the GC heap. This member is filled only in server mode; otherwise, it is `NULL`. |
| `highAllocMark` | The high allocation mark. If this segment is the ephemeral segment, this value includes the ephemeral generation. |
| `flags` | The heap segment flags. |
| `background_allocated` | The background GC allocated address for the segment. |
| `Request` | Populates the structure by calling `ISOSDacInterface::GetHeapSegmentData` and computes `highAllocMark`. |

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
- [DacpGcHeapDetails Structure](dacpgcheapdetails-structure.md)
