---
description: "Learn more about: IXCLRDataModule::StartEnumTypeDefinitions Method"
title: "IXCLRDataModule::StartEnumTypeDefinitions Method"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataModule::StartEnumTypeDefinitions Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataModule::StartEnumTypeDefinitions Method"
helpviewer.keywords:
  - "IXCLRDataModule::StartEnumTypeDefinitions Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataModule::StartEnumTypeDefinitions Method

Provides a handle for the enumeration of type definitions associated with the module.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT StartEnumTypeDefinitions(
    [out] CLRDATA_ENUM *handle
);
```

## Parameters

`handle`\
[out] A handle for enumerating type definitions associated with the module.

## Remarks

The provided method is part of the `IXCLRDataModule` interface and corresponds to the 7th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [IXCLRDataModule Interface](ixclrdatamodule-interface.md)
- [IXCLRDataTypeDefinition Interface](ixclrdatatypedefinition-interface.md)
- [IXCLRDataModule::EnumTypeDefinition Method](ixclrdatamodule-enumtypedefinition-method.md)
- [IXCLRDataModule::EndEnumTypeDefinitions Method](ixclrdatamodule-endenumtypedefinitions-method.md)
