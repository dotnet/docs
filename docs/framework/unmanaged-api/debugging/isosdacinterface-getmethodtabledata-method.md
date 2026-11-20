---
description: "Learn more about: ISOSDacInterface::GetMethodTableData Method"
title: "ISOSDacInterface::GetMethodTableData Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetMethodTableData Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetMethodTableData Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetMethodTableData Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetMethodTableData Method

Gets data for a method table.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetMethodTableData(CLRDATA_ADDRESS mt, struct DacpMethodTableData *data);
```

## Parameters

`mt`\
[in] The address of the method table.

`data`\
[out] A pointer to a [DacpMethodTableData structure](dacpmethodtabledata-structure.md) that receives the method table data.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 38th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [DacpMethodTableData Structure](dacpmethodtabledata-structure.md)
- [ISOSDacInterface::GetMethodTableSlot Method](isosdacinterface-getmethodtableslot-method.md)
- [ISOSDacInterface::GetMethodTableFieldData Method](isosdacinterface-getmethodtablefielddata-method.md)
- [ISOSDacInterface::GetMethodTableForEEClass Method](isosdacinterface-getmethodtableforeeclass-method.md)
- [ISOSDacInterface::GetFieldDescData Method](isosdacinterface-getfielddescdata-method.md)
