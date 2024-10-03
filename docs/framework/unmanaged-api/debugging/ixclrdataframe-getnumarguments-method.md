---
description: "Learn more about: IXCLRDataFrame::GetNumArguments Method"
title: "IXCLRDataFrame::GetNumArguments Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataFrame::GetNumArguments Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataFrame::GetNumArguments Method"
helpviewer.keywords:
  - "IXCLRDataFrame::GetNumArguments Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataFrame::GetNumArguments Method

Gets the number of arguments corresponding to the stack frame method.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetNumArguments(
    [out] ULONG32 *numArgs
);
```

## Parameters

`numArgs`\
[out] The number of arguments to the stack frame method.

## Remarks

The provided method is part of the `IXCLRDataFrame` interface and corresponds to the 7th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataFrame Interface](ixclrdataframe-interface.md)
- [IXCLRDataFrame::GetArgumentByIndex Method](ixclrdataframe-getargumentbyindex-method.md)
