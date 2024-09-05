---
description: "Learn more about: IXCLRDataTask::CreateStackWalk Method"
title: "IXCLRDataTask::CreateStackWalk Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataTask::CreateStackWalk Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataTask::CreateStackWalk Method"
helpviewer.keywords:
  - "IXCLRDataTask::CreateStackWalk Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataTask::CreateStackWalk Method

Creates a stack walker to walk the task's stack.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT CreateStackWalk(
    [in] ULONG32 flags,
    [out] IXCLRDataStackWalk **stackWalk
);
```

## Parameters

`flags`\
[in] A set of one or more flags from the `CLRDataSimpleFrameType` enumeration which define the kinds of frames which should be returned from the stack walk.

`stackWalk`\
[out] An interface to walk the stack of the task.

## Remarks

The provided method is part of the `IXCLRDataTask` interface and corresponds to the 12th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataTask Interface](ixclrdatatask-interface.md)
- [IXCLRDataStackWalk Interface](ixclrdatastackwalk-interface.md)
- [CLRDataSimpleFrameType Enumeration](clrdatasimpleframetype-enumeration.md)
