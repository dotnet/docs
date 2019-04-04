---
title: "IXCLRDataModule::GetVersionId Method"
ms.date: "01/16/2019"
api.name:
  - "IXCLRDataModule::GetVersionId Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataModule::GetVersionId Method"
helpviewer.keywords:
  - "IXCLRDataModule::GetVersionId Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataModule::GetVersionId Method

Gets the module's version identifier.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```
HRESULT GetVersionId(
    [out] GUID* vid
);
```

## Parameters

`vid`\
[out] The module's version identifier.

## Remarks

The provided method is part of the `IXCLRDataModule` interface and corresponds to the 40th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [IXCLRDataModule Interface](ixclrdatamodule-interface.md)