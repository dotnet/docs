---
description: "Learn more about: IXCLRDataExceptionNotification::OnProcessExecution Method"
title: "IXCLRDataExceptionNotification::OnProcessExecution Method"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataExceptionNotification::OnProcessExecution Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataExceptionNotification::OnProcessExecution Method"
helpviewer.keywords:
  - "IXCLRDataExceptionNotification::OnProcessExecution Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataExceptionNotification::OnProcessExecution Method

Client implemented callback which is made during a call to `IXCLRDataProcess::TranslateExceptionRecordToNotification` when a given exception represents the process reaching a desired execution state.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT OnProcessExecution(
    [in] ULONG32 state
);
```

## Parameters

`state`\
[in] The execution state of the process

## Remarks

The provided method is part of the `IXCLRDataExceptionNotification` interface and corresponds to the 6th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataProcess::TranslateExceptionRecordToNotification Method](ixclrdataprocess-translateexceptionrecordtonotification-method.md)
