---
description: "Learn more about: ISOSDacInterface::GetMethodTableFieldData Method"
title: "ISOSDacInterface::GetMethodTableFieldData Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetMethodTableFieldData Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetMethodTableFieldData Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetMethodTableFieldData Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetMethodTableFieldData Method

Gets field data for a method table.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetMethodTableFieldData(CLRDATA_ADDRESS mt, struct DacpMethodTableFieldData *data);
```

## Parameters

`mt`\
[in] The address of the method table.

`data`\
[out] A pointer to a [DacpMethodTableFieldData structure](dacpmethodtablefielddata-structure.md) that receives the method table field data.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 40th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [DacpMethodTableFieldData Structure](dacpmethodtablefielddata-structure.md)
