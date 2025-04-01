---
description: "Learn more about: IXCLRDataModule::EndEnumExtents Method"
title: "IXCLRDataModule::EndEnumExtents Method"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataModule::EndEnumExtents Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataModule::EndEnumExtents Method"
helpviewer.keywords:
  - "IXCLRDataModule::EndEnumExtents Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataModule::EndEnumExtents Method

Releases the resources used by internal iterators used during memory region enumeration.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT EndEnumExtents(
    [in] CLRDATA_ENUM handle
);
```

## Parameters

`handle`\
[in] A handle for enumerating the memory regions.

## Remarks

The provided method is part of the `IXCLRDataModule` interface and corresponds to the 36th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [IXCLRDataModule Interface](ixclrdatamodule-interface.md)
- [IXCLRDataModule::StartEnumExtents Method](ixclrdatamodule-startenumextents-method.md)
- [IXCLRDataModule::EnumExtent Method](ixclrdatamodule-enumextent-method.md)
- [CLRDATA_MODULE_EXTENT Structure](clrdata-module-extent-structure.md)
