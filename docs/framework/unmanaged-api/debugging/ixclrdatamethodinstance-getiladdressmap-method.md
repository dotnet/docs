---
title: "IXCLRDataMethodInstance::GetILAddressMap Method"
ms.date: "01/16/2019"
api.name:
  - "IXCLRDataMethodInstance::GetILAddressMap Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataMethodInstance::GetILAddressMap Method"
helpviewer.keywords:
  - "IXCLRDataMethodInstance::GetILAddressMap Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataMethodInstance::GetILAddressMap Method

Gets the IL to address mapping information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```
HRESULT GetILAddressMap(
    [in] ULONG32                                   mapLen,
    [out] ULONG32                                 *mapNeeded,
    [out, size_is(mapLen)] CLRDATA_IL_ADDRESS_MAP  maps[]
);
```

## Parameters

`mapLen`\
[in] The length of the provided maps array.

`mapNeeded`\
[out] The number of map entries that the method needs.

`maps`\
[out, size_is(mapLen)] The array for storing the map entries.

## Remarks

The provided method is part of the `IXCLRDataMethodInstance` interface and corresponds to the 14th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [IXCLRDataMethodInstance Interface](ixclrdatamethodinstance-interface.md)
