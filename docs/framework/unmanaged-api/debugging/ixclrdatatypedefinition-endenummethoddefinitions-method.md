---
description: "Learn more about: IXCLRDataTypeDefinition::EndEnumMethodDefinitions Method"
title: "IXCLRDataTypeDefinition::EndEnumMethodDefinitions Method"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataTypeDefinition::EndEnumMethodDefinitions Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataTypeDefinition::EndEnumMethodDefinitions Method"
helpviewer.keywords:
  - "IXCLRDataTypeDefinition::EndEnumMethodDefinitions Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataTypeDefinition::EndEnumMethodDefinitions Method

Releases the resources used by internal iterators used during method definition enumeration.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT EndEnumMethodDefinitions(
    [in] CLRDATA_ENUM handle
);
```

## Parameters

`handle`\
[in] A handle for enumerating the method definitions within the type.

## Remarks

The provided method is part of the `IXCLRDataTypeDefinition` interface and corresponds to the 7th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataTypeDefinition Interface](ixclrdatatypedefinition-interface.md)
- [IXCLRDataMethodDefinition Interface](ixclrdatamethoddefinition-interface.md)
- [IXCLRDataTypeDefinition::StartEnumMethodDefinitions Method](ixclrdatatypedefinition-startenummethoddefinitions-method.md)
- [IXCLRDataTypeDefinition::EnumMethodDefinitions Method](ixclrdatatypedefinition-enummethoddefinition-method.md)
