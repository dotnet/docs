---
description: "Learn more about: ISOSDacInterface::GetOOMStaticData Method"
title: "ISOSDacInterface::GetOOMStaticData Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetOOMStaticData Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetOOMStaticData Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetOOMStaticData Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetOOMStaticData Method

Retrieves static out-of-memory data for the garbage collector.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetOOMStaticData(struct DacpOomData *data);
```

## Parameters

`data`\
[out] A pointer to a [DacpOomData structure](dacpoomdata-structure.md) that receives the out-of-memory data.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 53rd slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [DacpOomData Structure](dacpoomdata-structure.md)
- [ISOSDacInterface::GetOOMData Method](isosdacinterface-getoomdata-method.md)
