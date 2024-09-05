---
description: "Learn more about: IXCLRDataMethodInstance::StartEnumExtents Method"
title: "IXCLRDataMethodInstance::StartEnumExtents Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataMethodInstance::StartEnumExtents Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataMethodInstance::StartEnumExtents Method"
helpviewer.keywords:
  - "IXCLRDataMethodInstance::StartEnumExtents Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataMethodInstance::StartEnumExtents Method

Provides a handle for the enumeration of native code regions associated with the method.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT StartEnumExtents(
    [out] CLRDATA_ENUM *handle
);
```

## Parameters

`handle`\
[out] A handle for enumerating the native code regions associated with the method.

## Remarks

The provided method is part of the `IXCLRDataMethodInstance` interface and corresponds to the 16th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataMethodInstance Interface](ixclrdatamethodinstance-interface.md)
- [IXCLRDataMethodInstance::EnumExtent Method](ixclrdatamethodinstance-enumextent-method.md)
- [IXCLRDataMethodInstance::EndEnumExtents Method](ixclrdatamethodinstance-endenumextents-method.md)
- [CLRDATA_ADDRESS_RANGE Structure](clrdata-address-range-structure.md)
