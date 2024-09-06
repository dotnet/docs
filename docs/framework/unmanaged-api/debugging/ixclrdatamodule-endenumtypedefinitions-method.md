---
description: "Learn more about: IXCLRDataModule::EndEnumTypeDefinitions Method"
title: "IXCLRDataModule::EndEnumTypeDefinitions Method"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataModule::EndEnumTypeDefinitions Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataModule::EndEnumTypeDefinitions Method"
helpviewer.keywords:
  - "IXCLRDataModule::EndEnumTypeDefinitions Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataModule::EndEnumTypeDefinitions Method

Releases the resources used by internal iterators used during type definition enumeration.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT EndEnumTypeDefinitions(
    [in] CLRDATA_ENUM handle
);
```

## Parameters

`handle`\
[in] A handle for enumerating the type definitions associated with the module.

## Remarks

The provided method is part of the `IXCLRDataModule` interface and corresponds to the 9th slot of the virtual method table.

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
- [IXCLRDataModule::EnumTypeDefinition Method](ixclrdatamodule-enumtypedefinition-method.md)
