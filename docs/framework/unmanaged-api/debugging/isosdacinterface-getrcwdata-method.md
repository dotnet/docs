---
description: "Learn more about: ISOSDacInterface::GetRCWData Method"
title: "ISOSDacInterface::GetRCWData Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetRCWData Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetRCWData Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetRCWData Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetRCWData Method

Retrieves runtime callable wrapper (RCW) data for a COM wrapper address.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetRCWData(CLRDATA_ADDRESS addr, struct DacpRCWData *data);
```

## Parameters

`addr`\
[in] The address of the RCW to retrieve information for.

`data`\
[out] A pointer to a [DacpRCWData structure](dacprcwdata-structure.md) that receives the RCW data.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 75th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [DacpRCWData Structure](dacprcwdata-structure.md)
- [ISOSDacInterface::GetRCWInterfaces Method](isosdacinterface-getrcwinterfaces-method.md)
- [ISOSDacInterface::TraverseRCWCleanupList Method](isosdacinterface-traversercwcleanuplist-method.md)
