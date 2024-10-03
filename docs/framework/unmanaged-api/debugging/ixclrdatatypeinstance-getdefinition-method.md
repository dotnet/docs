---
description: "Learn more about: IXCLRDataTypeInstance::GetDefinition Method"
title: "IXCLRDataTypeInstance::GetDefinition Method"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataTypeInstance::GetDefinition Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataTypeInstance::GetDefinition Method"
helpviewer.keywords:
  - "IXCLRDataTypeInstance::GetDefinition Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataTypeInstance::GetDefinition Method

Gets the definition corresponding to this type instance.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetDefinition(
    [out] IXCLRDataTypeDefinition **typeDefinition
);
```

## Parameters

`typeDefinition`\
[out] The definition corresponding to this type instance.

## Remarks

The provided method is part of the `IXCLRDataTypeInstance` interface and corresponds to the 19th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataTypeInstance Interface](ixclrdatatypeinstance-interface.md)
- [IXCLRDataTypeDefinition Interface](ixclrdatatypedefinition-interface.md)
