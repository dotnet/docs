---
description: "Learn more about: IXCLRDataMethodInstance::GetILOffsetsByAddress Method"
title: "IXCLRDataMethodInstance::GetILOffsetsByAddress Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataMethodInstance::GetILOffsetsByAddress Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataMethodInstance::GetILOffsetsByAddress Method"
helpviewer.keywords:
  - "IXCLRDataMethodInstance::GetILOffsetsByAddress Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataMethodInstance::GetILOffsetsByAddress Method

Gets the IL offset(s) corresponding to the given address for the method.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetILOffsetsByAddress(
    [in] CLRDATA_ADDRESS address
    [in] ULONG32 offsetsLen,
    [out] ULONG32 *offsetsNeeded,
    [out, size_is(offsetsLen)] ULONG32 ilOffsets[]
);
```

## Parameters

`address`\
[in] An address within the method for which to retrieve the corresponding IL offsets.

`offsetsLen`\
[in] The size of the `ilOffsets` buffer

`offsetsNeeded`\
[out] An indication of how many IL offsets are returned.

`ilOffsets`\
[out] The IL offsets corresponding to the given address within the method.

## Remarks

The provided method is part of the `IXCLRDataMethodInstance` interface and corresponds to the 13th slot of the virtual method table.  Note that CLRDATA_ADDRESS is a 64-bit unsigned integer.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataMethodInstance Interface](ixclrdatamethodinstance-interface.md)
- [IXCLRDataMethodInstance::GetAddressRangesByILOffset Method](ixclrdatamethodinstance-getaddressrangesbyiloffset-method.md)
- [IXCLRDataMethodInstance::GetILAddressMap Method](ixclrdatamethodinstance-getiladdressmap-method.md)
