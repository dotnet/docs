---
description: "Learn more about: IXCLRDataTypeInstance::StartEnumMethodInstances Method"
title: "IXCLRDataTypeInstance::StartEnumMethodInstances Method"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataTypeInstance::StartEnumMethodInstances Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataTypeInstance::StartEnumMethodInstances Method"
helpviewer.keywords:
  - "IXCLRDataTypeInstance::StartEnumMethodInstances Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataTypeInstance::StartEnumMethodInstances Method

Provides a handle for the enumeration of method instances within the type.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT StartEnumMethodInstances(
    [out] CLRDATA_ENUM *handle
);
```

## Parameters

`handle`\
[out] A handle for enumerating method instances within the type.

## Remarks

The provided method is part of the `IXCLRDataTypeInstance` interface and corresponds to the 4th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [IXCLRDataTypeInstance Interface](ixclrdatatypeinstance-interface.md)
- [IXCLRDataMethodInstance Interface](ixclrdatamethodinstance-interface.md)
- [IXCLRDataTypeInstance::EnumMethodInstance Method](ixclrdatatypeinstance-enummethodinstance-method.md)
- [IXCLRDataTypeInstance::EndEnumMethodInstances Method](ixclrdatatypeinstance-endenummethodinstances-method.md)
