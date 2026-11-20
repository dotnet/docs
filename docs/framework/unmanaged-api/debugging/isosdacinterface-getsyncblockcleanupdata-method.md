---
description: "Learn more about: ISOSDacInterface::GetSyncBlockCleanupData Method"
title: "ISOSDacInterface::GetSyncBlockCleanupData Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetSyncBlockCleanupData Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetSyncBlockCleanupData Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetSyncBlockCleanupData Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetSyncBlockCleanupData Method

Retrieves cleanup data for the sync block at the specified address.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetSyncBlockCleanupData(CLRDATA_ADDRESS addr, struct DacpSyncBlockCleanupData *data);
```

## Parameters

`addr`\
[in] The address of the sync block cleanup data to retrieve. Pass `NULL` on the first request to start a traversal.

`data`\
[out] A pointer to a [DacpSyncBlockCleanupData structure](dacpsyncblockcleanupdata-structure.md) that receives the sync block cleanup data.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 61st slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [DacpSyncBlockCleanupData Structure](dacpsyncblockcleanupdata-structure.md)
- [ISOSDacInterface::GetSyncBlockData Method](isosdacinterface-getsyncblockdata-method.md)
