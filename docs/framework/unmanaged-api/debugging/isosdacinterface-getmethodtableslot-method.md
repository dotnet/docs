---
description: "Learn more about: ISOSDacInterface::GetMethodTableSlot Method"
title: "ISOSDacInterface::GetMethodTableSlot Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetMethodTableSlot Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetMethodTableSlot Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetMethodTableSlot Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetMethodTableSlot Method

Gets the value of a slot in a method table.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetMethodTableSlot(CLRDATA_ADDRESS mt, unsigned int slot, CLRDATA_ADDRESS *value);
```

## Parameters

`mt`\
[in] The address of the method table.

`slot`\
[in] The method table slot index.

`value`\
[out] The value stored in the specified method table slot.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 39th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
