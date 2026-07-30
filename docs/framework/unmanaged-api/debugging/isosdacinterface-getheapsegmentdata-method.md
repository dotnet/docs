---
description: "Learn more about: ISOSDacInterface::GetHeapSegmentData Method"
title: "ISOSDacInterface::GetHeapSegmentData Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetHeapSegmentData Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetHeapSegmentData Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetHeapSegmentData Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetHeapSegmentData Method

Retrieves information for the specified garbage collection heap segment.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetHeapSegmentData(CLRDATA_ADDRESS seg, struct DacpHeapSegmentData *data);
```

## Parameters

`seg`\
[in] The address of the heap segment to retrieve information for.

`data`\
[out] A pointer to a [DacpHeapSegmentData structure](dacpheapsegmentdata-structure.md) that receives the heap segment data.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 51st slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [DacpHeapSegmentData Structure](dacpheapsegmentdata-structure.md)
