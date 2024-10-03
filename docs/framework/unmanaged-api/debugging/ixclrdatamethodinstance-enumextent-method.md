---
description: "Learn more about: IXCLRDataMethodInstance::EnumExtent Method"
title: "IXCLRDataMethodInstance::EnumExtent Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataMethodInstance::EnumExtent Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataMethodInstance::EnumExtent Method"
helpviewer.keywords:
  - "IXCLRDataMethodInstance::EnumExtent Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataMethodInstance::EnumExtent Method

Enumerates the native code regions associated with the method.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT EnumExtent(
    [in, out] CLRDATA_ENUM *handle,
    [out] CLRDATA_ADDRESS_RANGE *extent
);
```

## Parameters

`handle`\
[in, out] A handle for enumerating the memory regions associated with the module.

`extent`\
[out] The enumerated native code region associated with the method.

## Remarks

The provided method is part of the `IXCLRDataMethodInstance` interface and corresponds to the 17th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataMethodInstance Interface](ixclrdatamethodinstance-interface.md)
- [IXCLRDataMethodInstance::StartEnumExtents Method](ixclrdatamethodinstance-startenumextents-method.md)
- [IXCLRDataMethodInstance::EndEnumExtents Method](ixclrdatamethodinstance-endenumextents-method.md)
- [CLRDATA_ADDRESS_RANGE Structure](clrdata-address-range-structure.md)
