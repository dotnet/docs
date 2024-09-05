---
description: "Learn more about: IXCLRDataExceptionNotification::OnCodeGenerated Method"
title: "IXCLRDataExceptionNotification::OnCodeGenerated Method"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataExceptionNotification::OnCodeGenerated Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataExceptionNotification::OnCodeGenerated Method"
helpviewer.keywords:
  - "IXCLRDataExceptionNotification::OnCodeGenerated Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataExceptionNotification::OnCodeGenerated Method

Client implemented callback which is made during a call to `IXCLRDataProcess::TranslateExceptionRecordToNotification` when a given exception represents the generation of code for a particular method instance.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT OnCodeGenerated(
    [in] IXCLRDataMethodInstance *method
);
```

## Parameters

`method`\
[in] The method instance for which code was generated

## Remarks

The provided method is part of the `IXCLRDataExceptionNotification` interface and corresponds to the 4th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataProcess::TranslateExceptionRecordToNotification Method](ixclrdataprocess-translateexceptionrecordtonotification-method.md)
- [IXCLRDataMethodInstance Interface](ixclrdatamethodinstance-interface.md)
