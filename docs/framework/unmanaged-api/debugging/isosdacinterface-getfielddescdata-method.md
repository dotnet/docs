---
description: "Learn more about: ISOSDacInterface::GetFieldDescData Method"
title: "ISOSDacInterface::GetFieldDescData Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetFieldDescData Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetFieldDescData Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetFieldDescData Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetFieldDescData Method

Gets data for a FieldDesc address.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetFieldDescData(CLRDATA_ADDRESS fieldDesc, struct DacpFieldDescData *data);
```

## Parameters

`fieldDesc`\
[in] The address of the FieldDesc.

`data`\
[out] A pointer to a [DacpFieldDescData structure](dacpfielddescdata-structure.md) that receives the FieldDesc data.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 43rd slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [DacpFieldDescData Structure](dacpfielddescdata-structure.md)
