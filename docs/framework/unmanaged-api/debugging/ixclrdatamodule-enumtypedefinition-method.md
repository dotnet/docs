---
description: "Learn more about: IXCLRDataModule::EnumTypeDefinition Method"
title: "IXCLRDataModule::EnumTypeDefinition Method"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataModule::EnumTypeDefinition Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataModule::EnumTypeDefinition Method"
helpviewer.keywords:
  - "IXCLRDataModule::EnumTypeDefinition Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataModule::EnumTypeDefinition Method

Enumerates type definitions associated with the module.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT EnumTypeDefinition(
    [in, out] CLRDATA_ENUM *handle,
    [out] IXCLRDataTypeDefinition **typeDefinition
);
```

## Parameters

`handle`\
[in, out] A handle for enumerating type definitions associated with the module.

`typeDefinition`\
[out] The enumerated type definition.

## Remarks

The provided method is part of the `IXCLRDataModule` interface and corresponds to the 8th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataModule Interface](ixclrdatamodule-interface.md)
- [IXCLRDataTypeDefinition Interface](ixclrdatatypedefinition-interface.md)
- [IXCLRDataModule::StartEnumTypeDefinitions Method](ixclrdatamodule-startenumtypedefinitions-method.md)
- [IXCLRDataModule::EndEnumTypeDefinitions Method](ixclrdatamodule-endenumtypedefinitions-method.md)
