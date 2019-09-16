---
title: "ISOSDacInterface::GetModuleData Method"
ms.date: "02/01/2019"
api.name:
  - "ISOSDacInterface::GetModuleData Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetModuleData Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetModuleData Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "hoyosjs"
ms.author: "juhoyosa"
---
# ISOSDacInterface::GetModuleData Method

Fetches the data corresponding to the module loaded at a given address.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetModuleData(
    CLRDATA_ADDRESS moduleAddr,
    DacpModuleData *data
);
```

## Parameters

`moduleAddr`\
[in] The address of the module to retrieve information for.

`data`\
[out] The [DacpModuleData structure](dacpmoduledata-structure.md) to hold the information of the loaded module.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 13th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
