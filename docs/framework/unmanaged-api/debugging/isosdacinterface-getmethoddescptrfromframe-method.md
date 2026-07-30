---
description: "Learn more about: ISOSDacInterface::GetMethodDescPtrFromFrame Method"
title: "ISOSDacInterface::GetMethodDescPtrFromFrame Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetMethodDescPtrFromFrame Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetMethodDescPtrFromFrame Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetMethodDescPtrFromFrame Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetMethodDescPtrFromFrame Method

Gets the MethodDesc pointer that corresponds to a frame address.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetMethodDescPtrFromFrame(CLRDATA_ADDRESS frameAddr, CLRDATA_ADDRESS * ppMD);
```

## Parameters

`frameAddr`\
[in] The address of the frame.

`ppMD`\
[out] The MethodDesc pointer that corresponds to the frame.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 24th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
