---
description: "Learn more about: ISOSDacInterface::GetGCHeapDetails Method"
title: "ISOSDacInterface::GetGCHeapDetails Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetGCHeapDetails Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetGCHeapDetails Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetGCHeapDetails Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetGCHeapDetails Method

Retrieves detailed information for the specified garbage collection heap.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetGCHeapDetails(CLRDATA_ADDRESS heap, struct DacpGcHeapDetails *details);
```

## Parameters

`heap`\
[in] The address of the GC heap to retrieve information for.

`details`\
[out] A pointer to a [DacpGcHeapDetails structure](dacpgcheapdetails-structure.md) that receives the heap details.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 49th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [DacpGcHeapDetails Structure](dacpgcheapdetails-structure.md)
- [ISOSDacInterface::GetGCHeapData Method](isosdacinterface-getgcheapdata-method.md)
- [ISOSDacInterface::GetGCHeapList Method](isosdacinterface-getgcheaplist-method.md)
- [ISOSDacInterface::GetGCHeapStaticData Method](isosdacinterface-getgcheapstaticdata-method.md)
- [ISOSDacInterface::GetHeapSegmentData Method](isosdacinterface-getheapsegmentdata-method.md)
