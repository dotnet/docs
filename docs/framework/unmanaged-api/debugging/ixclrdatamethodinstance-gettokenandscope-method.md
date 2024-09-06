---
description: "Learn more about: IXCLRDataMethodInstance::GetTokenAndScope Method"
title: "IXCLRDataMethodInstance::GetTokenAndScope Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataMethodInstance::GetTokenAndScope Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataMethodInstance::GetTokenAndScope Method"
helpviewer.keywords:
  - "IXCLRDataMethodInstance::GetTokenAndScope Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataMethodInstance::GetTokenAndScope Method

Gets the metadata token and scope of the method.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetTokenAndScope(
    [out] mdMethodDef *token,
    [out] IXCLRDataModule **mod
);
```

## Parameters

`token`\
[in] The metadata token for the method.

`mod`\
[out] The module for which the metadata token is valid.

## Remarks

The provided method is part of the `IXCLRDataMethodInstance` interface and corresponds to the 15th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataMethodInstance Interface](ixclrdatamethodinstance-interface.md)
- [IXCLRDataModule Interface](ixclrdatamodule-interface.md)
