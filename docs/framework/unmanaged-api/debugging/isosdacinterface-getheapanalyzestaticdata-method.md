---
description: "Learn more about: ISOSDacInterface::GetHeapAnalyzeStaticData Method"
title: "ISOSDacInterface::GetHeapAnalyzeStaticData Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetHeapAnalyzeStaticData Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetHeapAnalyzeStaticData Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetHeapAnalyzeStaticData Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetHeapAnalyzeStaticData Method

Retrieves static heap analysis data for the garbage collector.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetHeapAnalyzeStaticData(struct DacpGcHeapAnalyzeData *data);
```

## Parameters

`data`\
[out] A pointer to a [DacpGcHeapAnalyzeData structure](dacpgcheapanalyzedata-structure.md) that receives the heap analysis data.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 55th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [DacpGcHeapAnalyzeData Structure](dacpgcheapanalyzedata-structure.md)
