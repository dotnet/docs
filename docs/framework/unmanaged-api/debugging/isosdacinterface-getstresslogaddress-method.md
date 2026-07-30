---
description: "Learn more about: ISOSDacInterface::GetStressLogAddress Method"
title: "ISOSDacInterface::GetStressLogAddress Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetStressLogAddress Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetStressLogAddress Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetStressLogAddress Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetStressLogAddress Method

Retrieves the address of the runtime stress log.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetStressLogAddress(CLRDATA_ADDRESS *stressLog);
```

## Parameters

`stressLog`\
[out] A pointer to the address of the runtime stress log.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 67th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  


## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
