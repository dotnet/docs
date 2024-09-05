---
description: "Learn more about: IXCLRDataFrame::GetNumLocalVariables Method"
title: "IXCLRDataFrame::GetNumLocalVariables Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataFrame::GetNumLocalVariables Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataFrame::GetNumLocalVariables Method"
helpviewer.keywords:
  - "IXCLRDataFrame::GetNumLocalVariables Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataFrame::GetNumLocalVariables Method

Gets the number of local variables in the stack frame method.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetNumLocalVariables(
    [out] ULONG32 *numLocals
);
```

## Parameters

`numLocals`\
[out] The number of local variables in the stack frame method.

## Remarks

The provided method is part of the `IXCLRDataFrame` interface and corresponds to the 9th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataFrame Interface](ixclrdataframe-interface.md)
- [IXCLRDataFrame::GetLocalVariableByIndex Method](ixclrdataframe-getlocalvariablebyindex-method.md)
