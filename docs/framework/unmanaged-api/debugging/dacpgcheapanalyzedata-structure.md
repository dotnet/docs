---
description: "Learn more about: DacpGcHeapAnalyzeData Structure"
title: "DacpGcHeapAnalyzeData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpGcHeapAnalyzeData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpGcHeapAnalyzeData Structure"
helpviewer.keywords:
  - "DacpGcHeapAnalyzeData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpGcHeapAnalyzeData Structure

Defines a transport buffer for garbage collection heap analysis information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpGcHeapAnalyzeData
    : ZeroInit<DacpGcHeapAnalyzeData>
{
    CLRDATA_ADDRESS heapAddr; // Only filled in in server mode, otherwise NULL

    CLRDATA_ADDRESS internal_root_array;
    ULONG64         internal_root_array_index;
    BOOL            heap_analyze_success;

    // Use this for workstation mode (DacpGcHeapDat.bServerMode==FALSE).
    HRESULT Request(ISOSDacInterface *sos)
    {
        return sos->GetHeapAnalyzeStaticData(this);   
    }

    // Use this for Server mode, as there are multiple heaps,
    // and you need to pass a heap address in addr.
    HRESULT Request(ISOSDacInterface *sos, CLRDATA_ADDRESS addr)
    {
        return sos->GetHeapAnalyzeData(addr, this);
    }
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `heapAddr` | The address of the GC heap. This member is filled only in server mode; otherwise, it is `NULL`. |
| `internal_root_array` | The address of the internal root array. |
| `internal_root_array_index` | The index into the internal root array. |
| `heap_analyze_success` | A value that indicates whether heap analysis succeeded. |
| `Request` | Populates the structure by calling `ISOSDacInterface::GetHeapAnalyzeStaticData` or `ISOSDacInterface::GetHeapAnalyzeData`. |

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
