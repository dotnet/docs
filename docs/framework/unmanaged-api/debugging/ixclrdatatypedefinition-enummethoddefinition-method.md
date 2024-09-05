---
description: "Learn more about: IXCLRDataTypeDefinition::EnumMethodDefinition Method"
title: "IXCLRDataTypeDefinition::EnumMethodDefinition Method"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataTypeDefinition::EnumMethodDefinition Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataTypeDefinition::EnumMethodDefinition Method"
helpviewer.keywords:
  - "IXCLRDataTypeDefinition::EnumMethodDefinition Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataTypeDefinition::EnumMethodDefinition Method

Enumerates method definitions within the type.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT EnumMethodDefinition(
    [in, out] CLRDATA_ENUM *handle,
    [out] IXCLRDataMethodDefinition **methodDefinition
);
```

## Parameters

`handle`\
[in, out] A handle for enumerating method definitions within the type.

`methodDefinition`\
[out] The enumerated method definition.

## Remarks

The provided method is part of the `IXCLRDataTypeDefinition` interface and corresponds to the 6th slot of the virtual method table.

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
- [IXCLRDataTypeDefinition::EndEnumMethodDefinitions Method](ixclrdatatypedefinition-endenummethoddefinitions-method.md)
