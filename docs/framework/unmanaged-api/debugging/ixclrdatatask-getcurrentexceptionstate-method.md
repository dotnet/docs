---
description: "Learn more about: IXCLRDataTask::GetCurrentExceptionState Method"
title: "IXCLRDataTask::GetCurrentExceptionState Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataTask::GetCurrentExceptionState Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataTask::GetCurrentExceptionState Method"
helpviewer.keywords:
  - "IXCLRDataTask::GetCurrentExceptionState Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataTask::GetCurrentExceptionState Method

Gets the current exception state for the task, if any.  This may be the first element in a list of exception states if there are nested exceptions.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetCurrentExceptionState(
    [out] IXCLRDataExceptionState **exception
);
```

## Parameters

`exception`\
[out] The current exception state for the task.

## Remarks

The provided method is part of the `IXCLRDataTask` interface and corresponds to the 16th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataTask Interface](ixclrdatatask-interface.md)
- [IXCLRDataExceptionState Interface](ixclrdataexceptionstate-interface.md)
