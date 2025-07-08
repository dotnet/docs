---
description: "Learn more about: IXCLRDataProcess::TranslateExceptionRecordToNotification Method"
title: "IXCLRDataProcess::TranslateExceptionRecordToNotification Method"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataProcess::TranslateExceptionRecordToNotification Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess::TranslateExceptionRecordToNotification Method"
helpviewer.keywords:
  - "IXCLRDataProcess::TranslateExceptionRecordToNotification Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataProcess::TranslateExceptionRecordToNotification Method

Translates a system exception record into a particular kind of notification if possible.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT TranslateExceptionRecordToNotification(
    [in] EXCEPTION_RECORD64 *record,
    [in] IXCLRDataExceptionNotification *notify
);
```

## Parameters

`record`\
[in] A pointer to the system exception record to translate into a CLR notification

`notify`\
[in] An caller provided implementation of IXCLRDataExceptionNotificationN interfaces.  If the system exception record given by `record` corresponds to a particular CLR notification, one of the methods on this IXCLRDataExceptionNotification interface will be immediately called back.

## Remarks

The provided method is part of the `IXCLRDataProcess` interface and corresponds to the 33rd slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [IXCLRDataProcess Interface](ixclrdataprocess-interface.md)
- [IXCLRDataExceptionNotification Interface](ixclrdataexceptionnotification-interface.md)
