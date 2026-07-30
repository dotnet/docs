---
description: "Learn more about: ISOSDacInterface::GetMethodDescFromToken Method"
title: "ISOSDacInterface::GetMethodDescFromToken Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetMethodDescFromToken Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetMethodDescFromToken Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetMethodDescFromToken Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetMethodDescFromToken Method

Gets a MethodDesc address for a metadata token in a module.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetMethodDescFromToken(CLRDATA_ADDRESS moduleAddr, mdToken token, CLRDATA_ADDRESS *methodDesc);
```

## Parameters

`moduleAddr`\
[in] The address of the module that contains the metadata token.

`token`\
[in] The metadata token.

`methodDesc`\
[out] The MethodDesc address that corresponds to the metadata token.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 25th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
