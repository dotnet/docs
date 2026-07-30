---
description: "Learn more about: VCSHeapType Enumeration"
title: "VCSHeapType Enumeration"
ms.date: "07/30/2026"
api_name:
  - "VCSHeapType"
api_location:
  - "mscordacwks.dll"
api_type:
  - "COM"
f1_keywords:
  - "VCSHeapType"
helpviewer_keywords:
  - "VCSHeapType Enumeration [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# VCSHeapType Enumeration

Identifies a virtual call stub heap type.

## Syntax

```cpp
typedef enum VCSHeapType {IndcellHeap, LookupHeap, ResolveHeap, DispatchHeap, CacheEntryHeap};
```

## Members

| Member | Description |
| ------ | ----------- |
| `IndcellHeap` | The indirection cell heap. |
| `LookupHeap` | The lookup stub heap. |
| `ResolveHeap` | The resolve stub heap. |
| `DispatchHeap` | The dispatch stub heap. |
| `CacheEntryHeap` | The cache entry heap. |

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
