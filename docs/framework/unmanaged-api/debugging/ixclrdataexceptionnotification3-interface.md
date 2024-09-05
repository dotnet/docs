---
description: "Learn more about: IXCLRDataExceptionNotification3 Interface"
title: "IXCLRDataExceptionNotification3 Interface"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataExceptionNotification3 Interface"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataExceptionNotification3 Interface"
helpviewer.keywords:
  - "IXCLRDataExceptionNotification3 Interface [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataExceptionNotification3 Interface

Caller provided interface which derives from `IXCLRDataExceptionNotification2` and includes callback methods for various CLR notifications which occur via system exceptions.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Methods

| Method                                                                                                                                               | Description                                                                                     |
| ---------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------- |
| [OnGcEvent](ixclrdataexceptionnotification3-ongcevent-method.md) | Callback made if the exception represents a particular GC event occurring. |

## Remarks

This interface is implemented by users of the `IXCLRDataProcess::TranslateExceptionRecordToNotification` method.  It is not exposed through any headers or library files. However, it's a COM interface that derives from `IXCLRDataExceptionNotification2` with GUID `31201a94-4337-49b7-aef7-0c7550540920` and can be implemented through the usual COM mechanisms.  The list of methods above is the complete list of non IXCLRDataExceptionNotification# and IUnknown methods on this interface and are in vtable order.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [Debugging Interfaces](debugging-interfaces.md)
- [IXCLRDataProcess::TranslateExceptionRecordToNotification Method](ixclrdataprocess-translateexceptionrecordtonotification-method.md)
- [IXCLRDataExceptionNotification Interface](ixclrdataexceptionnotification-interface.md)
- [IXCLRDataExceptionNotification2 Interface](ixclrdataexceptionnotification2-interface.md)
