---
description: "Learn more about: IXCLRDataExceptionNotification4 Interface"
title: "IXCLRDataExceptionNotification4 Interface"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataExceptionNotification4 Interface"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataExceptionNotification4 Interface"
helpviewer.keywords:
  - "IXCLRDataExceptionNotification4 Interface [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataExceptionNotification4 Interface

Caller provided interface which derives from `IXCLRDataExceptionNotification4` and includes callback methods for various CLR notifications which occur via system exceptions.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Methods

| Method                                                                                                                                               | Description                                                                                     |
| ---------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------- |
| [ExceptionCatcherEnter](ixclrdataexceptionnotification4-exceptioncatcherenter-method.md) | Callback made if the exception represents the entry of a managed catch block. |

## Remarks

This interface is implemented by users of the `IXCLRDataProcess::TranslateExceptionRecordToNotification` method.  It is not exposed through any headers or library files. However, it's a COM interface that derives from `IXCLRDataExceptionNotification3` with GUID `C25E926E-5F09-4AA2-BBAD-B7FC7F10CFD7` and can be implemented through the usual COM mechanisms.  The list of methods above is the complete list of non IXCLRDataExceptionNotification# and IUnknown methods on this interface and are in vtable order.

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
- [IXCLRDataExceptionNotification3 Interface](ixclrdataexceptionnotification3-interface.md)
