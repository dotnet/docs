---
description: "Learn more about: IXCLRDataExceptionNotification2 Interface"
title: "IXCLRDataExceptionNotification2 Interface"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataExceptionNotification2 Interface"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataExceptionNotification2 Interface"
helpviewer.keywords:
  - "IXCLRDataExceptionNotification2 Interface [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataExceptionNotification2 Interface

Caller provided interface which derives from `IXCLRDataExceptionNotification` and includes callback methods for various CLR notifications which occur via system exceptions.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Methods

| Method                                                                                                                                               | Description                                                                                     |
| ---------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------- |
| [OnAppDomainLoaded](ixclrdataexceptionnotification2-onappdomainloaded-method.md)     | Callback made if the exception represents the loading of a particular app domain. |
| [OnAppDomainUnloaded](ixclrdataexceptionnotification2-onappdomainunloaded-method.md) | Callback made if the exception represents the unloading of a particular app domain. |
| [OnException](ixclrdataexceptionnotification2-onexception-method.md)                 | Callback made if the exception represents a managed exception being raised. |

## Remarks

This interface is implemented by users of the `IXCLRDataProcess::TranslateExceptionRecordToNotification` method.  It is not exposed through any headers or library files. However, it's a COM interface that derives from `IXCLRDataExceptionNotification` with GUID `31201a94-4337-49b7-aef7-0c755054091f` and can be implemented through the usual COM mechanisms.  The list of methods above is the complete list of non IXCLRDataExceptionNotification# and IUnknown methods on this interface and are in vtable order.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [Debugging Interfaces](debugging-interfaces.md)
- [IXCLRDataProcess::TranslateExceptionRecordToNotification Method](ixclrdataprocess-translateexceptionrecordtonotification-method.md)
