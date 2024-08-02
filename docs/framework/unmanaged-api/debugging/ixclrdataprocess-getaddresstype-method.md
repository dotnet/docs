---
description: "Learn more about: IXCLRDataProcess::GetAddressType Method"
title: "IXCLRDataProcess::GetAddressType Method"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataProcess::GetAddressType Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess::GetAddressType Method"
helpviewer.keywords:
  - "IXCLRDataProcess::GetAddressType Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataProcess::GetAddressType Method

Returns an indication of the type of data referred to by the given address.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetAddressType(
    [in] CLRDATA_ADDRESS address,
    [out] CLRDataAddressType *type
);
```

## Parameters

`address`\
[in] The address for which to return an indication of the type of data.

`type`\
[out] An indication of the type of data referred to by the given address

## Remarks

The provided method is part of the `IXCLRDataProcess` interface and corresponds to the 15th slot of the virtual method table. The `IXCLRDataAppDomain*` returned is used for interaction with other APIs.  Note that CLRDATA_ADDRESS is a 64-bit unsigned integer.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataProcess Interface](ixclrdataprocess-interface.md)
- [CLRDataAddressType Enumeration](clrdataaddresstype-enumeration.md)
