---
description: "Learn more about: IXCLRDataProcess::EnumModule Method"
title: "IXCLRDataProcess::EnumModule Method"
ms.date: "01/16/2019"
api.name:
  - "IXCLRDataProcess::EnumModule Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess::EnumModule Method"
helpviewer.keywords:
  - "IXCLRDataProcess::EnumModule Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataProcess::EnumModule Method

Enumerates the modules of this process.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT EnumModule(
    [in, out] CLRDATA_ENUM  *handle,
    [out] IXCLRDataModule  **mod
);
```

## Parameters

`handle`\
[in, out] A handle for enumerating the modules.

`mod`\
[out] The enumerated module.

## Remarks

The provided method is part of the `IXCLRDataProcess` interface and corresponds to the 25th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [CLRDataSourceType Enumeration](clrdatasourcetype-enumeration.md)
- [Debugging](index.md)
- [IXCLRDataModule Interface](ixclrdatamodule-interface.md)
- [IXCLRDataProcess Interface](ixclrdataprocess-interface.md)
