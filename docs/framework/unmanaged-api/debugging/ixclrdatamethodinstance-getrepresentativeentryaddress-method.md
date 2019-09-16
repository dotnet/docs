---
title: "IXCLRDataMethodInstance::GetRepresentativeEntryAddress Method"
ms.date: "02/01/2019"
api.name:
  - "IXCLRDataMethodInstance::GetRepresentativeEntryAddress"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataMethodInstance::GetRepresentativeEntryAddress"
helpviewer.keywords:
  - "IXCLRDataMethodInstance::GetRepresentativeEntryAddress Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "hoyosjs"
ms.author: "juhoyosa"
---
# IXCLRDataMethodInstance::GetRepresentativeEntryAddress Method

Gets the most representative entry point address for the native compilation of all the possible entry points for a method.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetRepresentativeEntryAddress(
    [out] CLRDATA_ADDRESS* addr
);
```

## Parameters

`addr`\
[out] The address of the most representative native entry point for the method.

## Remarks

The provided method is part of the [`IXCLRDataMethodInstance` interface](ixclrdatamethodinstance-interface.md) and corresponds to the 19th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [IXCLRDataMethodInstance Interface](ixclrdatamethodinstance-interface.md)
