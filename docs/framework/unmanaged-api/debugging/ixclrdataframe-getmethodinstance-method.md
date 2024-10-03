---
description: "Learn more about: IXCLRDataFrame::GetCurrentAppDomain Method"
title: "IXCLRDataFrame::GetCurrentAppDomain Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataFrame::GetCurrentAppDomain Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataFrame::GetCurrentAppDomain Method"
helpviewer.keywords:
  - "IXCLRDataFrame::GetCurrentAppDomain Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataFrame::GetMethodInstance Method

Gets the method instance corresponding to the stack frame.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetMethodInstance(
    [out] IXCLRDataMethodInstance **method
);
```

## Parameters

`method`\
[out] The method instance corresponding to the stack frame.

## Remarks

The provided method is part of the `IXCLRDataFrame` interface and corresponds to the 12th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [IXCLRDataFrame Interface](ixclrdataframe-interface.md)
- [IXCLRDataMethodInstance Interface](ixclrdatamethodinstance-interface.md)
