---
description: "Learn more about: ISOSDacInterface::GetTLSIndex Method"
title: "ISOSDacInterface::GetTLSIndex Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetTLSIndex Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetTLSIndex Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetTLSIndex Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetTLSIndex Method

Retrieves the thread-local storage index used by the runtime.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetTLSIndex(unsigned long *pIndex);
```

## Parameters

`pIndex`\
[out] A pointer to the thread-local storage index used by the runtime.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 73rd slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  


## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
