---
description: "Learn more about: IXCLRDataTypeDefinition::GetTokenAndScope Method"
title: "IXCLRDataTypeDefinition::GetTokenAndScope Method"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataTypeDefinition::GetTokenAndScope Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataTypeDefinition::GetTokenAndScope Method"
helpviewer.keywords:
  - "IXCLRDataTypeDefinition::GetTokenAndScope Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataTypeDefinition::GetTokenAndScope Method

Gets the metadata token and scope of the type definition.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetTokenAndScope(
    [out] mdTypeDef *token,
    [out] IXCLRDataModule **mod
);
```

## Parameters

`token`\
[in] The metadata token for the type definition.

`mod`\
[out] The module for which the metadata token is valid.

## Remarks

The provided method is part of the `IXCLRDataTypeDefinition` interface and corresponds to the 16th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataTypeDefinition Interface](ixclrdatatypedefinition-interface.md)
- [IXCLRDataModule Interface](ixclrdatamodule-interface.md)
