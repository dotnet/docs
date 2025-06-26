---
description: "Learn more about: IXCLRDataTypeDefinition::GetCorElementType Method"
title: "IXCLRDataTypeDefinition::GetCorElementType Method"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataTypeDefinition::GetCorElementType Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataTypeDefinition::GetCorElementType Method"
helpviewer.keywords:
  - "IXCLRDataTypeDefinition::GetCorElementType Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataTypeDefinition::GetCorElementType Method

Gets the standard element type of this type definition.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetCorElementType(
    [out] CorElementType *type
);
```

## Parameters

`type`\
[out] The standard element type of this type definition.

## Remarks

The provided method is part of the `IXCLRDataTypeDefinition` interface and corresponds to the 17th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataTypeDefinition Interface](ixclrdatatypedefinition-interface.md)
- [CorElementType Enumeration](../../../core/unmanaged-api/metadata/corelementtype-enumeration.md)
