---
description: "Learn more about: IXCLRDataExceptionState::GetPrevious Method"
title: "IXCLRDataExceptionState::GetPrevious Method"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataExceptionState::GetPrevious Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataExceptionState::GetPrevious Method"
helpviewer.keywords:
  - "IXCLRDataExceptionState::GetPrevious Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataExceptionState::GetPrevious Method

For nested exceptions, this gets the exception that was being handled when this exception occurred.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetPrevious(
    [out] IXCLRDataExceptionState **exState
);
```

## Parameters

`exState`\
[out] The exception that was being handled when this exception occurred.

## Remarks

The provided method is part of the `IXCLRDataExceptionState` interface and corresponds to the 5th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataExceptionState Interface](ixclrdataexceptionstate-interface.md)
