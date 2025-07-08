---
description: "Learn more about: IXCLRDataExceptionNotification Interface"
title: "IXCLRDataExceptionNotification Interface"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataExceptionNotification Interface"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataExceptionNotification Interface"
helpviewer.keywords:
  - "IXCLRDataExceptionNotification Interface [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataExceptionNotification Interface

Caller provided interface which derives from IUnknown and includes callback methods for various CLR notifications which occur via system exceptions.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Methods

| Method | Description |
|--------|-------------|
| [OnCodeGenerated](ixclrdataexceptionnotification-oncodegenerated-method.md)        | Callback made if the exception represents the generation of code for a particular method instance. |
| [OnCodeDiscarded](ixclrdataexceptionnotification-oncodediscarded-method.md)        | Callback made if the exception represents discarding of code for a particular method instance. |
| [OnProcessExecution](ixclrdataexceptionnotification-onprocessexecution-method.md)  | Callback made if the exception represents the process reaching a desired execution state. |
| [OnTaskExecution](ixclrdataexceptionnotification-ontaskexecution-method.md) | Callback made if the exception represents a task reaching a desired execution state. |
| [OnModuleLoaded](ixclrdataexceptionnotification-onmoduleloaded-method.md)          | Callback made if the exception represents a module being loaded. |
| [OnModuleUnloaded](ixclrdataexceptionnotification-onmoduleunloaded-method.md)      | Callback made if the exception represents a module being unloaded. |
| [OnTypeLoaded](ixclrdataexceptionnotification-ontypeloaded-method.md)              | Callback made if the exception represents a particular type instance being loaded. |
| [OnTypeUnloaded](ixclrdataexceptionnotification-ontypeunloaded-method.md)          | Callback made if the exception represents a particular type instance being unloaded. |

## Remarks

This interface is implemented by users of the `IXCLRDataProcess::TranslateExceptionRecordToNotification` method.  It is not exposed through any headers or library files. However, it's a COM interface that derives from `IUnknown` with GUID `2D95A079-42A1-4837-818F-0B97D7048E0E` and can be implemented through the usual COM mechanisms.  The list of methods above is the complete list of non IUnknown methods on this interface and are in vtable order.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [Debugging Interfaces](debugging-interfaces.md)
- [IXCLRDataProcess::TranslateExceptionRecordToNotification Method](ixclrdataprocess-translateexceptionrecordtonotification-method.md)
