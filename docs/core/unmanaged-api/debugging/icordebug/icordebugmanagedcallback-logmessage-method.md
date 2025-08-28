---
description: "Learn more about: ICorDebugManagedCallback::LogMessage Method"
title: "ICorDebugManagedCallback::LogMessage Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback.LogMessage"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback::LogMessage"
helpviewer_keywords:
  - "ICorDebugManagedCallback::LogMessage method [.NET debugging]"
  - "LogMessage method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback::LogMessage Method

Notifies the debugger that a common language runtime (CLR) managed thread has called a method in the <xref:System.Diagnostics.EventLog> class to log an event.

## Syntax

```cpp
HRESULT LogMessage (
    [in] ICorDebugAppDomain  *pAppDomain,
    [in] ICorDebugThread     *pThread,
    [in] LONG                 lLevel,
    [in] WCHAR               *pLogSwitchName,
    [in] WCHAR               *pMessage
);
```

## Parameters

 `pAppDomain`
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain containing the managed thread that logged the event.

 `pThread`
 [in] A pointer to an ICorDebugThread object that represents the managed thread.

 `lLevel`
 [in] A value of the [LoggingLevelEnum](../../../../framework/unmanaged-api/debugging/logginglevelenum-enumeration.md) enumeration that indicates the severity level of the descriptive message that was written to the event log.

 `pLogSwitchName`
 [in] A pointer to the name of the tracing switch.

 `pMessage`
 [in] A pointer to the message that was written to the event log.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
