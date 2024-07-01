---
description: "Learn more about: IXCLRDataModule::StartEnumExtents Method"
title: "IXCLRDataModule::StartEnumExtents Method"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataModule::StartEnumExtents Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataModule::StartEnumExtents Method"
helpviewer.keywords:
  - "IXCLRDataModule::StartEnumExtents Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataModule::StartEnumExtents Method

Provides a handle for the enumeration of memory regions associated with the module.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT StartEnumExtents(
    [out] CLRDATA_ENUM *handle
);
```

## Parameters

`handle`\
[out] A handle for enumerating the memory regions associated with the module.

## Remarks

The provided method is part of the `IXCLRDataModule` interface and corresponds to the 34th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [IXCLRDataModule Interface](ixclrdatamodule-interface.md)
- [IXCLRDataModule::EnumExtent Method](ixclrdatamodule-enumextent-method.md)
- [IXCLRDataModule::EndEnumExtents Method](ixclrdatamodule-endenumextents-method.md)
- [CLRDATA_MODULE_EXTENT Structure](clrdata-module-extent-structure.md)
