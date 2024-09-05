---
description: "Learn more about: IXCLRDataExceptionNotification::OnTaskExecution Method"
title: "IXCLRDataExceptionNotification::OnTaskExecution Method"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataExceptionNotification::OnTaskExecution Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataExceptionNotification::OnTaskExecution Method"
helpviewer.keywords:
  - "IXCLRDataExceptionNotification::OnTaskExecution Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataExceptionNotification::OnTaskExecution Method

Client implemented callback which is made during a call to `IXCLRDataProcess::TranslateExceptionRecordToNotification` when a given exception represents a managed task reaching a desired execution state.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT OnTaskExecution(
    [in] IXCLRDataTask *task,
    [in] ULONG32 state
);
```

## Parameters

`task`\
[in] The managed task which has reached a desired execution state

`state`\
[in] The execution state of the task

## Remarks

The provided method is part of the `IXCLRDataExceptionNotification` interface and corresponds to the 7th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataProcess::TranslateExceptionRecordToNotification Method](ixclrdataprocess-translateexceptionrecordtonotification-method.md)
- [IXCLRDataTask Interface](ixclrdatatask-interface.md)
