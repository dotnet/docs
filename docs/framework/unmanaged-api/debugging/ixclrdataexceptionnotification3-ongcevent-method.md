---
description: "Learn more about: IXCLRDataExceptionNotification3::OnGcEvent Method"
title: "IXCLRDataExceptionNotification3::OnGcEvent Method"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataExceptionNotification3::OnGcEvent Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataExceptionNotification3::OnGcEvent Method"
helpviewer.keywords:
  - "IXCLRDataExceptionNotification3::OnGcEvent Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataExceptionNotification3::OnGcEvent Method

Client implemented callback which is made during a call to `IXCLRDataProcess::TranslateExceptionRecordToNotification` when a given exception represents a particular GC event occurring.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT OnGcEvent(
    [in] GcEvtArgs gcEvtArgs
);
```

## Parameters

`gcEvtArgs`\
[in] A set of arguments which describe the GC event which occurred.

## Remarks

The provided method is part of the `IXCLRDataExceptionNotification3` interface and corresponds to the 15th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataProcess::TranslateExceptionRecordToNotification Method](ixclrdataprocess-translateexceptionrecordtonotification-method.md)
- [GcEvtArgs Structure](gcevtargs-structure.md)
- [IXCLRDataExceptionNotification Interface](ixclrdataexceptionnotification-interface.md)
- [IXCLRDataExceptionNotification2 Interface](ixclrdataexceptionnotification2-interface.md)
