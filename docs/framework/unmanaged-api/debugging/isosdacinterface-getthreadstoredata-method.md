---
description: "Learn more about: ISOSDacInterface::GetThreadStoreData Method"
title: "ISOSDacInterface::GetThreadStoreData Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetThreadStoreData Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetThreadStoreData Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetThreadStoreData Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetThreadStoreData Method

Retrieves data about the runtime thread store.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetThreadStoreData(struct DacpThreadStoreData *data);
```

## Parameters

`data`\
[out] A pointer to a [DacpThreadStoreData structure](dacpthreadstoredata-structure.md) that receives the thread store data.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 4th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [DacpThreadStoreData Structure](dacpthreadstoredata-structure.md)
