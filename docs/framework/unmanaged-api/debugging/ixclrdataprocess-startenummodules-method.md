---
title: "IXCLRDataProcess::StartEnumModules Method"
ms.date: "01/16/2019"
api.name:
  - "IXCLRDataProcess::StartEnumModules Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess::StartEnumModules Method"
helpviewer.keywords:
  - "IXCLRDataProcess::StartEnumModules Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataProcess::StartEnumModules Method

Provides a handle to enumerate the modules of a process.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```
HRESULT StartEnumModules(
    [out] CLRDATA_ENUM *handle
);
```

## Parameters

`handle`\
[out] A handle for enumerating the modules.

## Remarks

The provided method is part of the `IXCLRDataProcess` interface and corresponds to the 24th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [CLRDataSourceType Enumeration](clrdatasourcetype-enumeration.md)
- [Debugging](index.md)
- [IXCLRDataProcess Interface](ixclrdataprocess-interface.md)
