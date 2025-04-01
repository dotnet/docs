---
description: "Learn more about: IXCLRDataMethodInstance::GetDefinition Method"
title: "IXCLRDataMethodInstance::GetDefinition Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataMethodInstance::GetDefinition Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataMethodInstance::GetDefinition Method"
helpviewer.keywords:
  - "IXCLRDataMethodInstance::GetDefinition Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataMethodInstance::GetDefinition Method

Gets the method definition which matches this method instance.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetDefinition(
    [out] IXCLRDataMethodDefinition **methodDefinition
);
```

## Parameters

`methodDefinition`\
[out] The method definition which matches this method instance.

## Remarks

The provided method is part of the `IXCLRDataMethodInstance` interface and corresponds to the 5th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataMethodInstance Interface](ixclrdatamethodinstance-interface.md)
- [IXCLRDataMethodDefinition Interface](ixclrdatamethoddefinition-interface.md)
