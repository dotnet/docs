---
description: "Learn more about: IXCLRDataProcess::GetTaskByUniqueID Method"
title: "IXCLRDataProcess::GetTaskByUniqueID Method"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataProcess::GetTaskByUniqueID Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess::GetTaskByUniqueID Method"
helpviewer.keywords:
  - "IXCLRDataProcess::GetTaskByUniqueID Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataProcess::GetTaskByUniqueID Method

Gets a managed task in a process based on its unique identifier.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetTaskByUniqueID(
    [in] ULONG64 id,
    [out] IXCLRDataTask **task
);
```

## Parameters

`id`\
[in] The unique identifier of the managed task.

`task`\
[out] The managed task.

## Remarks

The provided method is part of the `IXCLRDataProcess` interface and corresponds to the 9th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataProcess Interface](ixclrdataprocess-interface.md)
- [IXCLRDataProcess::GetTaskByOSThreadID Method](ixclrdataprocess-gettaskbyosthreadid-method.md)
- [IXCLRDataTask Interface](ixclrdatatask-interface.md)
