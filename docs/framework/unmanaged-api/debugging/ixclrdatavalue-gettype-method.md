---
description: "Learn more about: IXCLRDataValue::GetType Method"
title: "IXCLRDataValue::GetType Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataValue::GetType Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataValue::GetType Method"
helpviewer.keywords:
  - "IXCLRDataValue::GetType Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataValue::GetType Method

Gets the type of the value.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetType(
    [out] IXCLRDataTypeInstance **typeInstance
);
```

## Parameters

`typeInstance`\
[out] The type of the value.

## Remarks

The provided method is part of the `IXCLRDataValue` interface and corresponds to the 9th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataValue Interface](ixclrdatavalue-interface.md)
- [IXCLRDataTypeInstance Interface](ixclrdatatypeinstance-interface.md)
