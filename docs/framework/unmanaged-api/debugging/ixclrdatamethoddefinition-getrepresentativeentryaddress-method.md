---
description: "Learn more about: IXCLRDataMethodDefinition::GetRepresentativeEntryAddress Method"
title: "IXCLRDataMethodDefinition::GetRepresentativeEntryAddress Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataMethodDefinition::GetRepresentativeEntryAddress Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataMethodDefinition::GetRepresentativeEntryAddress Method"
helpviewer.keywords:
  - "IXCLRDataMethodDefinition::GetRepresentativeEntryAddress Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataMethodDefinition::GetRepresentativeEntryAddress Method

Gets the most representative start address of the native code for this method.  A method may have multiple entry points, so this address is not guaranteed to be hit by all entries.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetRepresentativeEntryAddress(
    [out] CLRDATA_ADDRESS *addr
);
```

## Parameters

`addr`\
[out] The most representative start address of the native code for this method.

## Remarks

The provided method is part of the `IXCLRDataMethodDefinition` interface and corresponds to the 19th slot of the virtual method table.  CLRDATA_ADDRESS is a 64-bit unsigned integer.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [IXCLRDataMethodDefinition Interface](ixclrdatamethoddefinition-interface.md)
