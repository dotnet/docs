---
description: "Learn more about: IXCLRDataExceptionNotification5 Interface"
title: "IXCLRDataExceptionNotification5 Interface"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataExceptionNotification5 Interface"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataExceptionNotification5 Interface"
helpviewer.keywords:
  - "IXCLRDataExceptionNotification5 Interface [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataExceptionNotification5 Interface

Caller provided interface which derives from `IXCLRDataExceptionNotification4` and includes callback methods for various CLR notifications which occur via system exceptions.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Methods

| Method                                                                                                                                               | Description                                                                                     |
| ---------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------- |
| [OnCodeGenerated2](ixclrdataexceptionnotification5-oncodegenerated2-method.md) | Callback made if the exception represents the generation of code for a particular method instance. |

## Remarks

This interface is implemented by users of the `IXCLRDataProcess::TranslateExceptionRecordToNotification` method.  It is not exposed through any headers or library files. However, it's a COM interface that derives from `IXCLRDataExceptionNotification4` with GUID `e77a39ea-3548-44d9-b171-8569ed1a9423` and can be implemented through the usual COM mechanisms.  The list of methods above is the complete list of non IXCLRDataExceptionNotification# and IUnknown methods on this interface and are in vtable order.

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
- [IXCLRDataExceptionNotification4 Interface](ixclrdataexceptionnotification4-interface.md)
