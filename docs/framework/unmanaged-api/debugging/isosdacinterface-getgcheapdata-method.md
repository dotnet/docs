---
description: "Learn more about: ISOSDacInterface::GetGCHeapData Method"
title: "ISOSDacInterface::GetGCHeapData Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetGCHeapData Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetGCHeapData Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetGCHeapData Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetGCHeapData Method

Retrieves general information about the garbage-collected heap.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetGCHeapData(struct DacpGcHeapData *data);
```

## Parameters

`data`\
[out] A pointer to a [DacpGcHeapData structure](dacpgcheapdata-structure.md) that receives the GC heap data.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 47th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [DacpGcHeapData Structure](dacpgcheapdata-structure.md)
