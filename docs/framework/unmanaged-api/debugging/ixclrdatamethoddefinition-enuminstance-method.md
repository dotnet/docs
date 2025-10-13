---
description: "Learn more about: IXCLRDataMethodDefinition::EnumInstance Method"
title: "IXCLRDataMethodDefinition::EnumInstance Method"
ms.date: "01/16/2019"
api.name:
  - "IXCLRDataMethodDefinition::EnumInstance Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataMethodDefinition::EnumInstance Method"
helpviewer.keywords:
  - "IXCLRDataMethodDefinition::EnumInstance Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
---
# IXCLRDataMethodDefinition::EnumInstance Method

Enumerates the instances of this method definition.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT EnumInstance(
    [in, out] CLRDATA_ENUM         *handle,
    [out] IXCLRDataMethodInstance **instance
);
```

## Parameters

`handle`\
[in, out] A handle for enumerating the instances.

`instance`\
[out] The enumerated instance.

## Remarks

The provided method is part of the `IXCLRDataMethodDefinition` interface and corresponds to the 6th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [CLRDataSourceType Enumeration](clrdatasourcetype-enumeration.md)
- [Debugging](index.md)
- [IXCLRDataMethodDefinition Interface](ixclrdatamethoddefinition-interface.md)
- [IXCLRDataMethodInstance Interface](ixclrdatamethodinstance-interface.md)
