---
description: "Learn more about: ISOSDacInterface::GetModule Method"
title: "ISOSDacInterface::GetModule Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetModule Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetModule Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetModule Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetModule Method

Gets an `IXCLRDataModule` interface for a module address.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetModule(CLRDATA_ADDRESS addr, IXCLRDataModule **mod);
```

## Parameters

`addr`\
[in] The address of the module.

`mod`\
[out] A pointer to the [IXCLRDataModule Interface](ixclrdatamodule-interface.md) for the module.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 13th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [IXCLRDataModule Interface](ixclrdatamodule-interface.md)
